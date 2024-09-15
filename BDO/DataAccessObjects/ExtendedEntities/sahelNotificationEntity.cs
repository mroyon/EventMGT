using BDO.Core.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace BDO.DataAccessObjects.ExtendedEntities
{

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
        public string value { get; set; }
    }

    public class DataTableEn
    {
        public string title { get; set; }
        public string value { get; set; }
    }


    public class DataTableListAr
    {
        public string additionalPropValue { get; set; }
    }

    public class DataTableListEn
    {
        public string additionalPropValue { get; set; }
    }



    public class sahelNotificationRequestEntity
    {
        public string subscriberCivilId { get; set; }
        public string bodyAr { get; set; }
        public string bodyEn { get; set; }
        public List<BDO.DataAccessObjects.ExtendedEntities.DataTableAr> dataTableAr { get; set; }
        public List<BDO.DataAccessObjects.ExtendedEntities.DataTableEn> dataTableEn { get; set; }
        public bool isForSubscriber { get; set; }
        public string notificationType { get; set; }
        public List<ActionButtonRequestList> actionButtonRequestList { get; set; }
    }

    public class sahelNotificationRequestListEntity
    {
        public List<string> subscriberCivilId { get; set; }
        public string bodyAr { get; set; }
        public string bodyEn { get; set; }
        public List<BDO.DataAccessObjects.ExtendedEntities.DataTableListAr> dataTableAr { get; set; }
        public List<BDO.DataAccessObjects.ExtendedEntities.DataTableListEn> dataTableEn { get; set; }
        public bool isForSubscriber { get; set; }
        public string notificationType { get; set; }
        public List<ActionButtonRequestList> actionButtonRequestList { get; set; }
    }


    [Serializable]
    [DataContract(Name = "sahelNotificationResponseEntity", Namespace = "http://www.KAF.com/types")]
    public class sahelNotificationResponseEntity
    {
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public int responseCode { get; set; }
        [DataMember]
        public string subscriberCivilId { get; set; }
    }

    [Serializable]
    [DataContract(Name = "sahelNotificationEntity", Namespace = "http://www.KAF.com/types")]
    public class sahelNotificationEntity : BaseEntity
    {
        [DataMember]
        public string subscriberCivilId { get; set; }
        [DataMember]
        public string messagear { get; set; }
        [DataMember]
        public string messageen { get; set; }
        [DataMember]
        public List<BDO.DataAccessObjects.ExtendedEntities.DataTableAr> dataTableAr { get; set; }
        [DataMember]
        public List<BDO.DataAccessObjects.ExtendedEntities.DataTableEn> dataTableEn { get; set; }
        [DataMember]
        public bool isForSubscriber { get; set; }
        [DataMember]
        public string notificationType { get; set; }
        [DataMember]
        public List<ActionButtonRequestList> actionButtonRequestList { get; set; }

        [DataMember]
        public string referenceapptag { get; set; }
        [DataMember]
        public string referenceid { get; set; }


    }

    [Serializable]
    [DataContract(Name = "sahelNotificationBulkEntity", Namespace = "http://www.KAF.com/types")]
    public class sahelNotificationBulkEntity : BaseEntity
    {
        [DataMember]
        public List<string> subscriberCivilId { get; set; }
        [DataMember]
        public string messagear { get; set; }
        [DataMember]
        public string messageen { get; set; }
        [DataMember]
        public List<BDO.DataAccessObjects.ExtendedEntities.DataTableListAr> dataTableAr { get; set; }
        [DataMember]
        public List<BDO.DataAccessObjects.ExtendedEntities.DataTableListEn> dataTableEn { get; set; }
        [DataMember]
        public bool isForSubscriber { get; set; }
        [DataMember]
        public string notificationType { get; set; }
        [DataMember]
        public List<ActionButtonRequestList> actionButtonRequestList { get; set; }

        [DataMember]
        public string referenceapptag { get; set; }
        [DataMember]
        public string referenceid { get; set; }

    }
}
