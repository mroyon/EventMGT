using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "gen_eventcategoryEntity", Namespace = "http://www.KAF.com/types")]
    public partial class gen_eventcategoryEntity : BaseEntity
    {
        #region Properties
    
        protected long ? _eventcategoryid;
        protected string _eventcategory;
        protected string _description;
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
        public long ? eventcategoryid
        {
            get { return _eventcategoryid; }
            set { _eventcategoryid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(500)]
        [Display(Name = "eventcategory", ResourceType = typeof(CLL.LLClasses.Models._gen_eventcategory))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._gen_eventcategory), ErrorMessageResourceName = "eventcategoryRequired")]
        public string eventcategory
        {
            get { return _eventcategory; }
            set { _eventcategory = value; this.OnChnaged(); }
        }
        
        [DataMember]        
        [Display(Name = "description", ResourceType = typeof(CLL.LLClasses.Models._gen_eventcategory))]
        public string description
        {
            get { return _description; }
            set { _description = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_date1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventcategory))]
        public DateTime ? ex_date1
        {
            get { return _ex_date1; }
            set { _ex_date1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_date2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventcategory))]
        public DateTime ? ex_date2
        {
            get { return _ex_date2; }
            set { _ex_date2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "ex_nvarchar1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventcategory))]
        public string ex_nvarchar1
        {
            get { return _ex_nvarchar1; }
            set { _ex_nvarchar1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "ex_nvarchar2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventcategory))]
        public string ex_nvarchar2
        {
            get { return _ex_nvarchar2; }
            set { _ex_nvarchar2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "ex_nvarchar3", ResourceType = typeof(CLL.LLClasses.Models._gen_eventcategory))]
        public string ex_nvarchar3
        {
            get { return _ex_nvarchar3; }
            set { _ex_nvarchar3 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_bigint1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventcategory))]
        public long ? ex_bigint1
        {
            get { return _ex_bigint1; }
            set { _ex_bigint1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_bigint2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventcategory))]
        public long ? ex_bigint2
        {
            get { return _ex_bigint2; }
            set { _ex_bigint2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_decimal1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventcategory))]
        public decimal ? ex_decimal1
        {
            get { return _ex_decimal1; }
            set { _ex_decimal1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_decimal2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventcategory))]
        public decimal ? ex_decimal2
        {
            get { return _ex_decimal2; }
            set { _ex_decimal2 = value; this.OnChnaged(); }
        }
        
        
        #endregion
    
        #region Constructor
    
        public gen_eventcategoryEntity():base()
        {
        }
        
        public gen_eventcategoryEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }
        
         public gen_eventcategoryEntity(IDataReader reader, bool IsListViewShow)
        {
            this.LoadFromReader(reader, IsListViewShow);
        }
        
      
        
        protected void LoadFromReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("EventCategoryID"))) _eventcategoryid = reader.GetInt64(reader.GetOrdinal("EventCategoryID"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventCategory"))) _eventcategory = reader.GetString(reader.GetOrdinal("EventCategory"));
                if (!reader.IsDBNull(reader.GetOrdinal("Description"))) _description = reader.GetString(reader.GetOrdinal("Description"));
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
                if (!reader.IsDBNull(reader.GetOrdinal("EventCategoryID"))) _eventcategoryid = reader.GetInt64(reader.GetOrdinal("EventCategoryID"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventCategory"))) _eventcategory = reader.GetString(reader.GetOrdinal("EventCategory"));
                if (!reader.IsDBNull(reader.GetOrdinal("Description"))) _description = reader.GetString(reader.GetOrdinal("Description"));
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
