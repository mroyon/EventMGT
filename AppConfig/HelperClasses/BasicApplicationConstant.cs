using BDO.Core.DataAccessObjects.ExtendedEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppConfig.HelperClasses
{
    public static class BasicApplicationConstant
    {
    
    public enum OptionFromEnum
        {
            New,
            Processing,
            Processed
        }

        public static List<clsDropDown> optisonS = new List<clsDropDown>();


        public static List<clsDropDown> GetListConstant()
        {
            clsDropDown objA = new clsDropDown();
            objA.drpId = "1";
            objA.drpText = "OptionA";
            optisonS.Add(objA);

            objA.drpId = "2";
            objA.drpText = "OptionB";
            optisonS.Add(objA);
            return optisonS;
        }


        public enum basicbuttons
        {
            Edit = 1,
            Delete = 2,
            View = 3
        }

        public enum DocumentTypeEnum
        {
            Mudakkara = 1,
            Kitab = 2,
            Circular = 3,

        }
    }
}
