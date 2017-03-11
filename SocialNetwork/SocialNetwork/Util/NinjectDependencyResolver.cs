using System.Web.Mvc;
using Ninject;
using System;
using System.Collections.Generic;
using SocialNetwork.Repositories;
using SocialNetwork.Models;
using SocialNetwork.Repositories.RepositoryModels;

namespace SocialNetwork.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IRepository<Group>>().To<GroupRepostirory>();
            kernel.Bind<IRepository<Story>>().To<StoryRepository>();
            kernel.Bind<IRepository<User>>().To<UserRepository>();
        }
    }
}