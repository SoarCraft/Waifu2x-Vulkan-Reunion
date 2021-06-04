using Microsoft.UI.Xaml.Controls;

namespace Waifu2x_Vulkan_Reunion.Helpers
{
    public static class FrameExtensions
    {
        public static object GetPageViewModel(this Frame frame)
            => frame?.Content?.GetType().GetProperty("ViewModel")?.GetValue(frame.Content, null);
    }
}
