using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryGravityCalculator
{
    public class Planet
    {
        public const double G = 6.67e-11;

        private string name;
        private int radius;
        private int density;
        private double volume;
        private double mass;

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public Planet(string name, int radius, int density)
        {
            this.name = name;
            this.radius = radius;
            this.density = density;
            this.volume = 4.0D / 3.0D * Math.PI * Math.Pow(this.radius, 3);
            this.mass = volume * density;
        }

        public double gravitationalForce(int mass)
        {
            return G * ((mass * this.mass) / Math.Pow(radius, 2));
        }
    }
}
