using System;
using System.Data.Entity;
using System.Linq;
using TestApplication.DataContracts;
using TestApplication.Model;

namespace TestApplication.DataAccessLayer
{
    public class AttendingRepository : EntityRepository<Attending>, IAttendingRepository
    {

        public AttendingRepository(DbContext context) : base(context) { }

        public override Attending GetById(int id)
        {
            throw new InvalidOperationException("Cannot return a single Attending object by single id value.");
        }

        public override void Delete(int id)
        {
            throw new InvalidOperationException("Cannot delete an Attending object by single id value.");
        }

        public void Delete(int pupilId, int lessonId)
        {
            var attending = new Attending { PupilId = pupilId, LessonId = lessonId };
            Delete(attending);
        }

        public Attending GetByIds(int pupilId, int lessonId)
        {
            return DbSet.FirstOrDefault(ps => ps.PupilId == pupilId && ps.LessonId == lessonId);
        }

        public IQueryable<Attending> GetByLessonId(int id)
        {
            return DbSet.Where(ps => ps.LessonId == id);
        }

        public IQueryable<Attending> GetByPupilId(int id)
        {
            return DbSet.Where(ps => ps.PupilId == id);
        }
    }
}
