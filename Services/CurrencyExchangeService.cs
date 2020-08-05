using AppGr8.WebApiECommerce.Services.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppGr8.WebApiECommerce.Services
{
    /// <summary>
    /// Class for calling the 3rd party API (https://exchangeratesapi.io/)
    /// </summary>
    public class CurrencyExchangeService
    {
        public static async Task ExecuteJsonAsync()
        {
            HttpClient _httpClient = new HttpClient();
            JsonSerializer _serializer = new JsonSerializer();
            var url = "https://api.exchangeratesapi.io/latest?base=USD";

            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using var sr = new StreamReader(await response.Content.ReadAsStreamAsync());
                    using var jsonTextReader = new JsonTextReader(sr);
                    var exchangeRateResult = _serializer.Deserialize<CurrencyExchange>(jsonTextReader);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}
