using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace DotNet.Static.Data
{
    public class TargetFrameworks : IEquatable<TargetFrameworks>
    {
        public string[] Monikers { get; set; }

        [JsonPropertyName("targetFrameworks")] public TargetFramework[] Frameworks { get; set; }

        public bool Equals(TargetFrameworks other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Monikers?.SequenceEqual(other.Monikers) == true && Frameworks?.SequenceEqual(other.Frameworks) == true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TargetFrameworks) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (GetArrayGetHashCode(Monikers) * 397) ^ GetArrayGetHashCode(Frameworks);
            }
        }

        private int GetArrayGetHashCode<T>(T[] array)
        {
            if (array == null)
            {
                return 0;
            }

            int hash = 17;
            foreach (T element in array)
            {
                hash = hash * 31 + element.GetHashCode();
            }

            return hash;
        }
    }
}