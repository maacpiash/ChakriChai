using System;
using System.Collections.Generic;
using System.Linq;
using static Newber.Factory;

namespace Newber
{
    public class Driver
    {
        #region Absolute Attributes
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public double FarePerKM { get; set; }
        public double TotalKM { get; set; }
        public CarType CarType { get; set; }
        public string CarNumber { get; set; }
        public int Capacity { get; set; }
        public Location CurrentLocation { get; set; }
        public int FineTimes { get; set; }
        public double TotalFine { get; set; }
        public int Rating { get => _rating; set => _rating = value < 6 && value > 0 ? value : 0; }
        private int _rating;

        #endregion

        public double Score;
        
        public List<string> GetDistance(Location driver, Location client, out int distance)
        {
            distance = 0;

            Dictionary<string, Dictionary<string, int>> vertices = new Dictionary<string, Dictionary<string, int>>();
            foreach (Location from in AllLocations)
            {
                vertices[from.Name] = from.Distances;
            }

            var previous = new Dictionary<string, string>();
            var distances = new Dictionary<string, int>();
            var nodes = new List<string>();

            List<string> path = null;

            foreach (var vertex in vertices)
            {
                if (vertex.Key == driver.Name)
                    distances[vertex.Key] = 0;
                else
                    distances[vertex.Key] = int.MaxValue;
                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == client.Name)
                {
                    path = new List<string>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }
                    break;
                }

                if (distances[smallest] == double.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in vertices[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        distance += alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            return path;
        }
    }

    public enum CarType { S, M, L }

    
}