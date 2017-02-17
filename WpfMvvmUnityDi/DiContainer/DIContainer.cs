using Microsoft.Practices.Unity;
using System;

using WpfMvvmUnityDi.DAL;
using WpfMvvmUnityDi.Services;

namespace WpfMvvmUnityDi.DiContainer
{
    sealed class DIContainer
    {
        private static Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() =>
        {
            System.Diagnostics.Trace.WriteLine("DIContainer instance: Create!");

            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer Container => _container.Value;

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDataLayer, DataLayer>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBookService, BookService>();
        }
    }
}
