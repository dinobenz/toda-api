using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using toda.api.Services.GeoLocation;

namespace toda.api
{
    /// <summary>
    /// The inversion of control class.
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        public static IContainer Container { get; private set; }

        /// <summary>
        /// Build the container.
        /// </summary>
        public static void BuildContainer()
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register the Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register other dependencies.
            builder.Register(c => new GeoLocationService()).As<IGeoLocationService>().InstancePerRequest();

            // Build the container.
            var container = builder.Build();

            // Create the depenedency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}