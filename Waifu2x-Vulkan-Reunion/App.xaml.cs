// To learn more about WinUI3, see: https://docs.microsoft.com/windows/apps/winui/winui3/.
namespace Waifu2x_Vulkan_Reunion {
    using CommunityToolkit.Mvvm.DependencyInjection;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.UI.Xaml;

    using Waifu2x_Vulkan_Reunion.Activation;
    using Waifu2x_Vulkan_Reunion.Contracts.Services;
    using Waifu2x_Vulkan_Reunion.Helpers;
    using Waifu2x_Vulkan_Reunion.Services;
    using Waifu2x_Vulkan_Reunion.ViewModels;
    using Waifu2x_Vulkan_Reunion.Views;

    public partial class App : Application {
        public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };

        public App() {
            InitializeComponent();
            UnhandledException += App_UnhandledException;
            Ioc.Default.ConfigureServices(ConfigureServices());
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/windows/winui/api/microsoft.ui.xaml.unhandledexceptioneventargs
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args) {
            base.OnLaunched(args);
            var activationService = Ioc.Default.GetService<IActivationService>();
            await activationService.ActivateAsync(args);
        }

        private System.IServiceProvider ConfigureServices() {
            // TODO WTS: Register your services, viewmodels and pages here
            var services = new ServiceCollection();

            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddTransient<INavigationViewService, NavigationViewService>();
            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Core Services

            // Views and ViewModels
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();

            services.AddTransient<OverviewViewModel>();
            services.AddTransient<OverviewPage>();
            services.AddTransient<SelectingImagesViewModel>();
            services.AddTransient<SelectingImagesPage>();
            services.AddTransient<SettingWaifu2xViewModel>();
            services.AddTransient<SettingWaifu2xPage>();
            services.AddTransient<ExportingViewModel>();
            services.AddTransient<ExportingPage>();
            return services.BuildServiceProvider();
        }
    }
}
