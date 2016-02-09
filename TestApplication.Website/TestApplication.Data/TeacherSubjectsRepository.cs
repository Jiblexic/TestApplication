using System;
using System.Data.Entity;
using System.Linq;
using TestApplication.DataAccessLayer;
using TestApplication.DataContracts;
using TestApplication.Model;

namespace TestApplication.Data
{
    public class TeacherSubjectsRepository : EntityRepository<TeacherSubjects>, ITeacherSubjectsRepository
    {

        public TeacherSubjectsRepository(DbContext context) : base(context) { }

        public override TeacherSubjects GetById(int id)
        {
            throw new InvalidOperationException("Cannot return a single TeacherSubjects object by single id value.");
        }

        public override void Delete(int id)
        {
            throw new InvalidOperationException("Cannot delete a TeacherSubjects object by single id value.");
        }
        
        public void Delete(int teacherId, int subjectId)
        {
            var teacherSubjects = new TeacherSubjects { TeacherId = teacherId, SubjectId = subjectId };
            Delete(teacherSubjects);
        }

        public TeacherSubjects GetByIds(int teacherId, int subjectId)
        {
            return DbSet.FirstOrDefault(ps => ps.TeacherId == teacherId && ps.SubjectId == subjectId);
        }

        public IQueryable<TeacherSubjects> GetBySubjectId(int id)
        {
            return DbSet.Where(ps => ps.SubjectId == id);
        }

        public IQueryable<TeacherSubjects> GetByTeacherId(int id)
        {
            return DbSet.Where(ps => ps.TeacherId == id);
        }
    }
}
