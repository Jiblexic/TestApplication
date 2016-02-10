using System;
using System.Collections.Generic;

namespace TestApplication.Model
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        
        public virtual ICollection<Attending> AttendingList { get; set; }
        //public virtual ICollection<RoomLessons> RoomLessonsList { get; set; }

    }
}
