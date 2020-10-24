using System.Diagnostics;

namespace DotNet.Static.Data
{
    [DebuggerDisplay("Name: {Name}}")]
    public class TargetFramework
    {
        public string Name { get; set; }
        public string[] BaseSymbols { get; set; }
        public string[] Monikers { get; set; }
    }
}