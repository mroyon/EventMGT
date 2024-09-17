using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BDO.Core.DataAccessObjects.Models
{
    public partial class gen_unitEntity
    {

        [DataMember]
        public List<gen_eventfileinfoEntity> UnitfileinfoList { get; set; } // Files from form-data

        public List<EventInfoTestFile> postedFiles { get; set; }

        [DataMember]
        public IFormFile file { get; set; }


    }
}
