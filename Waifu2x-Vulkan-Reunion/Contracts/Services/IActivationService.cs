using System.Threading.Tasks;

namespace Waifu2x_Vulkan_Reunion.Contracts.Services {
    public interface IActivationService {
        Task ActivateAsync(object activationArgs);
    }
}
