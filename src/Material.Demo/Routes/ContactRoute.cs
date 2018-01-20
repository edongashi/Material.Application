using System.Windows.Input;
using Material.Application.Routing;

namespace Material.Demo.Routes
{
    public class ContactRoute : Route
    {
        private string message;
        private string name;

        public ContactRoute(string name)
        {
            RouteConfig.Title = "Contact us";

            // We do something with the passed argument.
            Name = name;

            // Initialize commands.
            CancelCommand = Command(Cancel);
            SendCommand = Command(Send);
        }

        public string Name
        {
            get => name;
            set
            {
                if (Equals(name, value))
                {
                    return;
                }
                name = value;
                NotifyPropertyChanged();
                if (string.IsNullOrWhiteSpace(name))
                {
                    AddError("Your name is required.");
                }
                else
                {
                    RemoveError();
                }
            }
        }

        public string Message
        {
            get => message;
            set
            {
                if (Equals(message, value))
                {
                    return;
                }
                message = value;
                NotifyPropertyChanged();
                if (message == null || message.Length < 10)
                {
                    AddError("Message must contain at least 10 characters.");
                }
                else
                {
                    RemoveError();
                }
            }
        }

        public ICommand CancelCommand { get; set; }

        public ICommand SendCommand { get; set; }

        private void Cancel()
        {
            // Return false to indicate that we canceled.
            PopRoute(false);
        }

        private void Send()
        {
            if (!Validate())
            {
                return;
            }

            // Send email here...
            var emailName = Name;
            var emailMessage = Message;

            // Pop and return true to indicate that the email is sent.
            PopRoute(true);
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                AddError("Your name is required.", nameof(Name));
                return false;
            }

            if (message == null || message.Length < 10)
            {
                AddError("Message must contain at least 10 characters.", nameof(Message));
                return false;
            }

            return true;
        }
    }
}
