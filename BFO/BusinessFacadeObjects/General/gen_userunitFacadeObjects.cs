﻿
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
    public sealed partial class gen_userunitFacadeObjects : BaseFacade, Igen_userunitFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "gen_userunitFacadeObjects";
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

        public gen_userunitFacadeObjects()
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

        ~gen_userunitFacadeObjects()
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
		
		async Task<long> Igen_userunitFacadeObjects.Delete(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.Creategen_userunitDataAccess().Delete(gen_userunit, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_userunitFacade.Deletegen_userunit"));
            }
        }
		
		async Task<long> Igen_userunitFacadeObjects.Update(gen_userunitEntity gen_userunit , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_userunitDataAccess().Update(gen_userunit,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Igen_userunitFacade.Updategen_userunit"));
            }
		}
		
		async Task<long> Igen_userunitFacadeObjects.Add(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_userunitDataAccess().Add(gen_userunit, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_userunitFacade.Addgen_userunit"));
            }
		}
		
        async Task<long> Igen_userunitFacadeObjects.SaveList(List<gen_userunitEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<gen_userunitEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<gen_userunitEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<gen_userunitEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.Creategen_userunitDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_gen_userunit"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<gen_userunitEntity>> Igen_userunitFacadeObjects.GetAll(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_userunitDataAccess().GetAll(gen_userunit, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<gen_userunitEntity> Igen_userunitFacade.GetAllgen_userunit"));
            }
		}
		
		async Task<IList<gen_userunitEntity>> Igen_userunitFacadeObjects.GetAllByPages(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_userunitDataAccess().GetAllByPages(gen_userunit,cancellationToken);
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
        async  Task<gen_userunitEntity>  Igen_userunitFacadeObjects.GetSingle(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_userunitDataAccess().GetSingle(gen_userunit,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("gen_userunitEntity Igen_userunitFacade.GetSinglegen_userunit"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<gen_userunitEntity>> Igen_userunitFacadeObjects.GAPgListView(gen_userunitEntity gen_userunit, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_userunitDataAccess().GAPgListView(gen_userunit,cancellationToken);
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