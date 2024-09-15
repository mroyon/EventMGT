using BDO.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    public class sahelvcsubscribercivilidEntity : BaseEntity
    {
        public sahelvcsubscribercivilidEntity()
        { }


        public string civil_id { get; set; }
        public string step_no { get; set; }
        public List<InputModel> inputmodel { get; set; }
    }
}
