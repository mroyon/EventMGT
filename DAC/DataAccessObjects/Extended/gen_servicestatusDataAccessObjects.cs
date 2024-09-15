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

namespace DAC.Core.DataAccessObjects.General
{
	/// <summary>
    /// Un touched: From Generator
    /// KAF Information Center
    /// </summary>
	
	internal sealed partial class gen_servicestatusDataAccessObjects 
	{
		
		async Task<IList<gen_dropdownEntity>> Igen_servicestatusDataAccessObjects.GetDataForDropDownRefWithService(gen_servicestatusEntity gen_servicestatus, CancellationToken cancellationToken)
		{
			try
			{
				string SP = "gen_servicestatus_GAPgDropDown_Ext";

				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
					AddSortExpressionParameter(cmd, gen_servicestatus.SortExpression);
					AddPageSizeParameter(cmd, gen_servicestatus.PageSize);
					AddCurrentPageParameter(cmd, gen_servicestatus.CurrentPage);                    
					FillSequrityParameters(gen_servicestatus.BaseSecurityParam, cmd, Database);
					FillParameters(gen_servicestatus, cmd,Database);


                    Database.AddInParameter(cmd, "@ServiceID", DbType.Int64, gen_servicestatus.prntkey);

                    if (!string.IsNullOrEmpty(gen_servicestatus.strCommonSerachParam))
						Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String, " % " + gen_servicestatus.strCommonSerachParam + " % ");
					IList<gen_dropdownEntity> itemList = new List<gen_dropdownEntity>();
					IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
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
					if(itemList.Count>0)
					{
						itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						gen_servicestatus.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
					}
					cmd.Dispose();
					return itemList;
				}
			}
			catch (Exception ex)
			{
				throw GetDataAccessException(ex, SourceOfException("Igen_servicestatusDataAccess.GetDataForDropDownRefWithService"));
			}
		}
    
	}
}