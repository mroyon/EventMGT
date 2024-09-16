using BDO.Core.DataAccessObjects.CommonEntities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace BDO.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "EventSearchEntity", Namespace = "http://www.dsfaf.com/types")]
    public class EventSearchEntity : DtParameters
    {
        public long? eventcategoryid { get; set; }
        public long? eventid { get; set; }
        public long? unitid { get; set; }
        public string eventname { get; set; }
        public string eventdescription { get; set; }
        public string eventcode { get; set; }
        public DateTime? eventstartdate { get; set; }
        public DateTime? eventenddate { get; set; }
    }
}
