using System;
using System.Runtime.Serialization;

namespace BDO.DataAccessObjects.ExtendedEntities.IQRCodeAuthentication
{
    [Serializable]
    [DataContract(Name = "PACIQRCodeAuthenticationEntity", Namespace = "http://www.KAF.com/types")]


    public class PACIQRCodeAuthenticationEntity
    {
        [DataMember]
        public Data data { get; set; }
        [DataMember]
        public int recordsTotal { get; set; }
        [DataMember]
        public int recordsFiltered { get; set; }
    }

    [Serializable]
    [DataContract(Name = "Data", Namespace = "http://www.KAF.com/types")]
    public class Data
    {
        [DataMember]
        public string civilID { get; set; }
        [DataMember]
        public string tran_pacisigninrequestinfoSerial { get; set; }
        [DataMember]
        public string KeyParam { get; set; }
        [DataMember]
        public Result result { get; set; }
    }

    [Serializable]
    [DataContract(Name = "Result", Namespace = "http://www.KAF.com/types")]

    public class Result
    {
        [DataMember]
        public string qrCodeImage { get; set; }
        [DataMember]
        public string qrCode { get; set; }
    }

    [Serializable]
    [DataContract(Name = "PACICivilIDAuthenticationEntity", Namespace = "http://www.KAF.com/types")]

    public class PACICivilIDAuthenticationEntity
    {
        [DataMember]
        public DataCivil data { get; set; }
        [DataMember]
        public int recordsTotal { get; set; }
        [DataMember]
        public int recordsFiltered { get; set; }
    }

    [Serializable]
    [DataContract(Name = "DataCivil", Namespace = "http://www.KAF.com/types")]
    public class DataCivil
    {
        [DataMember]
        public string civilID { get; set; }
        [DataMember]
        public string tran_pacisigninrequestinfoSerial { get; set; }
        [DataMember]
        public string KeyParam { get; set; }
        [DataMember]
        public string result { get; set; }
    }


}
