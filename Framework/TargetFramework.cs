using System;
using System.Diagnostics;
using System.Linq;

namespace DotNet.Static.Data
{
    [DebuggerDisplay("Name: {Name}}")]
    public class TargetFramework : IEquatable<TargetFramework>
    {
        public string Name { get; set; }
        public string[] BaseSymbols { get; set; }
        public string[] Monikers { get; set; }

        public bool Equals(TargetFramework other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && BaseSymbols?.SequenceEqual(other.BaseSymbols) == true && Monikers?.SequenceEqual(other.Monikers) == true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TargetFramework) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Name != null ? Name.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (BaseSymbols != null ? GetArrayGetHashCode(BaseSymbols) : 0);
                hashCode = (hashCode * 397) ^ (Monikers != null ? GetArrayGetHashCode(Monikers) : 0);
                return hashCode;
            }
        }

        private int GetArrayGetHashCode(string[] array)
        {
            if (array == null)
            {
                return 0;
            }

            int hash = 17;
            foreach (string element in array)
            {
                hash = hash * 31 + element.GetHashCode();
            }

            return hash;
        }
    }
}