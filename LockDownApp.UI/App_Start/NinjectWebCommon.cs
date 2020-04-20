using System.Data.Entity;
using LockDownApp.BL;
using LockDownApp.BL.Interface;
using LockDownApp.DAL;
using LockDownApp.DAL.Repo;
using LockDownApp.DAL.Repo.Interface;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LockDownApp.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LockDownApp.UI.App_Start.NinjectWebCommon), "Stop")]

namespace LockDownApp.UI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
                {
                    kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                    kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                    kernel.Bind<DbContext>().To<LockDownDbEntities>();
                    kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
                    kernel.Bind<ICourseRepository>().To<CourseRepository>();
                    kernel.Bind<IInstructorRepository>().To<InstructorRepository>();
                    kernel.Bind<IInstructorCourseRepository>().To<InstrcutorCourseRepository>();
                    kernel.Bind<IInstructorService>().To<InstructorService>();
                    kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
                    RegisterServices(kernel);
                    return kernel;
                }
            catch
                {
                    kernel.Dispose();
                    throw;
                }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }        
    }
}
