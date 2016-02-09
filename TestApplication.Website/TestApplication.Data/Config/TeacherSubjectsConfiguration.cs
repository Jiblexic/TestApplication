using System.Data.Entity.ModelConfiguration;
using TestApplication.Model;

namespace TestApplication.DataAccessLayer.Config
{
    public class TeacherSubjectsConfiguration : EntityTypeConfiguration<TeacherSubjects>
    {
        public TeacherSubjectsConfiguration()
        {
            HasKey(x => new { x.TeacherId, x.SubjectId });

            HasRequired(a => a.Teacher)
                .WithMany(s => s.TeacherSubjectList)
                .HasForeignKey(a => a.TeacherId)
                .WillCascadeOnDelete(false);

            HasRequired(a => a.Subject)
                .WithMany(p => p.TeacherSubjectList)
                .HasForeignKey(a => a.SubjectId)
                .WillCascadeOnDelete(false);
        }
    }
}
