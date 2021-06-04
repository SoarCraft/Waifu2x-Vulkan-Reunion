namespace Waifu2x_Vulkan_Reunion.Views {
    using CommunityToolkit.Mvvm.DependencyInjection;

    using Microsoft.UI.Xaml.Controls;

    using Waifu2x_Vulkan_Reunion.ViewModels;

    public sealed partial class SelectingImagesPage : Page {
        public SelectingImagesViewModel ViewModel { get; }

        public SelectingImagesPage() {
            ViewModel = Ioc.Default.GetService<SelectingImagesViewModel>();
            InitializeComponent();
        }
    }
}
