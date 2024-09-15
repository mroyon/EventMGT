using System;
using System.Runtime.Serialization;


namespace WinFormReports.Models
{
    [Serializable]
    [DataContract(Name = "kaf_hr_militarysvcinfoEntity", Namespace = "http://www.KAF.com/types")]
    public partial class kaf_hr_militarysvcinfoEntity 
    {
        #region Properties
        [DataMember]
        public long ? hrbasicid { get; set; }

        [DataMember]
        public long ? militaryno { get; set; }

        [DataMember]
        public long ? civilid { get; set; }

        [DataMember]
        public string fullname { get; set; }

        [DataMember]
        public string fullnameeng { get; set; }

        [DataMember]
        public long ? currententitykey { get; set; }

        [DataMember]
        public string currententitycode { get; set; }

        [DataMember]
        public string currentfullunitpath { get; set; }

        [DataMember]
        public long ? entitykey { get; set; }

        [DataMember]
        public long ? originalentitykey { get; set; }

        [DataMember]
        public string originalfullunitpath { get; set; }

        [DataMember]
        public DateTime ? birthdate { get; set; }

        [DataMember]
        public string age { get; set; }

        [DataMember]
        public DateTime ? joindate { get; set; }

        [DataMember]
        public string servicelength { get; set; }

        [DataMember]
        public string rankname { get; set; }

        [DataMember]
        public string nationality { get; set; }

        [DataMember]
        public string servicestatusname { get; set; }

        [DataMember]
        public DateTime ? lastpromotiondate { get; set; }

        [DataMember]
        public string certificatelevel { get; set; }

        [DataMember]
        public string certificatename { get; set; }

        [DataMember]
        public string certificategradename { get; set; }

        [DataMember]
        public string educationcountry { get; set; }

        [DataMember]
        public string coursename { get; set; }

        [DataMember]
        public long ? acryear { get; set; }

        [DataMember]
        public string acrgrade { get; set; }
        #endregion
    }
}
