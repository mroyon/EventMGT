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
        public IFormFile file { get; set; }

    }
}