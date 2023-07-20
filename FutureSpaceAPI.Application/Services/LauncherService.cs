using FutureSpaceAPI.Application.Helpers;
using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using FutureSpaceAPI.Domain.Interfaces.Services;
using Hangfire;
using Newtonsoft.Json;

namespace FutureSpaceAPI.Application.Services
{
    public class LauncherService : ILauncherService
    {
        private readonly HttpClient _httpClient;
        private readonly ILauncherRepository _launcherRepository;
        private static string _url = "https://ll.thespacedevs.com/2.0.0/launch/?limit=100&offset=100";

        public LauncherService(ILauncherRepository launcherRepository, HttpClient httpClient)
        {
            _launcherRepository = launcherRepository;
            _httpClient = httpClient;
        }

        [AutomaticRetry(Attempts = 2)]
        [AutoDisableJob]
        public async Task Execute()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage responseMessage = await httpClient.GetAsync(_url);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var launchers = new List<Launcher>();
                        var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                        var response = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

                        _url = response?.next.Value;

                        foreach (var result in response.results)
                        {
                            var launch = JsonConvert.DeserializeObject<Launch>(result.ToString());

                            var launcher = new Launcher()
                            {
                                LaunchId = launch.Id,
                                LaunchJson = result.ToString(),
                                ImportDate = DateTime.Now,
                            };

                            launchers.Add(launcher);
                        }

                        await _launcherRepository.InsertInRangeAsync(launchers);
                        LauncherServiceExecutionCount.ExecutionCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

