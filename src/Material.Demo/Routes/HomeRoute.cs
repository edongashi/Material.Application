using Material.Application.Routing;
using MaterialDesignThemes.Wpf;

namespace Material.Demo.Routes
{
    public class HomeRoute : Route
    {
        public HomeRoute()
        {
            RouteConfig.Title = "Home";
            RouteConfig.Icon = PackIconKind.Home;
        }
    }
}
