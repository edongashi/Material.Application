using System.Threading.Tasks;
using System.Windows.Input;
using Material.Application.Infrastructure;
using Material.Application.Routing;
using MaterialDesignThemes.Wpf;

namespace Material.Demo.Routes
{
    public class AboutRoute : Route
    {
        private readonly INotificationService notificationService;

        public AboutRoute(INotificationService notificationService)
        {
            this.notificationService = notificationService;
            RouteConfig.Title = "About";
            RouteConfig.Icon = PackIconKind.Information;

            // Initialize commands.
            HomeCommand = Command(Home);
            ContactCommand = AsyncCommand(Contact);
        }

        public ICommand HomeCommand { get; }

        public ICommand ContactCommand { get; }

        private void Home()
        {
            GoToMenuRoute<HomeRoute>();
        }

        private async Task Contact()
        {
            var result = await GetRoute<ContactRoute>("name", "Guest").Push();
            if (result is true)
            {
                notificationService.Notify("E-mail sent.");
            }
        }
    }
}
