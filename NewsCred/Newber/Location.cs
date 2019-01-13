using System.Collections.Generic;

namespace Newber
{
    public class Location
    {
        public string Name { get; set; }
        public Dictionary<string, int> Distances { get; set; }

        //public Location() => Distances = new Dictionary<string, double>();
    }
}