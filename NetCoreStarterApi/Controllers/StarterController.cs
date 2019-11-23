using Microsoft.AspNetCore.Mvc;
using NetCoreStarterApi.Logic.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NetCoreStarterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StarterController : ControllerBase
    {
        private readonly ISingletonService _singletonService;
        private readonly IScopedService _scopedService;
        private readonly IScopedService _secondScopedService;
        private readonly ITransientService _transientService;
        private readonly ITransientService _secondTransientService;
        private readonly IAsyncService _asyncService;

        public StarterController(ISingletonService singletonService, IScopedService scopedService, ITransientService transientService, IScopedService secondScopedService, ITransientService secondTransientService, IAsyncService asyncService)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
            _secondScopedService = secondScopedService;
            _secondTransientService = secondTransientService;
            _asyncService = asyncService;
        }

        [HttpGet]
        [Route("")]
        public OkResult Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetSingletonCounter")]
        public async Task<int> GetSingletonCounter()
        {
            return await _singletonService.GetCounter();
        }

        [HttpGet]
        [Route("GetScopedCounter")]
        public async Task<int> GetScopedCounter()
        {
            await _scopedService.GetCounter();
            return await _secondScopedService.GetCounter();
        }

        [HttpGet]
        [Route("GetTransientCounter")]
        public async Task<int> GetTransientCounter()
        {
            await _transientService.GetCounter();
            return await _secondTransientService.GetCounter();
        }

        [HttpGet]
        [Route("GetAsyncTime")]
        public async Task<long> GetAsyncTime()
        {
            var watch = Stopwatch.StartNew();
            await _asyncService.Wait();
            await _asyncService.Wait();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        [HttpGet]
        [Route("GetAsyncTimeWithoutAwaits")]
        public async Task<long> GetAsyncTimeWithoutAwaits()
        {
            var watch = Stopwatch.StartNew();
            _asyncService.Wait();
            _asyncService.Wait();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        [HttpGet]
        [Route("GetAsyncTimeWhenAll")]
        public async Task<long> GetAsyncTimeWhenAll()
        {
            var watch = Stopwatch.StartNew();
            var firstTask = _asyncService.Wait();
            var secondTask = _asyncService.Wait();
            await Task.WhenAll(firstTask, secondTask);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        [HttpGet]
        [Route("GetAsyncTimeWhenAny")]
        public async Task<long> GetAsyncTimeWhenAny()
        {
            var watch = Stopwatch.StartNew();
            var firstTask = _asyncService.Wait();
            var secondTask = _asyncService.Wait();
            await Task.WhenAny(firstTask, secondTask);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        [HttpGet]
        [Route("GetAsyncTimeParallel")]
        public async Task<long> GetAsyncTimeParallel()
        {
            var watch = Stopwatch.StartNew();
            Parallel.Invoke(() => { _asyncService.Wait(); },
                () => { _asyncService.Wait(); });
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
