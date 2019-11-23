using NetCoreStarterApi.Logic.Interfaces;
using System.Threading.Tasks;

namespace NetCoreStarterApi.Logic.Services
{
    public class ScopedService : IScopedService
    {
        private int _inMemoryCounter;

        public ScopedService()
        {
            _inMemoryCounter = 0;
        }

        public async Task<int> GetCounter()
        {
            return await Task.Run(() =>
            {
                return _inMemoryCounter += 1;
            });
        }
    }
}
