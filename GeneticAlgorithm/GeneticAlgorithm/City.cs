using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public class City
    {
        public double x, y;
        public City(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public List<double> distanceToOther = new List<double>();
    }
}
