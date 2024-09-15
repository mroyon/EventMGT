
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
    public sealed partial class gen_eventinfoFacadeObjects : BaseFacade, Igen_eventinfoFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "gen_eventinfoFacadeObjects";
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

        public gen_eventinfoFacadeObjects()
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

        ~gen_eventinfoFacadeObjects()
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
		
		async Task<long> Igen_eventinfoFacadeObjects.Delete(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.Creategen_eventinfoDataAccess().Delete(gen_eventinfo, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_eventinfoFacade.Deletegen_eventinfo"));
            }
        }
		
		async Task<long> Igen_eventinfoFacadeObjects.Update(gen_eventinfoEntity gen_eventinfo , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventinfoDataAccess().Update(gen_eventinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Igen_eventinfoFacade.Updategen_eventinfo"));
            }
		}
		
		async Task<long> Igen_eventinfoFacadeObjects.Add(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventinfoDataAccess().Add(gen_eventinfo, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_eventinfoFacade.Addgen_eventinfo"));
            }
		}
		
        async Task<long> Igen_eventinfoFacadeObjects.SaveList(List<gen_eventinfoEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<gen_eventinfoEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<gen_eventinfoEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<gen_eventinfoEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.Creategen_eventinfoDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_gen_eventinfo"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<gen_eventinfoEntity>> Igen_eventinfoFacadeObjects.GetAll(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventinfoDataAccess().GetAll(gen_eventinfo, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_eventinfoEntity> Igen_eventinfoFacade.GetAllgen_eventinfo"));
            }
		}
		
		async Task<IList<gen_eventinfoEntity>> Igen_eventinfoFacadeObjects.GetAllByPages(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventinfoDataAccess().GetAllByPages(gen_eventinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_eventinfoEntity> Igen_eventinfoFacade.GetAllByPagesgen_eventinfo"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        async Task<long> Igen_eventinfoFacadeObjects.SaveMasterDetgen_eventfileinfo(gen_eventinfoEntity Master, List<gen_eventfileinfoEntity> DetailList, CancellationToken cancellationToken)
        {
            try
               {
                    DetailList.ForEach(P => P.BaseSecurityParam = new SecurityCapsule());
                    DetailList.ForEach(P => P.BaseSecurityParam = Master.BaseSecurityParam);
                    if (Master.CurrentState == BaseEntity.EntityState.Deleted)
						DetailList.ForEach(p => p.CurrentState = BaseEntity.EntityState.Deleted);
                    IList<gen_eventfileinfoEntity> listAdded = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                    IList<gen_eventfileinfoEntity> listUpdated = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                    IList<gen_eventfileinfoEntity> listDeleted = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
                    return await DataAccessFactory.Creategen_eventinfoDataAccess().SaveMasterDetgen_eventfileinfo(Master, listAdded, listUpdated, listDeleted, cancellationToken);
               }
               catch (Exception ex)
               {
                    throw GetFacadeException(ex, SourceOfException("Imer_poFacade.SaveMasterDetgen_eventfileinfo"));
               }
        }
        
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<gen_eventinfoEntity>  Igen_eventinfoFacadeObjects.GetSingle(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventinfoDataAccess().GetSingle(gen_eventinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("gen_eventinfoEntity Igen_eventinfoFacade.GetSinglegen_eventinfo"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<gen_eventinfoEntity>> Igen_eventinfoFacadeObjects.GAPgListView(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventinfoDataAccess().GAPgListView(gen_eventinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_eventinfoEntity> Igen_eventinfoFacade.GAPgListViewgen_eventinfo"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
        #region for Dropdown 
		async Task<IList<gen_dropdownEntity>> Igen_eventinfoFacadeObjects.GetDataForDropDown(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventinfoDataAccess().GetDataForDropDown(gen_eventinfo,cancellationToken);
			}
			catch (Exception ex)
			{
				throw GetFacadeException(ex, SourceOfException("IList<gen_eventinfoEntity> Igen_eventinfoFacade.GetDataForDropDown")); 
			}
		}
		#endregion
    
        
    
    
        #endregion
	}
}