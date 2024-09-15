using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "gen_eventfileinfoEntity", Namespace = "http://www.KAF.com/types")]
    public partial class gen_eventfileinfoEntity : BaseEntity
    {
        #region Properties
    
        protected long ? _eventfileid;
        protected long ? _eventid;
        protected string _filename;
        protected string _filetype;
        protected string _extension;
        protected long? _filesize;
        protected string _filetitle;
        protected bool ? _iscoverphoto;
        protected string _filedescription;
        protected string _comment;
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
        public long ? eventfileid
        {
            get { return _eventfileid; }
            set { _eventfileid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "eventid", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo), ErrorMessageResourceName = "eventidRequired")]
        public long ? eventid
        {
            get { return _eventid; }
            set { _eventid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "filename", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo), ErrorMessageResourceName = "filenameRequired")]
        public string filename
        {
            get { return _filename; }
            set { _filename = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "filetype", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo), ErrorMessageResourceName = "filetypeRequired")]
        public string filetype
        {
            get { return _filetype; }
            set { _filetype = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "extension", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo), ErrorMessageResourceName = "extensionRequired")]
        public string extension
        {
            get { return _extension; }
            set { _extension = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(50)]
        [Display(Name = "filesize", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public long? filesize
        {
            get { return _filesize; }
            set { _filesize = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "filetitle", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public string filetitle
        {
            get { return _filetitle; }
            set { _filetitle = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "iscoverphoto", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public bool ? iscoverphoto
        {
            get { return _iscoverphoto; }
            set { _iscoverphoto = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(-1)]
        [Display(Name = "filedescription", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public string filedescription
        {
            get { return _filedescription; }
            set { _filedescription = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(-1)]
        [Display(Name = "comment", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public string comment
        {
            get { return _comment; }
            set { _comment = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_date1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public DateTime ? ex_date1
        {
            get { return _ex_date1; }
            set { _ex_date1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_date2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public DateTime ? ex_date2
        {
            get { return _ex_date2; }
            set { _ex_date2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "ex_nvarchar1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public string ex_nvarchar1
        {
            get { return _ex_nvarchar1; }
            set { _ex_nvarchar1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "ex_nvarchar2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public string ex_nvarchar2
        {
            get { return _ex_nvarchar2; }
            set { _ex_nvarchar2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        [Display(Name = "ex_nvarchar3", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public string ex_nvarchar3
        {
            get { return _ex_nvarchar3; }
            set { _ex_nvarchar3 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_bigint1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public long ? ex_bigint1
        {
            get { return _ex_bigint1; }
            set { _ex_bigint1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_bigint2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public long ? ex_bigint2
        {
            get { return _ex_bigint2; }
            set { _ex_bigint2 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_decimal1", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public decimal ? ex_decimal1
        {
            get { return _ex_decimal1; }
            set { _ex_decimal1 = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "ex_decimal2", ResourceType = typeof(CLL.LLClasses.Models._gen_eventfileinfo))]
        public decimal ? ex_decimal2
        {
            get { return _ex_decimal2; }
            set { _ex_decimal2 = value; this.OnChnaged(); }
        }
        
        
        #endregion
    
        #region Constructor
    
        public gen_eventfileinfoEntity():base()
        {
        }
        
        public gen_eventfileinfoEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }
        
         public gen_eventfileinfoEntity(IDataReader reader, bool IsListViewShow)
        {
            this.LoadFromReader(reader, IsListViewShow);
        }
        
      
        
        protected void LoadFromReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("EventFileID"))) _eventfileid = reader.GetInt64(reader.GetOrdinal("EventFileID"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventID"))) _eventid = reader.GetInt64(reader.GetOrdinal("EventID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileName"))) _filename = reader.GetString(reader.GetOrdinal("FileName"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileType"))) _filetype = reader.GetString(reader.GetOrdinal("FileType"));
                if (!reader.IsDBNull(reader.GetOrdinal("Extension"))) _extension = reader.GetString(reader.GetOrdinal("Extension"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileSize"))) _filesize = reader.GetInt64(reader.GetOrdinal("FileSize"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileTitle"))) _filetitle = reader.GetString(reader.GetOrdinal("FileTitle"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsCoverPhoto"))) _iscoverphoto = reader.GetBoolean(reader.GetOrdinal("IsCoverPhoto"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileDescription"))) _filedescription = reader.GetString(reader.GetOrdinal("FileDescription"));
                if (!reader.IsDBNull(reader.GetOrdinal("Comment"))) _comment = reader.GetString(reader.GetOrdinal("Comment"));
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
                if (!reader.IsDBNull(reader.GetOrdinal("EventFileID"))) _eventfileid = reader.GetInt64(reader.GetOrdinal("EventFileID"));
                if (!reader.IsDBNull(reader.GetOrdinal("EventID"))) _eventid = reader.GetInt64(reader.GetOrdinal("EventID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileName"))) _filename = reader.GetString(reader.GetOrdinal("FileName"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileType"))) _filetype = reader.GetString(reader.GetOrdinal("FileType"));
                if (!reader.IsDBNull(reader.GetOrdinal("Extension"))) _extension = reader.GetString(reader.GetOrdinal("Extension"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileSize"))) _filesize = reader.GetInt64(reader.GetOrdinal("FileSize"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileTitle"))) _filetitle = reader.GetString(reader.GetOrdinal("FileTitle"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsCoverPhoto"))) _iscoverphoto = reader.GetBoolean(reader.GetOrdinal("IsCoverPhoto"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileDescription"))) _filedescription = reader.GetString(reader.GetOrdinal("FileDescription"));
                if (!reader.IsDBNull(reader.GetOrdinal("Comment"))) _comment = reader.GetString(reader.GetOrdinal("Comment"));
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
