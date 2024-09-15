
using BDO.DataAccessObjects.ExtendedEntities;
using System.Threading.Tasks;
using BDO;
using BDO.Core.DataAccessObjects.Models;
using Microsoft.AspNetCore.Http;
using BDO.Core.Base;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System;
using BDO.Core.DataAccessObjects.CommonEntities;
using System.DirectoryServices;

namespace Web.Core.Frame.Interfaces.Services
{
    internal sealed partial class ADUserService : IADUserService
    {

        private readonly IConfiguration _config;
        private readonly IJwtTokenValidator _jwtTokenValidator;
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly IStringCompression _stringCompression;
        private readonly hrwebapiconnectionsettings _hrwebapiconnectionsettingss;

        internal ADUserService(IConfiguration config
            , IHttpContextAccessor contextAccessor
            , IHttpClientFactory IHttpClienFactory
            , IJwtTokenValidator jwtTokenValidator
            , IStringCompression stringCompression
            )
        {
            _contextAccessor = contextAccessor;
            _config = config;
            _stringCompression = stringCompression;
            _jwtTokenValidator = jwtTokenValidator;
            _hrwebapiconnectionsettingss = _config.GetSection(nameof(hrwebapiconnectionsettings)).Get<hrwebapiconnectionsettings>();

        }

        /// <summary>
        /// GetADInfoByMilitaryID
        /// </summary>
        /// <param name="militaryid"></param>
        /// <returns></returns>
        public async Task<string> GetADInfoByMilitaryID(string militaryid)
        {
            string samaccountname = string.Empty;
            try
            {
                DirectorySearcher dirSearch = new DirectorySearcher(new DirectoryEntry(_hrwebapiconnectionsettingss.LDAPURL));
                dirSearch.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(description=" + militaryid + "))";
                dirSearch.SearchScope = SearchScope.Subtree;
                dirSearch.ServerTimeLimit = TimeSpan.FromSeconds(90);
                SearchResult userObject = dirSearch.FindOne();

                if (userObject != null)
                    samaccountname = userObject.GetDirectoryEntry().Properties["samaccountname"].Value.ToString() + "";
                else
                    return samaccountname;

                await Task.Delay(1000);
            }
            catch (DirectoryServicesCOMException e)
            {
                throw e;
            }
            return samaccountname;
        }

    }
}
