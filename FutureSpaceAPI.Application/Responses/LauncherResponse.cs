using FutureSpaceAPI.Domain.Entities;
using Newtonsoft.Json;

namespace FutureSpaceAPI.Application.Responses
{
    public class LauncherResponse
    {
        public DateTime ImportDate { get; private set; }
        public Launch Launch { get; private set; }

        public LauncherResponse(DateTime importDate, string launchJson)
        {
            ImportDate = importDate;
            Launch = JsonConvert.DeserializeObject<Launch>(launchJson.ToString());
        }
    }
}