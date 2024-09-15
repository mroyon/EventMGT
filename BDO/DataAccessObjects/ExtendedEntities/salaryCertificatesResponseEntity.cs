using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "salaryCertificatesResponseEntity", Namespace = "http://www.KAF.com/types")]
    public partial class salaryCertificatesResponseEntity
    {
        [DataMember]
        public string completereporturl { get; set; }
        [DataMember]
        public long salarycertificaterequestid { get; set; }
        [DataMember]
        public string salarycertificaterequestguid { get; set; }
        [DataMember]
        public string secCode { get; set; }
    }

    [Serializable]
    [DataContract(Name = "salaryCertificatesResponseEntityRoot", Namespace = "http://www.KAF.com/types")]
    public class salaryCertificatesResponseEntityRoot
    {
        [DataMember]
        public salaryCertificatesResponseEntity data { get; set; }
        [DataMember]
        public int recordsTotal { get; set; }
        [DataMember]
        public int recordsFiltered { get; set; }
    }




    [Serializable]
    [DataContract(Name = "EmployeeSalData", Namespace = "http://www.KAF.com/types")]
    public class EmployeeSalData
    {
        [DataMember]
        public List<EmployeeSalaryAllowanceEntity> _EmployeeSalaryAllowanceEntity { get; set; }
        [DataMember]
        public List<EmployeeSalaryDeductionEntity> _EmployeeSalaryDeductionEntity { get; set; }
        [DataMember]
        public string emP_ID { get; set; }
        [DataMember]
        public string emP_NO { get; set; }
        [DataMember]
        public string emP_NAME { get; set; }
        [DataMember]
        public string civiL_ID { get; set; }
        [DataMember]
        public DateTime joiN_DATE { get; set; }
        [DataMember]
        public string joiN_ID { get; set; }
        [DataMember]
        public string joiN_NAME { get; set; }
        [DataMember]
        public string graD_NAME { get; set; }
        [DataMember]
        public string qualificatioN_NAME { get; set; }
        [DataMember]
        public string natioN_NAME { get; set; }
        [DataMember]
        public string positioN_NAME { get; set; }
        [DataMember]
        public string joB_NAME { get; set; }
        [DataMember]
        public string banK_ID { get; set; }
        [DataMember]
        public string banK_NAME { get; set; }
        [DataMember]
        public string banK_ACCT_NO { get; set; }
        [DataMember]
        public string iban { get; set; }
        [DataMember]
        public string emP_STATUS { get; set; }
        [DataMember]
        public int systemRequestFromApp { get; set; }
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
    [DataContract(Name = "EmployeeSalaryAllowanceEntity", Namespace = "http://www.KAF.com/types")]
    public class EmployeeSalaryAllowanceEntity
    {
        [DataMember]
        public string emP_ID { get; set; }
        [DataMember]
        public string alloW_ID { get; set; }
        [DataMember]
        public string alloW_NAME { get; set; }
        [DataMember]
        public double alloW_VALUE { get; set; }
    }

    [Serializable]
    [DataContract(Name = "EmployeeSalaryDeductionEntity", Namespace = "http://www.KAF.com/types")]
    public class EmployeeSalaryDeductionEntity
    {
        [DataMember]
        public string emP_ID { get; set; }
        [DataMember]
        public string deducT_ID { get; set; }
        [DataMember]
        public string deductS_NAME { get; set; }
        [DataMember]
        public double deducT_VALUE { get; set; }
    }

    [Serializable]
    [DataContract(Name = "EmployeeProfileWithSalaryDataReviewOnly_SaheelEntity", Namespace = "http://www.KAF.com/types")]

    public class EmployeeProfileWithSalaryDataReviewOnly_SaheelEntity
    {
        [DataMember]
        public List<EmployeeSalData> data { get; set; }
        [DataMember]
        public int recordsTotal { get; set; }
        [DataMember]
        public int recordsFiltered { get; set; }
    }
  
}
