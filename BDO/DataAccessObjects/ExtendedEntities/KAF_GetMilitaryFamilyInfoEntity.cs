using BDO.Core.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace BDO.DataAccessObjects.ExtendedEntities
{
    /// This object represents the properties and methods of a KAF_GetMilitaryFamilyInfoEntity.
    /// </summary>
    [Serializable]
    [DataContract(Name = "KAF_GetMilitaryFamilyInfoEntity", Namespace = "http://www.KAF.com/types")]
    public class KAF_GetMilitaryFamilyInfoEntity : BaseEntity
    {
        [DataMember]
        public long? ocfileid { get; set; }
        [DataMember]
        public long? militaryno { get; set; }
        [DataMember]
        public Guid? userid { get; set; }
        [DataMember]
        public long? hrbasicid { get; set; }
        [DataMember]
        public long? profiletype { get; set; }
        [DataMember]
        public string fullname { get; set; }
        [DataMember]
        public long? civilid { get; set; }
        [DataMember]
        public long? hrfamilyid { get; set; }
        [DataMember]
        public long? relationshipid { get; set; }
        [DataMember]
        public string relationshipname { get; set; }
        [DataMember]
        public string relationshipnameeng { get; set; }
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
        public long? familyreligionid { get; set; }
        [DataMember]
        public long? familybloodgroupid { get; set; }
        [DataMember]
        public DateTime? familybirthdate { get; set; }
        [DataMember]
        public long? familybithdoctypeid { get; set; }
        [DataMember]
        public string familybirthdocno { get; set; }
        [DataMember]
        public DateTime? familybirthdocdate { get; set; }
        [DataMember]
        public long? familycountryid { get; set; }
        [DataMember]
        public long? familynationalityid { get; set; }
        [DataMember]
        public long? familynationalityclassificatioid { get; set; }
        [DataMember]
        public long? familynationalitydegreeid { get; set; }
        [DataMember]
        public long? familymaritalstatusid { get; set; }
        [DataMember]
        public DateTime? familymarriagedate { get; set; }
        [DataMember]
        public string familymarriagedocno { get; set; }
        [DataMember]
        public DateTime? familymarriagedocdate { get; set; }
        [DataMember]
        public string marriagepermissiondocno { get; set; }
        [DataMember]
        public DateTime? marriagepermissiondocdate { get; set; }
        [DataMember]
        public long? marriageserialno { get; set; }
        [DataMember]
        public DateTime? paydate { get; set; }
        [DataMember]
        public string paydocno { get; set; }
        [DataMember]
        public DateTime? paydocdate { get; set; }
        [DataMember]
        public Guid? payfileno { get; set; }
        [DataMember]
        public string payunitdocno { get; set; }
        [DataMember]
        public DateTime? payunitdocdate { get; set; }
        [DataMember]
        public DateTime? paystopdate { get; set; }
        [DataMember]
        public string paystopdocno { get; set; }
        [DataMember]
        public DateTime? paystopdocdate { get; set; }
        [DataMember]
        public Guid? paystopfileno { get; set; }
        [DataMember]
        public string paystopunitdocno { get; set; }
        [DataMember]
        public DateTime? paystopunitdocdate { get; set; }
        [DataMember]
        public string paystopreason { get; set; }
        [DataMember]
        public DateTime? divorcedate { get; set; }
        [DataMember]
        public string divorcedocno { get; set; }
        [DataMember]
        public DateTime? divorcedocdate { get; set; }
        [DataMember]
        public string familycuraddressflatno { get; set; }
        [DataMember]
        public string familycuraddresshouseno { get; set; }
        [DataMember]
        public string familycuraddressstreet { get; set;  } 
        [DataMember]
        public string familycuradrressblock { get; set;  } 
        [DataMember]
        public long? familycurgovnerid { get; set;  } 
        [DataMember]
        public long? familycurareaid { get; set;  } 
        [DataMember]
        public string familymobile1 { get; set;  } 
        [DataMember]
        public string familytelephone1 { get; set;  } 
        [DataMember]
        public long? fatherstatusid { get; set;  } 
        [DataMember]
        public bool? approve65 { get; set;  } 
        [DataMember]
        public bool? isservedinmilitary { get; set;  } 
        [DataMember]
        public long? militarynofamily { get; set;  } 
        [DataMember]
        public long? workplaceid { get; set;  } 
        [DataMember]
        public string workdesignation { get; set;  } 
        [DataMember]
        public DateTime? familydeathdate { get; set;  } 
        [DataMember]
        public string familydeathdocno { get; set;  } 
        [DataMember]
        public DateTime? familydeathdocdate { get; set;  } 
        [DataMember]
        public DateTime? separetiondate { get; set;  } 
        [DataMember]
        public string separetionreason { get; set;  } 
        [DataMember]
        public string separetiondocno { get; set;  } 
        [DataMember]
        public DateTime? separetiondocdate { get; set;  } 
        [DataMember]
        public long? familypacino { get; set;  } 
        [DataMember]
        public int? forreview { get; set;  } 
        [DataMember]
        public long? serviceid { get; set; }
        public KAF_GetMilitaryFamilyInfoEntity() : base()
        {
        }
    }
}
