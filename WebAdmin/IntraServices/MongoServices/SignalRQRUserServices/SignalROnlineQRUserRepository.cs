
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

namespace WebAdmin.IntraServices
{
    /// <summary>
    /// MessageRepository
    /// </summary>
    public class SignalROnlineQRUserRepository : ISignalROnlineQRUserRepository
    {
        private readonly IMongoCollection<HubQRUserContextEntity> _signalROnlineQRUserCollection;
        private readonly IUserProfileParserService _iUserProfileParserService;

        private List<HubQRUserContextEntity> _OnlineUserList = new List<HubQRUserContextEntity>();

        /// <summary>
        /// SignalROnlineQRUserRepository
        /// </summary>
        /// <param name="mongoDatabase"></param>
        /// <param name="iUserProfileParserService"></param>
        /// <param name="configuration"></param>
        public SignalROnlineQRUserRepository(
            IMongoDatabase mongoDatabase,
            IUserProfileParserService iUserProfileParserService,
             IConfiguration configuration)
        {
            _iUserProfileParserService = iUserProfileParserService;
            var mongoDBSettingsOnlineUser = configuration.GetSection(nameof(MongoDBSettingsSignalRServices)).Get<MongoDBSettingsSignalRServices>();
            _signalROnlineQRUserCollection = mongoDatabase.GetCollection<HubQRUserContextEntity>(mongoDBSettingsOnlineUser.OnlineQRUserCollection);
        }

        /// <summary>
        /// AddeOnlineUser
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public async Task<HubQRUserContextEntity> AddeOnlineUser(HubQRUserContextEntity User)
        {
            await _signalROnlineQRUserCollection.InsertOneAsync(User);
            return User;
        }

        /// <summary>
        /// AddeOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param> 
        /// <returns></returns>
        public async Task<HubQRUserContextEntity> AddeOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid, string code)
        {
            HubQRUserContextEntity User = new HubQRUserContextEntity();

            //get user from mongodb by user
            var obj = await FindByConnectionIDOrCode(connectionid, code);
            if (obj == null)
            {
                User.ConnectionId = connectionid;
                User.TemIdentifierCode = code; 
                User.LoggedInTime = DateTime.Now;

                User.ResponseCode = String.Empty;
                User.PKeyEX = -99;
                await _signalROnlineQRUserCollection.InsertOneAsync(User);
            }
            else
            {
                var UpdateFilter = Builders<HubQRUserContextEntity>.Filter.Eq(a => a.ConnectionId, connectionid);
                var update = Builders<HubQRUserContextEntity>.Update.Set(a => a.TemIdentifierCode, code);
                var result = await _signalROnlineQRUserCollection.UpdateOneAsync(UpdateFilter, update);
            }
            return User;
        }

        /// <summary>
        /// UpdateOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<HubQRUserContextEntity> UpdateOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid, string code)
        {
            HubQRUserContextEntity User = new HubQRUserContextEntity();
            //get user from mongodb by user
            var obj = await FindByConnectionIDOrCode(connectionid, code);
            if (obj != null)
            {
            }
            else {
                await AddeOnlineUser(httpCtx, connectionid, code);
            }
            return User;
        }

        /// <summary>
        /// UpdateOnlineUserAfterQR
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <param name="objKeyParam"></param>
        /// <returns></returns>
        public async Task<HubQRUserContextEntity> UpdateOnlineUserAfterQR(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid, string code, 
            PaciKeyParamsValuesEntity objKeyParam)
        {
            HubQRUserContextEntity User = new HubQRUserContextEntity();
            //get user from mongodb by user
            var obj = await FindByConnectionIDOrCode(connectionid, code);
            if (obj != null)
            {
                User.ConnectionId = connectionid;
                User.TemIdentifierCode = objKeyParam.WebSessionID;
                User.ResponseCode = objKeyParam.ResponseCode;
                User.PKeyEX = objKeyParam.SignInRequestID;

                var UpdateFilter = Builders<HubQRUserContextEntity>.Filter.Eq(a => a.ConnectionId, connectionid);
                var update = Builders<HubQRUserContextEntity>.Update
                    .Set(a => a.TemIdentifierCode, code)
                    .Set(a=> a.ResponseCode , User.ResponseCode)
                    .Set(a=> a.PKeyEX, User.PKeyEX);
                var result = _signalROnlineQRUserCollection.UpdateOneAsync(UpdateFilter, update);
            }
            return User;
        }


        /// <summary>
        /// RemoveOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<HubQRUserContextEntity> RemoveOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid, string code)
        {
            HubQRUserContextEntity User = new HubQRUserContextEntity();
            //get user from mongodb by user
            var obj = await FindByConnectionIDOrCode(connectionid, code);
            if (obj != null)
            {
                User.ConnectionId = connectionid;
                User.TemIdentifierCode = code;

                var filter = Builders<HubQRUserContextEntity>.Filter.Eq(person => person.TemIdentifierCode, code);
                var personDeleteResult = await _signalROnlineQRUserCollection.DeleteManyAsync(filter);
            }
            return User;
        }


        /// <summary>
        /// FindByConnectionIDOrCode
        /// </summary>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<HubQRUserContextEntity> FindByConnectionIDOrCode(string connectionid, string code)
        {
            var filter = Builders<HubQRUserContextEntity>.Filter.Eq(x => x.ConnectionId, connectionid);
            var @event = (await _signalROnlineQRUserCollection.FindAsync(filter)).FirstOrDefault();
            if (@event != null)
            {
                return @event;
            }
            else
            {
                filter = Builders<HubQRUserContextEntity>.Filter.Eq(x => x.TemIdentifierCode, code);
                @event = (await _signalROnlineQRUserCollection.FindAsync(filter)).FirstOrDefault();
                if (@event != null)
                {
                    return @event;
                }
                else 
                    return null;
            }
        }

        /// <summary>
        /// GetOnlineUserListFromDB
        /// </summary>
        /// <returns></returns>
        public async Task<List<HubQRUserContextEntity>> GetOnlineUserListFromDB()
        {
            _OnlineUserList = new List<HubQRUserContextEntity>();
            _OnlineUserList = await _signalROnlineQRUserCollection.Find(_ => true).ToListAsync();
            return _OnlineUserList;
        }


        /// <summary>
        /// FindBySessionID
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<HubQRUserContextEntity> FindBySessionID(HubQRUserContextEntity user)
        {
            var filter = Builders<HubQRUserContextEntity>.Filter.Eq(x => x.TemIdentifierCode, user.TemIdentifierCode);
            var @event = (await _signalROnlineQRUserCollection.FindAsync(filter)).FirstOrDefault();
            if (@event != null)
            {
                return @event;
            }
            else
                return null;
        }

    }

}

