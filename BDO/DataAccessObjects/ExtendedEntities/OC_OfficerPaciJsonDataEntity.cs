using BDO.Core.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace BDO.DataAccessObjects.ExtendedEntities
{
    /// This object represents the properties and methods of a OC_OfficerPaciJsonDataEntity.
    /// </summary>
    [Serializable]
    [DataContract(Name = "OC_OfficerPaciJsonDataEntity", Namespace = "http://www.KAF.com/types")]
    public class OC_OfficerPaciJsonDataEntity : BaseEntity
    {
        [DataMember]
        public long? hrbasicid { get; set; }
        [DataMember]
        public long? militaryno { get; set; }
        [DataMember]
        public long? militarytype { get; set; }
        [DataMember]
        public string officertype { get; set; }
        [DataMember]
        public string rankname { get; set; }
        [DataMember]
        public string milcourseprefix { get; set; }
        [DataMember]
        public string fullname { get; set; }
        [DataMember]
        public DateTime? birthdate { get; set; }
        [DataMember]
        public long? civilid { get; set; }
        [DataMember]
        public DateTime? joindate { get; set; }
        [DataMember]
        public string senno { get; set; }
        [DataMember]
        public string mainunit { get; set; }
        [DataMember]
        public string currentunit { get; set; }
        [DataMember]
        public string passportno { get; set; }
        [DataMember]
        public string photo { get; set; }
        [DataMember]
        public string orglogo { get; set; }
        [DataMember]
        public string nationality { get; set; }
        [DataMember]
        public string ademail { get; set; }
        [DataMember]
        public string samaccount { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string entitycode { get; set; }
        [DataMember]
        public string mobileno { get; set; }

        public OC_OfficerPaciJsonDataEntity() : base()
        {
        }
    }
}
