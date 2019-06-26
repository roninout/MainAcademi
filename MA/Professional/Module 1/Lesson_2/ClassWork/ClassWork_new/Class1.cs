using System;

[assembly: CLSCompliant(true)]
namespace ClassWork_new
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]

        public sealed class BirdSpeciesAttribute : System.Attribute
        {
            public string Classification { get; set; }

            public BirdSpeciesAttribute() { }

            public BirdSpeciesAttribute(string classification)
            {
                Classification = classification;
            }
        }

        [SerializableAttribute]
        [BirdSpecies("Black song is croak")]
        public class Crow { }

        [BirdSpecies("Small song is croak")]
        public class Titmouse { }
    }
