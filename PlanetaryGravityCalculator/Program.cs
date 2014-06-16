using System;
using System.Text.RegularExpressions;
using System.IO;

namespace PlanetaryGravityCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream inFile = new FileStream(args[0], FileMode.Open);
            StreamReader sReader = new StreamReader(inFile);
            int mass = Convert.ToInt32(sReader.ReadLine());
            int numPlanets = Convert.ToInt32(sReader.ReadLine());
            for (int i = 0; i < numPlanets; i++)
            {
                string planetLine = sReader.ReadLine();
                //string[] splits = planetLine.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                Regex reg = new Regex(@"^(.*),\s(\d+),\s(\d+)$");
                string[] matches = reg.Split(planetLine);
                // regex returns an empty string if a match exists and begin and end of line, so...
                if (matches.Length != 5)
                {
                    Console.WriteLine("Not enough elements: {0}", planetLine);
                    continue;
                }
                //string planetName = splits[0];
                string planetName = matches[1];
                //int planetRadius = Convert.ToInt32(splits[1]);
                int planetRadius = Convert.ToInt32(matches[2]);
                //int planetDesity = Convert.ToInt32(splits[2]);
                int planetDesity = Convert.ToInt32(matches[3]);
                Planet planet = new Planet(planetName, planetRadius, planetDesity);
                Console.WriteLine("{0}: {1:0.000}", planet.Name, planet.gravitationalForce(mass));
                if (sReader.EndOfStream)
                {
                    Console.WriteLine("Reached end of stream before {0} planets read.", numPlanets);
                    break;
                }
            }
            inFile.Close();
            Console.ReadLine();
        }
    }
}