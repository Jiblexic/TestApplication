using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApplication.DataContracts;
using TestApplication.Model;

namespace TestApplication.Website.Controllers
{
    public class TeachersController : ApiControllerBase
    {
        public TeachersController(ITestApplicationUOW uow)
        {
            Uow = uow;
        }

        // Read all
        public IEnumerable<Teacher> Get()
        {
            return Uow.Teachers.GetAll().OrderBy(s => s.FirstName);
        }

        // Read Specific
        public Teacher Get(int id)
        {
            var teacher = Uow.Teachers.GetById(id);
            if (teacher != null) return teacher;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        }

        // Create
        public HttpResponseMessage Post(Teacher teacher)
        {
            Uow.Teachers.Add(teacher);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, teacher);

            response.Headers.Location = new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = teacher.Id }));

            return response;
        }

        // Update
        public HttpResponseMessage Put(Teacher teacher)
        {
            Uow.Teachers.Update(teacher);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }


        // Delete
        public HttpResponseMessage Delete(int id)
        {
            Uow.Teachers.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
