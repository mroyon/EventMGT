using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;
using BDO.Core.DataAccessObjects.CommonEntities;

namespace BDO.Core.DataAccessObjects.Models
{

    public partial class s2gen_serviceinfoEntity : S2Parameters
    {
        #region Properties

        [DataMember]
        public bool? isExt { get; set; }


        #endregion
    }


    public partial class gen_serviceinfoEntity 
    {
        #region Properties

        [DataMember]
        public bool? isExt { get; set; }

        [DataMember]
        public Guid? UserID { get; set; }
        [DataMember]
        public string UserName { get; set; }


        #endregion
    }

    public partial class gen_servicestatusEntity
    {
        [DataMember]
        public bool? isExt { get; set; }
    }


}
