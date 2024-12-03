using System.Net;
using Web.Core.Frame.RequestResponse.UseCaseResponses;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.Serialization;
using Web.Core.Frame.Helpers;

namespace  Web.Core.Frame.Presenters
{
    /// <summary>
    /// BackupPresenter
    /// </summary>
    public sealed partial class BackupPresenter : IOutputPort<BackupResponse>, ICRUDRequestHandler<BackupResponse>

    {
         /// <summary>
        /// ContentResult
        /// </summary>
        public JsonContentResult ContentResult { get; }
        /// <summary>
        /// Result list of object (anynomous)
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        /// Gen_PriorityPresenter
        /// </summary>
        public BackupPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="response"></param>
        public void Handle(BackupResponse response)
        {
            //ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            //ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new Gen_PriorityResponse(response._gen_PriorityList.AccessToken, response.RefreshToken)) : JsonSerializer.SerializeObject(response.Errors);
        }

        public void GetAll(BackupResponse response)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(BackupResponse response)
        {
            throw new System.NotImplementedException();
        }

        public void GetAllPaged(BackupResponse response)
        {
            throw new System.NotImplementedException();
        }

        public void GetListView(BackupResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : httpStatusCodeParser.SetHttpStatusCode(response.Errors));
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response._ajaxresponse) : JsonSerializer.SerializeObject(response.Errors);
            Result = response.Success ? response._ajaxresponse as object : response.Errors;
        }

        public void GetSingle(BackupResponse response)
        {
            throw new System.NotImplementedException();
        }

        public void Save(BackupResponse response)
        {
            throw new System.NotImplementedException();
        }

        public void Update(BackupResponse response)
        {
            throw new System.NotImplementedException();
        }

        //      /// <summary>
        ///// GetDataForDropDown
        ///// </summary>
        ///// <param name="response"></param>
        //public void GetDropDown(Gen_EventCategoryResponse response)
        //{
        //	ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : httpStatusCodeParser.SetHttpStatusCode(response.Errors)); 
        //	ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new Gen_EventCategoryResponse(response._gen_EventCategoryList, response.Success)) : JsonSerializer.SerializeObject(response.Errors);
        //	Result = response.Success ? response._ajaxresponse as object : response.Errors;
        //}


    }
}
