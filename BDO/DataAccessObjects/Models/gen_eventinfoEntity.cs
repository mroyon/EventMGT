using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "gen_eventinfoEntity", Namespace = "http://www.KAF.com/types")]
    public partial class gen_eventinfoEntity : BaseEntity
    {
        #region Properties
    
        protected long ? _eventid;
        protected long ? _eventcategoryid;
        protected string _eventcode;
        protected string _eventname;
        protected DateTime ? _eventstartdate;
        protected DateTime ? _eventenddate;
        protected string _eventdescription;
        protected string _eventdescription1;
        protected string _eventdescription2;
        protected string _eventspecialnote;
        protected bool ? _isdeleted;
        protected long ? _eventorganizedby;
        protected DateTime ? _ex_date1;
        protected DateTime ? _ex_date2;
        protected string _ex_nvarchar1;
        protected string _ex_nvarchar2;
        protected string _ex_nvarchar3;
        protected long ? _ex_bigint1;
        protected long ? _ex_bigint2;
        protected decimal ? _ex_decimal1;
        protected decimal ? _ex_decimal2;
                
        
        [DataMember]
        public long ? eventid
        {
            get { return _eventid; }
            set { _eventid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "eventcategoryid", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo), ErrorMessageResourceName = "eventcategoryidRequired")]
        public long ? eventcategoryid
        {
            get { return _eventcategoryid; }
            set { _eventcategoryid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(50)]
        [Display(Name = "eventcode", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo), ErrorMessageResourceName = "eventcodeRequired")]
        public string eventcode
        {
            get { return _eventcode; }
            set { _eventcode = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(500)]
        [Display(Name = "eventname", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo), ErrorMessageResourceName = "eventnameRequired")]
        public string eventname
        {
            get { return _eventname; }
            set { _eventname = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "eventstartdate", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo), ErrorMessageResourceName = "eventstartdateRequired")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ? eventstartdate
        {
            get { return _eventstartdate; }
            set { _eventstartdate = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "eventenddate", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ? eventenddate
        {
            get { return _eventenddate; }
            set { _eventenddate = value; this.OnChnaged(); }
        }
        
        [DataMember]
        
        [Display(Name = "eventdescription", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public string eventdescription
        {
            get { return _eventdescription; }
            set { _eventdescription = value; this.OnChnaged(); }
        }
        
        [DataMember]
        
        [Display(Name = "eventdescription1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public string eventdescription1
        {
            get { return _eventdescription1; }
            set { _eventdescription1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        
        [Display(Name = "eventdescription2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public string eventdescription2
        {
            get { return _eventdescription2; }
            set { _eventdescription2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        
        [Display(Name = "eventspecialnote", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public string eventspecialnote
        {
            get { return _eventspecialnote; }
            set { _eventspecialnote = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "isdeleted", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public bool ? isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "eventorganizedby", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo), ErrorMessageResourceName = "eventorganizedbyRequired")]
        public long ? eventorganizedby
        {
            get { return _eventorganizedby; }
            set { _eventorganizedby = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_date1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public DateTime ? ex_date1
        {
            get { return _ex_date1; }
            set { _ex_date1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_date2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public DateTime ? ex_date2
        {
            get { return _ex_date2; }
            set { _ex_date2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "ex_nvarchar1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public string ex_nvarchar1
        {
            get { return _ex_nvarchar1; }
            set { _ex_nvarchar1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "ex_nvarchar2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public string ex_nvarchar2
        {
            get { return _ex_nvarchar2; }
            set { _ex_nvarchar2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "ex_nvarchar3", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public string ex_nvarchar3
        {
            get { return _ex_nvarchar3; }
            set { _ex_nvarchar3 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_bigint1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public long ? ex_bigint1
        {
            get { return _ex_bigint1; }
            set { _ex_bigint1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_bigint2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public long ? ex_bigint2
        {
            get { return _ex_bigint2; }
            set { _ex_bigint2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_decimal1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public decimal ? ex_decimal1
        {
            get { return _ex_decimal1; }
            set { _ex_decimal1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_decimal2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventinfo))]
        public decimal ? ex_decimal2
        {
            get { return _ex_decimal2; }
            set { _ex_decimal2 = value; this.OnChnaged(); }
        }
        
        
        #endregion
    
        #region Constructor
    
        public gen_eventinfoEntity():base()
        {
        }
        
        public gen_eventinfoEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }
        
         public gen_eventinfoEntity(IDataReader reader, bool IsListViewShow)
        {
            this.LoadFromReader(reader, IsListViewShow);
        }
        
      
        
        protected void LoadFromReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("EventID"))) _eventid = reader.GetInt64(reader.GetOrdinal("EventID"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventCategoryID"))) _eventcategoryid = reader.GetInt64(reader.GetOrdinal("EventCategoryID"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventCode"))) _eventcode = reader.GetString(reader.GetOrdinal("EventCode"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventName"))) _eventname = reader.GetString(reader.GetOrdinal("EventName"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventStartDate"))) _eventstartdate = reader.GetDateTime(reader.GetOrdinal("EventStartDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventEndDate"))) _eventenddate = reader.GetDateTime(reader.GetOrdinal("EventEndDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventDescription"))) _eventdescription = reader.GetString(reader.GetOrdinal("EventDescription"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventDescription1"))) _eventdescription1 = reader.GetString(reader.GetOrdinal("EventDescription1"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventDescription2"))) _eventdescription2 = reader.GetString(reader.GetOrdinal("EventDescription2"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventSpecialNote"))) _eventspecialnote = reader.GetString(reader.GetOrdinal("EventSpecialNote"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsDeleted"))) _isdeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventOrganizedBy"))) _eventorganizedby = reader.GetInt64(reader.GetOrdinal("EventOrganizedBy"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Date1"))) _ex_date1 = reader.GetDateTime(reader.GetOrdinal("Ex_Date1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Date2"))) _ex_date2 = reader.GetDateTime(reader.GetOrdinal("Ex_Date2"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Nvarchar1"))) _ex_nvarchar1 = reader.GetString(reader.GetOrdinal("Ex_Nvarchar1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Nvarchar2"))) _ex_nvarchar2 = reader.GetString(reader.GetOrdinal("Ex_Nvarchar2"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Nvarchar3"))) _ex_nvarchar3 = reader.GetString(reader.GetOrdinal("Ex_Nvarchar3"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Bigint1"))) _ex_bigint1 = reader.GetInt64(reader.GetOrdinal("Ex_Bigint1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Bigint2"))) _ex_bigint2 = reader.GetInt64(reader.GetOrdinal("Ex_Bigint2"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Decimal1"))) _ex_decimal1 = reader.GetDecimal(reader.GetOrdinal("Ex_Decimal1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Decimal2"))) _ex_decimal2 = reader.GetDecimal(reader.GetOrdinal("Ex_Decimal2"));
                if (!reader.IsDBNull(reader.GetOrdinal("TransID"))) this.BaseSecurityParam.transid = reader.GetString(reader.GetOrdinal("TransID"));
                if (!reader.IsDBNull(reader.GetOrdinal("CreatedByUserName"))) this.BaseSecurityParam.createdbyusername = reader.GetString(reader.GetOrdinal("CreatedByUserName"));
                if (!reader.IsDBNull(reader.GetOrdinal("CreatedDate"))) this.BaseSecurityParam.createddate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("UpdatedByUserName"))) this.BaseSecurityParam.updatedbyusername = reader.GetString(reader.GetOrdinal("UpdatedByUserName"));
                if (!reader.IsDBNull(reader.GetOrdinal("UpdatedDate"))) this.BaseSecurityParam.updateddate = reader.GetDateTime(reader.GetOrdinal("UpdatedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("IPAddress"))) this.BaseSecurityParam.ipaddress = reader.GetString(reader.GetOrdinal("IPAddress"));
                if (!reader.IsDBNull(reader.GetOrdinal("TS"))) this.BaseSecurityParam.ts = reader.GetInt64(reader.GetOrdinal("ts"));
                CurrentState = EntityState.Unchanged;
            }
        }


        protected void LoadFromReader(IDataReader reader, bool IsListViewShow)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("EventID"))) _eventid = reader.GetInt64(reader.GetOrdinal("EventID"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventCategoryID"))) _eventcategoryid = reader.GetInt64(reader.GetOrdinal("EventCategoryID"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventCode"))) _eventcode = reader.GetString(reader.GetOrdinal("EventCode"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventName"))) _eventname = reader.GetString(reader.GetOrdinal("EventName"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventStartDate"))) _eventstartdate = reader.GetDateTime(reader.GetOrdinal("EventStartDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventEndDate"))) _eventenddate = reader.GetDateTime(reader.GetOrdinal("EventEndDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventDescription"))) _eventdescription = reader.GetString(reader.GetOrdinal("EventDescription"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventDescription1"))) _eventdescription1 = reader.GetString(reader.GetOrdinal("EventDescription1"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventDescription2"))) _eventdescription2 = reader.GetString(reader.GetOrdinal("EventDescription2"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventSpecialNote"))) _eventspecialnote = reader.GetString(reader.GetOrdinal("EventSpecialNote"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsDeleted"))) _isdeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventOrganizedBy"))) _eventorganizedby = reader.GetInt64(reader.GetOrdinal("EventOrganizedBy"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Date1"))) _ex_date1 = reader.GetDateTime(reader.GetOrdinal("Ex_Date1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Date2"))) _ex_date2 = reader.GetDateTime(reader.GetOrdinal("Ex_Date2"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Nvarchar1"))) _ex_nvarchar1 = reader.GetString(reader.GetOrdinal("Ex_Nvarchar1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Nvarchar2"))) _ex_nvarchar2 = reader.GetString(reader.GetOrdinal("Ex_Nvarchar2"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Nvarchar3"))) _ex_nvarchar3 = reader.GetString(reader.GetOrdinal("Ex_Nvarchar3"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Bigint1"))) _ex_bigint1 = reader.GetInt64(reader.GetOrdinal("Ex_Bigint1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Bigint2"))) _ex_bigint2 = reader.GetInt64(reader.GetOrdinal("Ex_Bigint2"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Decimal1"))) _ex_decimal1 = reader.GetDecimal(reader.GetOrdinal("Ex_Decimal1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Ex_Decimal2"))) _ex_decimal2 = reader.GetDecimal(reader.GetOrdinal("Ex_Decimal2"));
                if (!reader.IsDBNull(reader.GetOrdinal("TransID"))) this.BaseSecurityParam.transid = reader.GetString(reader.GetOrdinal("TransID"));
                if (!reader.IsDBNull(reader.GetOrdinal("CreatedByUserName"))) this.BaseSecurityParam.createdbyusername = reader.GetString(reader.GetOrdinal("CreatedByUserName"));
                if (!reader.IsDBNull(reader.GetOrdinal("CreatedDate"))) this.BaseSecurityParam.createddate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("UpdatedByUserName"))) this.BaseSecurityParam.updatedbyusername = reader.GetString(reader.GetOrdinal("UpdatedByUserName"));
                if (!reader.IsDBNull(reader.GetOrdinal("UpdatedDate"))) this.BaseSecurityParam.updateddate = reader.GetDateTime(reader.GetOrdinal("UpdatedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("IPAddress"))) this.BaseSecurityParam.ipaddress = reader.GetString(reader.GetOrdinal("IPAddress"));
                if (!reader.IsDBNull(reader.GetOrdinal("TS"))) this.BaseSecurityParam.ts = reader.GetInt64(reader.GetOrdinal("ts"));
                CurrentState = EntityState.Unchanged;
            }
        }
        
        #endregion
        
        
            
    }
}
