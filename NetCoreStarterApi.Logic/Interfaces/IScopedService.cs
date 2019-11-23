using System.Threading.Tasks;

namespace NetCoreStarterApi.Logic.Interfaces
{
    public interface IScopedService
    {
        Task<int> GetCounter();
    }
}
