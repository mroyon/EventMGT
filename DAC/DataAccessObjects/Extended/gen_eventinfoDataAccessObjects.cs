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
            const string SP = "gen_eventinfo_Ins";

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
            const string SP = "gen_eventinfo_Upd";

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
    }
}


