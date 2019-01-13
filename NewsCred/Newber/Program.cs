using System;
using static Newber.Factory;

namespace Newber
{
    class Program
    {

        static Location clientLocation;
        static Location driverLocation;


        public static double GetDriverScore(Driver driver)
        {
            int distance = int.MaxValue;
            driver.GetDistance(driverLocation, clientLocation, out distance);
            /*
            { "FareRate", 1.0 },
                        { "Capacity", 3.0 },
                        { "Distance", 4.5 },
                        { "TotalFine", 5.0 },
                        { "FineTimes", 7.0 },
                        { "Mileage", 4.0 },
                        { "Rating", 10.0 } */
            double negative = AllWeights["Capacity"] * driver.Capacity
            + AllWeights["Distance"] * distance
            + AllWeights["TotalFine"] * driver.TotalFine
            + AllWeights["FineTimes"] * driver.FineTimes;
            double positive = AllWeights["Mileage"] * driver.TotalKM;
            
        }

        static void Main(string[] args)
        {
            
        }
    }
}
