using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GeneticAlgorithm
{
    class Tsp
    {
        #region Variables
        private string[] variables = { "NAME", "COMMENT", "TYPE", "DIMENSION", "EDGE_WEIGHT_TYPE", "NODE_COORD_SECTION" };
        public string[] variablesValue = new string[5];
        private string selectionMethod, crossoverOperator, mutationOperator;

        private double mutationRatio, elitismCount, crossoverRatio, elitismRatio, best = double.MaxValue;
        private int populationCount, iterationCount, citiesCount;

        public List<City> cities = new List<City>();
        public List<int> bestTour = new List<int>();
        private Population firstPopulation = new Population(), secondPopulation = new Population();
        public List<DataPoint> averageList = new List<DataPoint>(), bestList = new List<DataPoint>();

        Random r = new Random();
        #endregion
        #region Like Constructor Method
        public void Fillİnfo(int populationCount, double mutationRatio, double crossoverRatio, int iterationCount, double elitismRatio, string selectionMethod, string crossoverOperator, string mutationOperator)
        {
            this.populationCount = populationCount;
            this.mutationRatio = mutationRatio;
            this.iterationCount = iterationCount;
            this.elitismRatio = elitismRatio;
            this.elitismCount = Math.Round(elitismRatio * populationCount);
            this.selectionMethod = selectionMethod;
            this.crossoverOperator = crossoverOperator;
            this.mutationOperator = mutationOperator;
            this.crossoverRatio = crossoverRatio;
        }
        #endregion       
        #region Graphic Operation
        void takeInfoForGraphics()
        {
            double totalTotalDistance = 0;
            foreach (var item in firstPopulation.population) totalTotalDistance += item.totalDistance;
            totalTotalDistance /= populationCount;

            if (firstPopulation.population[0].totalDistance < best)
            {
                best = firstPopulation.population[0].totalDistance;
                bestTour = firstPopulation.population[0].tour.ToList();
            }

            int temp = bestList.Count;

            averageList.Add(new DataPoint(temp, totalTotalDistance));
            bestList.Add(new DataPoint(temp, best));
        }
        #endregion
        #region File Operations

        //Read File
        public bool takeAFile()
        {
            string tsp = "";
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Something|*.tsp", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    tsp = sr.ReadToEnd();
                    sr.Close();
                    fs.Close();
                    return parseText(tsp);
                }
                else return false;
            }
        }

        //Parse File
        bool parseText(string text)
        {
            text = text.Trim();
            //Take Sections
            int firstNodeRow = 0;
            List<string> listOfLines = new List<string>();
            string[] vectorOfLines = text.Split('\n');

            int vectorOfLinesCount = vectorOfLines.Length;
            for (int i = 0; i < vectorOfLinesCount; i++)
            {
                if (vectorOfLines[i].Trim().Equals(variables[5]))
                {
                    firstNodeRow = i;
                    break;
                }
                else
                {
                    if (vectorOfLines[i].Contains(':'))
                    {
                        string[] temp = vectorOfLines[i].Split(':');
                        temp[0] = temp[0].Trim();
                        temp[1] = temp[1].Trim();
                        for (int j = 0; j < variables.Length - 1; j++)
                        {
                            if (temp[0] == variables[j])
                            {
                                variablesValue[j] = temp[1];
                                break;
                            }
                        }
                    }
                }
            }
            string[] edgeWeightTypeVariables = { "EUC_2D", "MAX_2D", "MAN_2D", "CEIL_2D" };
            if (edgeWeightTypeVariables.Contains(variablesValue[4]))
            {
                //Take Node
                for (int j = firstNodeRow + 1; j < vectorOfLinesCount; j++)
                {
                    if (vectorOfLines[j] != "EOF")
                    {
                        List<string> temp = new List<string>();
                        foreach (var item in vectorOfLines[j].Split(' '))
                        {
                            if (item != " " && item.Length > 0)
                                temp.Add(item);
                        }
                        City tempCity = new City(Convert.ToDouble(temp[1]), Convert.ToDouble(temp[2]));
                        cities.Add(tempCity);
                    }
                    else break;
                }
                citiesCount = cities.Count;
                switch (variablesValue[4])
                {
                    case "EUC_2D":
                        calculateDistance(distanceEUC2D);
                        break;
                    case "MAX_2D":
                        calculateDistance(distanceMAX2D);
                        break;
                    case "MAN_2D":
                        calculateDistance(distanceMAN2D);
                        break;
                    case "CEIL_2D":
                        calculateDistance(distanceCEIL2D);
                        break;
                }
                return true;
            }
            else
            {
                MessageBox.Show("Dosya Bilinenlerden Farklı Bir Mesafe Ağırlıklandırma Yöntemi İçeriyor..");
                return false;
            }
        }

        //Write File
        public void writeFile()
        {
            string name = variablesValue[0];
            string temp = "";
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = name + ".opt.tour";
            sfd.Title = "Save an Opt.Tour File";

            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
            {
                FileStream fs = (FileStream)sfd.OpenFile();
                StreamWriter sw = new StreamWriter(fs);
                temp += "NAME : " + name + ".opt.tour\n" +
                    "COMMENT : " + best.ToString() + "  #   " + "Population: " + populationCount + "   Iteration: " + iterationCount + "   Elitism Ratio: " + elitismRatio + "   Mutation Ratio: " + mutationRatio + "   Crossover Ratio: " + crossoverRatio + "\n" +
                    "TYPE : TOUR\n" +
                    "DIMENSION : " + bestTour.Count + "\n" +
                    "TOUR_SECTION\n";
                foreach (var item in bestTour) temp += (item + 1).ToString() + "\n";
                temp += "-1\nEOF\n";
                sw.Write(temp);
                sw.Close();
                fs.Close();
            }
        }

        #endregion
        #region Distance Methods 
        double distanceEUC2D(City first, City second)
        {
            return Math.Sqrt(Math.Pow(first.x - second.x, 2) + Math.Pow(first.y - second.y, 2));
        }
        double distanceMAX2D(City first, City second)
        {
            return Math.Max(Math.Abs(first.x - second.x), Math.Abs(first.y - second.y));
        }
        double distanceMAN2D(City first, City second)
        {
            return Math.Abs(first.x - second.x) + Math.Abs(first.y - second.y);
        }
        double distanceCEIL2D(City first, City second)
        {
            return Math.Ceiling(distanceEUC2D(first, second));
        }
        void calculateDistance(Func<City, City, double> distance)
        {
            for (int i = 0; i < citiesCount; i++) for (int j = 0; j < citiesCount; j++) cities[i].distanceToOther.Add(distance(cities[i], cities[j]));
        }
        #endregion
        #region Population Methods
        void productionOfFirstPopulation()
        {
            int[] forRandom = new int[citiesCount];

            for (int i = 0; i < citiesCount; i++) forRandom[i] = i;

            for (int i = 0; i < populationCount; i++)
            {
                List<int> forRandomCopy = new List<int>(forRandom);
                Tour temp = new Tour();
                int random;
                for (int j = 0; j < forRandomCopy.Count;)
                {
                    random = r.Next(forRandomCopy.Count);
                    temp.tour.Add(forRandomCopy[random]);
                    forRandomCopy.RemoveAt(random);
                }
                firstPopulation.population.Add(temp);
            }
        }
        void calculatePopulationFitness(Population population)
        {
            for (int i = 0; i < populationCount; i++)
            {
                for (int j = 0; j < citiesCount - 1; j++)
                {
                    population.population[i].totalDistance += cities[population.population[i].tour[j]].distanceToOther[population.population[i].tour[j + 1]];
                }
                population.population[i].totalDistance += cities[population.population[i].tour[population.population[i].tour.Count - 1]].distanceToOther[population.population[i].tour[0]];
            }

            for (int i = 0; i < populationCount; i++)
            {
                population.population[i].viceVercaOfTotalDistance = 1 / population.population[i].totalDistance;
                population.totalViceVercaOfTotalDistance += population.population[i].viceVercaOfTotalDistance;
            }
            population.population = population.population.OrderByDescending(x => x.viceVercaOfTotalDistance).ToList();

            double temp = 0, tempCount = 0;
            double Count = populationCount;
            double totalCount = populationCount * (populationCount + 1) / 2;

            if (selectionMethod == "Fitness Ratio Base Roulette Wheel Selection")
            {
                for (int i = 0; i < populationCount; i++)
                {
                    temp += (population.population[i].viceVercaOfTotalDistance / population.totalViceVercaOfTotalDistance);
                    population.population[i].ratioFitness = temp;
                }
            }
            else
            {
                for (int i = 0; i < populationCount; i++, Count--)
                {
                    tempCount += Count / totalCount;
                    population.population[i].rankFitness = tempCount;
                }
            }
        }
        #endregion
        #region Selection Methods
        Tour selection(Population population)
        {
            if (selectionMethod == "Fitness Ratio Base Roulette Wheel Selection")
            {
                return fitnessRatioBaseRouletteWheelSelection(population);
            }
            else
            {
                return fitnessRankBaseRouletteWheelSelection(population);
            }
        }
        Tour fitnessRatioBaseRouletteWheelSelection(Population population)
        {
            double temp = r.NextDouble();
            int index = 0;
            for (int i = populationCount - 1; i >= 0; i--)
            {
                if (temp >= population.population[i].ratioFitness)
                {
                    index = i;
                    break;
                }
            }
            return population.population[index];
        }
        Tour fitnessRankBaseRouletteWheelSelection(Population population)
        {
            double temp = r.NextDouble();
            int index = 0;
            for (int i = populationCount - 1; i >= 0; i--)
            {
                if (temp >= population.population[i].rankFitness)
                {
                    index = i;
                    break;
                }
            }
            return population.population[index];
        }
        #endregion
        #region Crossover Methods
        void crossover()
        {
            double temporaryCount = (populationCount / 2.0) - (elitismCount / 2);
            for (int i = 0; i < elitismCount; i++)
            {
                secondPopulation.population.Add(new Tour());
                secondPopulation.population[i].tour = firstPopulation.population[i].tour;
            }
            switch (crossoverOperator)
            {
                case "Single Point Crossover":
                    for (int i = 0; i < temporaryCount; i++)
                    {
                        Tour firstParent = new Tour(selection(firstPopulation));
                        Tour secondParent = new Tour(selection(firstPopulation));
                        int index = r.Next(citiesCount);
                        singlePointCrossover(firstParent, secondParent, index);
                    }
                    if (populationCount % 2 != elitismCount % 2)
                    {
                        secondPopulation.population.RemoveAt(populationCount);
                    }
                    break;
                case "Double Point Crossover":
                    for (int i = 0; i < temporaryCount; i++)
                    {
                        Tour firstParent = new Tour(selection(firstPopulation));
                        Tour secondParent = new Tour(selection(firstPopulation));
                        int index = r.Next(citiesCount);
                        int index2 = index;
                        while (index == index2)
                        {
                            index2 = r.Next(citiesCount);
                        }
                        if (index > index2) doublePointCrossover(firstParent, secondParent, index2, index);
                        else doublePointCrossover(firstParent, secondParent, index, index2);
                    }
                    if (populationCount % 2 != elitismCount % 2)
                    {
                        secondPopulation.population.RemoveAt(populationCount);
                    }
                    break;
                case "Sequential Constructive Crossover":
                    for (int i = 0; i < populationCount - elitismCount; i++)
                    {
                        Tour firstParent = new Tour(selection(firstPopulation));
                        Tour secondParent = new Tour(selection(firstPopulation));
                        int index = r.Next(citiesCount);
                        sequentialConstructiveCrossover(firstParent, secondParent);
                    }
                    break;
            }
        }
        void singlePointCrossover(Tour first, Tour second, int index)
        {
            if (r.NextDouble() <= crossoverRatio)
            {
                Tour child = new Tour(first, second, index);
                secondPopulation.population.Add(child);
                Tour child2 = new Tour(second, first, index);
                secondPopulation.population.Add(child2);
            }
            else
            {
                secondPopulation.population.Add(first);
                secondPopulation.population.Add(second);
            }
        }
        void doublePointCrossover(Tour first, Tour second, int index, int index2)
        {
            if (r.NextDouble() <= crossoverRatio)
            {
                Tour child = new Tour(first, second, index, index2);
                secondPopulation.population.Add(child);
                Tour child2 = new Tour(second, first, index, index2);
                secondPopulation.population.Add(child2);
            }
            else
            {
                secondPopulation.population.Add(first);
                secondPopulation.population.Add(second);
            }
        }
        void sequentialConstructiveCrossover(Tour first, Tour second)
        {
            if (r.NextDouble() <= crossoverRatio)
            {
                int Count = first.tour.Count;
                List<int> reachedCity = new List<int>();
                int reachedCityCount = 0;
                int findFirstUnreached(Tour tour)
                {
                    int temp = -1;
                    for (int i = tour.tour.IndexOf(reachedCity[reachedCityCount]) + 1; i < Count; i++)
                    {
                        if (!reachedCity.Contains(tour.tour[i]))
                        {
                            temp = tour.tour[i];
                            break;
                        }
                    }
                    if (temp == -1)
                    {
                        for (int i = 1; i < Count; i++)
                        {
                            if (!reachedCity.Contains(i))
                            {
                                temp = i;
                                break;
                            }
                        }
                    }
                    return temp;
                }
                Tour child = new Tour();
                int forFirst, forSecond;
                reachedCity.Add(0);
                for (int i = 0; i < Count - 1; i++)
                {
                    forFirst = findFirstUnreached(first);
                    forSecond = findFirstUnreached(second);
                    if (forFirst == forSecond)
                    {
                        reachedCity.Add(forFirst);
                        reachedCityCount++;
                    }
                    else
                    {
                        if (cities[reachedCity[reachedCityCount]].distanceToOther[forFirst] > cities[reachedCity[reachedCityCount]].distanceToOther[forSecond])
                        {
                            reachedCity.Add(forSecond);
                            reachedCityCount++;
                        }
                        else
                        {
                            reachedCity.Add(forFirst);
                            reachedCityCount++;
                        }
                    }
                }
                child.tour = new List<int>(reachedCity);
                secondPopulation.population.Add(child);
            }
            else
            {
                if (r.NextDouble() < 0.5) secondPopulation.population.Add(first);
                else secondPopulation.population.Add(second);
            }
        }
        #endregion
        #region Mutation Methods
        void mutation()
        {
            switch (mutationOperator)
            {
                case "Twors Mutation":
                    tworsMutation();
                    break;
                case "Reverse Sequence Mutation":
                    reverseSequenceMutation();
                    break;
            }
        }
        void tworsMutation()
        {
            for (int i = 0; i < populationCount; i++)
            {
                if (r.NextDouble() <= mutationRatio)
                {
                    int random1 = r.Next(citiesCount);
                    int random2 = random1;
                    while (random1 == random2)
                    {
                        random2 = r.Next(citiesCount);
                    }
                    int temp = secondPopulation.population[i].tour[random1];
                    secondPopulation.population[i].tour[random1] = secondPopulation.population[i].tour[random2];
                    secondPopulation.population[i].tour[random2] = temp;
                }
            }
            firstPopulation = secondPopulation;
            secondPopulation = new Population();
        }
        void reverseSequenceMutation()
        {
            for (int i = 0; i < populationCount; i++)
            {
                if (r.NextDouble() <= mutationRatio)
                {
                    int random1 = r.Next(citiesCount);
                    int random2 = random1;
                    while (random1 == random2)
                    {
                        random2 = r.Next(citiesCount);
                    }
                    if (random1 < random2)
                        for (int k = random1, l = random2; k <= (random1 + random2) / 2 && l >= (random1 + random2) / 2; k++, l--)
                        {
                            int temp = secondPopulation.population[i].tour[k];
                            secondPopulation.population[i].tour[k] = secondPopulation.population[i].tour[l];
                            secondPopulation.population[i].tour[l] = temp;
                        }
                    else
                        for (int k = random2, l = random1; k <= (random1 + random2) / 2 && l >= (random1 + random2) / 2; k++, l--)
                        {
                            int temp = secondPopulation.population[i].tour[k];
                            secondPopulation.population[i].tour[k] = secondPopulation.population[i].tour[l];
                            secondPopulation.population[i].tour[l] = temp;
                        }
                }
            }
            firstPopulation = secondPopulation;
            secondPopulation = new Population();
        }
        #endregion

        public void Run(ToolStripProgressBar bar, ToolStripStatusLabel label)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            bestList.Clear(); averageList.Clear(); best = double.MaxValue;
            firstPopulation = new Population();
            productionOfFirstPopulation();

            for (int i = 0; i < iterationCount; i++)
            {
                calculatePopulationFitness(firstPopulation);
                takeInfoForGraphics();
                crossover();
                mutation();
                bar.Value = i + 1;
                label.Text = sw.Elapsed.ToString().Substring(3, 8);
                Application.DoEvents();
            }

            calculatePopulationFitness(firstPopulation);
            takeInfoForGraphics();
            sw.Stop();
            label.Text = sw.Elapsed.ToString().Substring(3, 8);

            MessageBox.Show("Optimal Solution :" + best.ToString(), "Result");
        }
    }
}
