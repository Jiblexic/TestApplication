using System.Collections.Generic;

namespace TestApplication.Model
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RoomLessons> RoomLessonsList { get; set; }
    }
}
