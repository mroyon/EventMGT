using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "knsCertificatesResponseEntity", Namespace = "http://www.KAF.com/types")]
    public partial class knsCertificatesResponseEntity
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string responsetext { get; set; }

    }

    [Serializable]
    [DataContract(Name = "AjaxresponseKNSEntity", Namespace = "http://www.KAF.com/types")]
    public class AjaxresponseKNSEntity
    {
        [DataMember]
        public int recordsTotal { get; set; }
        [DataMember]
        public int recordsFiltered { get; set; }
        [DataMember]
        public string responsecode { get; set; }
        [DataMember]
        public string responsetext { get; set; }
        [DataMember]
        public string responsestatus { get; set; }
        [DataMember]
        public string responsetitle { get; set; }
        [DataMember]
        public string responseredirecturl { get; set; }
    }
    [Serializable]
    [DataContract(Name = "AjaxresponseKNS", Namespace = "http://www.KAF.com/types")]
    public class AjaxresponseKNS
    {
        [DataMember]
        public AjaxresponseKNSEntity _ajaxresponse { get; set; }
        [DataMember]
        public bool success { get; set; }
    }

    [Serializable]
    [DataContract(Name = "BaseSecurityParamKNSEntity", Namespace = "http://www.KAF.com/types")]
    public class BaseSecurityParamKNSEntity
    {
        [DataMember]
        public int ts { get; set; }
    }
    [Serializable]
    [DataContract(Name = "KnsGenCertificateEntity", Namespace = "http://www.KAF.com/types")]
    public class KnsGenCertificateEntity
    {
        [DataMember]
        public int certificateid { get; set; }
        [DataMember]
        public string certificatename { get; set; }
        [DataMember]
        public int educationlevel { get; set; }
        [DataMember]
        public BaseSecurityParamKNSEntity baseSecurityParam { get; set; }
        [DataMember]
        public int totalRecord { get; set; }
        [DataMember]
        public int pageSize { get; set; }
        [DataMember]
        public int currentPage { get; set; }
        [DataMember]
        public int rowNumber { get; set; }
        [DataMember]
        public int currentState { get; set; }
        [DataMember]
        public int returN_KEY { get; set; }
    }

    [Serializable]
    [DataContract(Name = "KNSRootGetAllCertificateEntity", Namespace = "http://www.KAF.com/types")]
    public class KNSRootGetAllCertificateEntity
    {
        [DataMember]
        public List<KnsGenCertificateEntity> _kns_GenCertificateList { get; set; }
        [DataMember]
        public bool success { get; set; }
    }

    [Serializable]
    [DataContract(Name = "KnsGenCertificateSubjectsEntity", Namespace = "http://www.KAF.com/types")]
    public class KnsGenCertificateSubjectsEntity
    {
        [DataMember]
        public int certificatesubjectid { get; set; }
        [DataMember]
        public int certificateid { get; set; }
        [DataMember]
        public string certificatesubjectname { get; set; }
        [DataMember]
        public BaseSecurityParamKNSEntity baseSecurityParam { get; set; }
        [DataMember]
        public int totalRecord { get; set; }
        [DataMember]
        public int pageSize { get; set; }
        [DataMember]
        public int currentPage { get; set; }
        [DataMember]
        public int rowNumber { get; set; }
        [DataMember]
        public int currentState { get; set; }
        [DataMember]
        public int returN_KEY { get; set; }
    }

    [Serializable]
    [DataContract(Name = "KNSCertificateSubjectsEntity", Namespace = "http://www.KAF.com/types")]
    public class KNSCertificateSubjectsEntity
    {
        [DataMember]
        public List<KnsGenCertificateSubjectsEntity> _kns_GenCertificateSubjectsList { get; set; }
        [DataMember]
        public bool success { get; set; }
    }

}
