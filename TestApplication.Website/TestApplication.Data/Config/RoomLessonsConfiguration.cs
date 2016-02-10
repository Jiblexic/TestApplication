using System.Data.Entity.ModelConfiguration;
using TestApplication.Model;

namespace TestApplication.DataAccessLayer.Config
{
    public class RoomLessonsConfiguration : EntityTypeConfiguration<RoomLessons>
    {
        public RoomLessonsConfiguration()
        {
            HasKey(x => new { x.RoomId, x.LessonId });

            //HasRequired(a => a.Room)
            //    .WithMany(s => s.RoomLessonsList)
            //    .HasForeignKey(a => a.RoomId)
            //    .WillCascadeOnDelete(false);

            //HasRequired(a => a.Lesson)
            //    .WithMany(p => p.RoomLessonsList)
            //    .HasForeignKey(a => a.LessonId)
            //    .WillCascadeOnDelete(false);
        }
    }
}
