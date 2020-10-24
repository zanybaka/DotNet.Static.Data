using System.Text.Json.Serialization;

namespace DotNet.Static.Data
{
    public class TargetFrameworks
    {
        public string[] Monikers { get; set; }

        [JsonPropertyName("targetFrameworks")] public TargetFramework[] Frameworks { get; set; }
    }
}