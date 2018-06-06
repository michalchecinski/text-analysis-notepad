using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TextAnalysisNotepad
{
    public class Recognision
    {
        private readonly string _connectionString;

        private readonly HttpClient client = new HttpClient();

        public Recognision(string cognitiveServicesConnectionString)
        {
            _connectionString = cognitiveServicesConnectionString;
        }

        public async Task<KeyPhrasesJson> RecogniseKeyPhrases(string text)
        {
            string json = GetSendJson(text);

            var uri = "https://northeurope.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases";

            var responseString = await GetResponseStringAsync(uri, json);

            return JsonConvert.DeserializeObject<KeyPhrasesJson>(responseString);
        }

        public async Task<SentimentJson> RecogniseSentiment(string text)
        {
            var json = GetSendJson(text);

            var uri = "https://northeurope.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";

            var responseString = await GetResponseStringAsync(uri, json);

            return JsonConvert.DeserializeObject<SentimentJson>(responseString);
        }

        private string GetSendJson(string text)
        {
            SendJson sendJson = new SendJson();
            Document doc = new Document
            {
                text = text,
                id = "1"
            };
            sendJson.documents = new Document[1];
            sendJson.documents[0] = doc;

            string json = JsonConvert.SerializeObject(sendJson);
            return json;
        }

        private async Task<string> GetResponseStringAsync(string uri, string json)
        {
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _connectionString);

            var response = await client.PostAsync(
                uri,
                new StringContent(json, Encoding.UTF8, "application/json"));

            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
    }
}
