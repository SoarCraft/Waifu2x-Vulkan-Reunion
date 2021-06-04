using System.Threading.Tasks;

namespace Waifu2x_Vulkan_Reunion.Activation {
    public interface IActivationHandler {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
