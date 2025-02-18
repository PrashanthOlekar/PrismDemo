using Prism.Ioc;
using Prism.DryIoc;
using System.Windows;
using PrismDialogSample.Views;
using PrismDialogSample.ViewModels;

namespace PrismDialogSample
{
    public partial class App 
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<MyDialog, MyDialogViewModel>();
        }
    }
}
