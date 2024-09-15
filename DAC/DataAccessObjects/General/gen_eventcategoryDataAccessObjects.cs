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
	
	internal sealed partial class gen_eventcategoryDataAccessObjects : BaseDataAccess, Igen_eventcategoryDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "gen_eventcategoryDataAccessObjects";
        
		public gen_eventcategoryDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(gen_eventcategoryEntity gen_eventcategory, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (gen_eventcategory.eventcategoryid.HasValue)
				Database.AddInParameter(cmd, "@EventCategoryID", DbType.Int64, gen_eventcategory.eventcategoryid);
            if (forDelete) return;
			if (!(string.IsNullOrEmpty(gen_eventcategory.eventcategory)))
				Database.AddInParameter(cmd, "@EventCategory", DbType.String, gen_eventcategory.eventcategory);
			if (!(string.IsNullOrEmpty(gen_eventcategory.description)))
				Database.AddInParameter(cmd, "@Description", DbType.String, gen_eventcategory.description);
			if ((gen_eventcategory.ex_date1.HasValue))
				Database.AddInParameter(cmd, "@Ex_Date1", DbType.DateTime, gen_eventcategory.ex_date1);
			if ((gen_eventcategory.ex_date2.HasValue))
				Database.AddInParameter(cmd, "@Ex_Date2", DbType.DateTime, gen_eventcategory.ex_date2);
			if (!(string.IsNullOrEmpty(gen_eventcategory.ex_nvarchar1)))
				Database.AddInParameter(cmd, "@Ex_Nvarchar1", DbType.String, gen_eventcategory.ex_nvarchar1);
			if (!(string.IsNullOrEmpty(gen_eventcategory.ex_nvarchar2)))
				Database.AddInParameter(cmd, "@Ex_Nvarchar2", DbType.String, gen_eventcategory.ex_nvarchar2);
			if (!(string.IsNullOrEmpty(gen_eventcategory.ex_nvarchar3)))
				Database.AddInParameter(cmd, "@Ex_Nvarchar3", DbType.String, gen_eventcategory.ex_nvarchar3);
			if (gen_eventcategory.ex_bigint1.HasValue)
				Database.AddInParameter(cmd, "@Ex_Bigint1", DbType.Int64, gen_eventcategory.ex_bigint1);
			if (gen_eventcategory.ex_bigint2.HasValue)
				Database.AddInParameter(cmd, "@Ex_Bigint2", DbType.Int64, gen_eventcategory.ex_bigint2);
			if (gen_eventcategory.ex_decimal1.HasValue)
				Database.AddInParameter(cmd, "@Ex_Decimal1", DbType.Decimal, gen_eventcategory.ex_decimal1);
			if (gen_eventcategory.ex_decimal2.HasValue)
				Database.AddInParameter(cmd, "@Ex_Decimal2", DbType.Decimal, gen_eventcategory.ex_decimal2);

        }
		
        
		#region Add Operation

        async Task<long> Igen_eventcategoryDataAccessObjects.Add(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "gen_eventcategory_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(gen_eventcategory, cmd,Database);
                FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("Igen_eventcategoryDataAccess.Addgen_eventcategory"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> Igen_eventcategoryDataAccessObjects.Update(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "gen_eventcategory_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(gen_eventcategory, cmd,Database);
                FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("Igen_eventcategoryDataAccess.Updategen_eventcategory"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> Igen_eventcategoryDataAccessObjects.Delete(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "gen_eventcategory_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(gen_eventcategory, cmd,Database, true);
                FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, Database);
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
                   throw GetDataAccessException(ex, SourceOfException("Igen_eventcategoryDataAccess.Deletegen_eventcategory"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> Igen_eventcategoryDataAccessObjects.SaveList(IList<gen_eventcategoryEntity> listAdded, IList<gen_eventcategoryEntity> listUpdated, IList<gen_eventcategoryEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "gen_eventcategory_Ins";
            const string SPUpdate = "gen_eventcategory_Upd";
            const string SPDelete = "gen_eventcategory_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (gen_eventcategoryEntity gen_eventcategory in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(gen_eventcategory, cmd, Database, true);
                            FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, Database);
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
                    foreach (gen_eventcategoryEntity gen_eventcategory in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(gen_eventcategory, cmd, Database);
                            FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, Database);
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
                    foreach (gen_eventcategoryEntity gen_eventcategory in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(gen_eventcategory, cmd, Database);
                            FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, Database);
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
                throw GetDataAccessException(ex, SourceOfException("Igen_eventcategoryDataAccess.Save_gen_eventcategory"));
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
       IList<gen_eventcategoryEntity> listAdded, 
       IList<gen_eventcategoryEntity> listUpdated, 
       IList<gen_eventcategoryEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "gen_eventcategory_Ins";
            const string SPUpdate = "gen_eventcategory_Upd";
            const string SPDelete = "gen_eventcategory_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (gen_eventcategoryEntity gen_eventcategory in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(gen_eventcategory, cmd, db, true);
                            FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, db);
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
                    foreach (gen_eventcategoryEntity gen_eventcategory in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(gen_eventcategory, cmd, db);
                            FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, db);
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
                    foreach (gen_eventcategoryEntity gen_eventcategory in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(gen_eventcategory, cmd, db);
                            FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, db);
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
               
                throw GetDataAccessException(ex, SourceOfException("Igen_eventcategoryDataAccess.Save_gen_eventcategory"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<gen_eventcategoryEntity>> Igen_eventcategoryDataAccessObjects.GetAll(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "gen_eventcategory_GA";
                IList<gen_eventcategoryEntity> itemList = new List<gen_eventcategoryEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, gen_eventcategory.SortExpression);
                    FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, Database);
                    FillParameters(gen_eventcategory, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_eventcategoryEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_eventcategoryDataAccess.GetAllgen_eventcategory"));
            }	
        }
		
        async Task<IList<gen_eventcategoryEntity>> Igen_eventcategoryDataAccessObjects.GetAllByPages(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "gen_eventcategory_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, gen_eventcategory.SortExpression);
                    AddPageSizeParameter(cmd, gen_eventcategory.PageSize);
                    AddCurrentPageParameter(cmd, gen_eventcategory.CurrentPage);                    
                    FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, Database);
                    
					FillParameters(gen_eventcategory, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (gen_eventcategory.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+gen_eventcategory.strCommonSerachParam+"%");

                    IList<gen_eventcategoryEntity> itemList = new List<gen_eventcategoryEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_eventcategoryEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						gen_eventcategory.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_eventcategoryDataAccess.GetAllByPagesgen_eventcategory"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        
        async Task<long> Igen_eventcategoryDataAccessObjects.SaveMasterDetgen_eventinfo(gen_eventcategoryEntity masterEntity, 
        IList<gen_eventinfoEntity> listAdded, 
        IList<gen_eventinfoEntity> listUpdated,
        IList<gen_eventinfoEntity> listDeleted, 
        CancellationToken cancellationToken)
        {
			long returnCode = -99;
                Int64 PrimaryKeyMaster = -99;
            
            string SP = "";
            const string MasterSPInsert = "gen_eventcategory_Ins";
            const string MasterSPUpdate = "gen_eventcategory_Upd";
            const string MasterSPDelete = "gen_eventcategory_Del";
            
			
            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
			
            if (masterEntity.CurrentState == BaseEntity.EntityState.Added)
                SP = MasterSPInsert;
            else if (masterEntity.CurrentState == BaseEntity.EntityState.Changed)
                SP = MasterSPUpdate;
            else if (masterEntity.CurrentState == BaseEntity.EntityState.Deleted)
                 SP = MasterSPDelete;
            else
            {
                throw new Exception("Nothing to save.");
            }
            DateTime dt = DateTime.Now;
            
            try
            {
                using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    if (masterEntity.CurrentState == BaseEntity.EntityState.Added || masterEntity.CurrentState == BaseEntity.EntityState.Changed)
                    {
                        FillParameters(masterEntity, cmd, Database);
                    }
                    else
                    {
                        FillParameters(masterEntity, cmd, Database, true);
                    }
                    FillSequrityParameters(masterEntity.BaseSecurityParam, cmd, Database);                    
                    AddOutputParameter(cmd, Database);
					
					if (masterEntity.CurrentState != BaseEntity.EntityState.Deleted)
                    {
                        IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                        while (!result.IsCompleted)
                        {
                        }
                        returnCode = Database.EndExecuteNonQuery(result);
                                PrimaryKeyMaster = (Int64)(cmd.Parameters["@RETURN_KEY"].Value);
                                masterEntity.RETURN_KEY = PrimaryKeyMaster;
                        
                    }
                    else
                    {
                        returnCode = 1;
                    }
				
                    if (returnCode>0)
                    {
                        if (masterEntity.CurrentState != BaseEntity.EntityState.Deleted)
                        {
                            foreach (var item in listAdded)
                            {
                                item.eventcategoryid=PrimaryKeyMaster;
                            }
                        }
                        gen_eventinfoDataAccessObjects objgen_eventinfo=new gen_eventinfoDataAccessObjects(this.Context);
                        objgen_eventinfo.SaveList(Database, transaction, listAdded, listUpdated, listDeleted, cancellationToken);
                    }
                    if (masterEntity.CurrentState == BaseEntity.EntityState.Deleted)
                        returnCode = Database.ExecuteNonQuery(cmd, transaction);
                        cmd.Dispose();
                }
				transaction.Commit();                
			}
			catch (Exception ex)
            {
                transaction.Rollback();
                throw GetDataAccessException(ex, SourceOfException("Igen_eventcategoryDataAccess.SaveDsgen_eventcategory"));
            }
            finally
            {
                transaction.Dispose();
                connection.Close();
                connection = null;
            }
            return returnCode;
		}
        
        #endregion
        
        
        #region Simple load Single Row
        async Task<gen_eventcategoryEntity> Igen_eventcategoryDataAccessObjects.GetSingle(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "gen_eventcategory_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, Database);
                    FillParameters(gen_eventcategory, cmd, Database);
                    
                    IList<gen_eventcategoryEntity> itemList = new List<gen_eventcategoryEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_eventcategoryEntity(reader));
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
                throw GetDataAccessException(ex, SourceOfException("Igen_eventcategoryDataAccess.GetSinglegen_eventcategory"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<gen_eventcategoryEntity>> Igen_eventcategoryDataAccessObjects.GAPgListView(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "gen_eventcategory_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, gen_eventcategory.SortExpression);
                    AddPageSizeParameter(cmd, gen_eventcategory.PageSize);
                    AddCurrentPageParameter(cmd, gen_eventcategory.CurrentPage);                    
                    FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, Database);
                    
					FillParameters(gen_eventcategory, cmd,Database);
                    
					if (!string.IsNullOrEmpty (gen_eventcategory.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+gen_eventcategory.strCommonSerachParam+"%");

                    IList<gen_eventcategoryEntity> itemList = new List<gen_eventcategoryEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_eventcategoryEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						gen_eventcategory.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_eventcategoryDataAccess.GAPgListViewgen_eventcategory"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
        #region for Dropdown 
		async Task<IList<gen_dropdownEntity>> Igen_eventcategoryDataAccessObjects.GetDataForDropDown(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
		{
			try
			{
				const string SP = "gen_eventcategory_GAPgDropDown";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
					AddSortExpressionParameter(cmd, gen_eventcategory.SortExpression);
					AddPageSizeParameter(cmd, gen_eventcategory.PageSize);
					AddCurrentPageParameter(cmd, gen_eventcategory.CurrentPage);                    
					FillSequrityParameters(gen_eventcategory.BaseSecurityParam, cmd, Database);
					FillParameters(gen_eventcategory, cmd,Database);
					if (!string.IsNullOrEmpty(gen_eventcategory.strCommonSerachParam))
						Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String, " % " + gen_eventcategory.strCommonSerachParam + " % ");
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
						gen_eventcategory.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
					}
					cmd.Dispose();
					return itemList;
				}
			}
			catch (Exception ex)
			{
				throw GetDataAccessException(ex, SourceOfException("Igen_eventcategoryDataAccess.GetDataForDropDown"));
			}
		}
		#endregion
    
	}
}