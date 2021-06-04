using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using Waifu2x_Vulkan_Reunion.ViewModels;

namespace Waifu2x_Vulkan_Reunion.Views
{
    public sealed partial class SettingWaifu2xPage : Page
    {
        public SettingWaifu2xViewModel ViewModel { get; }

        public SettingWaifu2xPage()
        {
            ViewModel = Ioc.Default.GetService<SettingWaifu2xViewModel>();
            InitializeComponent();
        }
    }
}
