using Material.Application.Infrastructure;
using Material.Application.Routing;
using Material.Demo.Routes;

namespace Material.Demo
{
    public class DemoAppController : AppController
    {
        protected override void OnInitializing()
        {
            IsAppbarExtended = true;
            var factory = Routes.RouteFactory;
            Routes.MenuRoutes.Add(InitialRoute = factory.Get<HomeRoute>());
            Routes.MenuRoutes.Add(factory.Get<AboutRoute>());
        }
    }
}
