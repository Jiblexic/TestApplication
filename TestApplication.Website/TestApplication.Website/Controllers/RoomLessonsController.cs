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
    public class RoomLessonsController : ApiControllerBase
    {
        public RoomLessonsController(ITestApplicationUOW uow)
        {
            Uow = uow;
        }

        // Read all
        public IEnumerable<RoomLessons> Get()
        {
            return Uow.RoomLessons.GetAll().OrderBy(r => r.LessonId);
        }
    }
}