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
    public class SubjectsController : ApiControllerBase
    {
        public SubjectsController(ITestApplicationUOW uow)
        {
            Uow = uow;
        }

        // Read all
        public IEnumerable<Subject> Get()
        {
            return Uow.Subjects.GetAll().OrderBy(s => s.Name);
        }

        // Read Specific
        public Subject Get(int id)
        {
            var subject = Uow.Subjects.GetById(id);
            if (subject != null) return subject;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        }

        // Create
        public HttpResponseMessage Post(Subject subject)
        {
            Uow.Subjects.Add(subject);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, subject);

            response.Headers.Location = new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = subject.Id }));

            return response;
        }

        // Update
        public HttpResponseMessage Put(Subject subject)
        {
            Uow.Subjects.Update(subject);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }


        // Delete
        public HttpResponseMessage Delete(int id)
        {
            Uow.Subjects.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}