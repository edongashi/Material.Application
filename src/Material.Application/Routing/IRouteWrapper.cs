using System;
using System.Threading.Tasks;

namespace Material.Application.Routing
{
    public interface IRouteWrapper<out TRoute> where TRoute : Route
    {
        TRoute Route { get; }

        Task<object> Push(bool cacheCurrentView);

        Task Change();
    }

    public class RouteWrapper<TRoute> : IRouteWrapper<TRoute> where TRoute : Route
    {
        public RouteWrapper(IRouteWrapper<TRoute> innerWrapper)
        {
            InnerWrapper = innerWrapper;
        }

        public IRouteWrapper<TRoute> InnerWrapper { get; }

        public TRoute Route => InnerWrapper.Route;

        public Task<object> Push(bool cacheCurrentView)
        {
            return InnerWrapper.Push(cacheCurrentView);
        }

        public Task Change()
        {
            return InnerWrapper.Change();
        }

        public static implicit operator TRoute(RouteWrapper<TRoute> routeWrapper)
        {
            return routeWrapper.Route;
        }

        public static implicit operator Task<TRoute>(RouteWrapper<TRoute> routeWrapper)
        {
            return Task.FromResult(routeWrapper.Route);
        }

        public static implicit operator Task<Route>(RouteWrapper<TRoute> routeWrapper)
        {
            return Task.FromResult<Route>(routeWrapper.Route);
        }
    }

    public static class RouteWrapperExtensions
    {
        public const bool CachedByDefault = true;

        public static IRouteWrapper<TRoute> With<TRoute>(this IRouteWrapper<TRoute> wrapper, Action<TRoute> initializer)
            where TRoute : Route
        {
            initializer?.Invoke(wrapper.Route);
            return wrapper;
        }

        public static Task<object> Push<TRoute>(this IRouteWrapper<TRoute> wrapper) where TRoute : Route
        {
            return wrapper.Push(CachedByDefault);
        }

        public static Task<TResult> Push<TRoute, TResult>(this IRouteWrapper<TRoute> wrapper) where TRoute : Route
        {
            return Push<TRoute, TResult>(wrapper, CachedByDefault);
        }

        public static async Task<TResult> Push<TRoute, TResult>(this IRouteWrapper<TRoute> wrapper,
            bool cacheCurrentView) where TRoute : Route
        {
            return (TResult)await wrapper.Push(cacheCurrentView);
        }

        internal static RouteWrapper<TRoute> CreateProxy<TRoute>(this IRouteWrapper<TRoute> routeWrapper)
            where TRoute : Route
        {
            return new RouteWrapper<TRoute>(routeWrapper);
        }
    }
}
