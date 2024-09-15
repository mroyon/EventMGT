using System;
using System.Globalization;
using System.IO;
using CLL.Abstract;

namespace CLL.LLClasses.Models
{
    
    public  class _gen_unit : _Common
    {
         private static IResourceProvider resourceProvider_gen_unit = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LanguagesFiles/_gen_unit.xml"));//DbResourceProvider(); //  
         
         
        public static string unitList
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("unitList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string unitCreate
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("unitCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string unitUpdate
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("unitUpdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string unitDetails
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("unitDetails", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         
     
         public static string unit
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("unit", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string unitRequired
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("unitRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string unitcode
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("unitcode", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_date1
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("ex_date1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_date2
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("ex_date2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_nvarchar1
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("ex_nvarchar1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_nvarchar2
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("ex_nvarchar2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_nvarchar3
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("ex_nvarchar3", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_bigint1
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("ex_bigint1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_bigint2
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("ex_bigint2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_decimal1
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("ex_decimal1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string ex_decimal2
        {
            get
            {
                return resourceProvider_gen_unit.GetResource("ex_decimal2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
      
    }
}
