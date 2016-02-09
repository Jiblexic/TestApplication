using System.Data.Entity.ModelConfiguration;
using TestApplication.Model;

namespace TestApplication.DataAccessLayer.Config
{
    public class AttendingConfiguration : EntityTypeConfiguration<Attending>
    {
        public AttendingConfiguration()
        {
            HasKey(x => new { x.PupilId, x.LessonId });

            HasRequired(a => a.Lesson)
                .WithMany(s => s.AttendingList)
                .HasForeignKey(a => a.LessonId)
                .WillCascadeOnDelete(false);

            HasRequired(a => a.Pupil)
                .WithMany(p => p.AttendingList)
                .HasForeignKey(a => a.PupilId)
                .WillCascadeOnDelete(false);
        }
    }
}
