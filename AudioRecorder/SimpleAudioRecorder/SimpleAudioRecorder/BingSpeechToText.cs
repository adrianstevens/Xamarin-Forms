using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace SimpleAudioRecorder
{
    public class BingSpeechToText
    {
        AuthenticationService authenticationService;

        HttpClient httpClient;

        public BingSpeechToText(string apiKey)
        {
            authenticationService = new AuthenticationService(apiKey);
        }

        public async Task<SpeechResult> RecognizeSpeechAsync(string filename)
        {
            SpeechResult result;

            using (FileStream stream = File.OpenRead(filename))
            {
                var requestUri = GetRequestUri(Constants.SpeechRecognitionEndpoint);
                var accessToken = await authenticationService.GetAccessToken();

                var response = await SendRequestAsync(stream, requestUri, accessToken, Constants.AudioContentType);

                result = JsonConvert.DeserializeObject<SpeechResult>(response);
            }
            return result;
        }

        string GetRequestUri(string speechEndpoint)
        {
            return $"{speechEndpoint}dictation/cognitiveservices/v1?language=en-us&format=simple";
        }

        async Task<string> SendRequestAsync(Stream fileStream, string url, string bearerToken, string contentType)
        {
            if (httpClient == null)
                httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var content = new StreamContent(fileStream);
            content.Headers.TryAddWithoutValidation("Content-Type", contentType);

            var response = await httpClient.PostAsync(url, content);

            return await response.Content.ReadAsStringAsync();
        }
    }
}