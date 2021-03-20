using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace LingvoWeb.Service
{
    public class Translate : ITranslateable
    {
        private const string apiurl = "https://developers.lingvolive.com/";
        private static readonly HttpClient client = new HttpClient();

#if DEBUG
        private const string appKeyPath = @"../../../appkey";
        private const string keyPath = @"../../../key";
#else
        private const String appKeyPath = @"appkey";
        private const String keyPath = @"key";
#endif

        private string key;

        public async Task<string> GetTranslation(
            string toTranslate,
            LanguageEnum srcLang,
            LanguageEnum dstLang,
            bool isShort = false)
        {
            try
            {
                var builder = new UriBuilder(apiurl + (isShort ? "api/v1/minicard" : "api/v1/translation"))
                {
                    Port = -1
                };
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["text"] = toTranslate;
                query["srcLang"] = ((ushort)srcLang).ToString();
                query["dstLang"] = ((ushort)dstLang).ToString();
                builder.Query = query.ToString();
                string url = builder.ToString();

                var response = await client.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return new string("");
            }
        }

        public async Task Initialize()
        {
            key = ReadKey();

            TimeSpan dateDiff = DateTime.Now - File.GetLastWriteTime(keyPath);

            if (key.Length < 2 || dateDiff.TotalHours > 24)
            {
                await RenewAuthenticationKey();
            }
            else
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", key);
                Console.WriteLine("Key is up to date.");
            }
        }

        private async Task RenewAuthenticationKey()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", GetAppKey());
                var httpContent = new MultipartContent();
                var response = await client.PostAsync(apiurl + "api/v1.1/authenticate", httpContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(responseBody);
                await WriteKey(responseBody);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", key);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        private async Task WriteKey(string key)
        {
            try
            {
                await File.WriteAllTextAsync(keyPath, key);
                Console.WriteLine("New key has been successfully written.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nCant write in key file!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        private string ReadKey()
        {
            try
            {
                string result = File.ReadAllText(keyPath);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nCant read key file!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }

        private string GetAppKey()
        {
            try
            {
                string result = File.ReadAllText(appKeyPath);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nCant read appkey file!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }
    }
}
