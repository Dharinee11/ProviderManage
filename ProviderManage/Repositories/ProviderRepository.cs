using ProviderManage.Models;
using ProviderManage.Repositories.Interfaces;

namespace ProviderManage.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private static readonly List<Provider> Providers =
        [
            new Provider
            {
                Id = 1,
                ProviderName = "Apollo Hospital",
                Email = "apollo@test.com",
                City = "Ahmedabad",
                IsActive = true
            },
            new Provider
            {
                Id = 2,
                ProviderName = "Care Hospital",
                Email = "care@test.com",
                City = "Surat",
                IsActive = true
            }
        ];

        public IEnumerable<Provider> GetAllProviders()
        {
            return Providers;
        }
    }
}