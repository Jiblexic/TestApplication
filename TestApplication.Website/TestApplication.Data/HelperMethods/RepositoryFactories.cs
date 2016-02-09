using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.DataAccessLayer;
using TestApplication.DataContracts;

namespace TestApplication.Data.HelperMethods
{
    public class RepositoryFactories
    {

        // Factory Pattern

        private IDictionary<Type, Func<DbContext, object>> GetCodeCamperFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
                {
                   {typeof(IAttendingRepository), dbContext => new AttendingRepository(dbContext)},
                   {typeof(IRoomLessonsRepository), dbContext => new RoomLessonsRepository(dbContext)},
                   {typeof(ITeacherSubjectsRepository), dbContext => new TeacherSubjectsRepository(dbContext)},
                };
        }

        public RepositoryFactories()
        {
            _repositoryFactories = GetCodeCamperFactories();
        }

        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {

            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new EntityRepository<T>(dbContext);
        }

        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

    }
}
