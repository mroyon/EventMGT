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
	
	internal sealed partial class gen_userunitDataAccessObjects : BaseDataAccess, Igen_userunitDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "gen_userunitDataAccessObjects";
        
		public gen_userunitDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(gen_userunitEntity gen_userunit, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (gen_userunit.serial.HasValue)
				Database.AddInParameter(cmd, "@Serial", DbType.Int64, gen_userunit.serial);
            if (forDelete) return;
			if (gen_userunit.unitid.HasValue)
				Database.AddInParameter(cmd, "@UnitID", DbType.Int64, gen_userunit.unitid);
			
				Database.AddInParameter(cmd, "@UserId", DbType.Guid, gen_userunit.userid);
			if ((gen_userunit.ex_date1.HasValue))
				Database.AddInParameter(cmd, "@Ex_Date1", DbType.DateTime, gen_userunit.ex_date1);
			if ((gen_userunit.ex_date2.HasValue))
				Database.AddInParameter(cmd, "@Ex_Date2", DbType.DateTime, gen_userunit.ex_date2);
			if (!(string.IsNullOrEmpty(gen_userunit.ex_nvarchar1)))
				Database.AddInParameter(cmd, "@Ex_Nvarchar1", DbType.String, gen_userunit.ex_nvarchar1);
			if (!(string.IsNullOrEmpty(gen_userunit.ex_nvarchar2)))
				Database.AddInParameter(cmd, "@Ex_Nvarchar2", DbType.String, gen_userunit.ex_nvarchar2);
			if (!(string.IsNullOrEmpty(gen_userunit.ex_nvarchar3)))
				Database.AddInParameter(cmd, "@Ex_Nvarchar3", DbType.String, gen_userunit.ex_nvarchar3);
			if (gen_userunit.ex_bigint1.HasValue)
				Database.AddInParameter(cmd, "@Ex_Bigint1", DbType.Int64, gen_userunit.ex_bigint1);
			if (gen_userunit.ex_bigint2.HasValue)
				Database.AddInParameter(cmd, "@Ex_Bigint2", DbType.Int64, gen_userunit.ex_bigint2);
			if (gen_userunit.ex_decimal1.HasValue)
				Database.AddInParameter(cmd, "@Ex_Decimal1", DbType.Decimal, gen_userunit.ex_decimal1);
			if (gen_userunit.ex_decimal2.HasValue)
				Database.AddInParameter(cmd, "@Ex_Decimal2", DbType.Decimal, gen_userunit.ex_decimal2);

        }
		
        
		#region Add Operation

        async Task<long> Igen_userunitDataAccessObjects.Add(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "gen_userunit_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(gen_userunit, cmd,Database);
                FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("Igen_userunitDataAccess.Addgen_userunit"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> Igen_userunitDataAccessObjects.Update(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "gen_userunit_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(gen_userunit, cmd,Database);
                FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("Igen_userunitDataAccess.Updategen_userunit"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> Igen_userunitDataAccessObjects.Delete(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "gen_userunit_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(gen_userunit, cmd,Database, true);
                FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, Database);
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
                   throw GetDataAccessException(ex, SourceOfException("Igen_userunitDataAccess.Deletegen_userunit"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> Igen_userunitDataAccessObjects.SaveList(IList<gen_userunitEntity> listAdded, IList<gen_userunitEntity> listUpdated, IList<gen_userunitEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "gen_userunit_Ins";
            const string SPUpdate = "gen_userunit_Upd";
            const string SPDelete = "gen_userunit_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (gen_userunitEntity gen_userunit in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(gen_userunit, cmd, Database, true);
                            FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, Database);
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
                    foreach (gen_userunitEntity gen_userunit in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(gen_userunit, cmd, Database);
                            FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, Database);
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
                    foreach (gen_userunitEntity gen_userunit in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(gen_userunit, cmd, Database);
                            FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, Database);
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
                throw GetDataAccessException(ex, SourceOfException("Igen_userunitDataAccess.Save_gen_userunit"));
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
       IList<gen_userunitEntity> listAdded, 
       IList<gen_userunitEntity> listUpdated, 
       IList<gen_userunitEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "gen_userunit_Ins";
            const string SPUpdate = "gen_userunit_Upd";
            const string SPDelete = "gen_userunit_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (gen_userunitEntity gen_userunit in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(gen_userunit, cmd, db, true);
                            FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, db);
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
                    foreach (gen_userunitEntity gen_userunit in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(gen_userunit, cmd, db);
                            FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, db);
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
                    foreach (gen_userunitEntity gen_userunit in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(gen_userunit, cmd, db);
                            FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, db);
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
               
                throw GetDataAccessException(ex, SourceOfException("Igen_userunitDataAccess.Save_gen_userunit"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<gen_userunitEntity>> Igen_userunitDataAccessObjects.GetAll(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "gen_userunit_GA";
                IList<gen_userunitEntity> itemList = new List<gen_userunitEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, gen_userunit.SortExpression);
                    FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, Database);
                    FillParameters(gen_userunit, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_userunitEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_userunitDataAccess.GetAllgen_userunit"));
            }	
        }
		
        async Task<IList<gen_userunitEntity>> Igen_userunitDataAccessObjects.GetAllByPages(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "gen_userunit_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, gen_userunit.SortExpression);
                    AddPageSizeParameter(cmd, gen_userunit.PageSize);
                    AddCurrentPageParameter(cmd, gen_userunit.CurrentPage);                    
                    FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, Database);
                    
					FillParameters(gen_userunit, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (gen_userunit.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+gen_userunit.strCommonSerachParam+"%");

                    IList<gen_userunitEntity> itemList = new List<gen_userunitEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_userunitEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						gen_userunit.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_userunitDataAccess.GetAllByPagesgen_userunit"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        #endregion
        
        
        #region Simple load Single Row
        async Task<gen_userunitEntity> Igen_userunitDataAccessObjects.GetSingle(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "gen_userunit_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, Database);
                    FillParameters(gen_userunit, cmd, Database);
                    
                    IList<gen_userunitEntity> itemList = new List<gen_userunitEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_userunitEntity(reader));
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
                throw GetDataAccessException(ex, SourceOfException("Igen_userunitDataAccess.GetSinglegen_userunit"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<gen_userunitEntity>> Igen_userunitDataAccessObjects.GAPgListView(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "gen_userunit_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, gen_userunit.SortExpression);
                    AddPageSizeParameter(cmd, gen_userunit.PageSize);
                    AddCurrentPageParameter(cmd, gen_userunit.CurrentPage);                    
                    FillSequrityParameters(gen_userunit.BaseSecurityParam, cmd, Database);
                    
					FillParameters(gen_userunit, cmd,Database);
                    
					if (!string.IsNullOrEmpty (gen_userunit.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+gen_userunit.strCommonSerachParam+"%");

                    IList<gen_userunitEntity> itemList = new List<gen_userunitEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_userunitEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						gen_userunit.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_userunitDataAccess.GAPgListViewgen_userunit"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
            
	}
}