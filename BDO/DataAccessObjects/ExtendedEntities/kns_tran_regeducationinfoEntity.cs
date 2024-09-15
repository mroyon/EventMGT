using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "kns_tran_regeducationinfoEntity", Namespace = "http://www.KAF.com/types")]
    public partial class kns_tran_regeducationinfoEntity : BaseEntity
    {
        #region Properties
    
        protected long ? _educationid;
        protected long ? _basicinfoid;
        protected long ? _certificateid;
        protected long ? _batchid;
        protected long ? _certificatesubjectid;
        protected long ? _edugradeid;
        protected string _comment;
                
        
        [DataMember]
        public long ? educationid
        {
            get { return _educationid; }
            set { _educationid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        public long ? basicinfoid
        {
            get { return _basicinfoid; }
            set { _basicinfoid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        public long ? certificateid
        {
            get { return _certificateid; }
            set { _certificateid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._kns_tran_regeducationinfo), ErrorMessageResourceName = "batchidRequired")]
        public long ? batchid
        {
            get { return _batchid; }
            set { _batchid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        public long ? certificatesubjectid
        {
            get { return _certificatesubjectid; }
            set { _certificatesubjectid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        public long ? edugradeid
        {
            get { return _edugradeid; }
            set { _edugradeid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(150)]
        public string comment
        {
            get { return _comment; }
            set { _comment = value; this.OnChnaged(); }
        }
        
        
        #endregion
    
        #region Constructor
    
        public kns_tran_regeducationinfoEntity():base()
        {
        }
        
        public kns_tran_regeducationinfoEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }
        
         public kns_tran_regeducationinfoEntity(IDataReader reader, bool IsListViewShow)
        {
            this.LoadFromReader(reader, IsListViewShow);
        }
        
      
        
        protected void LoadFromReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("EducationID"))) _educationid = reader.GetInt64(reader.GetOrdinal("EducationID"));
                if (!reader.IsDBNull(reader.GetOrdinal("BasicInfoID"))) _basicinfoid = reader.GetInt64(reader.GetOrdinal("BasicInfoID"));
                if (!reader.IsDBNull(reader.GetOrdinal("CertificateID"))) _certificateid = reader.GetInt64(reader.GetOrdinal("CertificateID"));
                if (!reader.IsDBNull(reader.GetOrdinal("BatchId"))) _batchid = reader.GetInt64(reader.GetOrdinal("BatchId"));
                if (!reader.IsDBNull(reader.GetOrdinal("CertificateSubjectID"))) _certificatesubjectid = reader.GetInt64(reader.GetOrdinal("CertificateSubjectID"));
                if (!reader.IsDBNull(reader.GetOrdinal("EduGradeID"))) _edugradeid = reader.GetInt64(reader.GetOrdinal("EduGradeID"));
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
                if (!reader.IsDBNull(reader.GetOrdinal("EducationID"))) _educationid = reader.GetInt64(reader.GetOrdinal("EducationID"));
                if (!reader.IsDBNull(reader.GetOrdinal("BasicInfoID"))) _basicinfoid = reader.GetInt64(reader.GetOrdinal("BasicInfoID"));
                if (!reader.IsDBNull(reader.GetOrdinal("CertificateID"))) _certificateid = reader.GetInt64(reader.GetOrdinal("CertificateID"));
                if (!reader.IsDBNull(reader.GetOrdinal("BatchId"))) _batchid = reader.GetInt64(reader.GetOrdinal("BatchId"));
                if (!reader.IsDBNull(reader.GetOrdinal("CertificateSubjectID"))) _certificatesubjectid = reader.GetInt64(reader.GetOrdinal("CertificateSubjectID"));
                if (!reader.IsDBNull(reader.GetOrdinal("EduGradeID"))) _edugradeid = reader.GetInt64(reader.GetOrdinal("EduGradeID"));
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
