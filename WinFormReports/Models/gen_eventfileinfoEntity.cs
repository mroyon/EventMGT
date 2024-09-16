using System;
using System.Runtime.Serialization;
using System.Data;
using System.ComponentModel.DataAnnotations;


namespace WinFormReports.Models
{
    [Serializable]
    [DataContract(Name = "gen_eventfileinfoEntity", Namespace = "http://www.KAF.com/types")]
    public partial class gen_eventfileinfoEntity
    {
        private string fileUrl;

        [DataMember]
        public string FileUrl { get => fileUrl; set => fileUrl = value; }
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
            set { _eventfileid = value;  }
        }
        
        [DataMember]
        public long ? eventid
        {
            get { return _eventid; }
            set { _eventid = value;  }
        }
        
        [DataMember]
        [MaxLength(250)]
        public string filename
        {
            get { return _filename; }
            set { _filename = value;  }
        }
        
        [DataMember]
        [MaxLength(250)]
        public string filetype
        {
            get { return _filetype; }
            set { _filetype = value;  }
        }
        
        [DataMember]
        [MaxLength(250)]
        public string extension
        {
            get { return _extension; }
            set { _extension = value;  }
        }
        
        [DataMember]
        [MaxLength(50)]
        public long? filesize
        {
            get { return _filesize; }
            set { _filesize = value;  }
        }
        
        [DataMember]
        [MaxLength(250)]
        public string filetitle
        {
            get { return _filetitle; }
            set { _filetitle = value;  }
        }
        
        [DataMember]
        public bool ? iscoverphoto
        {
            get { return _iscoverphoto; }
            set { _iscoverphoto = value;  }
        }
        
        [DataMember]
        [MaxLength(-1)]
        public string filedescription
        {
            get { return _filedescription; }
            set { _filedescription = value;  }
        }
        
        [DataMember]
        [MaxLength(-1)]
        public string comment
        {
            get { return _comment; }
            set { _comment = value;  }
        }
        
        [DataMember]
        public DateTime ? ex_date1
        {
            get { return _ex_date1; }
            set { _ex_date1 = value;  }
        }
        
        [DataMember]
        public DateTime ? ex_date2
        {
            get { return _ex_date2; }
            set { _ex_date2 = value;  }
        }
        
        [DataMember]
        [MaxLength(250)]
        public string ex_nvarchar1
        {
            get { return _ex_nvarchar1; }
            set { _ex_nvarchar1 = value;  }
        }
        
        [DataMember]
        [MaxLength(250)]
        public string ex_nvarchar2
        {
            get { return _ex_nvarchar2; }
            set { _ex_nvarchar2 = value;  }
        }
        
        [DataMember]
        [MaxLength(250)]
        public string ex_nvarchar3
        {
            get { return _ex_nvarchar3; }
            set { _ex_nvarchar3 = value;  }
        }
        
        [DataMember]
        public long ? ex_bigint1
        {
            get { return _ex_bigint1; }
            set { _ex_bigint1 = value;  }
        }
        
        [DataMember]
        public long ? ex_bigint2
        {
            get { return _ex_bigint2; }
            set { _ex_bigint2 = value;  }
        }
        
        [DataMember]
        public decimal ? ex_decimal1
        {
            get { return _ex_decimal1; }
            set { _ex_decimal1 = value;  }
        }
        
        [DataMember]
        public decimal ? ex_decimal2
        {
            get { return _ex_decimal2; }
            set { _ex_decimal2 = value;  }
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
            }
        }


        protected void LoadFromReader(IDataReader reader, bool IsListViewShow)
        {
            if (reader != null && !reader.IsClosed)
            {
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
            }
        }
        
        #endregion
        
        
            
    }
}
