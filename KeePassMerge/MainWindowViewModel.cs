using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace KeePassMerge
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        private StorageFile? fromFile;
        private StorageFile? toFile;

        [ObservableProperty]
        private string fromFilePath = "";

        [ObservableProperty]
        private string toFilePath = "";

        [ObservableProperty]
        private string fromFilePassword = "";

        [ObservableProperty]
        private string toFilePassword = "";

        [ObservableProperty]
        private bool useSamePasswords = true;

        partial void OnFromFilePasswordChanged(string? oldValue, string newValue)
        {
            if (UseSamePasswords && oldValue != newValue)
            {
                ToFilePassword = newValue;
            }
        }

        partial void OnToFilePasswordChanged(string? oldValue, string newValue)
        {
            if (UseSamePasswords && oldValue != newValue)
            {
                FromFilePassword = newValue;
            }
        }

        [RelayCommand]
        private async Task SelectToFile(Microsoft.UI.Xaml.Window parentWindow)
        {
            toFile = await SelectFile(parentWindow);
            ToFilePath = toFile?.Path ?? "";
            MergeCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand]
        private async Task SelectFromFile(Microsoft.UI.Xaml.Window parentWindow)
        {
            fromFile = await SelectFile(parentWindow);
            FromFilePath = fromFile?.Path ?? "";
            MergeCommand.NotifyCanExecuteChanged();
        }

        private async Task<StorageFile?> SelectFile(Microsoft.UI.Xaml.Window parentWindow)
        {
            var filePicker = new FileOpenPicker();

            // Get the current window's HWND by passing in the Window object
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(parentWindow);

            // Associate the HWND with the file picker
            WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);

            // Use file picker like normal!
            filePicker.FileTypeFilter.Add("*");
            return await filePicker.PickSingleFileAsync();
        }

        [RelayCommand]
        private void Cancel(Microsoft.UI.Xaml.Window parentWindow)
        {
            parentWindow.Close();
        }

        [RelayCommand(CanExecute = nameof(CanMerge))]
        private async Task Merge()
        {
        }

        private bool CanMerge()
        {
            return toFile != null && fromFile != null;
        }
    }
}
