using BDO.Core.Base;
using BDO.DataAccessObjects.ExtendedEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "MINServiceRequestEntity", Namespace = "http://www.KAF.com/types")]
    public class MINServiceRequestEntity : BaseEntity
    {
        [DataMember]
        public string civilid { get; set; }
        [DataMember]
        public DateTime? fromdate { get; set; }
        [DataMember]
        public DateTime? todate { get; set; }
        [DataMember]
        public string categoryid { get; set; }
    }




    [Serializable]
    [DataContract(Name = "ResponseDepartedStructure", Namespace = "http://www.KAF.com/types")]
    public class ResponseDepartedStructure
    {
        [DataMember]
        public List<MINServicePAAETRequestEntity> _minServicePAAETRequestList;

        [DataMember]
        public List<MinServiceDepartedEntity> _minServiceDepartedEntityList;

        [DataMember]
        public List<MinServiceKuUniDataEntity> _minServiceKuUniDataEntityList;



        [DataMember]
        public List<MinServiceCivilServiceComEntity> _minServiceCivilServiceComEntity;


        [DataMember]
        public List<MinServiceMOEDataEntity> _minServiceMOEDataEntity;

        /// <summary>
        /// place for 4th api
        /// </summary>
        //[DataMember]
        //public List<MinServiceKuUniDataEntity> _minServiceKuUniDataEntityList;


        [DataMember]
        public List<MinServicePUCDataEntity> _minServicePUCDataEntity;

        [DataMember]
        public List<MinServiceMOHEduDataEntity> _minServiceMOHEduDataEntity;

        [DataMember]
        public List<MinServiceMOEduDataEntity> _minServiceMOEduDataEntity;

        [DataMember]
        public List<MinServiceKSFDDataEntity> _minServiceKSFDDataEntity;

        [DataMember]
        public List<MinServiceKSFDDataByDateEntity> _minServiceKSFDDataByDateEntity;

        [DataMember]
        public List<MinServiceDisabledDataEntity> _minServiceDisabledDataEntity;


        [DataMember]
        public Payload PACI_Single;


        [DataMember]
        public List<MinServiceManpowerDataEntity> _minServiceManpowerDataEntity;


        [DataMember]
        public List<MinServiceKPCDataEntity> _minServiceKPCDataEntity;

        [DataMember]
        public List<MinServiceMOIEntryDataEntity> _minServiceMOIEntryDataEntity;

        [DataMember]
        public List<MinServiceMOISecEntryDataEntity> _minServiceMOISecEntryDataEntity;

    }




}
