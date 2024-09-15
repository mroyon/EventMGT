using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;
using BDO.DataAccessObjects.ExtendedEntities;

namespace BDO.Core.DataAccessObjects.Models
{
    public partial class oc_registrationinfomasterEntity
    {
        [DataMember]
        public OC_OfficerPaciJsonDataEntity oc_officerpacijsondataEntity { get; set; }

        [DataMember]
        public OC_Hr_MilitarySvcInfoJsonDataEntity oc_hr_militarysvcinfojsondataEntity { get; set; }

        [DataMember]
        public KAF_GetMilitaryFamilyInfoEntity kaf_getmilitaryfamilyinfoEntity { get; set; }
    }
}
