//using System;
//using Material.Application.Helpers;
//using MaterialForms;

//namespace Material.Application.Infrastructure
//{
//    internal class DialogHostService : IDialogService
//    {
//        private readonly IMainWindowLocator windowLocator;

//        public DialogHostService(IMainWindowLocator windowLocator)
//        {
//            this.windowLocator = windowLocator;
//        }

//        public DialogSession ShowTrackedDialog(MaterialDialog dialog, double width)
//        {
//            var window = windowLocator.GetMainWindow();
//            if (window == null)
//            {
//                throw new InvalidOperationException(ErrorMessages.MainWindowNotFound);
//            }

//            if (window is IDialogHostContainer hostContainer)
//            {
//                var dialogHost = hostContainer.GetRootDialog();
//                return dialog.ShowTracked(dialogHost.Identifier.ToString(), width);
//            }

//            throw new InvalidOperationException("Cannot display dialog in current window.");
//        }

//        public void CloseDialogs()
//        {
//            var window = windowLocator.GetMainWindow();
//            if (window == null)
//            {
//                return;
//            }

//            if (window is IDialogHostContainer hostContainer)
//            {
//                var dialogHost = hostContainer.GetRootDialog();
//                if (dialogHost.CheckAccess())
//                {
//                    dialogHost.IsOpen = false;
//                }
//            }
//        }
//    }
//}
