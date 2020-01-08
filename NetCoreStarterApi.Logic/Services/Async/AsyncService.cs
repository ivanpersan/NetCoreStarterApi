using NetCoreStarterApi.Logic.Interfaces;
using System.Net.Http;
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

        public async Task<string> WaitReturnString()
        {
            Thread.Sleep(2000);
            return "";
        }


        public async Task<string> CallMockService()
        {
            var httpClient = new HttpClient();
            await httpClient.GetAsync("http://slowwly.robertomurray.co.uk/delay/1000/url/http://www.google.es");
            return "";
        }
    }
}
