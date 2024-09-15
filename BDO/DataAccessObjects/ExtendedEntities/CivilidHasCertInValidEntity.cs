using BDO.Core.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Text;

namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    /// </summary>
    [Serializable]
    [DataContract(Name = "CivilidHasCertInValidEntity", Namespace = "http://www.KAF.com/types")]
    public class CivilidHasCertInValidEntity : BaseEntity
    {
        [DataMember]
        public long? requestserialid { get; set; }
        [DataMember]
        public long? serviceid { get; set; }
        [DataMember]
        public bool consumed { get; set; }
        [DataMember]
        public DateTime? requestdate { get; set; }
        [DataMember]
        public int? validtilldays { get; set; }
        [DataMember]
        public bool requestisactive { get; set; }
        [DataMember]
        public long? transactionid { get; set; }
        [DataMember]
        public DateTime? transactiondate { get; set; }
        [DataMember]
        public Guid requestguid { get; set; }
        [DataMember]
        public string requestercivilid { get; set; }
        [DataMember]
        public string merchanttrackid { get; set; }
        [DataMember]
        public string knet_paymentid { get; set; }
        [DataMember]
        public string knet_referenceid { get; set; }
        [DataMember]
        public string knet_result_code { get; set; }
        [DataMember]
        public decimal? actamount { get; set; }
        [DataMember]
        public bool issuccess { get; set; }
        [DataMember]
        public long? salarycertificaterequestid { get; set; }
        [DataMember]
        public int? scannedvaliditydays { get; set; }
        [DataMember]
        public string completereporturl { get; set; }

        [DataMember]
        public string militaryprofilejson { get; set; }


        public CivilidHasCertInValidEntity()
        {
        }

        public CivilidHasCertInValidEntity(IDataReader ireader)
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
                if (!reader.IsDBNull(reader.GetOrdinal("RequestSerialID"))) requestserialid = reader.GetInt64(reader.GetOrdinal("RequestSerialID"));
                if (!reader.IsDBNull(reader.GetOrdinal("ServiceID"))) serviceid = reader.GetInt64(reader.GetOrdinal("ServiceID"));
                if (!reader.IsDBNull(reader.GetOrdinal("Consumed"))) consumed = reader.GetBoolean(reader.GetOrdinal("Consumed"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequestDate"))) requestdate = reader.GetDateTime(reader.GetOrdinal("RequestDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("ValidTillDays"))) validtilldays = reader.GetInt32(reader.GetOrdinal("ValidTillDays"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequestIsActive"))) requestisactive = reader.GetBoolean(reader.GetOrdinal("RequestIsActive"));
                if (!reader.IsDBNull(reader.GetOrdinal("TransactionID"))) transactionid = reader.GetInt64(reader.GetOrdinal("TransactionID"));
                if (!reader.IsDBNull(reader.GetOrdinal("TransactionDate"))) transactiondate = reader.GetDateTime(reader.GetOrdinal("TransactionDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequestGUID"))) requestguid = reader.GetGuid(reader.GetOrdinal("RequestGUID"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequesterCivilID"))) requestercivilid = reader.GetString(reader.GetOrdinal("RequesterCivilID"));
                if (!reader.IsDBNull(reader.GetOrdinal("MerchantTrackID"))) merchanttrackid = reader.GetString(reader.GetOrdinal("MerchantTrackID"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_PaymentID"))) knet_paymentid = reader.GetString(reader.GetOrdinal("KNet_PaymentID"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_ReferenceID"))) knet_referenceid = reader.GetString(reader.GetOrdinal("KNet_ReferenceID"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_Result_Code"))) knet_result_code = reader.GetString(reader.GetOrdinal("KNet_Result_Code"));
                if (!reader.IsDBNull(reader.GetOrdinal("ActAmount"))) actamount = reader.GetDecimal(reader.GetOrdinal("ActAmount"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsSuccess"))) issuccess = reader.GetBoolean(reader.GetOrdinal("IsSuccess"));
                if (!reader.IsDBNull(reader.GetOrdinal("SalaryCertificateRequestID"))) salarycertificaterequestid = reader.GetInt64(reader.GetOrdinal("SalaryCertificateRequestID"));
                if (!reader.IsDBNull(reader.GetOrdinal("ScannedValidityDays"))) scannedvaliditydays = reader.GetInt32(reader.GetOrdinal("ScannedValidityDays"));
                if (!reader.IsDBNull(reader.GetOrdinal("CompleteReportURL"))) completereporturl = reader.GetString(reader.GetOrdinal("CompleteReportURL"));
                if (!reader.IsDBNull(reader.GetOrdinal("MilitaryProfileJson"))) militaryprofilejson = reader.GetString(reader.GetOrdinal("MilitaryProfileJson"));

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
