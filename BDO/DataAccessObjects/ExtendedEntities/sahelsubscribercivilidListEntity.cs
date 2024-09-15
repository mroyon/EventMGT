using BDO.Core.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    public class sahelsubscribercivilidListEntity : BaseEntity
    {
        public sahelsubscribercivilidListEntity()
        { }

        [DataMember]
        public string civil_id { get; set; }
        [DataMember]
        public string step_no { get; set; }
        [DataMember]
        public List<InputModel> inputmodel { get; set; }
    }
}
