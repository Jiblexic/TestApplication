using System;
using System.Data.Entity;
using System.Linq;
using TestApplication.DataAccessLayer;
using TestApplication.DataContracts;
using TestApplication.Model;

namespace TestApplication.Data
{
    public class RoomLessonsRepository : EntityRepository<RoomLessons>, IRoomLessonsRepository
    {

        public RoomLessonsRepository(DbContext context) : base(context) { }

        public override RoomLessons GetById(int id)
        {
            throw new InvalidOperationException("Cannot return a single RoomLessons object by single id value.");
        }

        public override void Delete(int id)
        {
            throw new InvalidOperationException("Cannot delete a RoomLessons object by single id value.");
        }

        public void Delete(int roomId, int lessonId)
        {
            var roomLessons = new RoomLessons { RoomId = roomId, LessonId = lessonId };
            Delete(roomLessons);
        }

        public RoomLessons GetByIds(int roomId, int lessonId)
        {
            return DbSet.FirstOrDefault(ps => ps.RoomId == roomId && ps.LessonId == lessonId);
        }

        public IQueryable<RoomLessons> GetByLessonId(int id)
        {
            return DbSet.Where(ps => ps.LessonId == id);
        }

        public IQueryable<RoomLessons> GetByRoomId(int id)
        {
            return DbSet.Where(ps => ps.RoomId == id);
        }
    }
}
