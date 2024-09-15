using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using AppConfig.ConfigDAAC;
using DAC.Core.Base;
using System.Threading.Tasks;
using System.Threading;
using IDAC.Core.IDataAccessObjects.General;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.Base;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using CLL.LLClasses.Models;

namespace DAC.Core.DataAccessObjects.General
{
    /// <summary>
    /// Un touched: From Generator
    /// KAF Information Center
    /// </summary>

    internal sealed partial class gen_unitDataAccessObjects
    {



        #region for Dropdown 
        async Task<IList<gen_dropdownEntity>> Igen_unitDataAccessObjects.GetDataForDropDownByUserId(gen_unitEntity gen_eventcategory, CancellationToken cancellationToken)
        {
            try
            {
                const string SP = "gen_unit_GAPgDropDown_By_UserId";
                using (DbCommand cmd = Database.GetStoredProcCommand(SP))
                {
                    AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, gen_eventcategory.SortExpression);
                    AddPageSizeParameter(cmd, gen_eventcategory.PageSize);
                    AddCurrentPageParameter(cmd, gen_eventcategory.CurrentPage);
                    FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, Database);
                    FillParameters(gen_eventcategory, cmd, Database);
                    if (!string.IsNullOrEmpty(gen_eventcategory.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String, " % " + gen_eventcategory.strCommonSerachParam + " % ");

                  
                    if (gen_eventcategory.BaseSecurityParam.userid.HasValue)
                    {
                        Database.AddInParameter(cmd, "@UserId", DbType.Guid, gen_eventcategory.BaseSecurityParam.userid);
                    }

                    IList<gen_dropdownEntity> itemList = new List<gen_dropdownEntity>();
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null, null);
                    while (!result.IsCompleted)
                    {

                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_dropdownEntity(reader));
                        }
                        reader.Close();
                    }
                    if (itemList.Count > 0)
                    {
                        itemList[0].RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                        gen_eventcategory.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
                }
            }
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_unitDataAccessObjects.GetDataForDropDownByUserId"));
            }
        }
        #endregion

    }
}