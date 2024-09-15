using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;
using BDO.Core.DataAccessObjects.CommonEntities;
using System.Collections.Generic;

namespace BDO.Core.DataAccessObjects.Models
{
    public partial class oc_paymentinfoEntity
    {
        public bool isext { get; set; } = false;
        public long? occivilid { get; set; }
        public long? ocmilitaryid { get; set; }
    }

    public class DtOC_paymentinfoParameters : DtParameters
    {
        public string memberregistrationid { get; set; }
        public long? occivilid { get; set; }
        public long? ocmilitaryid { get; set; }
    }
}
