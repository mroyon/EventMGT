
using AppConfig.ConfigDAAC;
using BDO.Core.Base;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BFO.Base;
using DAC.Core.CoreFactory;
using IBFO.Core.IBusinessFacadeObjects.General;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BFO.Core.BusinessFacadeObjects.General
{
    public sealed partial class gen_userunitFacadeObjects 
    {
		#region Business Facade
		
		#region Save Update Delete List	
		
		async Task<long> Igen_userunitFacadeObjects.Delete_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.Creategen_userunitDataAccess().Delete_Ext(gen_userunit, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_userunitFacade.Deletegen_userunit"));
            }
        }
		
		async Task<long> Igen_userunitFacadeObjects.Update_Ext(gen_userunitEntity gen_userunit , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_userunitDataAccess().Update_Ext(gen_userunit,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Igen_userunitFacade.Updategen_userunit"));
            }
		}
		
		async Task<long> Igen_userunitFacadeObjects.Add_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_userunitDataAccess().Add_Ext(gen_userunit, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_userunitFacade.Addgen_userunit"));
            }
		}
		
        async Task<long> Igen_userunitFacadeObjects.SaveList_Ext(List<gen_userunitEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<gen_userunitEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<gen_userunitEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<gen_userunitEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.Creategen_userunitDataAccess().SaveList_Ext(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_gen_userunit"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<gen_userunitEntity>> Igen_userunitFacadeObjects.GetAll_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_userunitDataAccess().GetAll_Ext(gen_userunit, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_userunitEntity> Igen_userunitFacade.GetAllgen_userunit"));
            }
		}
		
		async Task<IList<gen_userunitEntity>> Igen_userunitFacadeObjects.GetAllByPages_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_userunitDataAccess().GetAllByPages_Ext(gen_userunit,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_userunitEntity> Igen_userunitFacade.GetAllByPagesgen_userunit"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<gen_userunitEntity>  Igen_userunitFacadeObjects.GetSingle_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_userunitDataAccess().GetSingle_Ext(gen_userunit,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("gen_userunitEntity Igen_userunitFacade.GetSinglegen_userunit"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<gen_userunitEntity>> Igen_userunitFacadeObjects.GAPgListView_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_userunitDataAccess().GAPgListView_Ext(gen_userunit,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_userunitEntity> Igen_userunitFacade.GAPgListViewgen_userunit"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
            
        
    
    
        #endregion
	}
}