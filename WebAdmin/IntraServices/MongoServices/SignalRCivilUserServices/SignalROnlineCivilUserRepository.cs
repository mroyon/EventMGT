
using BDO.Core.DataAccessObjects.Models;
using BDO.DataAccessObjects.ExtendedEntities;
using DocumentFormat.OpenXml.Office2013.Word;
using IdentityServer4.Models;
using Jil;
using Microsoft.Extensions.Configuration;
using Microsoft.ReportingServices.Interfaces;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DocumentFormat.OpenXml.Wordprocessing;
using MongoDB.Bson;
using Microsoft.AspNetCore.Http;
using WebAdmin.Providers;
using MongoDB.Driver.Core.Connections;
using System.CodeDom;

namespace WebAdmin.IntraServices
{
    /// <summary>
    /// SignalROnlineCivilUserRepository
    /// </summary>
    public class SignalROnlineCivilUserRepository : ISignalROnlineCivilUserRepository
    {
        private readonly IMongoCollection<HubCivilUserContextEntity> _signalROnlineCivilUserCollection;
        private readonly IUserProfileParserService _iUserProfileParserService;

        private List<HubCivilUserContextEntity> _OnlineUserList = new List<HubCivilUserContextEntity>();

        /// <summary>
        /// SignalROnlineCivilUserRepository
        /// </summary>
        /// <param name="mongoDatabase"></param>
        /// <param name="iUserProfileParserService"></param>
        /// <param name="configuration"></param>
        public SignalROnlineCivilUserRepository(
            IMongoDatabase mongoDatabase,
            IUserProfileParserService iUserProfileParserService,
             IConfiguration configuration)
        {
            _iUserProfileParserService = iUserProfileParserService;
            var mongoDBSettingsOnlineUser = configuration.GetSection(nameof(MongoDBSettingsSignalRServices)).Get<MongoDBSettingsSignalRServices>();
            _signalROnlineCivilUserCollection = mongoDatabase.GetCollection<HubCivilUserContextEntity>(mongoDBSettingsOnlineUser.OnlineCivilUserCollection);
        }

        /// <summary>
        /// AddeOnlineUser
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public async Task<HubCivilUserContextEntity> AddeOnlineUser(HubCivilUserContextEntity User)
        {
            await _signalROnlineCivilUserCollection.InsertOneAsync(User);
            return User;
        }


        /// <summary>
        /// AddeOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <param name="codecivilid"></param>
        /// <returns></returns>
        public async Task<HubCivilUserContextEntity> AddeOnlineUser(HttpContext httpCtx, string connectionid, string code, string codecivilid)
        {
            HubCivilUserContextEntity User = new HubCivilUserContextEntity();

            //get user from mongodb by user
            var obj = await FindByConnectionIDOrCode(connectionid, code, codecivilid);
            if (obj == null)
            {
                User.ConnectionId = connectionid;
                User.TemIdentifierCode = code;
                User.LoggedInTime = DateTime.Now;


                User.CivilID = codecivilid;
                User.ResponseCode = String.Empty;
                User.PKeyEX = -99;
                await _signalROnlineCivilUserCollection.InsertOneAsync(User);
            }
            else
            {
                var UpdateFilter = Builders<HubCivilUserContextEntity>.Filter.Eq(a => a.ConnectionId, connectionid);
                var update = Builders<HubCivilUserContextEntity>.Update.Set(a => a.TemIdentifierCode, code);
                var result = await _signalROnlineCivilUserCollection.UpdateOneAsync(UpdateFilter, update);
            }
            return User;
        }


        /// <summary>
        /// UpdateOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <param name="codecivilid"></param>
        /// <returns></returns>
        public async Task<HubCivilUserContextEntity> UpdateOnlineUser(HttpContext httpCtx, string connectionid, string code, string codecivilid)
        {
            HubCivilUserContextEntity User = new HubCivilUserContextEntity();
            //get user from mongodb by user
            var obj = await FindByConnectionIDOrCode(connectionid, code, codecivilid);
            if (obj != null)
            {
            }
            else
            {
                await AddeOnlineUser(httpCtx, connectionid, code, codecivilid);
            }
            return User;
        }



        /// <summary>
        /// UpdateOnlineUserAfterCivil
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <param name="codecivilid"></param>
        /// <param name="objKeyParam"></param>
        /// <returns></returns>
        public async Task<HubCivilUserContextEntity> UpdateOnlineUserAfterCivil(HttpContext httpCtx, 
            string connectionid, 
            string code, 
            string codecivilid,
            PaciKeyParamsValuesEntity objKeyParam)
        {
            HubCivilUserContextEntity User = new HubCivilUserContextEntity();
            //get user from mongodb by user
            var obj = await FindByConnectionIDOrCode(connectionid, code, codecivilid);
            if (obj != null)
            {
                User.ConnectionId = connectionid;
                User.TemIdentifierCode = objKeyParam.WebSessionID;
                User.ResponseCode = objKeyParam.ResponseCode;
                User.PKeyEX = objKeyParam.SignInRequestID;

                var UpdateFilter = Builders<HubCivilUserContextEntity>.Filter.Eq(a => a.ConnectionId, connectionid);
                var update = Builders<HubCivilUserContextEntity>.Update
                    .Set(a => a.TemIdentifierCode, code)
                    .Set(a => a.ResponseCode, User.ResponseCode)
                    .Set(a => a.PKeyEX, User.PKeyEX);
                var result = _signalROnlineCivilUserCollection.UpdateOneAsync(UpdateFilter, update);
            }
            return User;
        }


        /// <summary>
        /// RemoveOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <param name="codecivilid"></param>
        /// <returns></returns>
        public async Task<HubCivilUserContextEntity> RemoveOnlineUser(HttpContext httpCtx, string connectionid, string code, string codecivilid)
        {
            HubCivilUserContextEntity User = new HubCivilUserContextEntity();
            //get user from mongodb by user
            var obj = await FindByConnectionIDOrCode(connectionid, code, codecivilid);
            if (obj != null)
            {
                User.ConnectionId = connectionid;
                User.TemIdentifierCode = code;

                var filter = Builders<HubCivilUserContextEntity>.Filter.Eq(person => person.TemIdentifierCode, code);
                var personDeleteResult = await _signalROnlineCivilUserCollection.DeleteManyAsync(filter);
            }
            return User;
        }


        /// <summary>
        /// GetOnlineUserListFromDB
        /// </summary>
        /// <returns></returns>
        public async Task<List<HubCivilUserContextEntity>> GetOnlineUserListFromDB()
        {
            _OnlineUserList = new List<HubCivilUserContextEntity>();
            _OnlineUserList = await _signalROnlineCivilUserCollection.Find(_ => true).ToListAsync();
            return _OnlineUserList;
        }

        /// <summary>
        /// FindByConnectionIDOrCode
        /// </summary>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <param name="codecivilid"></param>
        /// <returns></returns>
        public async Task<HubCivilUserContextEntity> FindByConnectionIDOrCode(string connectionid, string code, string codecivilid)
        {
            var filter = Builders<HubCivilUserContextEntity>.Filter.Eq(x => x.ConnectionId, connectionid);
            var @event = (await _signalROnlineCivilUserCollection.FindAsync(filter)).FirstOrDefault();
            if (@event != null)
            {
                return @event;
            }
            else
            {
                filter = Builders<HubCivilUserContextEntity>.Filter.Eq(x => x.CivilID, codecivilid);
                @event = (await _signalROnlineCivilUserCollection.FindAsync(filter)).FirstOrDefault();
                if (@event != null)
                {
                    return @event;
                }
                else
                {
                    filter = Builders<HubCivilUserContextEntity>.Filter.Eq(x => x.TemIdentifierCode, code);
                    @event = (await _signalROnlineCivilUserCollection.FindAsync(filter)).FirstOrDefault();
                    if (@event != null)
                    {
                        return @event;
                    }
                    else
                        return null;
                }
            }
        }


        /// <summary>
        /// FindBySessionID
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<HubCivilUserContextEntity> FindBySessionID(HubCivilUserContextEntity user)
        {
            var filter = Builders<HubCivilUserContextEntity>.Filter.Eq(x => x.TemIdentifierCode, user.TemIdentifierCode);
            var @event = (await _signalROnlineCivilUserCollection.FindAsync(filter)).FirstOrDefault();
            if (@event != null)
            {
                return @event;
            }
            else
                return null;
        }
    }

}

