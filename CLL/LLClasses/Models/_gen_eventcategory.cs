using System;
using System.Globalization;
using System.IO;
using CLL.Abstract;

namespace CLL.LLClasses.Models
{
    
    public  class _gen_eventcategory : _Common
    {
         private static IResourceProvider resourceProvider_gen_eventcategory = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LanguagesFiles/_gen_eventcategory.xml"));//DbResourceProvider(); //  
         
         
        public static string eventcategoryList
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("eventcategoryList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string eventcategoryCreate
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("eventcategoryCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string eventcategoryUpdate
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("eventcategoryUpdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string eventcategoryDetails
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("eventcategoryDetails", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         
     
         public static string eventcategory
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("eventcategory", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string eventcategoryRequired
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("eventcategoryRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string description
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_date1
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("ex_date1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_date2
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("ex_date2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_nvarchar1
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("ex_nvarchar1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_nvarchar2
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("ex_nvarchar2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_nvarchar3
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("ex_nvarchar3", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_bigint1
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("ex_bigint1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_bigint2
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("ex_bigint2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_decimal1
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("ex_decimal1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_decimal2
        {
            get
            {
                return resourceProvider_gen_eventcategory.GetResource("ex_decimal2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
      
    }
}
