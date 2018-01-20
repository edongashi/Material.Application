using System;
using System.Collections.Generic;
using Material.Application.Routing;

namespace Material.Application.Infrastructure
{
    internal class ServiceLocatorRouteFactory : IRouteFactory
    {
        private readonly IServiceLocator serviceLocator;

        public ServiceLocatorRouteFactory(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public Route Get(Type routeType, IDictionary<string, object> parameters)
        {
            return (Route)serviceLocator.Get(routeType, parameters);
        }

        public IRouteWrapper<Route> Get(Route caller, Type routeType, IDictionary<string, object> parameters)
        {
            return new RouteWrapperInternal<Route>(caller, (Route)serviceLocator.Get(routeType, parameters));
        }

        public TRoute Get<TRoute>(IDictionary<string, object> parameters) where TRoute : Route
        {
            return serviceLocator.Get<TRoute>(parameters);
        }

        public IRouteWrapper<TRoute> Get<TRoute>(Route caller, IDictionary<string, object> parameters)
            where TRoute : Route
        {
            return new RouteWrapperInternal<TRoute>(caller, serviceLocator.Get<TRoute>(parameters));
        }
    }
}
