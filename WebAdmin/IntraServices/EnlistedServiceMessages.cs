using BDO.Core.DataAccessObjects.CommonEntities;
using BDO.DataAccessObjects.ExtendedEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using static IdentityServer4.Models.IdentityResources;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace WebAdmin.IntraServices
{
    /// <summary>
    /// EnlistedServiceMessages
    /// </summary>
    public class EnlistedServiceMessages : IEnlistedServiceMessages
    {
        private readonly IConfiguration _config;
        /// <summary>
        /// EnlistedServiceMessages
        /// </summary>
        /// <param name="optionsEmailSettings"></param>
        public EnlistedServiceMessages(IConfiguration config)
        {
            _config = config;
        }



        public async Task<List<string>> SahelEnlistedServiceApprovedMessagesList()
        {
            var applist = new List<string>()
                    {
                        "شهادة من يهمه الامر صادر من المؤسسة العامة للتأمينات الاجتماعية وارفاقها مع تقديم الطلب."
                    };

            return applist;
        }

        public async Task<List<string>> SahelEnlistedServiceRejectMessagesList()
        {
            var rejlist = new List<string>()
                    {
                        "بسبب التسريح لمقتضيات المصلحة العامة.",
                        "بسبب عدم التحاقة اثناء العمليات او الغياب اثناء العمليات.",
                        "بسبب الاعمال التي تتنافى مع مسلكه العسكري.",
                        "بسبب جريمة مخلة بالشرف والامانه مالم يرد اليه اعتبارة.",
                        "بسبب تجاوز الخدمات المقررة قانونا وهي 3 خدمات عسكرية.",
                        "بسبب وجود تحفظات امنية من قبل هيئة الاستخبارات والامن قبل ذلك.",
                        "بسبب تجاوز السن القانوني المقرر لاعادة الخدمة ويجب الحصول على استثناء للعمر.",
                        "بسبب تجاوز المدة القانونية المحددة لاعادة الخدمة ويجب الحصول على استثناء من المدة.",
                        "بسبب لدية إعادة خدمة قبل ذلك ويجب تقديم استثاء إعادة للخدمة للمرة الثانية.",
                        "بسبب تجاوز المدة المقررة والعمر القانوني لإعادة الخدمة ويجب الحصول على استثناء.",
                        "بسبب تجاوز السن المقرر للاستثناءات.",
                        "بسبب تجاوز المدة المقررة للاستثناءات."
                    };

            return rejlist;
        }
    }
}
