using  System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;
using BDO.Core.DataAccessObjects.CommonEntities;

namespace BDO.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "KAF_GetMilitaryFamilyRegEntity", Namespace = "http://www.KAF.com/types")]
    public class KAF_GetMilitaryFamilyRegEntity 
    {
        [DataMember]
        public long? militaryno { get; set; }
        [DataMember]
        public Guid userid { get; set; }
        [DataMember]
        public long? hrbasicid { get; set; }
        [DataMember]
        public long? profiletype { get; set; }
        [DataMember]
        public string fullname { get; set; }
        [DataMember]
        public long? civilid { get; set; }
        [DataMember]
        public long? relationshipid { get; set; }
        [DataMember]
        public long? hrfamilyid { get; set; }
        [DataMember]
        public string relationshipname { get; set; }
        [DataMember]
        public long? parenthrfamilyid { get; set; }
        [DataMember]
        public long? familycivilid { get; set; }
        [DataMember]
        public string familyfullname { get; set; }
        [DataMember]
        public string familyfullnameeng { get; set; }
        [DataMember]
        public long? healthstatusid { get; set; }
        [DataMember]
        public long? familygenderid { get; set; }
        [DataMember]
        public DateTime? familybirthdate { get; set; }
        [DataMember]
        public string isregistered { get; set; }

        public KAF_GetMilitaryFamilyRegEntity()
        {
        }

        public KAF_GetMilitaryFamilyRegEntity(IDataReader ireader)
        {
            //LoadFromReader(ireader);
            LoadFromReaderREF(ireader);
        }

        protected void LoadFromReaderREF(IDataReader reader)
        {
            //SqlDataReader reader = (SqlDataReader)ireader;
            if (reader != null && !reader.IsClosed)
            {
                if (!reader.IsDBNull(reader.GetOrdinal("MilitaryNo"))) militaryno = reader.GetInt64(reader.GetOrdinal("MilitaryNo"));
                if (!reader.IsDBNull(reader.GetOrdinal("Userid"))) userid = reader.GetGuid(reader.GetOrdinal("Userid"));
                if (!reader.IsDBNull(reader.GetOrdinal("HRBasicID"))) hrbasicid = reader.GetInt64(reader.GetOrdinal("HRBasicID"));
                if (!reader.IsDBNull(reader.GetOrdinal("ProfileType"))) profiletype = reader.GetInt64(reader.GetOrdinal("ProfileType"));
                if (!reader.IsDBNull(reader.GetOrdinal("FullName"))) fullname = reader.GetString(reader.GetOrdinal("FullName"));
                if (!reader.IsDBNull(reader.GetOrdinal("CivilID"))) civilid = reader.GetInt64(reader.GetOrdinal("CivilID"));
                if (!reader.IsDBNull(reader.GetOrdinal("RelationshipID"))) relationshipid = reader.GetInt64(reader.GetOrdinal("RelationshipID"));
                if (!reader.IsDBNull(reader.GetOrdinal("HrFamilyID"))) hrfamilyid = reader.GetInt64(reader.GetOrdinal("HrFamilyID"));
                if (!reader.IsDBNull(reader.GetOrdinal("RelationshipName"))) relationshipname = reader.GetString(reader.GetOrdinal("RelationshipName"));
                if (!reader.IsDBNull(reader.GetOrdinal("ParentHrFamilyID"))) parenthrfamilyid = reader.GetInt64(reader.GetOrdinal("ParentHrFamilyID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FamilyCivilID"))) familycivilid = reader.GetInt64(reader.GetOrdinal("FamilyCivilID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FamilyFullName"))) familyfullname = reader.GetString(reader.GetOrdinal("FamilyFullName"));
                if (!reader.IsDBNull(reader.GetOrdinal("FamilyFullNameEng"))) familyfullnameeng = reader.GetString(reader.GetOrdinal("FamilyFullNameEng"));
                if (!reader.IsDBNull(reader.GetOrdinal("HealthStatusID"))) healthstatusid = reader.GetInt64(reader.GetOrdinal("HealthStatusID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FamilyGenderID"))) familygenderid = reader.GetInt64(reader.GetOrdinal("FamilyGenderID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FamilyBirthDate"))) familybirthdate = reader.GetDateTime(reader.GetOrdinal("FamilyBirthDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsRegistered"))) isregistered = reader.GetString(reader.GetOrdinal("IsRegistered"));
            }
        }



    }
}
