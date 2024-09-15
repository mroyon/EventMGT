using System;
using System.Globalization;
using System.IO;
using CLL.Abstract;

namespace CLL.LLClasses.Models
{
    
    public  class _gen_userunit : _Common
    {
         private static IResourceProvider resourceProvider_gen_userunit = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LanguagesFiles/_gen_userunit.xml"));//DbResourceProvider(); //  
         
         
        public static string userunitList
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("userunitList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string userunitCreate
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("userunitCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string userunitUpdate
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("userunitUpdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string userunitDetails
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("userunitDetails", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         
     
         public static string unitid
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("unitid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string unitidRequired
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("unitidRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string userid
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("userid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string useridRequired
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("useridRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_date1
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("ex_date1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_date2
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("ex_date2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_nvarchar1
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("ex_nvarchar1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_nvarchar2
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("ex_nvarchar2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_nvarchar3
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("ex_nvarchar3", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_bigint1
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("ex_bigint1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_bigint2
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("ex_bigint2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_decimal1
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("ex_decimal1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_decimal2
        {
            get
            {
                return resourceProvider_gen_userunit.GetResource("ex_decimal2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
      
    }
}
