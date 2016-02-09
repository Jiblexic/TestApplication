using TestApplication.Data.HelperMethods;
using TestApplication.DataAccessLayer;
using TestApplication.DataContracts;
using TestApplication.Model;

namespace TestApplication.Data
{
    public class TestApplicationUOW : ITestApplicationUOW
    {
        private TestApplicationDbContext DbContext { get; set; }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        public IRepository<Classroom> Rooms {  get { return GetStandardRepo<Classroom>(); } }
        public IRepository<Pupil> Pupils { get { return GetStandardRepo<Pupil>(); } }
        public IRepository<Teacher> Teachers { get { return GetStandardRepo<Teacher>(); } }
        public IRepository<Subject> Subjects { get { return GetStandardRepo<Subject>(); } }
        public IRepository<Lesson> Lessons { get { return GetStandardRepo<Lesson>(); } }

        public IRoomLessonsRepository RoomLessons { get { return GetRepo<IRoomLessonsRepository>(); } }
        public ITeacherSubjectsRepository TeacherSubjects { get { return GetRepo<ITeacherSubjectsRepository>(); } }
        public IAttendingRepository Attending { get { return GetRepo<IAttendingRepository>(); } }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new TestApplicationDbContext();

            // Serialization fails without this
            DbContext.Configuration.ProxyCreationEnabled = false;

            DbContext.Configuration.LazyLoadingEnabled = false;

            // Validating through Web API
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

    }
}
