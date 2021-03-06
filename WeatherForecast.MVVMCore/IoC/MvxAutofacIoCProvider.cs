using System;
using Autofac;
using Cirrious.MvvmCross.Core;
using Cirrious.MvvmCross.Interfaces.IoC;

namespace WeatherForecast.MVVMCore.IoC
{
    public class MvxAutofacIoCServiceProvider : IMvxIoCProvider
    {
        public MvxAutofacIoCServiceProvider()
        {
            MvxAutofacIoCContainer.Initialise();
        }
        public bool SupportsService<T>() where T : class
        {
            return MvxAutofacIoCContainer.Instance.CanResolve<T>();
        }

        public T GetService<T>() where T : class
        {
            return MvxAutofacIoCContainer.Instance.Resolve<T>();
        }

        public bool TryGetService<T>(out T service) where T : class
        {

            return MvxAutofacIoCContainer.Instance.TryResolve(out service);
        }

        public void RegisterServiceType<TFrom, TTo>()
            where TFrom : class
            where TTo : class, TFrom
        {
            MvxAutofacIoCContainer.Instance.RegisterServiceType<TFrom, TTo>();
        }

        public void RegisterServiceInstance<TInterface>(TInterface theObject)
            where TInterface : class
        {
            MvxAutofacIoCContainer.Instance.RegisterServiceInstance(theObject);
        }

        public void RegisterServiceInstance<TInterface>(Func<TInterface> theConstructor)
            where TInterface : class
        {
            MvxAutofacIoCContainer.Instance.RegisterServiceInstance(theConstructor);
        }
    }

    public class MvxAutofacIoCContainer : MvxSingleton<MvxAutofacIoCContainer>
    {
        ContainerBuilder builder = new ContainerBuilder();
        private IContainer container;
        public static void Initialise()
        {
            var ioc = new MvxAutofacIoCContainer();
        }

        public MvxAutofacIoCContainer()
        {
            container = builder.Build();
        }

        public bool CanResolve<T>()
        {
            return container.IsRegistered<T>();
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public bool TryResolve<T>(out T service)
        {
            throw new NotImplementedException();
        }

        public void RegisterServiceType<T, T1>()
        {
            UpdateContainer(cb => cb.RegisterType<T1>().As<T>());
        }

        public void RegisterServiceInstance<T>(T theObject) where T : class
        {
            UpdateContainer(cb => cb.RegisterInstance(theObject).As<T>());
        }

        public void UpdateContainer(Action<ContainerBuilder> builderAction)
        {
            var thisBuilder = new ContainerBuilder();
            builderAction(thisBuilder);
            thisBuilder.Update(container);
        }

    }
}
