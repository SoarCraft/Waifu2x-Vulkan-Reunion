using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using Waifu2x_Vulkan_Reunion.ViewModels;

namespace Waifu2x_Vulkan_Reunion.Views
{
    public sealed partial class ExportingPage : Page
    {
        public ExportingViewModel ViewModel { get; }

        public ExportingPage()
        {
            ViewModel = Ioc.Default.GetService<ExportingViewModel>();
            InitializeComponent();
        }
    }
}
