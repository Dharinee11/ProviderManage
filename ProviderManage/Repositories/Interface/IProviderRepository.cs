using ProviderManage.Models;

namespace ProviderManage.Repositories.Interfaces
{
    public interface IProviderRepository
    {
        IEnumerable<Provider> GetAllProviders();
    }
}