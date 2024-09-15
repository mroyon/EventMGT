using BDO.Core.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "KnsUserRegistrationEntity", Namespace = "http://www.KAF.com/types")]
    public partial class KnsUserRegistrationEntity : BaseEntity
    {
        #region Properties
        private string _HUBCnnectionId;
        // private string _name;

        [DataMember]
        [Required]
        public string HUBCnnectionId
        {
            get { return _HUBCnnectionId; }
            set { _HUBCnnectionId = value; this.OnChnaged(); }
        }

        [DataMember]
        public long? basicinfoid { get => _basicInfoID; set => _basicInfoID = value; }

        private string _civilId;
        // private string _name;

        [DataMember]
        [Required]
        public string cividId
        {
            get { return _civilId; }
            set { _civilId = value; this.OnChnaged(); }
        }

        [DataMember]

        public string name { get => name1; set => name1 = value; }

        [DataMember]

        //public string Name { get => _name; set => _name = value; }

        private string _callingUrl;
        [DataMember]
        public string CallingUrl
        {
            get { return _callingUrl; }
            set { _callingUrl = value; }
        }

        private string _keyParam;
        [DataMember]
        public string KeyParam
        {
            get { return _keyParam; }
            set { _keyParam = value; }
        }
        private string _signalrContextName;
        [DataMember]
        public string SignalRContextName
        {
            get { return _signalrContextName; }
            set { _signalrContextName = value; }
        }
        private string _signalRMethodName;
        private string name1;
        private PaciUserData paciData;
        private string paciJsonData;
        private string paciPersonalDataJson;

        [DataMember]
        public string SignalRMethodName
        {
            get { return _signalRMethodName; }
            set { _signalRMethodName = value; }
        }

        [DataMember]
        [Required]
        public string Email { get; set; }

        [DataMember]
        [Compare("Email", ErrorMessage = "Confirm Email doesn't match, Type again !")]
        [Required]
        public string ConfirmEmail { get; set; }

        [DataMember]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }


        [DataMember]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [Required]
        public string ConfirmPassword { get; set; }
		protected kns_tran_regeducationinfoEntity _kns_tran_regeducationinfoEntity;

		[DataMember]
		public kns_tran_regeducationinfoEntity kns_tran_regeducationinfoEntity
		{
			get { return _kns_tran_regeducationinfoEntity; }
			set { _kns_tran_regeducationinfoEntity = value; this.OnChnaged(); }
		}


		[DataMember]

        public PaciUserData PaciData { get => paciData; set => paciData = value; }

        [DataMember]

        public string PaciJsonData { get => paciJsonData; set => paciJsonData = value; }
        [DataMember]
        public string PaciPersonalDataJson { get => paciPersonalDataJson; set => paciPersonalDataJson = value; }

        [DataMember]
        public PaciPersonalData PaciPersonalData { get => _paciPersonalData; set => _paciPersonalData = value; }

        [DataMember]
        public string BackOfficeAdminUser { get; set; }
        [DataMember]
        public string BackOfficeAdminUserPass { get; set; }


        protected kns_tran_regimergencycontactinfoEntity _kns_tran_regimergencycontactinfo;
        private PaciPersonalData _paciPersonalData;
        private long? _basicInfoID;

        [DataMember]
        public kns_tran_regimergencycontactinfoEntity kns_tran_regimergencycontactinfo
        {
            get { return _kns_tran_regimergencycontactinfo; }
            set { _kns_tran_regimergencycontactinfo = value; this.OnChnaged(); }
        }

        #endregion


        public KnsUserRegistrationEntity() : base()
        {
        }

    }




    [Serializable]
    [DataContract]

    public class PaciUserData
    {

        [DataMember] public string civno { get; set; }
        [DataMember] public string persoN_STATUS { get; set; }
        [DataMember]
        [Required]
        public DateTime? birtH_DATE { get; set; }

        [DataMember]
        public string araB_FULL_NAME { get; set; }
        [DataMember]
        public string araB_NAME_1 { get; set; }
        [DataMember]
        public string araB_NAME_2 { get; set; }
        [DataMember]
        public string araB_NAME_3 { get; set; }
        [DataMember]
        public string araB_NAME_4 { get; set; }
        [DataMember] public string governoratE_NAME { get; set; }
        [DataMember] public string districtname { get; set; }
        [DataMember] public string block { get; set; }
        [DataMember] public string plot { get; set; }
        [DataMember] public string streeT_NAME { get; set; }
        [DataMember] public string buildinG_NO { get; set; }
        [DataMember] public string bldG_COMPUTER_NO { get; set; }
        [DataMember] public string uniT_NO { get; set; }
        [DataMember] public string uniT_TYPE { get; set; }
        [DataMember] public string flooR_NO { get; set; }

        [DataMember]

        [Required]
        public string teL_1 { get; set; }


        [DataMember]
        [Required]
        public string teL_2 { get; set; }
        [DataMember]
        public string educatioN_TEXT { get; set; }

        [DataMember]
        public string relegioN_TEXT { get; set; }


        [DataMember]
        public string joB_STATUS { get; set; }

        [DataMember]
        public string blooD_TYPE { get; set; }
        [DataMember] public string datE_GRANT { get; set; }
        [DataMember] public string datE_WITHDRAWL { get; set; }
        [DataMember] public string eoS_CARD_NAME { get; set; }
        [DataMember] public string cons { get; set; }
        [DataMember] public string fatheR_CIVNO { get; set; }
        [DataMember] public string fatheR_STATUS_TEXT { get; set; }
        [DataMember] public string motheR_CIVNO { get; set; }
        [DataMember] public string motheR_STATUS_TEXT { get; set; }
        [DataMember] public string motheR_ARAB_NAME_1 { get; set; }
        [DataMember] public string motheR_ARAB_NAME_2 { get; set; }
        [DataMember] public string motheR_ARAB_NAME_3 { get; set; }
        [DataMember] public string motheR_ARAB_NAME_4 { get; set; }
        //[DataMember] public string rc { get; set; }
        //[DataMember] public string enquiryTime { get; set; }
        //[DataMember] public string msg { get; set; }
        //[DataMember] public string info { get; set; }
        //[DataMember] public string responseTime { get; set; }
        //[DataMember] public string verNo { get; set; }
        //[DataMember] public string env { get; set; }
        //[DataMember] public string hitsRemaining { get; set; }
        //[DataMember] public string disclaimer { get; set; }
    }

    [Serializable]
    [DataContract]
    public class PaciPersonalData
    {
        [DataMember] public string CivilID { get; set; }
        [DataMember] public string FullNameAr { get; set; }
        [DataMember] public string FullNameEn { get; set; }
        [DataMember] public string NationalityEn { get; set; }
        [DataMember] public string NationalityAr { get; set; }
        [DataMember] public DateTime BirthDate { get; set; }
        [DataMember] public string Gender { get; set; }
        [DataMember] public string MobileNumber { get; set; }
        [DataMember] public string EmailAddress { get; set; }
        [DataMember] public string BloodGroup { get; set; }
        [DataMember] public object Photo { get; set; }
        [DataMember] public DateTime CardExpiryDate { get; set; }
        [DataMember] public object DocumentNumber { get; set; }
        [DataMember] public string PassportNumber { get; set; }
        [DataMember] public object GovData { get; set; }
        [DataMember] public Address Address { get; set; }
    }

    [Serializable]
    [DataContract]
    public class Address
    {
        [DataMember] public string Governerate { get; set; }
        [DataMember] public string Area { get; set; }
        [DataMember] public string PaciBuildingNumber { get; set; }
        [DataMember] public object BuildingType { get; set; }
        [DataMember] public string FloorNumber { get; set; }
        [DataMember] public string BuildingNumber { get; set; }
        [DataMember] public string BlockNumber { get; set; }
        [DataMember] public string UnitNumber { get; set; }
        [DataMember] public string StreetName { get; set; }
        [DataMember] public string UnitType { get; set; }
    }

}