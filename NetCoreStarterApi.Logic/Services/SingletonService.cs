using NetCoreStarterApi.Logic.Interfaces;
using System.Threading.Tasks;

namespace NetCoreStarterApi.Logic.Services
{
    public class SingletonService : ISingletonService
    {
        private int _inMemoryCounter;

        public SingletonService()
        {
            _inMemoryCounter = 0;
        }

        public async Task<int> GetCounter()
        {
            return _inMemoryCounter += 1;
        }
    }
}
