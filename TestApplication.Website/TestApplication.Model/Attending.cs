namespace TestApplication.Model
{
    public class Attending
    {
        public int PupilId { get; set; }
        public Pupil Pupil { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
