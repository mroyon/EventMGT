using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace BDO.Core.DataAccessObjects.Models
{
   
    public partial class gen_userunitEntity 
    {
		protected long? _masteruserid;
		protected string _username;
		protected string _unit;

		[DataMember]
		public long? masteruserid
		{
			get { return _masteruserid; }
			set { _masteruserid = value; this.OnChnaged(); }
		}

		[DataMember]
		[MaxLength(256)]
		[Display(Name = "username", ResourceType = typeof(CLL.LLClasses.SecurityModels._owin_user))]
		public string username
		{
			get { return _username; }
			set { _username = value; this.OnChnaged(); }
		}

		[DataMember]
		[MaxLength(500)]
		[Display(Name = "unit", ResourceType = typeof(CLL.LLClasses.Models._gen_unit))]
		public string unit
		{
			get { return _unit; }
			set { _unit = value; this.OnChnaged(); }
		}


        public gen_userunitEntity(IDataReader reader, bool IsListViewShow, bool IsExt)
        {
            this.LoadFromReader_Ext(reader, IsListViewShow);
        }
        protected void LoadFromReader_Ext(IDataReader reader, bool IsListViewShow)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("Serial"))) _serial = reader.GetInt64(reader.GetOrdinal("Serial"));
                if (!reader.IsDBNull(reader.GetOrdinal("Unit"))) _unit = reader.GetString(reader.GetOrdinal("Unit"));
                if (!reader.IsDBNull(reader.GetOrdinal("UserName"))) _username = reader.GetString(reader.GetOrdinal("UserName"));
                if (!reader.IsDBNull(reader.GetOrdinal("UnitID"))) _unitid = reader.GetInt64(reader.GetOrdinal("UnitID"));
                if (!reader.IsDBNull(reader.GetOrdinal("UserId"))) _userid = reader.GetGuid(reader.GetOrdinal("UserId"));
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
    }
}
