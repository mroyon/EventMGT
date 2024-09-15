
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

namespace WebAdmin.IntraServices
{
    /// <summary>
    /// MessageRepository
    /// </summary>
    public class SignalROnlineUserRepository : ISignalROnlineUserRepository
    {
        private readonly IMongoCollection<HubUserContextEntity> _signalROnlineUserCollection;
        private readonly IUserProfileParserService _iUserProfileParserService;

        private List<HubUserContextEntity> _OnlineUserList = new List<HubUserContextEntity>();

        /// <summary>
        /// SignalROnlineUserRepository
        /// </summary>
        /// <param name="mongoDatabase"></param>
        /// <param name="iUserProfileParserService"></param>
        /// <param name="configuration"></param>
        public SignalROnlineUserRepository(
            IMongoDatabase mongoDatabase,
            IUserProfileParserService iUserProfileParserService,
             IConfiguration configuration)
        {
            _iUserProfileParserService = iUserProfileParserService;
            var mongoDBSettingsOnlineUser = configuration.GetSection(nameof(MongoDBSettingsSignalRServices)).Get<MongoDBSettingsSignalRServices>();
            _signalROnlineUserCollection = mongoDatabase.GetCollection<HubUserContextEntity>(mongoDBSettingsOnlineUser.OnlineUserCollection);
        }

        /// <summary>
        /// AddeOnlineUser
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public async Task<HubUserContextEntity> AddeOnlineUser(HubUserContextEntity User)
        {
            await _signalROnlineUserCollection.InsertOneAsync(User);
            return User;
        }

        /// <summary>
        /// AddeOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <returns></returns>
        public async Task<HubUserContextEntity> AddeOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid)
        {
            //get login in/connected user from the claim
            HubUserContextEntity User = _iUserProfileParserService.GetPrpfileFromClaim(connectionid, httpCtx);
            //get user from mongodb by user
            var obj = await FindByEmailAddress(User);
            if (obj == null)
            {
                User.ConnectionId = connectionid;
                await _signalROnlineUserCollection.InsertOneAsync(User);
            }
            else
            {
                var UpdateFilter = Builders<HubUserContextEntity>.Filter.Eq(a => a.UserEmail, User.UserEmail);
                var update = Builders<HubUserContextEntity>.Update.Set(a => a.ConnectionId, connectionid);
                var result = await _signalROnlineUserCollection.UpdateOneAsync(UpdateFilter, update);
            }
            return User;
        }

        /// <summary>
        /// UpdateOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <returns></returns>
        public async Task<HubUserContextEntity> UpdateOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid)
        {
            //get login in/connected user from the claim
            HubUserContextEntity User = _iUserProfileParserService.GetPrpfileFromClaim(connectionid, httpCtx);
            //get user from mongodb by user
            var obj = await FindByEmailAddress(User);
            if (obj != null)
            {
                var UpdateFilter = Builders<HubUserContextEntity>.Filter.Eq(a => a.UserEmail, User.UserEmail);
                var update = Builders<HubUserContextEntity>.Update.Set(a => a.ConnectionId, connectionid);
                var result = _signalROnlineUserCollection.UpdateOneAsync(UpdateFilter, update);
            }
            return User;
        }

        /// <summary>
        /// RemoveOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <returns></returns>
        public async Task<HubUserContextEntity> RemoveOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid)
        {
            //get login in/connected user from the claim
            HubUserContextEntity User = _iUserProfileParserService.GetPrpfileFromClaim(connectionid, httpCtx);
            //get user from mongodb by user
            var obj = await FindByEmailAddress(User);
            if (obj != null)
            {
                var filter = Builders<HubUserContextEntity>.Filter.Eq(person => person.UserEmail, obj.UserEmail);
                var personDeleteResult = await _signalROnlineUserCollection.DeleteOneAsync(filter);
            }
            return User;
        }

        /// <summary>
        /// FindByEmailAddress
        /// </summary>
        /// <returns></returns>
        public async Task<HubUserContextEntity> FindByEmailAddress(HubUserContextEntity user)
        {
            var filter = Builders<HubUserContextEntity>.Filter.Eq(x => x.UserEmail, user.UserEmail);
            var @event = (await _signalROnlineUserCollection.FindAsync(filter)).FirstOrDefault();
            if (@event != null)
            {
                return @event;
            }
            else
                return null;
        }

        /// <summary>
        /// GetOnlineUserListFromDB
        /// </summary>
        /// <returns></returns>
        public async Task<List<HubUserContextEntity>> GetOnlineUserListFromDB()
        {
            _OnlineUserList = new List<HubUserContextEntity>();
            _OnlineUserList = await _signalROnlineUserCollection.Find(_ => true).ToListAsync();
            return _OnlineUserList;
        }


       

        public async Task<HubUserContextEntity> FindByUserName(HubUserContextEntity user)
        {
            var filter = Builders<HubUserContextEntity>.Filter.Eq(x => x.UserName, user.UserName);
            var @event = (await _signalROnlineUserCollection.FindAsync(filter)).FirstOrDefault();
            if (@event != null)
            {
                return @event;
            }
            else
                return null;
        }
    }

}

