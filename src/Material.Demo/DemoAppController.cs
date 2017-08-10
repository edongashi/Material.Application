using Material.Application.Infrastructure;
using Material.Application.Routing;
using Material.Demo.Routes;

namespace Material.Demo
{
    public class DemoAppController : AppController
    {
        protected override void OnInitializing()
        {
            var factory = Routes.RouteFactory;
            Routes.MenuRoutes.Add(InitialRoute = factory.Get<HomeRoute>());
        }
    }
}
