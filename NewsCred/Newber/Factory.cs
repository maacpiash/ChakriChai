using System.Collections.Generic;

namespace Newber
{
    public static class Factory
    {
        private static List<Location> locations;

        public static List<Location> AllLocations
        {
            get
            {
                if (locations == null)
                    locations = new List<Location>()
                    {
                        new Location()
                        {
                            Name = "Uttara",
                            Distances = new Dictionary<string, int>()
                            {
                                { "Bashundhara", 20 },
                                { "Banani", 25 }
                            }
                        },
                        new Location()
                        {
                            Name = "Banani",
                            Distances = new Dictionary<string, int>()
                            {
                                { "Uttara", 25 },
                                { "Bashundhara", 15 },
                                { "Tejgaon", 10 }
                            }
                        },
                        new Location()
                        {
                            Name = "Bashundhara",
                            Distances = new Dictionary<string, int>()
                            {
                                { "Uttara", 20 },
                                { "Banani", 15 },
                                { "Rampura", 15}
                            }
                        },
                        new Location()
                        {
                            Name = "Rampura",
                            Distances = new Dictionary<string, int>()
                            {
                                { "Bashundhara", 15 },
                                { "Tejgaon", 5 },
                                { "Motijheel", 30 }
                            }
                        },
                        new Location()
                        {
                            Name = "Tejgaon",
                            Distances = new Dictionary<string, int>()
                            {
                                { "Banani", 10 },
                                { "Rampura", 5 },
                                { "Motijheel", 15 }
                            }
                        },
                        new Location()
                        {
                            Name = "Motijheel",
                            Distances = new Dictionary<string, int>()
                            {
                                { "Rampura", 30 },
                                { "Tejgaon", 15 }
                            }
                        }
                    };
                return locations;
            }
        }

        private static List<Driver> drivers;

        public static List<Driver> AllDrivers
        {
            get
            {
                if (drivers == null)
                    drivers = new List<Driver>()
                    {
                        new Driver()
                        {
                            Name = "ABC",
                            PhoneNum = "01711223344",

                            // Lower => Better
                            FarePerKM = 5.0,
                            Capacity = 4,
                            FineTimes = 3,
                            TotalFine = 1500,

                            // Higher => Better
                            TotalKM = 100,
                            Rating = 4
                        },
                        new Driver()
                        {
                            Name = "PQR",
                            PhoneNum = "01711523344",

                            // Lower => Better
                            FarePerKM = 5.0,
                            Capacity = 4,
                            FineTimes = 3,
                            TotalFine = 1500,

                            // Higher => Better
                            TotalKM = 200,
                            Rating = 3
                        },
                        new Driver()
                        {
                            Name = "XYZ",
                            PhoneNum = "01711278344",

                            // Lower => Better
                            FarePerKM = 10.0,
                            Capacity = 5,
                            FineTimes = 2,
                            TotalFine = 2000,

                            // Higher => Better
                            TotalKM = 150,
                            Rating = 3
                        }
                    };
                return drivers;
            }
        }

        private static Dictionary<string, double> weights;

        public static Dictionary<string, double> AllWeights
        {
            get
            {
                if (weights == null)
                    weights = new Dictionary<string, double>()
                    {
                        { "FareRate", 1.0 },
                        { "Capacity", 3.0 },
                        { "Distance", 4.5 },
                        { "TotalFine", 5.0 },
                        { "FineTimes", 7.0 },
                        { "Mileage", 4.0 },
                        { "Rating", 10.0 }
                    };
                return weights;
            }
        }
    }
}