namespace Waifu2x_Vulkan_Reunion.Views {
    using System;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;

    using Waifu2x_Vulkan_Reunion.ViewModels;
    using Waifu2x_Vulkan_Reunion.Helpers;
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

            WindowHelper.InitializeWithWindow(picker);
            var image = await picker.PickSingleFileAsync();

            if (image == null)
                return;
            ImageText.Text = image.Path;
            input = image;
        }

        private async void SetFolder(object sender, RoutedEventArgs e) {
            var picker = new FileSavePicker() {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };

            WindowHelper.InitializeWithWindow(picker);
            var folder = await picker.PickSaveFileAsync();

            if (folder == null)
                return;
            FolderText.Text = folder.Path;
            output = folder;
        }

        private void Start(object sender, RoutedEventArgs e) {
            if (input == null)
                return;

            waifu2X.setInput(input.Path);
            waifu2X.setOutput(input.Path + "_opt.png");
            ((Button)sender).Content = waifu2X.execute() == 0 ? "Successful" : "Error";
        }

    }
}
