using System.Threading.Tasks;

namespace NetCoreStarterApi.Logic.Interfaces
{
    public interface ISingletonService
    {
        Task<int> GetCounter();
    }
}
