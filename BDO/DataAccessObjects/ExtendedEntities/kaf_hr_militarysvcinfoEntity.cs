using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "kaf_hr_militarysvcinfoEntity", Namespace = "http://www.KAF.com/types")]
    public partial class kaf_hr_militarysvcinfoEntity : BaseEntity
    {
        #region Properties
    
        protected long ? _hrbasicid;
        protected long ? _militaryno;
        protected long ? _civilid;
        protected string _fullname;
        protected string _fullnameeng;
        protected long ? _currententitykey;
        protected string _currententitycode;
        protected string _currentfullunitpath;
        protected long ? _entitykey;
        protected long ? _originalentitykey;
        protected string _originalfullunitpath;
        protected DateTime ? _birthdate;
        protected string _age;
        protected DateTime ? _joindate;
        protected string _servicelength;
        protected string _rankname;
        protected string _nationality;
        protected string _servicestatusname;
        protected DateTime ? _lastpromotiondate;
        protected string _certificatelevel;
        protected string _certificatename;
        protected string _certificategradename;
        protected string _educationcountry;
        protected string _coursename;
        protected long ? _acryear;
        protected string _acrgrade;
        protected int? _isinservice;
        protected int? _iskuwaiti;


        [DataMember]
        public int? isinservice
        {
            get { return _isinservice; }
            set { _isinservice = value; this.OnChnaged(); }
        }
        [DataMember]
        public int? iskuwaiti
        {
            get { return _iskuwaiti; }
            set { _iskuwaiti = value; this.OnChnaged(); }
        }


        [DataMember]
        public long ? hrbasicid
        {
            get { return _hrbasicid; }
            set { _hrbasicid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[Display(Name = "militaryno", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        //[Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo), ErrorMessageResourceName = "militarynoRequired")]
        public long ? militaryno
        {
            get { return _militaryno; }
            set { _militaryno = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[Display(Name = "civilid", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public long ? civilid
        {
            get { return _civilid; }
            set { _civilid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(550)]
        //[Display(Name = "fullname", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        //[Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo), ErrorMessageResourceName = "fullnameRequired")]
        public string fullname
        {
            get { return _fullname; }
            set { _fullname = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        //[Display(Name = "fullnameeng", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string fullnameeng
        {
            get { return _fullnameeng; }
            set { _fullnameeng = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[Display(Name = "currententitykey", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public long ? currententitykey
        {
            get { return _currententitykey; }
            set { _currententitykey = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        //[Display(Name = "currententitycode", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string currententitycode
        {
            get { return _currententitycode; }
            set { _currententitycode = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[MaxLength(-1)]
        //[Display(Name = "currentfullunitpath", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string currentfullunitpath
        {
            get { return _currentfullunitpath; }
            set { _currentfullunitpath = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[Display(Name = "entitykey", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        //[Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo), ErrorMessageResourceName = "entitykeyRequired")]
        public long ? entitykey
        {
            get { return _entitykey; }
            set { _entitykey = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[Display(Name = "originalentitykey", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public long ? originalentitykey
        {
            get { return _originalentitykey; }
            set { _originalentitykey = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[MaxLength(-1)]
        //[Display(Name = "originalfullunitpath", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string originalfullunitpath
        {
            get { return _originalfullunitpath; }
            set { _originalfullunitpath = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[Display(Name = "birthdate", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public DateTime ? birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[MaxLength(-1)]
        //[Display(Name = "age", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string age
        {
            get { return _age; }
            set { _age = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[Display(Name = "joindate", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        //[Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo), ErrorMessageResourceName = "joindateRequired")]
        public DateTime ? joindate
        {
            get { return _joindate; }
            set { _joindate = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[MaxLength(-1)]
        //[Display(Name = "servicelength", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string servicelength
        {
            get { return _servicelength; }
            set { _servicelength = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(203)]
        //[Display(Name = "rankname", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        //[Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo), ErrorMessageResourceName = "ranknameRequired")]
        public string rankname
        {
            get { return _rankname; }
            set { _rankname = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(50)]
        //[Display(Name = "nationality", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string nationality
        {
            get { return _nationality; }
            set { _nationality = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(50)]
        //[Display(Name = "servicestatusname", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string servicestatusname
        {
            get { return _servicestatusname; }
            set { _servicestatusname = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[Display(Name = "lastpromotiondate", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public DateTime ? lastpromotiondate
        {
            get { return _lastpromotiondate; }
            set { _lastpromotiondate = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(100)]
        //[Display(Name = "certificatelevel", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string certificatelevel
        {
            get { return _certificatelevel; }
            set { _certificatelevel = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(100)]
        //[Display(Name = "certificatename", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string certificatename
        {
            get { return _certificatename; }
            set { _certificatename = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(50)]
        //[Display(Name = "certificategradename", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string certificategradename
        {
            get { return _certificategradename; }
            set { _certificategradename = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(50)]
        //[Display(Name = "educationcountry", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string educationcountry
        {
            get { return _educationcountry; }
            set { _educationcountry = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(100)]
        //[Display(Name = "coursename", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string coursename
        {
            get { return _coursename; }
            set { _coursename = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[Display(Name = "acryear", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public long ? acryear
        {
            get { return _acryear; }
            set { _acryear = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(100)]
        //[Display(Name = "acrgrade", ResourceType = typeof(CLL.LLClasses.Models._kaf_hr_militarysvcinfo))]
        public string acrgrade
        {
            get { return _acrgrade; }
            set { _acrgrade = value; this.OnChnaged(); }
        }
        
        
        #endregion
    
        #region Constructor
    
        public kaf_hr_militarysvcinfoEntity():base()
        {
        }
        
        public kaf_hr_militarysvcinfoEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }
        
         public kaf_hr_militarysvcinfoEntity(IDataReader reader, bool IsListViewShow)
        {
            this.LoadFromReader(reader, IsListViewShow);
        }
        
      
        
        protected void LoadFromReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("HRBasicID"))) _hrbasicid = reader.GetInt64(reader.GetOrdinal("HRBasicID"));
                if (!reader.IsDBNull(reader.GetOrdinal("MilitaryNo"))) _militaryno = reader.GetInt64(reader.GetOrdinal("MilitaryNo"));
                if (!reader.IsDBNull(reader.GetOrdinal("CivilID"))) _civilid = reader.GetInt64(reader.GetOrdinal("CivilID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FullName"))) _fullname = reader.GetString(reader.GetOrdinal("FullName"));
                if (!reader.IsDBNull(reader.GetOrdinal("FullNameEng"))) _fullnameeng = reader.GetString(reader.GetOrdinal("FullNameEng"));
                if (!reader.IsDBNull(reader.GetOrdinal("CurrentEntityKey"))) _currententitykey = reader.GetInt64(reader.GetOrdinal("CurrentEntityKey"));
                if (!reader.IsDBNull(reader.GetOrdinal("CurrentEntityCode"))) _currententitycode = reader.GetString(reader.GetOrdinal("CurrentEntityCode"));
                if (!reader.IsDBNull(reader.GetOrdinal("CurrentFullUnitPath"))) _currentfullunitpath = reader.GetString(reader.GetOrdinal("CurrentFullUnitPath"));
                if (!reader.IsDBNull(reader.GetOrdinal("EntityKey"))) _entitykey = reader.GetInt64(reader.GetOrdinal("EntityKey"));
                if (!reader.IsDBNull(reader.GetOrdinal("OriginalEntityKey"))) _originalentitykey = reader.GetInt64(reader.GetOrdinal("OriginalEntityKey"));
                if (!reader.IsDBNull(reader.GetOrdinal("OriginalFullUnitPath"))) _originalfullunitpath = reader.GetString(reader.GetOrdinal("OriginalFullUnitPath"));
                if (!reader.IsDBNull(reader.GetOrdinal("BirthDate"))) _birthdate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("Age"))) _age = reader.GetString(reader.GetOrdinal("Age"));
                if (!reader.IsDBNull(reader.GetOrdinal("JoinDate"))) _joindate = reader.GetDateTime(reader.GetOrdinal("JoinDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("ServiceLength"))) _servicelength = reader.GetString(reader.GetOrdinal("ServiceLength"));
                if (!reader.IsDBNull(reader.GetOrdinal("RankName"))) _rankname = reader.GetString(reader.GetOrdinal("RankName"));
                if (!reader.IsDBNull(reader.GetOrdinal("Nationality"))) _nationality = reader.GetString(reader.GetOrdinal("Nationality"));
                if (!reader.IsDBNull(reader.GetOrdinal("ServiceStatusName"))) _servicestatusname = reader.GetString(reader.GetOrdinal("ServiceStatusName"));
                if (!reader.IsDBNull(reader.GetOrdinal("LastPromotionDate"))) _lastpromotiondate = reader.GetDateTime(reader.GetOrdinal("LastPromotionDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("CertificateLevel"))) _certificatelevel = reader.GetString(reader.GetOrdinal("CertificateLevel"));
                if (!reader.IsDBNull(reader.GetOrdinal("CertificateName"))) _certificatename = reader.GetString(reader.GetOrdinal("CertificateName"));
                if (!reader.IsDBNull(reader.GetOrdinal("CertificateGradeName"))) _certificategradename = reader.GetString(reader.GetOrdinal("CertificateGradeName"));
                if (!reader.IsDBNull(reader.GetOrdinal("EducationCountry"))) _educationcountry = reader.GetString(reader.GetOrdinal("EducationCountry"));
                if (!reader.IsDBNull(reader.GetOrdinal("CourseName"))) _coursename = reader.GetString(reader.GetOrdinal("CourseName"));
                if (!reader.IsDBNull(reader.GetOrdinal("AcrYear"))) _acryear = reader.GetInt64(reader.GetOrdinal("AcrYear"));
                if (!reader.IsDBNull(reader.GetOrdinal("ACRGrade"))) _acrgrade = reader.GetString(reader.GetOrdinal("ACRGrade"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsInService"))) _isinservice = reader.GetInt32(reader.GetOrdinal("IsInService"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsKuwaiti"))) _iskuwaiti = reader.GetInt32(reader.GetOrdinal("IsKuwaiti"));
                CurrentState = EntityState.Unchanged;
            }
        }


        protected void LoadFromReader(IDataReader reader, bool IsListViewShow)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("HRBasicID"))) _hrbasicid = reader.GetInt64(reader.GetOrdinal("HRBasicID"));
                if (!reader.IsDBNull(reader.GetOrdinal("MilitaryNo"))) _militaryno = reader.GetInt64(reader.GetOrdinal("MilitaryNo"));
                if (!reader.IsDBNull(reader.GetOrdinal("CivilID"))) _civilid = reader.GetInt64(reader.GetOrdinal("CivilID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FullName"))) _fullname = reader.GetString(reader.GetOrdinal("FullName"));
                if (!reader.IsDBNull(reader.GetOrdinal("FullNameEng"))) _fullnameeng = reader.GetString(reader.GetOrdinal("FullNameEng"));
                if (!reader.IsDBNull(reader.GetOrdinal("CurrentEntityKey"))) _currententitykey = reader.GetInt64(reader.GetOrdinal("CurrentEntityKey"));
                if (!reader.IsDBNull(reader.GetOrdinal("CurrentEntityCode"))) _currententitycode = reader.GetString(reader.GetOrdinal("CurrentEntityCode"));
                if (!reader.IsDBNull(reader.GetOrdinal("CurrentFullUnitPath"))) _currentfullunitpath = reader.GetString(reader.GetOrdinal("CurrentFullUnitPath"));
                if (!reader.IsDBNull(reader.GetOrdinal("EntityKey"))) _entitykey = reader.GetInt64(reader.GetOrdinal("EntityKey"));
                if (!reader.IsDBNull(reader.GetOrdinal("OriginalEntityKey"))) _originalentitykey = reader.GetInt64(reader.GetOrdinal("OriginalEntityKey"));
                if (!reader.IsDBNull(reader.GetOrdinal("OriginalFullUnitPath"))) _originalfullunitpath = reader.GetString(reader.GetOrdinal("OriginalFullUnitPath"));
                if (!reader.IsDBNull(reader.GetOrdinal("BirthDate"))) _birthdate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("Age"))) _age = reader.GetString(reader.GetOrdinal("Age"));
                if (!reader.IsDBNull(reader.GetOrdinal("JoinDate"))) _joindate = reader.GetDateTime(reader.GetOrdinal("JoinDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("ServiceLength"))) _servicelength = reader.GetString(reader.GetOrdinal("ServiceLength"));
                if (!reader.IsDBNull(reader.GetOrdinal("RankName"))) _rankname = reader.GetString(reader.GetOrdinal("RankName"));
                if (!reader.IsDBNull(reader.GetOrdinal("Nationality"))) _nationality = reader.GetString(reader.GetOrdinal("Nationality"));
                if (!reader.IsDBNull(reader.GetOrdinal("ServiceStatusName"))) _servicestatusname = reader.GetString(reader.GetOrdinal("ServiceStatusName"));
                if (!reader.IsDBNull(reader.GetOrdinal("LastPromotionDate"))) _lastpromotiondate = reader.GetDateTime(reader.GetOrdinal("LastPromotionDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("CertificateLevel"))) _certificatelevel = reader.GetString(reader.GetOrdinal("CertificateLevel"));
                if (!reader.IsDBNull(reader.GetOrdinal("CertificateName"))) _certificatename = reader.GetString(reader.GetOrdinal("CertificateName"));
                if (!reader.IsDBNull(reader.GetOrdinal("CertificateGradeName"))) _certificategradename = reader.GetString(reader.GetOrdinal("CertificateGradeName"));
                if (!reader.IsDBNull(reader.GetOrdinal("EducationCountry"))) _educationcountry = reader.GetString(reader.GetOrdinal("EducationCountry"));
                if (!reader.IsDBNull(reader.GetOrdinal("CourseName"))) _coursename = reader.GetString(reader.GetOrdinal("CourseName"));
                if (!reader.IsDBNull(reader.GetOrdinal("AcrYear"))) _acryear = reader.GetInt64(reader.GetOrdinal("AcrYear"));
                if (!reader.IsDBNull(reader.GetOrdinal("ACRGrade"))) _acrgrade = reader.GetString(reader.GetOrdinal("ACRGrade"));
                CurrentState = EntityState.Unchanged;
            }
        }
        
        #endregion
        
        
            
    }
}
