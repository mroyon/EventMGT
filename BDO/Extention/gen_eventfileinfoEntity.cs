using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
   
    public partial class gen_eventfileinfoEntity
    {
        private string fileUrl;

        [DataMember]
        public string FileUrl { get => fileUrl; set => fileUrl = value; }


    }
}
