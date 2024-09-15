using BDO.Core.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Text;

namespace BDO.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "SahelSalaryCertiStepThreeEntity", Namespace = "http://www.KAF.com/types")]
    public class SahelSalaryCertiStepThreeEntity : BaseEntity
    {
        [DataMember]
        public string militaryprofilejson { get; set; }
        [DataMember]
        public long? requestserialid { get; set; }
        [DataMember]
        public string merchanttrackid { get; set; }
        [DataMember]
        public string requesttimestamp { get; set; }
        [DataMember]
        public DateTime? requestdateatsltb { get; set; }
        [DataMember]
        public int? validtilldays { get; set; }
        [DataMember]
        public string securitytoken { get; set; }
        [DataMember]
        public Guid requestguid { get; set; }
        [DataMember]
        public DateTime? requestdateatpgtb { get; set; }
        [DataMember]
        public bool requestisactive { get; set; }
        [DataMember]
        public string requestercivilid { get; set; }
        [DataMember]
        public string requestermilitaryid { get; set; }
        [DataMember]
        public long? transactionid { get; set; }
        [DataMember]
        public string knet_paymentid { get; set; }
        [DataMember]
        public string knet_referenceid { get; set; }
        [DataMember]
        public string knet_postdate { get; set; }
        [DataMember]
        public string knet_result_code { get; set; }
        [DataMember]
        public string knet_transactionid { get; set; }
        [DataMember]
        public string knet_authcode { get; set; }
        [DataMember]
        public decimal? actamount { get; set; }

        public SahelSalaryCertiStepThreeEntity()
        {
        }

        public SahelSalaryCertiStepThreeEntity(IDataReader ireader)
        {
            //LoadFromReader(ireader);
            LoadFromReaderREF(ireader);
        }

        protected void LoadFromReaderREF(IDataReader reader)
        {
            //SqlDataReader reader = (SqlDataReader)ireader;
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("MilitaryProfileJson"))) militaryprofilejson = reader.GetString(reader.GetOrdinal("MilitaryProfileJson"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequestSerialID"))) requestserialid = reader.GetInt64(reader.GetOrdinal("RequestSerialID"));
                if (!reader.IsDBNull(reader.GetOrdinal("MerchantTrackID"))) merchanttrackid = reader.GetString(reader.GetOrdinal("MerchantTrackID"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequestTimeStamp"))) requesttimestamp = reader.GetString(reader.GetOrdinal("RequestTimeStamp"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequestDateAtSLTB"))) requestdateatsltb = reader.GetDateTime(reader.GetOrdinal("RequestDateAtSLTB"));
                if (!reader.IsDBNull(reader.GetOrdinal("ValidTillDays"))) validtilldays = reader.GetInt32(reader.GetOrdinal("ValidTillDays"));
                if (!reader.IsDBNull(reader.GetOrdinal("SecurityToken"))) securitytoken = reader.GetString(reader.GetOrdinal("SecurityToken"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequestGUID"))) requestguid = reader.GetGuid(reader.GetOrdinal("RequestGUID"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequestDateAtPGTB"))) requestdateatpgtb = reader.GetDateTime(reader.GetOrdinal("RequestDateAtPGTB"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequestIsActive"))) requestisactive = reader.GetBoolean(reader.GetOrdinal("RequestIsActive"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequesterCivilID"))) requestercivilid = reader.GetString(reader.GetOrdinal("RequesterCivilID"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequesterMilitaryID"))) requestermilitaryid = reader.GetString(reader.GetOrdinal("RequesterMilitaryID"));
                if (!reader.IsDBNull(reader.GetOrdinal("TransactionID"))) transactionid = reader.GetInt64(reader.GetOrdinal("TransactionID"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_PaymentID"))) knet_paymentid = reader.GetString(reader.GetOrdinal("KNet_PaymentID"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_ReferenceID"))) knet_referenceid = reader.GetString(reader.GetOrdinal("KNet_ReferenceID"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_PostDate"))) knet_postdate = reader.GetString(reader.GetOrdinal("KNet_PostDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_Result_Code"))) knet_result_code = reader.GetString(reader.GetOrdinal("KNet_Result_Code"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_TransactionID"))) knet_transactionid = reader.GetString(reader.GetOrdinal("KNet_TransactionID"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_AuthCode"))) knet_authcode = reader.GetString(reader.GetOrdinal("KNet_AuthCode"));
                if (!reader.IsDBNull(reader.GetOrdinal("ActAmount"))) actamount = reader.GetDecimal(reader.GetOrdinal("ActAmount"));

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
