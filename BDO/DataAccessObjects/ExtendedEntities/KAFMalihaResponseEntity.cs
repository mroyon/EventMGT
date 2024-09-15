using BDO.Core.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace BDO.DataAccessObjects.ExtendedEntities
{
   
    /// This object represents the properties and methods of a KAFGetMilitaryInfo.
    /// </summary>
    [Serializable]
    [DataContract(Name = "KAFMalihaResponseEntity", Namespace = "http://www.KAF.com/types")]

    public class KAFMalihaResponsePersonEntity
    {
        [DataMember]
        public string civiL_ID { get; set; }
        [DataMember]
        public string emP_NAME { get; set; }
        [DataMember]
        public string emP_NO { get; set; }
        [DataMember]
        public string emP_ID { get; set; }
        [DataMember]
        public string emP_STATUS { get; set; }
    }

    [Serializable]
    [DataContract(Name = "KAFMalihaResponseEntity", Namespace = "http://www.KAF.com/types")]
    public class KAFMalihaResponseEntity
    {
        [DataMember]
        public KAFMalihaResponsePersonEntity data { get; set; }
        [DataMember]
        public int recordsTotal { get; set; }
        [DataMember]
        public int recordsFiltered { get; set; }
    }

}
