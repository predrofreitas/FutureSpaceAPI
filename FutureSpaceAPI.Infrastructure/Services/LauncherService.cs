using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Services;
using System.Net.Http.Json;

namespace FutureSpaceAPI.Infrastructure.Services
{
    public class LauncherService : ILauncherService
    {
        private readonly HttpClient _httpClient;
        private const string EndpointUrl = "https://ll.thespacedevs.com/2.0.0/launch/?limit=10&";
        public LauncherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Launcher>> GetLaunchersByPageAsync(int offset)
        {
            var offsetParameter = $"offset={offset}";
            var response = await _httpClient.GetFromJsonAsync<object>(EndpointUrl + offsetParameter);
            

            return null;
        }
    }
}
