using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApplication.DataAccessLayer;
using TestApplication.DataContracts;
using Ninject;
using System.Web.Http;
using TestApplication.Data.HelperMethods;
using TestApplication.Data;

namespace TestApplication.Website.App_Start
{
    public class IoCConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); // Ninject IoC

            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
                .InSingletonScope();

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();

            kernel.Bind<ITestApplicationUOW>().To<TestApplicationUOW>();

            // Tell WebApi how to use our Ninject IoC
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}