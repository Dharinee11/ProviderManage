using ProviderManage.Models;

namespace ProviderManage.Services.Interfaces
{
    public interface IProviderService
    {
        IEnumerable<Provider> GetProviders();
    }
}