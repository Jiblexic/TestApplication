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
    public class PupilsController : ApiControllerBase
    {
        public PupilsController(ITestApplicationUOW uow)
        {
            Uow = uow;
        }

        // Read all
        public IEnumerable<Pupil> Get()
        {
            return Uow.Pupils.GetAll().OrderBy(p => p.FirstName);
        }

        // Read Specific
        public Pupil Get(int id)
        {
            var pupil = Uow.Pupils.GetById(id);
            if (pupil != null) return pupil;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        }

        // Create
        public HttpResponseMessage Post(Pupil pupil)
        {
            Uow.Pupils.Add(pupil);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, pupil);

            response.Headers.Location = new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = pupil.Id }));

            return response;
        }

        // Update
        public HttpResponseMessage Put(Pupil pupil)
        {
            Uow.Pupils.Update(pupil);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }


        // Delete
        public HttpResponseMessage Delete(int id)
        {
            Uow.Pupils.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}