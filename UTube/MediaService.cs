using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace UTube {
    public class MediaService {
        private readonly string mediaAPIAddress;
        private readonly string medialistCommand;

        private readonly HttpClient httpClient;

        public MediaService() {
            mediaAPIAddress = "https://localhost:44307/api/";
            medialistCommand = "medialist";

            httpClient = new HttpClient();
        }

        public string[] GetMediaList() => httpClient.GetFromJsonAsync<string[]>(APICommand(medialistCommand)).Result;

        public string GetUrlByName(string name) => $"{mediaAPIAddress}mediafile?name={name}";

        private string APICommand(string command) => mediaAPIAddress + command;
    }
}
