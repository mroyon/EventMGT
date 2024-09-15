
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
    public sealed partial class gen_unitFacadeObjects : BaseFacade, Igen_unitFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "gen_unitFacadeObjects";
        private bool _isDisposed;
        private Context _currentContext;

        private BaseDataAccessFactory _dataAccessFactory;

        #endregion

        #region Private Properties

        private Context CurrentContext
        {
            [DebuggerStepThrough()]
            get
            {
                if (_currentContext == null)
                {
                    _currentContext = new Context();
                }

                return _currentContext;
            }
        }

        private BaseDataAccessFactory DataAccessFactory
        {
            [DebuggerStepThrough()]
            get
            {
                if (_dataAccessFactory == null)
                {
                    _dataAccessFactory = BaseDataAccessFactory.Create(CurrentContext);
                }

                return _dataAccessFactory;
            }
        }

        #endregion

        #region Constructer & Destructor

        public gen_unitFacadeObjects()
            : base()
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (_currentContext != null)
                    {
                        _currentContext.Dispose();
                    }
                }
            }

            _isDisposed = true;
        }

        ~gen_unitFacadeObjects()
        {
            Dispose(false);
        }
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        #endregion
		
		#region Business Facade
		
		#region Save Update Delete List	
		
		async Task<long> Igen_unitFacadeObjects.Delete(gen_unitEntity gen_unit, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.Creategen_unitDataAccess().Delete(gen_unit, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_unitFacade.Deletegen_unit"));
            }
        }
		
		async Task<long> Igen_unitFacadeObjects.Update(gen_unitEntity gen_unit , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_unitDataAccess().Update(gen_unit,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Igen_unitFacade.Updategen_unit"));
            }
		}
		
		async Task<long> Igen_unitFacadeObjects.Add(gen_unitEntity gen_unit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_unitDataAccess().Add(gen_unit, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_unitFacade.Addgen_unit"));
            }
		}
		
        async Task<long> Igen_unitFacadeObjects.SaveList(List<gen_unitEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<gen_unitEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<gen_unitEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<gen_unitEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.Creategen_unitDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_gen_unit"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<gen_unitEntity>> Igen_unitFacadeObjects.GetAll(gen_unitEntity gen_unit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_unitDataAccess().GetAll(gen_unit, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_unitEntity> Igen_unitFacade.GetAllgen_unit"));
            }
		}
		
		async Task<IList<gen_unitEntity>> Igen_unitFacadeObjects.GetAllByPages(gen_unitEntity gen_unit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_unitDataAccess().GetAllByPages(gen_unit,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_unitEntity> Igen_unitFacade.GetAllByPagesgen_unit"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        async Task<long> Igen_unitFacadeObjects.SaveMasterDetgen_eventinfo(gen_unitEntity Master, List<gen_eventinfoEntity> DetailList, CancellationToken cancellationToken)
        {
            try
               {
                    DetailList.ForEach(P => P.BaseSecurityParam = new SecurityCapsule());
                    DetailList.ForEach(P => P.BaseSecurityParam = Master.BaseSecurityParam);
                    if (Master.CurrentState == BaseEntity.EntityState.Deleted)
						DetailList.ForEach(p => p.CurrentState = BaseEntity.EntityState.Deleted);
                    IList<gen_eventinfoEntity> listAdded = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                    IList<gen_eventinfoEntity> listUpdated = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                    IList<gen_eventinfoEntity> listDeleted = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
                    return await DataAccessFactory.Creategen_unitDataAccess().SaveMasterDetgen_eventinfo(Master, listAdded, listUpdated, listDeleted, cancellationToken);
               }
               catch (Exception ex)
               {
                    throw GetFacadeException(ex, SourceOfException("Imer_poFacade.SaveMasterDetgen_eventinfo"));
               }
        }
        
        
        async Task<long> Igen_unitFacadeObjects.SaveMasterDetgen_userunit(gen_unitEntity Master, List<gen_userunitEntity> DetailList, CancellationToken cancellationToken)
        {
            try
               {
                    DetailList.ForEach(P => P.BaseSecurityParam = new SecurityCapsule());
                    DetailList.ForEach(P => P.BaseSecurityParam = Master.BaseSecurityParam);
                    if (Master.CurrentState == BaseEntity.EntityState.Deleted)
						DetailList.ForEach(p => p.CurrentState = BaseEntity.EntityState.Deleted);
                    IList<gen_userunitEntity> listAdded = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                    IList<gen_userunitEntity> listUpdated = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                    IList<gen_userunitEntity> listDeleted = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
                    return await DataAccessFactory.Creategen_unitDataAccess().SaveMasterDetgen_userunit(Master, listAdded, listUpdated, listDeleted, cancellationToken);
               }
               catch (Exception ex)
               {
                    throw GetFacadeException(ex, SourceOfException("Imer_poFacade.SaveMasterDetgen_userunit"));
               }
        }
        
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<gen_unitEntity>  Igen_unitFacadeObjects.GetSingle(gen_unitEntity gen_unit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_unitDataAccess().GetSingle(gen_unit,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("gen_unitEntity Igen_unitFacade.GetSinglegen_unit"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<gen_unitEntity>> Igen_unitFacadeObjects.GAPgListView(gen_unitEntity gen_unit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_unitDataAccess().GAPgListView(gen_unit,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_unitEntity> Igen_unitFacade.GAPgListViewgen_unit"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
        #region for Dropdown 
		async Task<IList<gen_dropdownEntity>> Igen_unitFacadeObjects.GetDataForDropDown(gen_unitEntity gen_unit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_unitDataAccess().GetDataForDropDown(gen_unit,cancellationToken);
			}
			catch (Exception ex)
			{
				throw GetFacadeException(ex, SourceOfException("IList<gen_unitEntity> Igen_unitFacade.GetDataForDropDown")); 
			}
		}
		#endregion
    
        
    
    
        #endregion
	}
}