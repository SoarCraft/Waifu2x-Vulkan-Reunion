using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using Waifu2x_Vulkan_Reunion.ViewModels;

namespace Waifu2x_Vulkan_Reunion.Views
{
    public sealed partial class OverviewPage : Page
    {
        public OverviewViewModel ViewModel { get; }

        public OverviewPage()
        {
            ViewModel = Ioc.Default.GetService<OverviewViewModel>();
            InitializeComponent();
        }
    }
}
