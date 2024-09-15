using BDO.Core.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Text;

namespace BDO.DataAccessObjects.ExtendedEntities
{
    #region LoadUnsendFileListSalaryCertificate
    /// <summary>
    /// This object represents the properties and methods of a LoadUnsendFileListSalaryCertificate.
    /// </summary>
    [Serializable]
    [DataContract(Name = "LoadUnsendFileListSalaryCertificateEntity", Namespace = "http://www.kaf.com/types")]
    public class LoadUnsendFileListSalaryCertificateEntity : BaseEntity
    {
        [DataMember]
        public long? requestermilitaryid { get; set; }
        [DataMember]
        public long? civilid { get; set; }
        [DataMember]
        public string knet_result_code { get; set; }
        [DataMember]
        public string militaryprofilejson { get; set; }
        [DataMember]
        public string knet_authcode { get; set; }
        [DataMember]
        public string completereporturl { get; set; }
        [DataMember]
        public DateTime? createddate { get; set; }
        [DataMember]
        public string knet_paymentid { get; set; }
        [DataMember]
        public string knet_referenceid { get; set; }
        [DataMember]
        public string knet_postdate { get; set; }
        [DataMember]
        public string knet_transactionid { get; set; }
        [DataMember]
        public decimal? actamount { get; set; }
        [DataMember]
        public string serviceurl { get; set; }
        [DataMember]
        public Guid requestguid { get; set; }
        [DataMember]
        public string secratecode { get; set; }
        [DataMember]
        public long? transactionid { get; set; }
        [DataMember]
        public long? salarycertificaterequestid { get; set; }
        [DataMember]
        public long? requestserialid { get; set; }
        [DataMember]
        public long? transactionmasterrefkey { get; set; }



        [DataMember]
        public bool? FileExists { get; set; }

        [DataMember]
        public long? serialnumberl { get; set; }

        [DataMember]
        public string PaidReportURL { get; set; }


        public LoadUnsendFileListSalaryCertificateEntity() : base()
        {
        }

        public LoadUnsendFileListSalaryCertificateEntity(IDataReader ireader)
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
                if (!reader.IsDBNull(reader.GetOrdinal("CivilID"))) civilid = reader.GetInt64(reader.GetOrdinal("CivilID"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_Result_Code"))) knet_result_code = reader.GetString(reader.GetOrdinal("KNet_Result_Code"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_AuthCode"))) knet_authcode = reader.GetString(reader.GetOrdinal("KNet_AuthCode"));
                if (!reader.IsDBNull(reader.GetOrdinal("CompleteReportURL"))) completereporturl = reader.GetString(reader.GetOrdinal("CompleteReportURL"));
                if (!reader.IsDBNull(reader.GetOrdinal("CreatedDate"))) createddate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_PaymentID"))) knet_paymentid = reader.GetString(reader.GetOrdinal("KNet_PaymentID"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_ReferenceID"))) knet_referenceid = reader.GetString(reader.GetOrdinal("KNet_ReferenceID"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_PostDate"))) knet_postdate = reader.GetString(reader.GetOrdinal("KNet_PostDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("KNet_TransactionID"))) knet_transactionid = reader.GetString(reader.GetOrdinal("KNet_TransactionID"));
                if (!reader.IsDBNull(reader.GetOrdinal("ActAmount"))) actamount = reader.GetDecimal(reader.GetOrdinal("ActAmount"));
                if (!reader.IsDBNull(reader.GetOrdinal("ServiceURL"))) serviceurl = reader.GetString(reader.GetOrdinal("ServiceURL"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequestGUID"))) requestguid = reader.GetGuid(reader.GetOrdinal("RequestGUID"));
                if (!reader.IsDBNull(reader.GetOrdinal("SecrateCode"))) secratecode = reader.GetString(reader.GetOrdinal("SecrateCode"));
                if (!reader.IsDBNull(reader.GetOrdinal("TransactionID"))) transactionid = reader.GetInt64(reader.GetOrdinal("TransactionID"));
                if (!reader.IsDBNull(reader.GetOrdinal("SalaryCertificateRequestID"))) salarycertificaterequestid = reader.GetInt64(reader.GetOrdinal("SalaryCertificateRequestID"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequestSerialID"))) requestserialid = reader.GetInt64(reader.GetOrdinal("RequestSerialID"));
                if (!reader.IsDBNull(reader.GetOrdinal("TransactionMasterRefKey"))) transactionmasterrefkey = reader.GetInt64(reader.GetOrdinal("TransactionMasterRefKey"));
                if (!reader.IsDBNull(reader.GetOrdinal("MilitaryProfileJson"))) militaryprofilejson = reader.GetString(reader.GetOrdinal("MilitaryProfileJson"));
                if (!reader.IsDBNull(reader.GetOrdinal("RequesterMilitaryID"))) requestermilitaryid = Convert.ToInt64(reader.GetString(reader.GetOrdinal("RequesterMilitaryID")));

                if (!reader.IsDBNull(reader.GetOrdinal("FileExists"))) FileExists = Convert.ToBoolean((reader.GetOrdinal("FileExists")));
                if (!reader.IsDBNull(reader.GetOrdinal("serialnumberl"))) serialnumberl = reader.GetInt64(reader.GetOrdinal("serialnumberl"));

                
                if (!reader.IsDBNull(reader.GetOrdinal("PaidReportURL"))) PaidReportURL = reader.GetString(reader.GetOrdinal("PaidReportURL"));



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
    #endregion
}
