using System;
using System.Runtime.Serialization;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "gen_eventinfoEntity", Namespace = "http://www.KAF.com/types")]
    public partial class gen_eventinfoEntity 
    {

        [DataMember]
        public List<gen_eventfileinfoEntity> EventfileinfoList { get; set; } // Files from form-data



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
            set { _eventid = value;  }
        }
        
        [DataMember]
        public long ? eventcategoryid
        {
            get { return _eventcategoryid; }
            set { _eventcategoryid = value;  }
        }
        
        [DataMember]
        [MaxLength(50)]
        public string eventcode
        {
            get { return _eventcode; }
            set { _eventcode = value;  }
        }
        
        [DataMember]
        [MaxLength(500)]
        public string eventname
        {
            get { return _eventname; }
            set { _eventname = value;  }
        }
        
        [DataMember]
        public DateTime ? eventstartdate
        {
            get { return _eventstartdate; }
            set { _eventstartdate = value;  }
        }
        
        [DataMember]
        public DateTime ? eventenddate
        {
            get { return _eventenddate; }
            set { _eventenddate = value;  }
        }
        
        [DataMember]
        
        public string eventdescription
        {
            get { return _eventdescription; }
            set { _eventdescription = value;  }
        }
        
        [DataMember]
        
        public string eventdescription1
        {
            get { return _eventdescription1; }
            set { _eventdescription1 = value;  }
        }
        
        [DataMember]
        
        public string eventdescription2
        {
            get { return _eventdescription2; }
            set { _eventdescription2 = value;  }
        }
        
        [DataMember]
        
        public string eventspecialnote
        {
            get { return _eventspecialnote; }
            set { _eventspecialnote = value;  }
        }
        
        [DataMember]
        public bool ? isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value;  }
        }
        
        [DataMember]
        public long ? eventorganizedby
        {
            get { return _eventorganizedby; }
            set { _eventorganizedby = value;  }
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
            }
        }


        protected void LoadFromReader(IDataReader reader, bool IsListViewShow)
        {
            if (reader != null && !reader.IsClosed)
            {
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
            }
        }
        
        #endregion
        
        
            
    }
}
