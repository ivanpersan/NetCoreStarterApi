using NetCoreStarterApi.Logic.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreStarterApi.Logic.Services.Async
{
    public class AsyncService : IAsyncService
    {
        public AsyncService()
        {
        }

        public async Task Wait()
        {
            Thread.Sleep(2000);
        }
    }
}
