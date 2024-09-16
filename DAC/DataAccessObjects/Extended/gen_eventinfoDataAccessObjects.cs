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

    internal sealed partial class gen_eventinfoDataAccessObjects
    {


        async Task<long> Igen_eventinfoDataAccessObjects.AddWithFiles(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "gen_eventinfo_Ins_Ext";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            try
            {
                using (DbCommand cmd = Database.GetStoredProcCommand(SP))
                {
                    FillParameters(gen_eventinfo, cmd, Database);
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

                gen_eventfileinfoDataAccessObjects gen_EventfileinfoDataAccessObjects = new gen_eventfileinfoDataAccessObjects(this.Context);
               
                IList<gen_eventfileinfoEntity> listAdded = gen_eventinfo.EventfileinfoList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                foreach (var item in listAdded)
                {
                        item.eventid=  returnCode;
                }
                IList<gen_eventfileinfoEntity> listUpdated = gen_eventinfo.EventfileinfoList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<gen_eventfileinfoEntity> listDeleted = gen_eventinfo.EventfileinfoList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);

                await gen_EventfileinfoDataAccessObjects.SaveList(Database, transaction, listAdded, listUpdated, listDeleted, cancellationToken);


                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
                connection.Close();
                connection = null;
            }


            return returnCode;
        }


         async Task<long> Igen_eventinfoDataAccessObjects.UpdateWithFiles(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "gen_eventinfo_Upd_EXT";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            try
            {
                using (DbCommand cmd = Database.GetStoredProcCommand(SP))
                {
                    FillParameters(gen_eventinfo, cmd, Database);
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

                gen_eventfileinfoDataAccessObjects gen_EventfileinfoDataAccessObjects = new gen_eventfileinfoDataAccessObjects(this.Context);
               
                IList<gen_eventfileinfoEntity> listAdded = gen_eventinfo.EventfileinfoList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                foreach (var item in listAdded)
                {
                        item.eventid=  returnCode;
                }
                IList<gen_eventfileinfoEntity> listUpdated = gen_eventinfo.EventfileinfoList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<gen_eventfileinfoEntity> listDeleted = gen_eventinfo.EventfileinfoList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);

                await gen_EventfileinfoDataAccessObjects.SaveList(Database, transaction, listAdded, listUpdated, listDeleted, cancellationToken);


                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
                connection.Close();
                connection = null;
            }


            return returnCode;
        }


        async Task<IList<gen_eventinfoEntity>> Igen_eventinfoDataAccessObjects.SearchEventInfo(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
        {
            try
            {
                const string SP = "gen_eventinfo_GA_Search";
                using (DbCommand cmd = Database.GetStoredProcCommand(SP))
                {

                    if (gen_eventinfo.eventid.HasValue)
                        Database.AddInParameter(cmd, "@EventID", DbType.Int64, gen_eventinfo.eventid);
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

                    if (gen_eventinfo.unitid.HasValue)
                        Database.AddInParameter(cmd, "@UnitID", DbType.Int64, gen_eventinfo.unitid);

                    AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, gen_eventinfo.SortExpression);
                    AddPageSizeParameter(cmd, gen_eventinfo.PageSize);
                    AddCurrentPageParameter(cmd, gen_eventinfo.CurrentPage);
                    FillSequrityParameters(gen_eventinfo.BaseSecurityParam, cmd, Database);

                    if (!string.IsNullOrEmpty(gen_eventinfo.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String, "%" + gen_eventinfo.strCommonSerachParam + "%");

                    IList<gen_eventinfoEntity> itemList = new List<gen_eventinfoEntity>();

                    IAsyncResult result = Database.BeginExecuteReader(cmd, null, null);
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

                    if (itemList.Count > 0)
                    {
                        itemList[0].RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
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

    }
}


