using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Concrete;
using ComputerStore.Domain.Entities;
using Ninject;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using ComputerStore.WebUI.Infrastructure.Abstract;
using ComputerStore.WebUI.Infrastructure.Concrete;

namespace ComputerStore.WebUI.Infrastructure
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
            kernel.Bind<IProductsRepository>().To<EFProductRepistory>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);

            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}