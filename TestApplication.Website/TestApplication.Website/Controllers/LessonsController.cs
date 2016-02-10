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
    public class LessonsController : ApiControllerBase
    {
        public LessonsController(ITestApplicationUOW uow)
        {
            Uow = uow;
        }

        // Read all
        public IEnumerable<Lesson> Get()
        {
            return Uow.Lessons.GetAll().OrderBy(r => r.Name);
        }

        // Read Specific
        public Lesson Get(int id)
        {
            var lessons = Uow.Lessons.GetById(id);
            if (lessons != null) return lessons;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        }

        // Create
        public HttpResponseMessage Post(Lesson lesson)
        {
            Uow.Lessons.Add(lesson);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, lesson);

            response.Headers.Location = new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = lesson.Id }));

            return response;
        }

        // Update
        public HttpResponseMessage Put(Lesson lesson)
        {
            Uow.Lessons.Update(lesson);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }


        // Delete
        public HttpResponseMessage Delete(int id)
        {
            Uow.Lessons.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}