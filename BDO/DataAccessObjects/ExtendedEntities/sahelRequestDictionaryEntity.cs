using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "sahelRequestDictionaryEntity", Namespace = "http://www.KAF.com/types")]
    public partial class sahelRequestDictionaryEntity
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Extension { get; set; }

    }
}
