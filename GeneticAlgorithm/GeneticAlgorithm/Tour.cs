using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Tour
    {
        public List<int> tour = new List<int>();
        public double totalDistance;
        public double viceVercaOfTotalDistance;
        public double ratioFitness;
        public double rankFitness;

        #region Constructor Methods
        public Tour(Tour forCopy)
        {
            foreach (var item in forCopy.tour)
            {
                this.tour.Add(item);
            }           
        }

        public Tour(Tour forCopy,Tour forCopy2, int index)
        {
            for (int i = 0; i < index; i++) this.tour.Add(forCopy.tour[i]);
            int count = forCopy.tour.Count;
            for (int i = 0; i < count; i++) if(!this.tour.Contains(forCopy2.tour[i])) this.tour.Add(forCopy2.tour[i]);
        }

        public Tour(Tour forCopy, Tour forCopy2, int index, int index2)
        {
            int[] temp = new int[forCopy.tour.Count];
            int tempCount = temp.Length;
            for (int i = 0; i < tempCount; i++) temp[i] = -1;

            for (int i = index; i < index2; i++) temp[i] = forCopy2.tour[i];

            for (int i = 0; i < index; i++) if (!temp.Contains(forCopy.tour[i])) temp[i] = forCopy.tour[i];

            for (int i = index2; i < tempCount; i++) if (!temp.Contains(forCopy.tour[i])) temp[i] = forCopy.tour[i];

            for (int i = index; i < index2; i++) if (!temp.Contains(forCopy.tour[i])) for (int j = 0; j < tempCount; j++) if (temp[j] == -1)
            {
                temp[j] = (forCopy.tour[i]);
                break;
            }

            this.tour = new List<int>(temp);
        }

        public Tour() { }
        #endregion
    }
}
