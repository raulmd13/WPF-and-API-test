using Mecalux_WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux_WPF
{
    public class TextOrderApiCaller
    {
        string BaseUrl = @"https://localhost:44382/api/TextProcess/";
        string GetOrderOptionsUrl = @"GetOrderOptions";
        string GetOrderedTextUrl = @"GetOrderedText";
        string GetStatisticsUrl = @"GetStatistics";

        public List<string> GetOrderTypes()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);

            HttpResponseMessage response = client.GetAsync(GetOrderOptionsUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<string>>(jsonString);
            }
            else
            {
                return null;
            }
        }

        public string OrderText(string textToOrder, string selectedOrderOption)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);

            HttpResponseMessage response = client.GetAsync(GetOrderedTextUrl+$"?textToOrder={textToOrder}&orderOption={selectedOrderOption}").Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return null;
            }
        }
        public TextStatistics GetTextStatistics(string textToAnalyze)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);

            HttpResponseMessage response = client.GetAsync(GetStatisticsUrl+$"?text={textToAnalyze}").Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TextStatistics>(jsonString);
            }
            else
            {
                return null;
            }
        }
    }
}
