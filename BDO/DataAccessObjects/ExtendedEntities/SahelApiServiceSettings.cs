using System;
using System.Collections.Generic;
using System.Text;

namespace BDO.DataAccessObjects.ExtendedEntities
{
    public class SahelApiServiceSettings
    {
        public string WebApiAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NotificationType { get; set; }
        public bool IsForSubscriber { get; set; }
    }
}
