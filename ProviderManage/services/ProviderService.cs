using ProviderManage.Models;
using ProviderManage.Repositories.Interfaces;
using ProviderManage.Services.Interfaces;

namespace ProviderManage.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(
            IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public IEnumerable<Provider> GetProviders()
        {
            return _providerRepository.GetAllProviders();
        }
    }
}