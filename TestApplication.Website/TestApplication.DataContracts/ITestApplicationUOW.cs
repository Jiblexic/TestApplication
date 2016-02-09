using TestApplication.Model;

namespace TestApplication.DataContracts
{
    public interface ITestApplicationUOW
    {
        // Repo's
        IRoomLessonsRepository RoomLessons { get; }
        ITeacherSubjectsRepository TeacherSubjects { get; }
        IAttendingRepository Attending { get; }
        IRepository<Pupil> Pupils { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<Classroom> Rooms { get; }
        IRepository<Lesson> Lessons { get; }

        void Commit();
    }
}
