using System.Linq;
using TestApplication.Model;

namespace TestApplication.DataContracts
{
    public interface IAttendingRepository : IRepository<Attending>
    {
        IQueryable<Attending> GetByPupilId(int id);
        IQueryable<Attending> GetByLessonId(int id);
        Attending GetByIds(int pupilId, int lessonId);
        void Delete(int pupilId, int lessonId);
    }
}
