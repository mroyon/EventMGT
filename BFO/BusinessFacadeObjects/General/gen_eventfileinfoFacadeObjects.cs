
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
    public sealed partial class gen_eventfileinfoFacadeObjects : BaseFacade, Igen_eventfileinfoFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "gen_eventfileinfoFacadeObjects";
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

        public gen_eventfileinfoFacadeObjects()
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

        ~gen_eventfileinfoFacadeObjects()
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
		
		async Task<long> Igen_eventfileinfoFacadeObjects.Delete(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.Creategen_eventfileinfoDataAccess().Delete(gen_eventfileinfo, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_eventfileinfoFacade.Deletegen_eventfileinfo"));
            }
        }
		
		async Task<long> Igen_eventfileinfoFacadeObjects.Update(gen_eventfileinfoEntity gen_eventfileinfo , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventfileinfoDataAccess().Update(gen_eventfileinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Igen_eventfileinfoFacade.Updategen_eventfileinfo"));
            }
		}
		
		async Task<long> Igen_eventfileinfoFacadeObjects.Add(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventfileinfoDataAccess().Add(gen_eventfileinfo, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_eventfileinfoFacade.Addgen_eventfileinfo"));
            }
		}
		
        async Task<long> Igen_eventfileinfoFacadeObjects.SaveList(List<gen_eventfileinfoEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<gen_eventfileinfoEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<gen_eventfileinfoEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<gen_eventfileinfoEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.Creategen_eventfileinfoDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_gen_eventfileinfo"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<gen_eventfileinfoEntity>> Igen_eventfileinfoFacadeObjects.GetAll(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventfileinfoDataAccess().GetAll(gen_eventfileinfo, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_eventfileinfoEntity> Igen_eventfileinfoFacade.GetAllgen_eventfileinfo"));
            }
		}
		
		async Task<IList<gen_eventfileinfoEntity>> Igen_eventfileinfoFacadeObjects.GetAllByPages(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventfileinfoDataAccess().GetAllByPages(gen_eventfileinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_eventfileinfoEntity> Igen_eventfileinfoFacade.GetAllByPagesgen_eventfileinfo"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<gen_eventfileinfoEntity>  Igen_eventfileinfoFacadeObjects.GetSingle(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventfileinfoDataAccess().GetSingle(gen_eventfileinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("gen_eventfileinfoEntity Igen_eventfileinfoFacade.GetSinglegen_eventfileinfo"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<gen_eventfileinfoEntity>> Igen_eventfileinfoFacadeObjects.GAPgListView(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_eventfileinfoDataAccess().GAPgListView(gen_eventfileinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_eventfileinfoEntity> Igen_eventfileinfoFacade.GAPgListViewgen_eventfileinfo"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
            
        
    
    
        #endregion
	}
}