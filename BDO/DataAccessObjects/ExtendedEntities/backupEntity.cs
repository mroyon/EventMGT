using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "backupEntity", Namespace = "http://www.KAF.com/types")]
    public partial class backupEntity : BaseEntity
    {
        #region Properties
    
        //protected long ? _eventcategoryid;
        protected string _backuptype;
        protected string _databasename;
        protected string _filepath;
        protected DateTime ? _backupdate;
             
        
        [DataMember]
        public string backuptype
        {
            get { return _backuptype; }
            set { _backuptype = value; this.OnChnaged(); }
        }
        
        [DataMember]        
        public string databasename
        {
            get { return _databasename; }
            set { _databasename = value; this.OnChnaged(); }
        }
        [DataMember]        
        public string filepath
        {
            get { return _filepath; }
            set { _filepath = value; this.OnChnaged(); }
        }
        
        [DataMember]
        public DateTime ? backupdate
        {
            get { return _backupdate; }
            set { _backupdate = value; this.OnChnaged(); }
        }
        
        
        
        #endregion
    
        #region Constructor
    
        public backupEntity():base()
        {
        }
        
        #endregion
    }
}
