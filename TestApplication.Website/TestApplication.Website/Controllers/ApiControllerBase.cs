using System.Web.Http;
using TestApplication.DataContracts;

namespace TestApplication.Website.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ITestApplicationUOW Uow { get; set; }
    }

}