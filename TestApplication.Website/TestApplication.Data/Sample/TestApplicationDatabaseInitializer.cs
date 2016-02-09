using System;
using System.Collections.Generic;
using System.Data.Entity;
using TestApplication.Model;

namespace TestApplication.DataAccessLayer.Sample
{
    public class TestApplicationDatabaseInitializer : DropCreateDatabaseIfModelChanges<TestApplicationDbContext>
    {
        protected override void Seed(TestApplicationDbContext context)
        {
            var rooms = AddRooms(context);
            var subjects = AddSubjects(context);
            var pupils = AddPupils(context);
            var teachers = AddTeachers(context);
        }

        private List<Classroom> AddRooms(TestApplicationDbContext context)
        {
            // Total number of rooms = (number of tracks) + (number of TheChosen people); see note in TheChosen.
            var names = new[] { 
                // 'Track' rooms (10 in use)
                "Great Hall", "Room 1A", "Room 1B", "Room 1C",
                "Room 2A", "Room 2B", "Room 2C",
                "Room 3A", "Room 3B", "Room 3C"
            };
            var rooms = new List<Classroom>();
            Array.ForEach(names, name =>
            {
                var item = new Classroom { Name = name };
                rooms.Add(item);
                context.Rooms.Add(item);
            });
            context.SaveChanges();
            return rooms;
        }

        private List<Subject> AddSubjects(TestApplicationDbContext context)
        {
            // Total number of rooms = (number of tracks) + (number of TheChosen people); see note in TheChosen.
            var names = new[] { 
                // 'Track' rooms (10 in use)
                "C#", "Knockout JS", "SQL", "jQuery",
                "Entity Framework", "Web API 2", "CSS", "SPA"
            };
            var subjects = new List<Subject>();
            Array.ForEach(names, name =>
            {
                var item = new Subject { Name = name };
                subjects.Add(item);
                context.Subjects.Add(item);
            });
            context.SaveChanges();
            return subjects;
        }

        private List<Pupil> AddPupils(TestApplicationDbContext context)
        {
            List<Pupil> pupils = new List<Pupil>();
            pupils.Add(new Pupil() { FirstName = "Isabella", LastName = "Anderson" });
            pupils.Add(new Pupil() { FirstName = "Sophia", LastName = "Davis" });
            pupils.Add(new Pupil() { FirstName = "Emma", LastName = "Thomas" });
            pupils.Add(new Pupil() { FirstName = "Colleen", LastName = "Robinson" });
            pupils.Add(new Pupil() { FirstName = "Hailey", LastName = "Wright" });
            pupils.Add(new Pupil() { FirstName = "Dylan", LastName = "King" });
            pupils.Add(new Pupil() { FirstName = "Matthew", LastName = "Cesar" });
            pupils.Add(new Pupil() { FirstName = "Isaac", LastName = "Jefferies" });

            foreach (var pupil in pupils)
            {
                context.Pupils.Add(pupil);
            }
            context.SaveChanges();
            return pupils;
        }

        private List<Teacher> AddTeachers(TestApplicationDbContext context)
        {
            List<Teacher> teachers = new List<Teacher>();
            teachers.Add(new Teacher() { FirstName = "Chloe", LastName = "Martinez", EmailAddress = "teacher1@foo.com" });
            teachers.Add(new Teacher() { FirstName = "Emma", LastName = "Garcia", EmailAddress = "teacher2@foo.com" });
            teachers.Add(new Teacher() { FirstName = "Sophie", LastName = "Adams", EmailAddress = "teacher3@foo.com" });
            teachers.Add(new Teacher() { FirstName = "Tristan", LastName = "Sanchez", EmailAddress = "teacher4@foo.com" });
            teachers.Add(new Teacher() { FirstName = "Carson", LastName = "Morgan", EmailAddress = "teacher5@foo.com" });


            foreach (var teacher in teachers)
            {
                context.Teachers.Add(teacher);
            }
            context.SaveChanges();
            return teachers;
        }
    }
}
