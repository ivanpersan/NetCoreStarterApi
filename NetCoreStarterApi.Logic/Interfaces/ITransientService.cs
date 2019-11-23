using System.Threading.Tasks;

namespace NetCoreStarterApi.Logic.Interfaces
{
    public interface ITransientService
    {
        Task<int> GetCounter();
    }
}
