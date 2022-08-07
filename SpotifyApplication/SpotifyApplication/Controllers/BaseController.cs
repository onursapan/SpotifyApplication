using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyApplication.Common;

namespace SpotifyApplication.Controllers
{
    public class BaseController : Controller
    {
        protected static async Task<JsonResult> JsonResult<T>(Task<T> task) =>
           new JsonResult(new OperationResult<T>(await task)) { ContentType = "application/json" };

        protected static async Task<JsonResult> JsonResult(Task task)
        {
            await task;
            return new JsonResult(new OperationResult()) { ContentType = "application/json" };
        }

        protected JsonResult JsonResult(OperationResult oRes)
            => new JsonResult(oRes) { ContentType = "application/json" };
        
    }
}
