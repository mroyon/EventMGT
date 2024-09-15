
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "InformationPortalAccessToken", Namespace = "http://www.KAF.com/types")]
    public sealed class InformationPortalAccessToken
    {
        [DataMember]
        public string token { get; set; }
        [DataMember]
        public int expiresIn { get; set; }
    }

    [Serializable]
    [DataContract(Name = "InformationPortalAccessTokenRoot", Namespace = "http://www.KAF.com/types")]
    public class InformationPortalAccessTokenRoot
    {
        [DataMember]
        public InformationPortalAccessToken accessToken { get; set; }
        [DataMember]
        public string refreshToken { get; set; }
        [DataMember]
        public bool success { get; set; }
    }

    [Serializable]
    [DataContract(Name = "PaymentGateqayLoginResponse", Namespace = "http://www.KAF.com/types")]
    public class PaymentGateqayLoginResponse
    {
        [DataMember]
        public string access_token { get; set; }
        [DataMember]
        public string token_type { get; set; }
        [DataMember]
        public int expires_in { get; set; }
    }

    [Serializable]
    [DataContract(Name = "generatePayLinkResponse", Namespace = "http://www.KAF.com/types")]
    public class generatePayLinkResponse
    {
        [DataMember] 
        public string Message { get; set; }
        [DataMember]
        public string Value { get; set; }
    }

    [Serializable]
    [DataContract(Name = "KNSServiceAccessToken", Namespace = "http://www.KAF.com/types")]
    public sealed class KNSServiceAccessToken
    {
        [DataMember]
        public string token { get; set; }
        [DataMember]
        public int expiresIn { get; set; }
    }

    [Serializable]
    [DataContract(Name = "KNSServiceAccessTokenRoot", Namespace = "http://www.KAF.com/types")]
    public class KNSServiceAccessTokenRoot
    {
        [DataMember]
        public KNSServiceAccessToken accessToken { get; set; }
        [DataMember]
        public string refreshToken { get; set; }
        [DataMember]
        public bool success { get; set; }
    }


    [Serializable]
    [DataContract(Name = "PaymentGatewayServiceAccessTokenRoot", Namespace = "http://www.KAF.com/types")]
    public class PaymentGatewayServiceAccessTokenRoot
    {
        [DataMember]
        public string refreshToken { get; set; }
        [DataMember]
        public string accessToken { get; set; }
        [DataMember]
        public int expiresIn { get; set; }
        [DataMember]
        public bool success { get; set; }
    }

    [Serializable]
    [DataContract(Name = "PaymentGatewaySaveStepOneEntity", Namespace = "http://www.KAF.com/types")]
    public class PaymentGatewaySaveStepOneDataEntity
    {
        [DataMember]
        public long transactionid { get; set; }
        [DataMember]
        public string refconsumerid { get; set; }
        [DataMember]
        public string requestguid { get; set; }
        [DataMember]
        public DateTime requestdate { get; set; }
        [DataMember]
        public bool requestisactive { get; set; }
        [DataMember]
        public string transactioncode { get; set; }
        [DataMember]
        public string merchanttrackid { get; set; }
        [DataMember]
        public long civilid { get; set; }
        [DataMember]
        public int militaryid { get; set; }
        [DataMember]
        public string merchantservicename { get; set; }
        [DataMember]
        public string serviceurl { get; set; }
        [DataMember]
        public string returnsuccessurl { get; set; }
        [DataMember]
        public string returnfailedurl { get; set; }
        [DataMember]
        public string fileurl { get; set; }
    }

    [Serializable]
    [DataContract(Name = "PaymentGatewaySaveStepOneMasterEntity", Namespace = "http://www.KAF.com/types")]
    public class PaymentGatewaySaveStepOneMasterEntity
    {
        [DataMember]
        public PaymentGatewaySaveStepOneDataEntity data { get; set; }
        [DataMember]
        public int recordsTotal { get; set; }
        [DataMember]
        public int recordsFiltered { get; set; }
    }
}
