using NetCoreStarterApi.Logic.Interfaces;
using System.Threading.Tasks;

namespace NetCoreStarterApi.Logic.Services
{
    public class TransientService : ITransientService
    {
        private int _inMemoryCounter;

        public TransientService()
        {
            _inMemoryCounter = 0;
        }

        public async Task<int> GetCounter()
        {
            return _inMemoryCounter += 1;
        }
    }
}
