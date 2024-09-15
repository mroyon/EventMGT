using BDO.Core.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "InputItemModels", Namespace = "http://www.KAF.com/types")]

    public class InputItemModels
    {
        [DataMember]
        [JsonPropertyName("Key")]
        public string Key { get; set; }
        [DataMember]
        [JsonPropertyName("Value")]
        public string Value { get; set; }
        [DataMember]
        [JsonPropertyName("Type")]
        public string Type { get; set; }
        [DataMember]
        [JsonPropertyName("Extension")]
        public string Extension { get; set; }
    }

    [Serializable]
    [DataContract(Name = "sahelPostEntity", Namespace = "http://www.KAF.com/types")]

    public class sahelPostEntity : BaseEntity
    {
        [DataMember]
        public string civilId { get; set; }
        [DataMember]
        public int stepNo { get; set; }
        [DataMember]
        public List<InputItemModels> Actions { get; set; }
    }


}
