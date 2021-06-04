namespace Waifu2x_Vulkan_Reunion.Views {
    using System;
    using WinRT;
    using System.Runtime.InteropServices;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;

    using Waifu2x_Vulkan_Reunion.ViewModels;
    using Windows.Storage;
    using Windows.Storage.Pickers;

    public sealed partial class OverviewPage : Page {
        public OverviewViewModel ViewModel { get; }
        private readonly Waifu2xWrapper waifu2X = new();
        private static StorageFile input;
        private static StorageFile output;

        public OverviewPage() {
            ViewModel = Ioc.Default.GetService<OverviewViewModel>();
            InitializeComponent();
        }

        private async void OpenImage(object sender, RoutedEventArgs e) {
            var picker = new FileOpenPicker {
                SuggestedStartLocation = PickerLocationId.Downloads,
                FileTypeFilter = { ".jpg" }
            };

            InitializeWithWindow(picker);
            var image = await picker.PickSingleFileAsync();

            if (image == null)
                return;
            ImageText.Text = image.Path;
            input = image;
        }

        private async void SetFolder(object sender, RoutedEventArgs e) {
            var folder = await new FileSavePicker() {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            }.PickSaveFileAsync();

            if (folder == null)
                return;
            FolderText.Text = folder.Path;
            output = folder;
        }

        private void Start(object sender, RoutedEventArgs e) {
            if (input == null || output == null)
                return;

            waifu2X.setInput(input.Path);
            waifu2X.setOutput(output.Path);
            ((Button)sender).Content = waifu2X.execute() == 0 ? "Successful" : "Error";
        }

        public static void InitializeWithWindow(object obj) {
            // When running on win32, FileOpenPicker needs to know the top-level hwnd via IInitializeWithWindow::Initialize.
            if (Window.Current == null) {
                var initializeWithWindowWrapper = obj.As<IInitializeWithWindow>();
                var hwnd = App.MainWindow.As<IWindowNative>().WindowHandle;
                initializeWithWindowWrapper.Initialize(hwnd);
            }
        }

    }

    [ComImport]
    [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInitializeWithWindow {
        void Initialize([In] IntPtr hwnd);
    }
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EECDBF0E-BAE9-4CB6-A68E-9598E1CB57BB")]
    internal interface IWindowNative {
        IntPtr WindowHandle { get; }
    }
}
