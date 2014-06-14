using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlanetaryGravityCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream inFile = new FileStream(args[0], FileMode.Open);
            StreamReader sReader = new StreamReader(inFile);
            string line;
            int mass = Convert.ToInt32(sReader.ReadLine());
            int numPlanets = Convert.ToInt32(sReader.ReadLine());
            for (int i = 0; i < numPlanets; i++)
            {
                string planetLine = sReader.ReadLine();
                string[] splits = planetLine.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string planetName = splits[0];
                int planetRadius = Convert.ToInt32(splits[1]);
                int planetDesity = Convert.ToInt32(splits[2]);
                Planet planet = new Planet(planetRadius, planetDesity);
                Console.WriteLine("{0}: {1:0.000}", planetName, planet.gravitationalForce(mass));
            }
            Console.ReadLine();
        }
    }
}
