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
    [XmlRoot(ElementName = "Table1")]
    public class MINServicePAAETRequestEntity
    {
        [DataMember]
        [XmlElement(ElementName = "CIVL_ID")]
        public string CIVLID { get; set; }

        [DataMember]
        [XmlElement(ElementName = "STUDENT_NAME")]
        public string STUDENTNAME { get; set; }

        [DataMember]
        [XmlElement(ElementName = "INST_NAME")]
        public string INSTNAME { get; set; }

        [DataMember]
        [XmlElement(ElementName = "SMSTR_ID_ADMIT")]
        public string SMSTRIDADMIT { get; set; }

        [DataMember]
        [XmlElement(ElementName = "STATUS_CATEGORY_DESC")]
        public string STATUSCATEGORYDESC { get; set; }

        [DataMember]
        [XmlElement(ElementName = "STATUS_DATE")]
        public DateTime STATUSDATE { get; set; }

        [DataMember]
        [XmlElement(ElementName = "PhoneNo")]
        public string PhoneNo { get; set; }
        
        [DataMember]
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [DataMember]
        [XmlAttribute(AttributeName = "rowOrder")]
        public int RowOrder { get; set; }
        
        [DataMember]
        [XmlAttribute(AttributeName = "hasChanges")]
        public string HasChanges { get; set; }

        [DataMember]
        [XmlText]
        public string Text { get; set; }

        [DataMember]
        [XmlElement(ElementName = "methodName")]
        public string methodName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "BirthDate")]
        public string BirthDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "viewcol")]
        public string viewcol { get; set; }


        [DataMember]
        [XmlElement(ElementName = "CertificateLabel")]
        public string CertificateLabel { get; set; }
    }


    [Serializable]
    [DataContract(Name = "MINServiceDepartedLogInResponse", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "LogInResponse")]
    public class MINServiceDepartedLogInResponse
    {

        [DataMember]
        [XmlElement(ElementName = "LogInResult")]
        public int LogInResult { get; set; }

        [DataMember]
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [DataMember]
        [XmlText]
        public int Text { get; set; }
    }


    [Serializable]
    [DataContract(Name = "MinServiceDepartedEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "GetPersonStatusResult")]
    public class MinServiceDepartedEntity
    {
        [DataMember]
        [XmlElement(ElementName = "CivilNumber")]
        public string CivilNumber { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Sex")]
        public string Sex { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Nationality")]
        public string Nationality { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Status_Code")]
        public string StatusCode { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Status_Date")]
        public string StatusDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Death_Reference_No")]
        public string DeathReferenceNo { get; set; }

        [DataMember]
        [XmlElement(ElementName = "FirstName_Eng")]
        public string FirstNameEng { get; set; }

        [DataMember]
        [XmlElement(ElementName = "SecondName_Eng")]
        public string SecondNameEng { get; set; }

        [DataMember]
        [XmlElement(ElementName = "ThirdName_Eng")]
        public string ThirdNameEng { get; set; }

        [DataMember]
        [XmlElement(ElementName = "ForthName_Eng")]
        public string ForthNameEng { get; set; }

        [DataMember]
        [XmlElement(ElementName = "FirstName_Ar")]
        public string FirstNameAr { get; set; }

        [DataMember]
        [XmlElement(ElementName = "SecondName_Ar")]
        public string SecondNameAr { get; set; }

        [DataMember]
        [XmlElement(ElementName = "ThirdName_Ar")]
        public string ThirdNameAr { get; set; }

        [DataMember]
        [XmlElement(ElementName = "FourthName_Ar")]
        public string FourthNameAr { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Birth_Date")]
        public string Birth_Date { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WvEnquiryTime")]
        public DateTime WvEnquiryTime { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WvMsg")]
        public string WvMsg { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WvResponseTime")]
        public string WvResponseTime { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WvInfo")]
        public string WvInfo { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WvHitsRemaining")]
        public string WvHitsRemaining { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WvVerNo")]
        public string WvVerNo { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WVPermissionStatus")]
        public string WVPermissionStatus { get; set; }

        [DataMember]
        [XmlElement(ElementName = "methodName")]
        public string methodName { get; set; }
    }


    [Serializable]
    [DataContract(Name = "GetDepartedByBirthDateResultEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "GetDepartedByBirthDateResult")]
    public class GetDepartedByBirthDateResultEntity
    {

        [DataMember]
        [XmlElement(ElementName = "CivilNumber")]
        public List<string> CivilNumber { get; set; }


        [DataMember]
        [XmlElement(ElementName = "Sex")]
        public List<string> Sex { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Nationality")]
        public List<string> Nationality { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Status_Code")]
        public List<string> StatusCode { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Status_Date")]
        public List<string> StatusDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Death_Reference_No")]
        public List<string> DeathReferenceNo { get; set; }

        [DataMember]
        [XmlElement(ElementName = "FirstName_Eng")]
        public List<string> FirstNameEng { get; set; }

        [DataMember]
        [XmlElement(ElementName = "SecondName_Eng")]
        public List<string> SecondNameEng { get; set; }

        [DataMember]
        [XmlElement(ElementName = "ThirdName_Eng")]
        public List<string> ThirdNameEng { get; set; }

        [DataMember]
        [XmlElement(ElementName = "ForthName_Eng")]
        public List<string> ForthNameEng { get; set; }

        [DataMember]
        [XmlElement(ElementName = "FirstName_Ar")]
        public List<string> FirstNameAr { get; set; }

        [DataMember]
        [XmlElement(ElementName = "SecondName_Ar")]
        public List<string> SecondNameAr { get; set; }

        [DataMember]
        [XmlElement(ElementName = "ThirdName_Ar")]
        public List<string> ThirdNameAr { get; set; }

        [DataMember]
        [XmlElement(ElementName = "FourthName_Ar")]
        public List<string> FourthNameAr { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Birth_Date")]
        public List<string> BirthDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WvEnquiryTime")]
        public string WvEnquiryTime { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WvMsg")]
        public string WvMsg { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WvResponseTime")]
        public string WvResponseTime { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WvInfo")]
        public string WvInfo { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WvHitsRemaining")]
        public string WvHitsRemaining { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WvVerNo")]
        public string WvVerNo { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WVPermissionStatus")]
        public string WVPermissionStatus { get; set; }
    }


    [Serializable]
    [DataContract(Name = "MinServiceCivilServiceComEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "return")]
    public class MinServiceCivilServiceComEntity
    {
        [DataMember]
        [XmlElement(ElementName = "msg")]
        public string Msg { get; set; }

        [DataMember]
        [XmlElement(ElementName = "successeded")]
        public string Successeded { get; set; }

        [DataMember]
        [XmlElement(ElementName = "HEDate")]
        public string HEDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "category")]
        public string Category { get; set; }

        [DataMember]
        [XmlElement(ElementName = "categoryCode")]
        public string CategoryCode { get; set; }

        [DataMember]
        [XmlElement(ElementName = "civilId")]
        public string CivilId { get; set; }

        [DataMember]
        [XmlElement(ElementName = "empName")]
        public string EmpName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "finishReson")]
        public string FinishReson { get; set; }

        [DataMember]
        [XmlElement(ElementName = "firstHDate")]
        public string FirstHDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "groupName")]
        public string GroupName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "job")]
        public string Job { get; set; }

        [DataMember]
        [XmlElement(ElementName = "jobCode")]
        public string JobCode { get; set; }

        [DataMember]
        [XmlElement(ElementName = "min")]
        public string Min { get; set; }

        [DataMember]
        [XmlElement(ElementName = "minCode")]
        public string MinCode { get; set; }

    }



    [Serializable]
    [DataContract(Name = "MinServiceKuUniDataEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "return")]
    public class MinServiceKuUniDataEntity
    {
        [DataMember]
        [XmlElement(ElementName = "civilId")]
        public string CivilId { get; set; }

        [DataMember]
        [XmlElement(ElementName = "college")]
        public string College { get; set; }

        [DataMember]
        [XmlElement(ElementName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        [XmlElement(ElementName = "graduationDate")]
        public string GraduationDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [DataMember]
        [XmlElement(ElementName = "studentId")]
        public string StudentId { get; set; }

        [DataMember]
        [XmlElement(ElementName = "textualStatus")]
        public string TextualStatus { get; set; }
    }


    [Serializable]
    [DataContract(Name = "MinServiceMOEDataEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "students")]
    public class MinServiceMOEDataEntity
    {
        [DataMember]
        [XmlElement(ElementName = "birthDate")]
        public string BirthDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "cid")]
        public string Cid { get; set; }

        [DataMember]
        [XmlElement(ElementName = "studentName")]
        public string StudentName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "studentgrade")]
        public string Studentgrade { get; set; }

        [DataMember]
        [XmlElement(ElementName = "studentlevel")]
        public string Studentlevel { get; set; }

        [DataMember]
        [XmlElement(ElementName = "studentschool")]
        public string Studentschool { get; set; }

        [DataMember]
        [XmlElement(ElementName = "studentstatus")]
        public string Studentstatus { get; set; }

        [DataMember]
        [XmlElement(ElementName = "year")]
        public string Year { get; set; }
    }



    [Serializable]
    [DataContract(Name = "MinServicePUCDataEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "GetStudentInfoResult")]
    public class MinServicePUCDataEntity
    {
        [DataMember]
        public int RowNumber { get; set; }

        [DataMember]
        public string civilid { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string studentcase { get; set; }

        [DataMember]
        public string college { get; set; }

        [DataMember]
        public string firstsemister { get; set; }

        [DataMember]
        public string certificate { get; set; }

        [DataMember]
        public string secondsemister { get; set; }

        [DataMember]
        public string universityname { get; set; }

        [DataMember]
        public string speciality { get; set; }

        [DataMember]
        public string bdate { get; set; }

        [DataMember]
        public string status { get; set; }
    }


    [Serializable]
    [DataContract(Name = "MinServiceMOHEduDataEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "Request")]
    public class MinServiceMOHEduDataEntity
    {
        [DataMember]
        [XmlElement(ElementName = "student_cid")]
        public string StudentCid { get; set; }

        //[DataMember]
        //[XmlElement(ElementName = "Student_CID")]
        //public string Student_Cid { get; set; }


        [DataMember]
        [XmlElement(ElementName = "name1")]
        public string Name1 { get; set; }

        [DataMember]
        [XmlElement(ElementName = "country1")]
        public string Country1 { get; set; }

        [DataMember]
        [XmlElement(ElementName = "day1")]
        public int Day1 { get; set; }

        [DataMember]
        [XmlElement(ElementName = "month1")]
        public int Month1 { get; set; }

        [DataMember]
        [XmlElement(ElementName = "year1")]
        public int Year1 { get; set; }

        [DataMember]
        [XmlElement(ElementName = "comments")]
        public string Comments { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Column1")]
        public string Column1 { get; set; }
    }

    [Serializable]
    [DataContract(Name = "MinServiceMOEduDataEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "Request")]
    public class MinServiceMOEduDataEntity
    {
        [DataMember]
        [XmlElement(ElementName = "strbirthDate")]
        public string strbirthDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "birthDate")]
        public DateTime birthDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "cid")]
        public string cid { get; set; }

        [DataMember]
        [XmlElement(ElementName = "studentName")]
        public string studentName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Rownumber")]
        public string Rownumber { get; set; }

        [DataMember]
        [XmlElement(ElementName = "year")]
        public string year { get; set; }

        [DataMember]
        [XmlElement(ElementName = "studentgrade")]
        public string studentgrade { get; set; }

        [DataMember]
        [XmlElement(ElementName = "studentlevel")]
        public string studentlevel { get; set; }

        [DataMember]
        [XmlElement(ElementName = "studentschool")]
        public string studentschool { get; set; }

        [DataMember]
        [XmlElement(ElementName = "studentstatus")]
        public string studentstatus { get; set; }

    }


    [Serializable]
    [DataContract(Name = "MinServiceKSFDDataEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "result")]
    public class MinServiceKSFDDataEntity
    {
        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string pempbirthOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string pempenddateOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string prespflagOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string pdegdescOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string pemporgdateOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string pempterminateflagOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string pempcivilOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string phirestatusdescOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string prespnoteOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string phirereasondescOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string pempdegdateOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string pempnameOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string pemporgnameOut { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string pemphirestatusdateOut { get; set; }
    }

    [Serializable]
    [DataContract(Name = "MinServiceKSFDDataByDateEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "ROW")]
    public class MinServiceKSFDDataByDateEntity
    {
        [DataMember]
        [XmlElement(ElementName = "EMP_NAME")]
        public string emp_name { get; set; }

        [DataMember]
        [XmlElement(ElementName = "EMP_CIVIL_ID")]
        public string emp_civil_id { get; set; }

        [DataMember]
        [XmlElement(ElementName = "EMP_BIRTHDATE")]
        public string emp_birthdate { get; set; }
        [DataMember]
        [XmlElement(ElementName = "EMP_ORG_NAME")]
        public string emp_org_name { get; set; }
        [DataMember]
        [XmlElement(ElementName = "EMP_ORG_DATE")]
        public string emp_org_date { get; set; }
        [DataMember]
        [XmlElement(ElementName = "DEG_DESC")]
        public string deg_desc { get; set; }
        [DataMember]
        [XmlElement(ElementName = "EMP_DEG_DATE")]
        public string emp_deg_date { get; set; }
        [DataMember]
        [XmlElement(ElementName = "EMP_TERMINATE_FLAG")]
        public string emp_terminate_flag { get; set; }
        [DataMember]
        [XmlElement(ElementName = "EMP_HIRE_STATUS_DATE")]
        public string emp_hire_status_date { get; set; }
        [DataMember]
        [XmlElement(ElementName = "HIRE_STATUS_DESC")]
        public string hire_status_desc { get; set; }
        [DataMember]
        [XmlAttribute(AttributeName = "num")]
        public string num { get; set; }
    }


    [Serializable]
    [DataContract(Name = "MinServiceDisabledDataEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "GetDisabledInfoResult")]
    public class MinServiceDisabledDataEntity
    {
        [DataMember]
        [XmlElement(ElementName = "CivilNumber")]
        public string CivilNumber { get; set; }

        [DataMember]
        [XmlElement(ElementName = "DisabledName")]
        public string DisabledName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Sex")]
        public string Sex { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Nationality")]
        public string Nationality { get; set; }

        [DataMember]
        [XmlElement(ElementName = "BirthDate")]
        public string BirthDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "DisabilityType")]
        public string DisabilityType { get; set; }

        [DataMember]
        [XmlElement(ElementName = "DisabilitySeverity")]
        public string DisabilitySeverity { get; set; }

        [DataMember]
        [XmlElement(ElementName = "FileStatus")]
        public string FileStatus { get; set; }

        [DataMember]
        [XmlElement(ElementName = "DisabilityDate")]
        public string DisabilityDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "DisabilityValidity")]
        public string DisabilityValidity { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Mobile")]
        public string Mobile { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Telephone")]
        public string Telephone { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WSMessage")]
        public string WSMessage { get; set; }

        [DataMember]
        [XmlElement(ElementName = "WSHits")]
        public string WSHits { get; set; }

        [DataMember]
        [XmlElement(ElementName = "string")]
        public string resdate { get; set; }
    }


    [Serializable]
    [DataContract(Name = "MinServiceManpowerDataEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "GetLabourSupportDetailsResult")]
    public class MinServiceManpowerDataEntity
    {
        [DataMember]
        [XmlElement(ElementName = "CIVIL_ID")]
        public string CIVILID { get; set; }

        [DataMember]
        [XmlElement(ElementName = "LABOUR_SUPPORT_STATUS_ID")]
        public string LABOURSUPPORTSTATUSID { get; set; }

        [DataMember]
        [XmlElement(ElementName = "LABOUR_SUPPORT_STATUS_DESC")]
        public string LABOURSUPPORTSTATUSDESC { get; set; }

        [DataMember]
        [XmlElement(ElementName = "RESPONSE_STATUS")]
        public string RESPONSESTATUS { get; set; }

        [DataMember]
        [XmlElement(ElementName = "RESPONSE_DESC")]
        public string RESPONSEDESC { get; set; }
    }

    [Serializable]
    [DataContract(Name = "MinServiceKPCDataEntity", Namespace = "http://www.KAF.com/types")]
    public class MinServiceKPCDataEntity
    {
        [DataMember]
        public string personID { get; set; }
        [DataMember]
        public string displayName { get; set; }
        [DataMember]
        public string nationalId { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string dateOfBirth { get; set; }
        [DataMember]
        public string leaveType { get; set; }
        [DataMember]
        public string leaveDuration { get; set; }
    }


    [Serializable]
    [DataContract(Name = "MinServiceMOIEntryDataEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "InquireNationalityDataResponse")]
    public class MinServiceMOIEntryDataEntity
    {
        [DataMember]
        [XmlElement(ElementName = "civilId")]
        public string CivilId { get; set; }

        [DataMember]
        [XmlElement(ElementName = "nationalNumber")]
        public string NationalNumber { get; set; }

        [DataMember]
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [DataMember]
        [XmlElement(ElementName = "ownerShip")]
        public string OwnerShip { get; set; }

        [DataMember]
        [XmlElement(ElementName = "firstName")]
        public string FirstName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "secondName")]
        public string SecondName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "thirdName")]
        public string ThirdName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "forthName")]
        public string ForthName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "familyName")]
        public string FamilyName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "sex")]
        public string Sex { get; set; }

        [DataMember]
        [XmlElement(ElementName = "birthDate")]
        public string BirthDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [DataMember]
        [XmlElement(ElementName = "fileType")]
        public string FileType { get; set; }

        [DataMember]
        [XmlElement(ElementName = "nationalityType")]
        public string NationalityType { get; set; }

        [DataMember]
        [XmlElement(ElementName = "kuwaitIssueDate")]
        public string KuwaitIssueDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "article")]
        public string Article { get; set; }

        [DataMember]
        [XmlElement(ElementName = "clause")]
        public string Clause { get; set; }

        [DataMember]
        [XmlElement(ElementName = "issueCriteria")]
        public string IssueCriteria { get; set; }

        [DataMember]
        [XmlElement(ElementName = "issueDate")]
        public string IssueDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [DataMember]
        [XmlElement(ElementName = "returnCode")]
        public string ReturnCode { get; set; }

        [DataMember]
        [XmlElement(ElementName = "returnMessage")]
        public string ReturnMessage { get; set; }      
    }

    [Serializable]
    [DataContract(Name = "MinServiceMOISecEntryDataEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "InquireNationalMilitaryServiceDataResponse")]
    public class MinServiceMOISecEntryDataEntity
    {
        [DataMember]
        [XmlElement(ElementName = "statusCode")]
        public string statusCode { get; set; }

        [DataMember]
        [XmlElement(ElementName = "statusMessage")]
        public string statusMessage { get; set; }

        [DataMember]
        [XmlElement(ElementName = "civilId")]
        public string civilId { get; set; }

        [DataMember]
        [XmlElement(ElementName = "personName")]
        public string personName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "employmentYears")]
        public string employmentYears { get; set; }

        [DataMember]
        [XmlElement(ElementName = "employmentMonths")]
        public string employmentMonths { get; set; }

        [DataMember]
        [XmlElement(ElementName = "employmentDays")]
        public string employmentDays { get; set; }

    }


    [Serializable]
    [DataContract(Name = "MinServiceMOISecByDateEntity", Namespace = "http://www.KAF.com/types")]
    [XmlRoot(ElementName = "MoiPersonDetails")]
    public class MinServiceMOISecByDateEntity
    {
        [DataMember]
        [XmlElement(ElementName = "CivilIdNumber")]
        public string CivilIdNumber { get; set; }

        [DataMember]
        [XmlElement(ElementName = "PersonName")]
        public string PersonName { get; set; }

        [DataMember]
        [XmlElement(ElementName = "BirthDate")]
        public string BirthDate { get; set; }

        [DataMember]
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
    }




    [Serializable]
    [DataContract(Name = "MinServicePIFSSDataEntity", Namespace = "http://www.KAF.com/types")]
    public class MinServicePIFSSDataEntity
    {
        public MODL[] MODL { get; set; }
        public string oError { get; set; }
    }


    [Serializable]
    [DataContract(Name = "MinServicePIFSSDataTwoEntity", Namespace = "http://www.KAF.com/types")]
    public class MinServicePIFSSDataTwoEntity
    {
        [DataMember]
        public string EMPLOYER { get; set; }
        [DataMember]
        public string NAME { get; set; }
        [DataMember]
        public string DATE_OF_BIRTH { get; set; }
        [DataMember]
        public string CID { get; set; }
        [DataMember]
        public string Error { get; set; }
    }

    public class MODL
    {
        [DataMember]
        public string EMPLOYER { get; set; }
        [DataMember]
        public string NAME { get; set; }
        [DataMember]
        public string DATE_OF_BIRTH { get; set; }
        [DataMember]
        public string CID { get; set; }

      
    }


}
