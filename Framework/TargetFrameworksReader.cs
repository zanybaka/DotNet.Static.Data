using System.IO;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNet.Static.Data
{
    public class TargetFrameworksReader
    {
        public const string DefaultUrl = "https://raw.githubusercontent.com/zanybaka/DotNet.Static.Data/master/target-frameworks.json";

        public async Task<TargetFrameworks> ReadEmbeddedAsync()
        {
            var assembly     = Assembly.GetExecutingAssembly();
            var resourceName = "DotNet.Static.Data.target-frameworks.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                return await ReadAndDeserializeFromStreamAsync(stream);
            }
        }

        public async Task<TargetFrameworks> LoadFromNetworkAsync(string url = DefaultUrl)
        {
            using (var client = new WebClient())
            {
                using (Stream stream = await client.OpenReadTaskAsync(url))
                {
                    return await ReadAndDeserializeFromStreamAsync(stream);
                }
            }
        }

        public TargetFrameworks ReadFromJson(string json)
        {
            return DeserializeJson(json);
        }

        private static async Task<TargetFrameworks> ReadAndDeserializeFromStreamAsync(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string text = await reader.ReadToEndAsync();
                return DeserializeJson(text);
            }
        }

        private static TargetFrameworks DeserializeJson(string json)
        {
            return JsonSerializer.Deserialize<TargetFrameworks>(
                json
                , new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }
    }
}