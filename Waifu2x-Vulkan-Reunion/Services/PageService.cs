namespace Waifu2x_Vulkan_Reunion.Services {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CommunityToolkit.Mvvm.ComponentModel;

    using Microsoft.UI.Xaml.Controls;

    using Waifu2x_Vulkan_Reunion.Contracts.Services;
    using Waifu2x_Vulkan_Reunion.ViewModels;
    using Waifu2x_Vulkan_Reunion.Views;

    public class PageService : IPageService {
        private readonly Dictionary<string, Type> _pages = new Dictionary<string, Type>();

        public PageService() {
            Configure<OverviewViewModel, OverviewPage>();
            Configure<SelectingImagesViewModel, SelectingImagesPage>();
            Configure<SettingWaifu2xViewModel, SettingWaifu2xPage>();
            Configure<ExportingViewModel, ExportingPage>();
        }

        public Type GetPageType(string key) {
            Type pageType;
            lock (_pages) {
                if (!_pages.TryGetValue(key, out pageType)) {
                    throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
                }
            }

            return pageType;
        }

        private void Configure<VM, V>()
            where VM : ObservableObject
            where V : Page {
            lock (_pages) {
                var key = typeof(VM).FullName;
                if (_pages.ContainsKey(key)) {
                    throw new ArgumentException($"The key {key} is already configured in PageService");
                }

                var type = typeof(V);
                if (_pages.Any(p => p.Value == type)) {
                    throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
                }

                _pages.Add(key, type);
            }
        }
    }
}
