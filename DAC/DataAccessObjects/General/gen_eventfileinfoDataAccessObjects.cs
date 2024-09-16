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
	
	internal sealed partial class gen_eventfileinfoDataAccessObjects : BaseDataAccess, Igen_eventfileinfoDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "gen_eventfileinfoDataAccessObjects";
        
		public gen_eventfileinfoDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(gen_eventfileinfoEntity gen_eventfileinfo, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (gen_eventfileinfo.eventfileid.HasValue)
				Database.AddInParameter(cmd, "@EventFileID", DbType.Int64, gen_eventfileinfo.eventfileid);
            if (forDelete) return;
			if (gen_eventfileinfo.eventid.HasValue)
				Database.AddInParameter(cmd, "@EventID", DbType.Int64, gen_eventfileinfo.eventid);
			if (!(string.IsNullOrEmpty(gen_eventfileinfo.filename)))
				Database.AddInParameter(cmd, "@FileName", DbType.String, gen_eventfileinfo.filename);
			if (!(string.IsNullOrEmpty(gen_eventfileinfo.filetype)))
				Database.AddInParameter(cmd, "@FileType", DbType.String, gen_eventfileinfo.filetype);
			if (!(string.IsNullOrEmpty(gen_eventfileinfo.extension)))
				Database.AddInParameter(cmd, "@Extension", DbType.String, gen_eventfileinfo.extension);
			if (gen_eventfileinfo.filesize.HasValue)
				Database.AddInParameter(cmd, "@FileSize", DbType.Int64, gen_eventfileinfo.filesize);
			if (!(string.IsNullOrEmpty(gen_eventfileinfo.filetitle)))
				Database.AddInParameter(cmd, "@FileTitle", DbType.String, gen_eventfileinfo.filetitle);
			if ((gen_eventfileinfo.iscoverphoto != null))
				Database.AddInParameter(cmd, "@IsCoverPhoto", DbType.Boolean, gen_eventfileinfo.iscoverphoto);
			if (!(string.IsNullOrEmpty(gen_eventfileinfo.filedescription)))
				Database.AddInParameter(cmd, "@FileDescription", DbType.String, gen_eventfileinfo.filedescription);
			if (!(string.IsNullOrEmpty(gen_eventfileinfo.comment)))
				Database.AddInParameter(cmd, "@Comment", DbType.String, gen_eventfileinfo.comment);
			if ((gen_eventfileinfo.ex_date1.HasValue))
				Database.AddInParameter(cmd, "@Ex_Date1", DbType.DateTime, gen_eventfileinfo.ex_date1);
			if ((gen_eventfileinfo.ex_date2.HasValue))
				Database.AddInParameter(cmd, "@Ex_Date2", DbType.DateTime, gen_eventfileinfo.ex_date2);
			if (!(string.IsNullOrEmpty(gen_eventfileinfo.ex_nvarchar1)))
				Database.AddInParameter(cmd, "@Ex_Nvarchar1", DbType.String, gen_eventfileinfo.ex_nvarchar1);
			if (!(string.IsNullOrEmpty(gen_eventfileinfo.ex_nvarchar2)))
				Database.AddInParameter(cmd, "@Ex_Nvarchar2", DbType.String, gen_eventfileinfo.ex_nvarchar2);
			if (!(string.IsNullOrEmpty(gen_eventfileinfo.ex_nvarchar3)))
				Database.AddInParameter(cmd, "@Ex_Nvarchar3", DbType.String, gen_eventfileinfo.ex_nvarchar3);
			if (gen_eventfileinfo.ex_bigint1.HasValue)
				Database.AddInParameter(cmd, "@Ex_Bigint1", DbType.Int64, gen_eventfileinfo.ex_bigint1);
			if (gen_eventfileinfo.ex_bigint2.HasValue)
				Database.AddInParameter(cmd, "@Ex_Bigint2", DbType.Int64, gen_eventfileinfo.ex_bigint2);
			if (gen_eventfileinfo.ex_decimal1.HasValue)
				Database.AddInParameter(cmd, "@Ex_Decimal1", DbType.Decimal, gen_eventfileinfo.ex_decimal1);
			if (gen_eventfileinfo.ex_decimal2.HasValue)
				Database.AddInParameter(cmd, "@Ex_Decimal2", DbType.Decimal, gen_eventfileinfo.ex_decimal2);

        }
		
        
		#region Add Operation

        async Task<long> Igen_eventfileinfoDataAccessObjects.Add(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "gen_eventfileinfo_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(gen_eventfileinfo, cmd,Database);
                FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, Database);
				AddOutputParameter(cmd);
				try
                {
                    IAsyncResult result = Database.BeginExecuteNonQuery(cmd, null, null);
                    while (!result.IsCompleted)
                    {
                    }
                    returnCode = Database.EndExecuteNonQuery(result);
                    returnCode = (Int64)(cmd.Parameters["@RETURN_KEY"].Value);
                }
                catch (Exception ex)
                {
                    throw GetDataAccessException(ex, SourceOfException("Igen_eventfileinfoDataAccess.Addgen_eventfileinfo"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> Igen_eventfileinfoDataAccessObjects.Update(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "gen_eventfileinfo_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(gen_eventfileinfo, cmd,Database);
                FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, Database);
				AddOutputParameter(cmd);
                try
                {
                  	IAsyncResult result = Database.BeginExecuteNonQuery(cmd, null, null);
                    while (!result.IsCompleted)
                    {
                    }
                    returnCode = Database.EndExecuteNonQuery(result);
                    returnCode = (Int64)(cmd.Parameters["@RETURN_KEY"].Value);
                }
                catch (Exception ex)
                {
                    throw GetDataAccessException(ex, SourceOfException("Igen_eventfileinfoDataAccess.Updategen_eventfileinfo"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> Igen_eventfileinfoDataAccessObjects.Delete(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "gen_eventfileinfo_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(gen_eventfileinfo, cmd,Database, true);
                FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, Database);
				AddOutputParameter(cmd);
				try
                {
                   	IAsyncResult result = Database.BeginExecuteNonQuery(cmd, null, null);
                    while (!result.IsCompleted)
                    {
                    }
                    returnCode = Database.EndExecuteNonQuery(result);
                    returnCode = (Int64)(cmd.Parameters["@RETURN_KEY"].Value);
                }
                catch (Exception ex)
                {
                   throw GetDataAccessException(ex, SourceOfException("Igen_eventfileinfoDataAccess.Deletegen_eventfileinfo"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> Igen_eventfileinfoDataAccessObjects.SaveList(IList<gen_eventfileinfoEntity> listAdded, IList<gen_eventfileinfoEntity> listUpdated, IList<gen_eventfileinfoEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "gen_eventfileinfo_Ins";
            const string SPUpdate = "gen_eventfileinfo_Upd";
            const string SPDelete = "gen_eventfileinfo_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (gen_eventfileinfoEntity gen_eventfileinfo in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(gen_eventfileinfo, cmd, Database, true);
                            FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, Database);
                            AddOutputParameter(cmd);
                            
                            IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                            while (!result.IsCompleted)
                            {
                            }
                            returnCode = Database.EndExecuteNonQuery(result);
                            if (returnCode < 0)
                            { 
                                throw new ArgumentException("Error in transaction.");
                            }
                            cmd.Dispose();
                        }
                    }
                }
                if (listUpdated.Count > 0 )
                {
                    foreach (gen_eventfileinfoEntity gen_eventfileinfo in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(gen_eventfileinfo, cmd, Database);
                            FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, Database);
                            AddOutputParameter(cmd);
                            IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                            while (!result.IsCompleted)
                            {
                            }
                            returnCode = Database.EndExecuteNonQuery(result);
                            if (returnCode < 0)
                            {
                                 throw new ArgumentException("Error in transaction.");
                            }
                            cmd.Dispose();
                        }
                    }
                }
                if (listAdded.Count > 0 )
                {
                    foreach (gen_eventfileinfoEntity gen_eventfileinfo in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(gen_eventfileinfo, cmd, Database);
                            FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, Database);
                            AddOutputParameter(cmd);
                            
                            IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                            while (!result.IsCompleted)
                            {
                            }
                            returnCode = Database.EndExecuteNonQuery(result);
                            if (returnCode < 0)
                            {
                                 throw new ArgumentException("Error in transaction.");
                            }
                            cmd.Dispose();
                        }
                    }
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw GetDataAccessException(ex, SourceOfException("Igen_eventfileinfoDataAccess.Save_gen_eventfileinfo"));
            }
            finally
            {
                transaction.Dispose();
                connection.Close();
                connection = null;
            }
            return returnCode;
        }
        
        
       public async Task<long> SaveList(
       Database db , 
       DbTransaction transaction,
       IList<gen_eventfileinfoEntity> listAdded, 
       IList<gen_eventfileinfoEntity> listUpdated, 
       IList<gen_eventfileinfoEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "gen_eventfileinfo_Ins";
            const string SPUpdate = "gen_eventfileinfo_Upd_ext";
            const string SPDelete = "gen_eventfileinfo_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (gen_eventfileinfoEntity gen_eventfileinfo in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(gen_eventfileinfo, cmd, db, true);
                            FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, db);
                            AddOutputParameter(cmd);
                            IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                            while (!result.IsCompleted)
                            {
                            }
                            returnCode = Database.EndExecuteNonQuery(result);
                            if (returnCode < 0)
                            { 
                                  throw new ArgumentException("Error in transaction.");
                            }
                            cmd.Dispose();
                        }
                    }
                }
                if (listUpdated.Count > 0 )
                {
                    foreach (gen_eventfileinfoEntity gen_eventfileinfo in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(gen_eventfileinfo, cmd, db);
                            FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, db);
                            AddOutputParameter(cmd);
                            IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                            while (!result.IsCompleted)
                            {
                            }
                            returnCode = Database.EndExecuteNonQuery(result);
                            if (returnCode < 0)
                            {
                                 throw new ArgumentException("Error in transaction.");
                            }
                            cmd.Dispose();
                        }
                    }
                }
                if (listAdded.Count > 0 )
                {
                    foreach (gen_eventfileinfoEntity gen_eventfileinfo in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(gen_eventfileinfo, cmd, db);
                            FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, db);
                            AddOutputParameter(cmd);
                            
                            IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                            while (!result.IsCompleted)
                            {
                            }
                            returnCode = Database.EndExecuteNonQuery(result);
                            if (returnCode < 0)
                            {
                                 throw new ArgumentException("Error in transaction.");
                            }
                            cmd.Dispose();
                        }
                    }
                }

              
            }
            catch (Exception ex)
            {
               
                throw GetDataAccessException(ex, SourceOfException("Igen_eventfileinfoDataAccess.Save_gen_eventfileinfo"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<gen_eventfileinfoEntity>> Igen_eventfileinfoDataAccessObjects.GetAll(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "gen_eventfileinfo_GA";
                IList<gen_eventfileinfoEntity> itemList = new List<gen_eventfileinfoEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, gen_eventfileinfo.SortExpression);
                    FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, Database);
                    FillParameters(gen_eventfileinfo, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_eventfileinfoEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_eventfileinfoDataAccess.GetAllgen_eventfileinfo"));
            }	
        }
		
        async Task<IList<gen_eventfileinfoEntity>> Igen_eventfileinfoDataAccessObjects.GetAllByPages(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "gen_eventfileinfo_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, gen_eventfileinfo.SortExpression);
                    AddPageSizeParameter(cmd, gen_eventfileinfo.PageSize);
                    AddCurrentPageParameter(cmd, gen_eventfileinfo.CurrentPage);                    
                    FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, Database);
                    
					FillParameters(gen_eventfileinfo, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (gen_eventfileinfo.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+gen_eventfileinfo.strCommonSerachParam+"%");

                    IList<gen_eventfileinfoEntity> itemList = new List<gen_eventfileinfoEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_eventfileinfoEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						gen_eventfileinfo.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_eventfileinfoDataAccess.GetAllByPagesgen_eventfileinfo"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        #endregion
        
        
        #region Simple load Single Row
        async Task<gen_eventfileinfoEntity> Igen_eventfileinfoDataAccessObjects.GetSingle(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "gen_eventfileinfo_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, Database);
                    FillParameters(gen_eventfileinfo, cmd, Database);
                    
                    IList<gen_eventfileinfoEntity> itemList = new List<gen_eventfileinfoEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_eventfileinfoEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    
                    if(itemList != null && itemList.Count > 0)
                        return itemList[0];
                    else
                        return null;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_eventfileinfoDataAccess.GetSinglegen_eventfileinfo"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<gen_eventfileinfoEntity>> Igen_eventfileinfoDataAccessObjects.GAPgListView(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "gen_eventfileinfo_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, gen_eventfileinfo.SortExpression);
                    AddPageSizeParameter(cmd, gen_eventfileinfo.PageSize);
                    AddCurrentPageParameter(cmd, gen_eventfileinfo.CurrentPage);                    
                    FillSequrityParameters(gen_eventfileinfo.BaseSecurityParam, cmd, Database);
                    
					FillParameters(gen_eventfileinfo, cmd,Database);
                    
					if (!string.IsNullOrEmpty (gen_eventfileinfo.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+gen_eventfileinfo.strCommonSerachParam+"%");

                    IList<gen_eventfileinfoEntity> itemList = new List<gen_eventfileinfoEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_eventfileinfoEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						gen_eventfileinfo.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_eventfileinfoDataAccess.GAPgListViewgen_eventfileinfo"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
            
	}
}