using AppConfig.HelperClasses;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.SecurityModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace Web.Core.Frame.Helpers
{
    public class dataTableButtonPanel : IDisposable
    {
        public IHttpContextAccessor _contextAccessor;
        //public IJwtFactory _jwtFactory;
        //public IOwin_FormActionUseCase _owin_FormActionUseCase;
        //public Owin_FormActionPresenter _owin_FormActionPresenter;


        #region IDisposable Members

        private bool isDisposed = false;

        ~dataTableButtonPanel()
        {
            Dispose(false);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Code to dispose the managed resources of the class
            }
            // Code to dispose the un-managed resources of the class

            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //public dataTableButtonPanel(IHttpContextAccessor contextAccessor
        //    , IJwtFactory jwtFactory
        //    , IOwin_FormActionUseCase owin_FormActionUseCase
        //    , Owin_FormActionPresenter owin_FormActionPresenter)
        //{
        //    _contextAccessor = contextAccessor;
        //    _jwtFactory = jwtFactory;
        //    _owin_FormActionUseCase = owin_FormActionUseCase;
        //    _owin_FormActionPresenter = owin_FormActionPresenter;
        //}
        public dataTableButtonPanel(
            )
        {
        }
        #endregion
        public clsPrivateKeys clsPrivate = new clsPrivateKeys();
        /// <summary>
        /// Basic button panel code: edit delete and view
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="primaryKeyName"></param>
        /// <param name="claimsIdentity"></param>
        /// <returns></returns>
        public string genDTBtnPanel<T>(string controllerName, T primaryKey, string primaryKeyName, ClaimsIdentity claimsIdentity,
            List<dataTableButtonModel> btnActionList, IHttpContextAccessor httpContextAccessor)
        {
            clsPrivateKeys objClsPrivate = new clsPrivateKeys();
            CancellationToken cancellationToken = new CancellationToken();
            owin_formactionEntity owin_formaction = new owin_formactionEntity();
            IList<Owin_ProcessGetFormActionistEntity> listProcessGetFormAction = new List<Owin_ProcessGetFormActionistEntity>();
            string strJson = string.Empty;
            try
            {
                if (claimsIdentity != null)
                {
                    List<Claim> listClaims = (List<Claim>)claimsIdentity.Claims;
                    if (listClaims != null && listClaims.Count > 0)
                    {
                        string masteruserid = listClaims.Find(c => c.Type == "masteruserid").Value;
                        _contextAccessor = httpContextAccessor;
                        owin_formaction.masteruserid = Convert.ToInt64(masteruserid);
                        owin_formaction.actionname = controllerName + "/";
                        listProcessGetFormAction = BFC.Core.FacadeCreatorObjects.Security.owin_formactionFCC.GetFacadeCreate(_contextAccessor)
                       .GetFormActionListByMasterUserId(owin_formaction, cancellationToken).GetAwaiter().GetResult();
                    }
                    strJson += "<div class='btn-toolbar pull-right' role='toolbar'>";
                    string btnclass = string.Empty;
                    //List<Owin_ProcessGetFormActionistEntity_Ext> itemList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Owin_ProcessGetFormActionistEntity_Ext>>(HttpContext.Current.Session["jsonList"].ToString());
                    foreach (dataTableButtonModel objsingButton in btnActionList)
                    {
                        var action = objsingButton.btnmethodname.Replace("{controllername}", controllerName).ToString();
                        if (listProcessGetFormAction.Any(x => x.ActionName.Contains(action)))
                        {
                            strJson += "<button type='button' class=\"" + objsingButton.btnclass + "\" ";
                            strJson += " onclick =\"location.href='/" + objsingButton.btnmethodname.Replace("{controllername}", controllerName) + clsPrivate.EncodeParams(primaryKeyName, primaryKey.ToString()) + "'\">";
                            strJson += "" + objsingButton.btnicon + "  " + objsingButton.btnname + "</button>  ";
                            //strJson += "<button class='"+ objsingButton.btnclass+ "' onclick ='" + editMethodName + "(&quot;" + objClsPrivate.BuildUrlMVCOnlyParams(menuName, menuId.ToString()) + "&quot;)'> <i class='fa fa-edit'> </i> " + KAF.MsgContainer._Common._btnUpdate + "</button> ";
                        }
                    }
                    strJson += "</div>";
                }
                else
                    throw new Exception("Login required");
            }
            catch (Exception ex)
            {
                strJson = ex.Message;
            }
            return strJson;
        }

        public string genDTBtnPanel(string controllerName, string[] primaryKeys, string[] primaryKeyNames, ClaimsIdentity claimsIdentity,
          List<dataTableButtonModel> btnActionList, IHttpContextAccessor httpContextAccessor = null)
        {
            clsPrivateKeys objClsPrivate = new clsPrivateKeys();
            CancellationToken cancellationToken = new CancellationToken();
            owin_formactionEntity owin_formaction = new owin_formactionEntity();
            IList<Owin_ProcessGetFormActionistEntity> listProcessGetFormAction = new List<Owin_ProcessGetFormActionistEntity>();
            string strJson = string.Empty;
            try
            {
                if (claimsIdentity != null)
                {
                    List<Claim> listClaims = (List<Claim>)claimsIdentity.Claims;
                    if (listClaims != null && listClaims.Count > 0)
                    {
                        string masteruserid = listClaims.Find(c => c.Type == "masteruserid").Value;
                        _contextAccessor = httpContextAccessor;
                        owin_formaction.masteruserid = Convert.ToInt64(masteruserid);
                        owin_formaction.actionname = controllerName + "/";
                        listProcessGetFormAction = BFC.Core.FacadeCreatorObjects.Security.owin_formactionFCC.GetFacadeCreate(_contextAccessor)
                       .GetFormActionListByMasterUserId(owin_formaction, cancellationToken).GetAwaiter().GetResult();
                    }
                    strJson += "<div class='btn-toolbar pull-right' role='toolbar'>";
                    string btnclass = string.Empty;
                    //List<Owin_ProcessGetFormActionistEntity_Ext> itemList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Owin_ProcessGetFormActionistEntity_Ext>>(HttpContext.Current.Session["jsonList"].ToString());
                    foreach (dataTableButtonModel objsingButton in btnActionList)
                    {
                        var action = objsingButton.btnmethodname.Replace("{controllername}", controllerName).ToString();
                        if (listProcessGetFormAction.Any(x => x.ActionName.Contains(action)))
                        {
                            strJson += "<button type='button' class=\"" + objsingButton.btnclass + "\" ";
                            strJson += " onclick =\"location.href='/" + objsingButton.btnmethodname.Replace("{controllername}", controllerName) + clsPrivate.EncodeParams(primaryKeyNames, primaryKeys.ToArray()) + "'\">";
                            strJson += "" + objsingButton.btnicon + "  " + objsingButton.btnname + "</button>  ";
                            //strJson += "<button class='"+ objsingButton.btnclass+ "' onclick ='" + editMethodName + "(&quot;" + objClsPrivate.BuildUrlMVCOnlyParams(menuName, menuId.ToString()) + "&quot;)'> <i class='fa fa-edit'> </i> " + KAF.MsgContainer._Common._btnUpdate + "</button> ";
                        }
                    }
                    strJson += "</div>";
                }
                else
                    throw new Exception("Login required");
            }
            catch (Exception ex)
            {
                strJson = ex.Message;
            }
            return strJson;
        }

    }
}
