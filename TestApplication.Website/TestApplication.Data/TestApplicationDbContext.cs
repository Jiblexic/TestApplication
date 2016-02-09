using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TestApplication.DataAccessLayer.Config;
using TestApplication.DataAccessLayer.Sample;
using TestApplication.Model;

namespace TestApplication.DataAccessLayer
{
    public class TestApplicationDbContext : DbContext
    {

        static TestApplicationDbContext()
        {
            Database.SetInitializer(new TestApplicationDatabaseInitializer());
        }

        public TestApplicationDbContext()
            : base(nameOrConnectionString: "DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new AttendingConfiguration());
            modelBuilder.Configurations.Add(new RoomLessonsConfiguration());
            modelBuilder.Configurations.Add(new TeacherSubjectsConfiguration());
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Attending> Attending { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Classroom> Rooms { get; set; }
        public DbSet<RoomLessons> RoomLessons { get; set; }
        public DbSet<TeacherSubjects> TeacherSubjects { get; set; }
    }
}
