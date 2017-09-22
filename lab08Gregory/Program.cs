using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using QuickType;
using System.Linq;

namespace lab08Gregory
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "data.json";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            string jsonString;
            using (StreamReader sr = File.OpenText(path))
            {
                jsonString = File.ReadAllText(path);
                //Console.WriteLine(jsonString);
            }
            List<string> filtered = new List<string>();

            var data = ManhattanNeighborhoods.FromJson(jsonString);
            //Console.WriteLine(data);

            IEnumerable<Feature> allHoods = from n in data.Features
                                            where n.Properties.Neighborhood != ""
                                            select n;

            foreach (var n in allHoods)
            {
                filtered.Add(n.Properties.Neighborhood);
                Console.WriteLine(n.Properties.Neighborhood);
            }
            Console.Read();

            Console.WriteLine("All Neighborhoods without Nulls");



        }
    }

}
