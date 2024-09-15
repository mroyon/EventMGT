
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
    public sealed partial class gen_eventcategoryFacadeObjects : BaseFacade, Igen_eventcategoryFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "gen_eventcategoryFacadeObjects";
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

        public gen_eventcategoryFacadeObjects()
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

        ~gen_eventcategoryFacadeObjects()
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
		
		async Task<long> Igen_eventcategoryFacadeObjects.Delete(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.Creategen_eventcategoryDataAccess().Delete(gen_eventcategory, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_eventcategoryFacade.Deletegen_eventcategory"));
            }
        }
		
		async Task<long> Igen_eventcategoryFacadeObjects.Update(gen_eventcategoryEntity gen_eventcategory , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventcategoryDataAccess().Update(gen_eventcategory,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Igen_eventcategoryFacade.Updategen_eventcategory"));
            }
		}
		
		async Task<long> Igen_eventcategoryFacadeObjects.Add(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventcategoryDataAccess().Add(gen_eventcategory, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_eventcategoryFacade.Addgen_eventcategory"));
            }
		}
		
        async Task<long> Igen_eventcategoryFacadeObjects.SaveList(List<gen_eventcategoryEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<gen_eventcategoryEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<gen_eventcategoryEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<gen_eventcategoryEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.Creategen_eventcategoryDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_gen_eventcategory"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<gen_eventcategoryEntity>> Igen_eventcategoryFacadeObjects.GetAll(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventcategoryDataAccess().GetAll(gen_eventcategory, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_eventcategoryEntity> Igen_eventcategoryFacade.GetAllgen_eventcategory"));
            }
		}
		
		async Task<IList<gen_eventcategoryEntity>> Igen_eventcategoryFacadeObjects.GetAllByPages(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventcategoryDataAccess().GetAllByPages(gen_eventcategory,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_eventcategoryEntity> Igen_eventcategoryFacade.GetAllByPagesgen_eventcategory"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        async Task<long> Igen_eventcategoryFacadeObjects.SaveMasterDetgen_eventinfo(gen_eventcategoryEntity Master, List<gen_eventinfoEntity> DetailList, CancellationToken cancellationToken)
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
                    return await DataAccessFactory.Creategen_eventcategoryDataAccess().SaveMasterDetgen_eventinfo(Master, listAdded, listUpdated, listDeleted, cancellationToken);
               }
               catch (Exception ex)
               {
                    throw GetFacadeException(ex, SourceOfException("Imer_poFacade.SaveMasterDetgen_eventinfo"));
               }
        }
        
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<gen_eventcategoryEntity>  Igen_eventcategoryFacadeObjects.GetSingle(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventcategoryDataAccess().GetSingle(gen_eventcategory,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("gen_eventcategoryEntity Igen_eventcategoryFacade.GetSinglegen_eventcategory"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<gen_eventcategoryEntity>> Igen_eventcategoryFacadeObjects.GAPgListView(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventcategoryDataAccess().GAPgListView(gen_eventcategory,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_eventcategoryEntity> Igen_eventcategoryFacade.GAPgListViewgen_eventcategory"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
        #region for Dropdown 
		async Task<IList<gen_dropdownEntity>> Igen_eventcategoryFacadeObjects.GetDataForDropDown(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventcategoryDataAccess().GetDataForDropDown(gen_eventcategory,cancellationToken);
			}
			catch (Exception ex)
			{
				throw GetFacadeException(ex, SourceOfException("IList<gen_eventcategoryEntity> Igen_eventcategoryFacade.GetDataForDropDown")); 
			}
		}
		#endregion
    
        
    
    
        #endregion
	}
}