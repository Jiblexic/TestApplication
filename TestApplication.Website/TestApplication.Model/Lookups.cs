using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Model
{
    public class Lookups
    {
        public IList<Classroom> Rooms { get; set; }
        public IList<Lesson> Lessons { get; set; }
        public IList<Pupil> Pupils { get; set; }
        public IList<Subject> Subjects { get; set; }
        public IList<Teacher> Teachers { get; set; }
    }
}
