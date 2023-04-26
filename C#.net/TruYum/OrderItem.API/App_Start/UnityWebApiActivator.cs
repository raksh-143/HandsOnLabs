using MenuItemListing.API.Controllers;
using OrderItem.API.Controllers;
using System.ComponentModel;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Injection;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OrderItem.API.UnityWebApiActivator), nameof(OrderItem.API.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(OrderItem.API.UnityWebApiActivator), nameof(OrderItem.API.UnityWebApiActivator.Shutdown))]

namespace OrderItem.API
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
    /// </summary>
    public static class UnityWebApiActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            // Use UnityHierarchicalDependencyResolver if you want to use
            // a new child container for each IHttpController resolution.
            // var resolver = new UnityHierarchicalDependencyResolver(UnityConfig.Container);
            var resolver = new UnityDependencyResolver(UnityConfig.Container);
            var container = new UnityContainer();
            container.RegisterType<MenuItemController>();
            container.RegisterType<OrderController>(new InjectionConstructor(new ResolvedParameter<MenuItemController>()));
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}