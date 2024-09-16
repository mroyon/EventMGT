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

        public List<EventInfoTestFile> postedFiles{ get;set;}

    }
}


public class EventInfoTestFile
{
    public long? eventfileid { get; set; }
    public long? eventid { get; set; }
    public IFormFile file { get; set; }
    public string fileDescription { get; set; }

}