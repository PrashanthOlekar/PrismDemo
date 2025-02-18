using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace PrismDialogSample.ViewModels
{
    public class MyDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "My Dialog";
        public event Action<IDialogResult> RequestClose;

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private string _userInput;
        public string UserInput
        {
            get => _userInput;
            set => SetProperty(ref _userInput, value);
        }

        public DelegateCommand<string> CloseDialogCommand { get; }

        public MyDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }

        public bool CanCloseDialog() => true;
        public void OnDialogClosed() { }
        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("message"))
            {
                Message = parameters.GetValue<string>("message");
            }
        }

        private void CloseDialog(string parameter)
        {
            ButtonResult result = parameter == "OK" ? ButtonResult.OK : ButtonResult.Cancel;
            var dialogResult = new DialogResult(result, new DialogParameters { { "userInput", UserInput } });
            RequestClose?.Invoke(dialogResult);
        }
    }
}
