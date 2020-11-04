namespace CSharp.Solution.Editor.Extensions
{
    public static class FrameworkExtensions
    {
        /// <remarks>
        ///     https://docs.microsoft.com/en-us/dotnet/standard/frameworks
        /// </remarks>
        public static string ToSymbol(this string moniker)
        {
            return moniker?
                .ToUpper()
                .Replace('.', '_')
                .Replace('-', '_');
        }
    }
}