using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BDO.Core.DataAccessObjects.Models
{
    public partial class gen_eventinfoEntity
    {

        [DataMember]
        public List<gen_eventfileinfoEntity> EventfileinfoList { get; set; } // Files from form-data

        public List<EventInfoTestFile> postedFiles { get; set; }

        [DataMember]
        public string unitname { get; set; }

        [DataMember]
        public string unitcode { get; set; }
        [DataMember]
        public string eventcategory { get; set; }

    }
}

[DataContract]
public class EventInfoTestFile
{
    [DataMember] public long? eventfileid { get; set; }
    [DataMember] public long? eventid { get; set; }
    [DataMember] public IFormFile file { get; set; }
    [DataMember] public string fileDescription { get; set; }

}