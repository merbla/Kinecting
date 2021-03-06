using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;

namespace Merbla.Kinecting
{
    public class AppBootstrapper : AutofacBootstrapper<IShell>
    {
        private IContainer _applicationContainer;


        protected override void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                // .SingleInstance()
                .AsImplementedInterfaces()
                .AsSelf();

            builder.Register<IWindowManager>(c => new WindowManager()).InstancePerLifetimeScope();
            builder.Register<IEventAggregator>(c => new EventAggregator()).InstancePerLifetimeScope();

            _applicationContainer = builder.Build();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (_applicationContainer.IsRegistered(serviceType))
                    return _applicationContainer.Resolve(serviceType);
            }
            else
            {
                if (_applicationContainer.IsRegisteredWithName(key, serviceType))
                    _applicationContainer.ResolveNamed(key, serviceType);
            }
            throw new Exception(string.Format("Could not locate any instances of contract {0}.", key ?? serviceType.Name));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return
                _applicationContainer.Resolve(typeof (IEnumerable<>).MakeGenericType(serviceType)) as
                IEnumerable<object>;
        }
    }
}