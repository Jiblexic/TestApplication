using System.Linq;
using TestApplication.Model;

namespace TestApplication.DataContracts
{
    public interface ITeacherSubjectsRepository : IRepository<TeacherSubjects>
    {
        IQueryable<TeacherSubjects> GetByTeacherId(int id);
        IQueryable<TeacherSubjects> GetBySubjectId(int id);
        TeacherSubjects GetByIds(int teacherId, int subjectId);
        void Delete(int teacherId, int subjectId);
    }
}
