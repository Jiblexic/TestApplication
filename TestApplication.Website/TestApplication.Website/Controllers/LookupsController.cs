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
    public class LookupsController : ApiControllerBase
    {
        public LookupsController(ITestApplicationUOW uow)
        {
            Uow = uow;
        }

        [ActionName("rooms")]
        public IEnumerable<Classroom> GetRooms()
        {
            return Uow.Rooms.GetAll().OrderBy(res => res.Name);
        }

        [ActionName("subjects")]
        public IEnumerable<Subject> GetSubjects()
        {
            return Uow.Subjects.GetAll().OrderBy(res => res.Name);
        }

        [ActionName("lessons")]
        public IEnumerable<Lesson> GetLessons()
        {
            return Uow.Lessons.GetAll().OrderBy(res => res.Name);
        }

        [ActionName("pupils")]
        public IEnumerable<Pupil> GetPupils()
        {
            return Uow.Pupils.GetAll().OrderBy(res => res.FirstName);
        }

        [ActionName("teachers")]
        public IEnumerable<Teacher> GetTeachers()
        {
            return Uow.Teachers.GetAll().OrderBy(res => res.FirstName);
        }

        [ActionName("all")]
        public Lookups GetLookups()
        {
            var lookups = new Lookups
            {
                Rooms = GetRooms().ToList(),
                Lessons = GetLessons().ToList(),
                Pupils = GetPupils().ToList(),
                Subjects = GetSubjects().ToList(),
                Teachers = GetTeachers().ToList()
            };
            return lookups;
        }

    }
}
