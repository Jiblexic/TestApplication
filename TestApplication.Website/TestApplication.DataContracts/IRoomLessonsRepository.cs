using System.Linq;
using TestApplication.Model;

namespace TestApplication.DataContracts
{
    public interface IRoomLessonsRepository : IRepository<RoomLessons>
    {
        IQueryable<RoomLessons> GetByRoomId(int id);
        IQueryable<RoomLessons> GetByLessonId(int id);
        RoomLessons GetByIds(int roomId, int lessonId);
        void Delete(int roomId, int lessonId);
    }
}
