using AppConfig.EncryptionHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization.Json; 
using System.Text;
using System.Xml.Linq;

namespace AppConfig.HelperClasses
{
    public class applicationEnamNConstants
    {

        public enum basicCRUDButtons
        { 
            New_GET = 1,
            New_POST = 2,

            Edit_GET = 3,
            Edit_POST = 4,

            Delete_GET = 5,
            Delete_POST = 6,

            GetSingle_GET = 7,
            GetSingle_POST = 8,

            Search_GET = 9,
            Search_POST = 10,

            Process_GET = 11,
            Process_POST = 12,

            Submit_POST = 13,

            CUSTOM = 8
        }

        public enum OC_Status
        {
            [Display(Name = "Blocked")]
            Blocked = 1,
            [Display(Name = "Reviewed")]
            Reviewed = 2,
            [Display(Name = "Payment Success")]
            PaymentSuccess = 3
        }

        public enum ServicesFromDB
        {
            [Display(Name = "طلب إعادة الخدمة")]
            Service_Reinstatement_Request = 1,
            [Display(Name = "خدمة الوزارة المتكاملة")]
            Ministry_Integrated_Service = 7,
            [Display(Name = "نادي الضباط")]
            Officers_Club = 9,
            [Display(Name = "Warrent Officer to Officer Registration")]
            WO_to_Officer_Registration = 13
        }

        //public enum Reg_FileCategory
        //{
        //    [Display(Name = "Blocked")]
        //    Blocked = 1,
        //    [Display(Name = "Reviewed")]
        //    Reviewed = 2,
        //    [Display(Name = "Payment Success")]
        //    PaymentSuccess = 3
        //}
    }
}
