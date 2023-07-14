using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Services;

namespace FutureSpaceAPI.Application.Services
{
    public class LauncherService : ILauncherService
    {
        private readonly HttpClient _httpClient;

        public LauncherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Launcher> GetLauncher(int launchId)
        {
            throw new NotImplementedException();
        }

        //public async Task<Launcher> GetLauncher(int launchId)
        //{
        //    string endpoint = "https://exemplo.com/api/launchers/" + launchId;

        //    HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        // Processar a resposta e mapear para um objeto do domínio
        //        var responseBody = await response.Content.ReadAsStringAsync();
        //        var launcher = MapResponseToLauncher(responseBody);
        //        return launcher;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //private Launcher MapResponseToLauncher(string responseBody)
        //{
        //    // Lógica para mapear os dados da resposta para um objeto Launcher do domínio
        //    // Pode envolver desserialização, validações, etc.
        //    // Retornar uma instância de Launcher
        //}
    }
}
