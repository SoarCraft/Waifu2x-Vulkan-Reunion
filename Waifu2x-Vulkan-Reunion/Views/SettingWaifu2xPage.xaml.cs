namespace Waifu2x_Vulkan_Reunion.Views {
    using CommunityToolkit.Mvvm.DependencyInjection;

    using Microsoft.UI.Xaml.Controls;

    using Waifu2x_Vulkan_Reunion.ViewModels;

    public sealed partial class SettingWaifu2xPage : Page {
        public SettingWaifu2xViewModel ViewModel { get; }

        public SettingWaifu2xPage() {
            ViewModel = Ioc.Default.GetService<SettingWaifu2xViewModel>();
            InitializeComponent();
        }
    }
}
