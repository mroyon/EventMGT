using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "kns_tran_regimergencycontactinfoEntity", Namespace = "http://www.KAF.com/types")]
    public partial class kns_tran_regimergencycontactinfoEntity : BaseEntity
    {
        #region Properties
    
        protected long ? _imergencycontactid;
        protected long ? _basicinfoid;
        protected long ? _batchid;
        protected string _name1;
        protected string _name2;
        protected string _name3;
        protected string _name4;
        protected string _name5;
        protected string _fullname;
        protected string _mobile1;
        protected string _mobile2;
        protected string _telephone1;
        protected string _telephone2;
        protected string _email;
        protected string _comment;
                
        
        [DataMember]
        public long ? imergencycontactid
        {
            get { return _imergencycontactid; }
            set { _imergencycontactid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        public long ? basicinfoid
        {
            get { return _basicinfoid; }
            set { _basicinfoid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        public long ? batchid
        {
            get { return _batchid; }
            set { _batchid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(150)]
        public string name1
        {
            get { return _name1; }
            set { _name1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(150)]
        public string name2
        {
            get { return _name2; }
            set { _name2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(150)]
        public string name3
        {
            get { return _name3; }
            set { _name3 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(150)]
        public string name4
        {
            get { return _name4; }
            set { _name4 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(150)]
        public string name5
        {
            get { return _name5; }
            set { _name5 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        public string fullname
        {
            get { return _fullname; }
            set { _fullname = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(8)]
        public string mobile1
        {
            get { return _mobile1; }
            set { _mobile1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(50)]
        public string mobile2
        {
            get { return _mobile2; }
            set { _mobile2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(50)]
        public string telephone1
        {
            get { return _telephone1; }
            set { _telephone1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(50)]
        public string telephone2
        {
            get { return _telephone2; }
            set { _telephone2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(150)]
        public string email
        {
            get { return _email; }
            set { _email = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        public string comment
        {
            get { return _comment; }
            set { _comment = value; this.OnChnaged(); }
        }
        
        
        #endregion
    
        #region Constructor
    
        public kns_tran_regimergencycontactinfoEntity():base()
        {
        }
        
        public kns_tran_regimergencycontactinfoEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }
        
         public kns_tran_regimergencycontactinfoEntity(IDataReader reader, bool IsListViewShow)
        {
            this.LoadFromReader(reader, IsListViewShow);
        }
        
      
        
        protected void LoadFromReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("ImergencyContactID"))) _imergencycontactid = reader.GetInt64(reader.GetOrdinal("ImergencyContactID"));
                if (!reader.IsDBNull(reader.GetOrdinal("BasicInfoID"))) _basicinfoid = reader.GetInt64(reader.GetOrdinal("BasicInfoID"));
                if (!reader.IsDBNull(reader.GetOrdinal("BatchId"))) _batchid = reader.GetInt64(reader.GetOrdinal("BatchId"));
                if (!reader.IsDBNull(reader.GetOrdinal("Name1"))) _name1 = reader.GetString(reader.GetOrdinal("Name1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Name2"))) _name2 = reader.GetString(reader.GetOrdinal("Name2"));
                if (!reader.IsDBNull(reader.GetOrdinal("Name3"))) _name3 = reader.GetString(reader.GetOrdinal("Name3"));
                if (!reader.IsDBNull(reader.GetOrdinal("Name4"))) _name4 = reader.GetString(reader.GetOrdinal("Name4"));
                if (!reader.IsDBNull(reader.GetOrdinal("Name5"))) _name5 = reader.GetString(reader.GetOrdinal("Name5"));
                if (!reader.IsDBNull(reader.GetOrdinal("FullName"))) _fullname = reader.GetString(reader.GetOrdinal("FullName"));
                if (!reader.IsDBNull(reader.GetOrdinal("Mobile1"))) _mobile1 = reader.GetString(reader.GetOrdinal("Mobile1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Mobile2"))) _mobile2 = reader.GetString(reader.GetOrdinal("Mobile2"));
                if (!reader.IsDBNull(reader.GetOrdinal("Telephone1"))) _telephone1 = reader.GetString(reader.GetOrdinal("Telephone1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Telephone2"))) _telephone2 = reader.GetString(reader.GetOrdinal("Telephone2"));
                if (!reader.IsDBNull(reader.GetOrdinal("Email"))) _email = reader.GetString(reader.GetOrdinal("Email"));
                if (!reader.IsDBNull(reader.GetOrdinal("Comment"))) _comment = reader.GetString(reader.GetOrdinal("Comment"));
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
                if (!reader.IsDBNull(reader.GetOrdinal("ImergencyContactID"))) _imergencycontactid = reader.GetInt64(reader.GetOrdinal("ImergencyContactID"));
                if (!reader.IsDBNull(reader.GetOrdinal("BasicInfoID"))) _basicinfoid = reader.GetInt64(reader.GetOrdinal("BasicInfoID"));
                if (!reader.IsDBNull(reader.GetOrdinal("BatchId"))) _batchid = reader.GetInt64(reader.GetOrdinal("BatchId"));
                if (!reader.IsDBNull(reader.GetOrdinal("Name1"))) _name1 = reader.GetString(reader.GetOrdinal("Name1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Name2"))) _name2 = reader.GetString(reader.GetOrdinal("Name2"));
                if (!reader.IsDBNull(reader.GetOrdinal("Name3"))) _name3 = reader.GetString(reader.GetOrdinal("Name3"));
                if (!reader.IsDBNull(reader.GetOrdinal("Name4"))) _name4 = reader.GetString(reader.GetOrdinal("Name4"));
                if (!reader.IsDBNull(reader.GetOrdinal("Name5"))) _name5 = reader.GetString(reader.GetOrdinal("Name5"));
                if (!reader.IsDBNull(reader.GetOrdinal("FullName"))) _fullname = reader.GetString(reader.GetOrdinal("FullName"));
                if (!reader.IsDBNull(reader.GetOrdinal("Mobile1"))) _mobile1 = reader.GetString(reader.GetOrdinal("Mobile1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Mobile2"))) _mobile2 = reader.GetString(reader.GetOrdinal("Mobile2"));
                if (!reader.IsDBNull(reader.GetOrdinal("Telephone1"))) _telephone1 = reader.GetString(reader.GetOrdinal("Telephone1"));
                if (!reader.IsDBNull(reader.GetOrdinal("Telephone2"))) _telephone2 = reader.GetString(reader.GetOrdinal("Telephone2"));
                if (!reader.IsDBNull(reader.GetOrdinal("Email"))) _email = reader.GetString(reader.GetOrdinal("Email"));
                if (!reader.IsDBNull(reader.GetOrdinal("Comment"))) _comment = reader.GetString(reader.GetOrdinal("Comment"));
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
