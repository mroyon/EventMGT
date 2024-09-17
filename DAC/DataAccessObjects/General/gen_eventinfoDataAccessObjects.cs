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
	
	internal sealed partial class gen_eventinfoDataAccessObjects : BaseDataAccess, Igen_eventinfoDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "gen_eventinfoDataAccessObjects";
        
		public gen_eventinfoDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(gen_eventinfoEntity gen_eventinfo, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (gen_eventinfo.eventid.HasValue)
				Database.AddInParameter(cmd, "@EventID", DbType.Int64, gen_eventinfo.eventid);
            if (forDelete) return;
			if (gen_eventinfo.eventcategoryid.HasValue)
				Database.AddInParameter(cmd, "@EventCategoryID", DbType.Int64, gen_eventinfo.eventcategoryid);
			if (!(string.IsNullOrEmpty(gen_eventinfo.eventcode)))
				Database.AddInParameter(cmd, "@EventCode", DbType.String, gen_eventinfo.eventcode);
			if (!(string.IsNullOrEmpty(gen_eventinfo.eventname)))
				Database.AddInParameter(cmd, "@EventName", DbType.String, gen_eventinfo.eventname);
			if ((gen_eventinfo.eventstartdate.HasValue))
				Database.AddInParameter(cmd, "@EventStartDate", DbType.DateTime, gen_eventinfo.eventstartdate);
			if ((gen_eventinfo.eventenddate.HasValue))
				Database.AddInParameter(cmd, "@EventEndDate", DbType.DateTime, gen_eventinfo.eventenddate);
			if (!(string.IsNullOrEmpty(gen_eventinfo.eventdescription)))
				Database.AddInParameter(cmd, "@EventDescription", DbType.String, gen_eventinfo.eventdescription);
			if (!(string.IsNullOrEmpty(gen_eventinfo.eventdescription1)))
				Database.AddInParameter(cmd, "@EventDescription1", DbType.String, gen_eventinfo.eventdescription1);
			if (!(string.IsNullOrEmpty(gen_eventinfo.eventdescription2)))
				Database.AddInParameter(cmd, "@EventDescription2", DbType.String, gen_eventinfo.eventdescription2);
			if (!(string.IsNullOrEmpty(gen_eventinfo.eventspecialnote)))
				Database.AddInParameter(cmd, "@EventSpecialNote", DbType.String, gen_eventinfo.eventspecialnote);
			if ((gen_eventinfo.isdeleted != null))
				Database.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, gen_eventinfo.isdeleted);
			if (gen_eventinfo.eventorganizedby.HasValue)
				Database.AddInParameter(cmd, "@EventOrganizedBy", DbType.Int64, gen_eventinfo.eventorganizedby);
			if ((gen_eventinfo.ex_date1.HasValue))
				Database.AddInParameter(cmd, "@Ex_Date1", DbType.DateTime, gen_eventinfo.ex_date1);
			if ((gen_eventinfo.ex_date2.HasValue))
				Database.AddInParameter(cmd, "@Ex_Date2", DbType.DateTime, gen_eventinfo.ex_date2);
			if (!(string.IsNullOrEmpty(gen_eventinfo.ex_nvarchar1)))
				Database.AddInParameter(cmd, "@Ex_Nvarchar1", DbType.String, gen_eventinfo.ex_nvarchar1);
			if (!(string.IsNullOrEmpty(gen_eventinfo.ex_nvarchar2)))
				Database.AddInParameter(cmd, "@Ex_Nvarchar2", DbType.String, gen_eventinfo.ex_nvarchar2);
			if (!(string.IsNullOrEmpty(gen_eventinfo.ex_nvarchar3)))
				Database.AddInParameter(cmd, "@Ex_Nvarchar3", DbType.String, gen_eventinfo.ex_nvarchar3);
			if (gen_eventinfo.ex_bigint1.HasValue)
				Database.AddInParameter(cmd, "@Ex_Bigint1", DbType.Int64, gen_eventinfo.ex_bigint1);
			if (gen_eventinfo.ex_bigint2.HasValue)
				Database.AddInParameter(cmd, "@Ex_Bigint2", DbType.Int64, gen_eventinfo.ex_bigint2);
			if (gen_eventinfo.ex_decimal1.HasValue)
				Database.AddInParameter(cmd, "@Ex_Decimal1", DbType.Decimal, gen_eventinfo.ex_decimal1);
			if (gen_eventinfo.ex_decimal2.HasValue)
				Database.AddInParameter(cmd, "@Ex_Decimal2", DbType.Decimal, gen_eventinfo.ex_decimal2);

        }
		
        
		#region Add Operation

        async Task<long> Igen_eventinfoDataAccessObjects.Add(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "gen_eventinfo_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(gen_eventinfo, cmd,Database);
                FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("Igen_eventinfoDataAccess.Addgen_eventinfo"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> Igen_eventinfoDataAccessObjects.Update(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "gen_eventinfo_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(gen_eventinfo, cmd,Database);
                FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("Igen_eventinfoDataAccess.Updategen_eventinfo"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> Igen_eventinfoDataAccessObjects.Delete(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "gen_eventinfo_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(gen_eventinfo, cmd,Database, true);
                FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, Database);
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
                   throw GetDataAccessException(ex, SourceOfException("Igen_eventinfoDataAccess.Deletegen_eventinfo"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> Igen_eventinfoDataAccessObjects.SaveList(IList<gen_eventinfoEntity> listAdded, IList<gen_eventinfoEntity> listUpdated, IList<gen_eventinfoEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "gen_eventinfo_Ins";
            const string SPUpdate = "gen_eventinfo_Upd";
            const string SPDelete = "gen_eventinfo_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (gen_eventinfoEntity gen_eventinfo in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(gen_eventinfo, cmd, Database, true);
                            FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, Database);
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
                    foreach (gen_eventinfoEntity gen_eventinfo in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(gen_eventinfo, cmd, Database);
                            FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, Database);
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
                    foreach (gen_eventinfoEntity gen_eventinfo in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(gen_eventinfo, cmd, Database);
                            FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, Database);
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
                throw GetDataAccessException(ex, SourceOfException("Igen_eventinfoDataAccess.Save_gen_eventinfo"));
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
       IList<gen_eventinfoEntity> listAdded, 
       IList<gen_eventinfoEntity> listUpdated, 
       IList<gen_eventinfoEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "gen_eventinfo_Ins";
            const string SPUpdate = "gen_eventinfo_Upd";
            const string SPDelete = "gen_eventinfo_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (gen_eventinfoEntity gen_eventinfo in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(gen_eventinfo, cmd, db, true);
                            FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, db);
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
                    foreach (gen_eventinfoEntity gen_eventinfo in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(gen_eventinfo, cmd, db);
                            FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, db);
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
                    foreach (gen_eventinfoEntity gen_eventinfo in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(gen_eventinfo, cmd, db);
                            FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, db);
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
               
                throw GetDataAccessException(ex, SourceOfException("Igen_eventinfoDataAccess.Save_gen_eventinfo"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<gen_eventinfoEntity>> Igen_eventinfoDataAccessObjects.GetAll(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "gen_eventinfo_GA";
                IList<gen_eventinfoEntity> itemList = new List<gen_eventinfoEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, gen_eventinfo.SortExpression);
                    FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, Database);
                    FillParameters(gen_eventinfo, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            gen_eventinfoEntity obj = new gen_eventinfoEntity(reader);
                            if (!reader.IsDBNull(reader.GetOrdinal("Unit"))) obj.unitname = reader.GetString(reader.GetOrdinal("Unit"));
                            itemList.Add(obj);
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_eventinfoDataAccess.GetAllgen_eventinfo"));
            }	
        }
		
        async Task<IList<gen_eventinfoEntity>> Igen_eventinfoDataAccessObjects.GetAllByPages(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "gen_eventinfo_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, gen_eventinfo.SortExpression);
                    AddPageSizeParameter(cmd, gen_eventinfo.PageSize);
                    AddCurrentPageParameter(cmd, gen_eventinfo.CurrentPage);                    
                    FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, Database);
                    
					FillParameters(gen_eventinfo, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (gen_eventinfo.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+gen_eventinfo.strCommonSerachParam+"%");

                    IList<gen_eventinfoEntity> itemList = new List<gen_eventinfoEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_eventinfoEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						gen_eventinfo.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_eventinfoDataAccess.GetAllByPagesgen_eventinfo"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        
        async Task<long> Igen_eventinfoDataAccessObjects.SaveMasterDetgen_eventfileinfo(gen_eventinfoEntity masterEntity, 
        IList<gen_eventfileinfoEntity> listAdded, 
        IList<gen_eventfileinfoEntity> listUpdated,
        IList<gen_eventfileinfoEntity> listDeleted, 
        CancellationToken cancellationToken)
        {
			long returnCode = -99;
                Int64 PrimaryKeyMaster = -99;
            
            string SP = "";
            const string MasterSPInsert = "gen_eventinfo_Ins";
            const string MasterSPUpdate = "gen_eventinfo_Upd";
            const string MasterSPDelete = "gen_eventinfo_Del";
            
			
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
                                item.eventid=PrimaryKeyMaster;
                            }
                        }
                        gen_eventfileinfoDataAccessObjects objgen_eventfileinfo=new gen_eventfileinfoDataAccessObjects(this.Context);
                        objgen_eventfileinfo.SaveList(Database, transaction, listAdded, listUpdated, listDeleted, cancellationToken);
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
                throw GetDataAccessException(ex, SourceOfException("Igen_eventinfoDataAccess.SaveDsgen_eventinfo"));
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
        async Task<gen_eventinfoEntity> Igen_eventinfoDataAccessObjects.GetSingle(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "gen_eventinfo_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, Database);
                    FillParameters(gen_eventinfo, cmd, Database);
                    
                    IList<gen_eventinfoEntity> itemList = new List<gen_eventinfoEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_eventinfoEntity(reader));
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
                throw GetDataAccessException(ex, SourceOfException("Igen_eventinfoDataAccess.GetSinglegen_eventinfo"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<gen_eventinfoEntity>> Igen_eventinfoDataAccessObjects.GAPgListView(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "gen_eventinfo_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, gen_eventinfo.SortExpression);
                    AddPageSizeParameter(cmd, gen_eventinfo.PageSize);
                    AddCurrentPageParameter(cmd, gen_eventinfo.CurrentPage);                    
                    FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, Database);
                    
					FillParameters(gen_eventinfo, cmd,Database);
                    
					if (!string.IsNullOrEmpty (gen_eventinfo.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+gen_eventinfo.strCommonSerachParam+"%");

                    IList<gen_eventinfoEntity> itemList = new List<gen_eventinfoEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_eventinfoEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						gen_eventinfo.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_eventinfoDataAccess.GAPgListViewgen_eventinfo"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
        #region for Dropdown 
		async Task<IList<gen_dropdownEntity>> Igen_eventinfoDataAccessObjects.GetDataForDropDown(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
		{
			try
			{
				const string SP = "gen_eventinfo_GAPgDropDown";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
					AddSortExpressionParameter(cmd, gen_eventinfo.SortExpression);
					AddPageSizeParameter(cmd, gen_eventinfo.PageSize);
					AddCurrentPageParameter(cmd, gen_eventinfo.CurrentPage);                    
					FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, Database);
					FillParameters(gen_eventinfo, cmd,Database);
					if (!string.IsNullOrEmpty(gen_eventinfo.strCommonSerachParam))
						Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String, " % " + gen_eventinfo.strCommonSerachParam + " % ");
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
						gen_eventinfo.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
					}
					cmd.Dispose();
					return itemList;
				}
			}
			catch (Exception ex)
			{
				throw GetDataAccessException(ex, SourceOfException("Igen_eventinfoDataAccess.GetDataForDropDown"));
			}
		}
		#endregion
    
	}
}