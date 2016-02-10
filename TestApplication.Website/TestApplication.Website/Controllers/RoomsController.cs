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
    public class RoomsController : ApiControllerBase
    {
        public RoomsController(ITestApplicationUOW uow)
        {
            Uow = uow;
        }

        // Read all
        public IEnumerable<Classroom> Get()
        {
            return Uow.Rooms.GetAll().OrderBy(r => r.Name);
        }

        // Read Specific
        public Classroom Get(int id)
        {
            var rooms = Uow.Rooms.GetById(id);
            if (rooms != null) return rooms;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        }

        // Create
        public HttpResponseMessage Post(Classroom room)
        {
            Uow.Rooms.Add(room);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, room);

            response.Headers.Location = new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = room.Id }));

            return response;
        }

        // Update
        public HttpResponseMessage Put(Classroom room)
        {
            Uow.Rooms.Update(room);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }


        // Delete
        public HttpResponseMessage Delete(int id)
        {
            Uow.Rooms.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}