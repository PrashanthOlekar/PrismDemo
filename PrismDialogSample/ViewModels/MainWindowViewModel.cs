using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace PrismDialogSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;
        public DelegateCommand OpenDialogCommand { get; }

        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            OpenDialogCommand = new DelegateCommand(OpenDialog);
        }

        private void OpenDialog()
        {
            _dialogService.ShowDialog("MyDialog", new DialogParameters { { "message", "Hello from MainWindow!" } },
                result =>
                {
                    if (result.Result == ButtonResult.OK)
                    {
                        var userInput = result.Parameters.GetValue<string>("userInput");
                        Console.WriteLine($"User entered: {userInput}");
                    }
                });
        }
    }
}
