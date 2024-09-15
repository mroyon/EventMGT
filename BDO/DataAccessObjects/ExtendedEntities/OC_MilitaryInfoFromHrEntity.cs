using BDO.Core.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace BDO.DataAccessObjects.ExtendedEntities
{
    /// This object represents the properties and methods of a OC_MilitaryInfoFromHrEntity.
    /// </summary>
    [Serializable]
    [DataContract(Name = "OC_MilitaryInfoFromHrEntity", Namespace = "http://www.KAF.com/types")]
    public class OC_MilitaryInfoFromHrEntity : BaseEntity
    {
        [DataMember]
        public long? hrbasicid { get; set; }
        [DataMember]
        public long? militaryno { get; set; }
        [DataMember]
        public long? civilid { get; set; }
        [DataMember]
        public string name1 { get; set; }
        [DataMember]
        public string name2 { get; set; }
        [DataMember]
        public string name3 { get; set; }
        [DataMember]
        public string name4 { get; set; }
        [DataMember]
        public string name5 { get; set; }
        [DataMember]
        public string fullname { get; set; }
        [DataMember]
        public string mobile1 { get; set; }
        [DataMember]
        public string rankname { get; set; }
        [DataMember]
        public string unit { get; set; }
        [DataMember]
        public string possitionname { get; set; }


        [DataMember]
        public DateTime? joindate { get; set; }
        [DataMember]
        public DateTime? birthdate { get; set; }
        [DataMember]
        public string age { get; set; }
        [DataMember]
        public string servicelength { get; set; }
        [DataMember]
        public string educationlevel { get; set; }
        [DataMember]
        public string gradeGPA { get; set; }
        [DataMember]
        public string educationcountry { get; set; }
        [DataMember]
        public string educationpermission { get; set; }
        [DataMember]
        public string manditorymilitarycourses { get; set; }
        [DataMember]
        public string acr { get; set; }

        public OC_MilitaryInfoFromHrEntity() : base()
        {
        }

        public OC_MilitaryInfoFromHrEntity(IDataReader reader)
        {
            this.LoadFromReader_OCRegistrationProcess_OfficersInfoFromHR(reader);
        }

        public void LoadFromReader_OCRegistrationProcess_OfficersInfoFromHR(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("hrbasicid"))) this.hrbasicid = reader.GetInt64(reader.GetOrdinal("hrbasicid"));
                if (!reader.IsDBNull(reader.GetOrdinal("militaryno"))) this.militaryno = reader.GetInt64(reader.GetOrdinal("militaryno"));
                if (!reader.IsDBNull(reader.GetOrdinal("civilid"))) this.civilid = reader.GetInt64(reader.GetOrdinal("civilid"));
                if (!reader.IsDBNull(reader.GetOrdinal("fullname"))) this.fullname = reader.GetString(reader.GetOrdinal("fullname"));
                if (!reader.IsDBNull(reader.GetOrdinal("mobile1"))) this.mobile1 = reader.GetString(reader.GetOrdinal("mobile1"));
                if (!reader.IsDBNull(reader.GetOrdinal("rankname"))) this.rankname = reader.GetString(reader.GetOrdinal("rankname"));
                if (!reader.IsDBNull(reader.GetOrdinal("unit"))) this.unit = reader.GetString(reader.GetOrdinal("unit"));
                if (!reader.IsDBNull(reader.GetOrdinal("possitionname"))) this.possitionname = reader.GetString(reader.GetOrdinal("possitionname"));
                if (!reader.IsDBNull(reader.GetOrdinal("joindate"))) this.joindate = reader.GetDateTime(reader.GetOrdinal("joindate"));
                if (!reader.IsDBNull(reader.GetOrdinal("birthdate"))) this.birthdate = reader.GetDateTime(reader.GetOrdinal("birthdate"));
                if (!reader.IsDBNull(reader.GetOrdinal("age"))) this.age = reader.GetString(reader.GetOrdinal("age"));
                if (!reader.IsDBNull(reader.GetOrdinal("servicelength"))) this.servicelength = reader.GetString(reader.GetOrdinal("servicelength"));
                if (!reader.IsDBNull(reader.GetOrdinal("educationlevel"))) this.educationlevel = reader.GetString(reader.GetOrdinal("educationlevel"));
                if (!reader.IsDBNull(reader.GetOrdinal("gradeGPA"))) this.gradeGPA = reader.GetString(reader.GetOrdinal("gradeGPA"));
                if (!reader.IsDBNull(reader.GetOrdinal("educationcountry"))) this.educationcountry = reader.GetString(reader.GetOrdinal("educationcountry"));
                if (!reader.IsDBNull(reader.GetOrdinal("educationpermission"))) this.educationpermission = reader.GetString(reader.GetOrdinal("educationpermission"));
                if (!reader.IsDBNull(reader.GetOrdinal("manditorymilitarycourses"))) this.manditorymilitarycourses = reader.GetString(reader.GetOrdinal("manditorymilitarycourses"));
                if (!reader.IsDBNull(reader.GetOrdinal("acr"))) this.acr = reader.GetString(reader.GetOrdinal("acr"));

                CurrentState = EntityState.Unchanged;
            }
        }
    }
}
