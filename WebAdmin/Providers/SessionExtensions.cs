using AppConfig.EncryptionHandler;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebAdmin.Providers
{
    /// <summary>
    /// SessionExtensions
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// SetObjectAsJson
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="enckey"></param>
        public static void SetRedis(this ISession session, string key, object value, string enckey = "")
        {
            string encstring = JsonConvert.SerializeObject(value);
            if (enckey != string.Empty)
            {
                EncryptionHelper objEncLib = new EncryptionHelper();
                encstring = objEncLib.Encrypt(encstring, true, enckey);
            }
            session.SetString(key, encstring);
        }

        /// <summary>
        /// GetObjectFromJson
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="enckey"></param>
        /// <returns></returns>
        public static T GetRedis<T>(this ISession session, string key, string enckey = "")
        {
            string value = session.GetString(key);
            if (enckey != string.Empty)
            {
                EncryptionHelper objEncLib = new EncryptionHelper();
                value = objEncLib.Decrypt(value, true, enckey);
            }
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
