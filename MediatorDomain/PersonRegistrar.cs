using System.Reflection;
using Autofac;
using FluentValidation;
using MediatR;

namespace MediatorDomain
{
    public class PersonRegistrar : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            //RegisterMediator(builder);
            //RegisterPipeline(builder);
            RegisterInterfaces(builder);
        }

        private void RegisterInterfaces(ContainerBuilder builder)
        {
            builder.RegisterType<PersonRepository>().As<IPersonRepository>()
                .InstancePerDependency();
        }

        private void RegisterPipeline(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                    .AsClosedTypesOf(typeof(IPipelineBehavior<,>))
                    .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                    .AsClosedTypesOf(typeof(IValidator<>))
                    .AsImplementedInterfaces();
        }

        private void RegisterMediator(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }
        }
    }
}
