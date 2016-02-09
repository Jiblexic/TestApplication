namespace TestApplication.Model
{
    public class RoomLessons
    {
        public int RoomId { get; set; }
        public Classroom Room { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
