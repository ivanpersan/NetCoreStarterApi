using System.Threading.Tasks;

namespace NetCoreStarterApi.Logic.Interfaces
{
    public interface IAsyncService
    { 
        Task Wait();
        Task<string> CallMockService();
        Task<string> WaitReturnString();
    }
}
