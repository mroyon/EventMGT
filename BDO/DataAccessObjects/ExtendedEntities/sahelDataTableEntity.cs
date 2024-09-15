using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BDO.Core.DataAccessObjects.ExtendedEntities
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ActionButtonRequestList
    {
        public string actionType { get; set; }
        public string actionUrl { get; set; }
        public string viewBag { get; set; }
        public string labelAr { get; set; }
        public string labelEn { get; set; }
    }

    public class DataTableAr
    {
        public string title { get; set; }
    }

    public class DataTableEn
    {
        public string title { get; set; }
    }

    public class sahelDataTableEntity
    {
        public string subscriberCivilId { get; set; }
        public string identifierValue { get; set; }
        public DataTableAr dataTableAr { get; set; }
        public DataTableEn dataTableEn { get; set; }
        public bool isForSubscriber { get; set; }
        public string serviceStatusType { get; set; }
        public string alertType { get; set; }
        public List<ActionButtonRequestList> actionButtonRequestList { get; set; }
    }



}
