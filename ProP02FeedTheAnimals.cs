using System;
using System.Collections.Generic;
using System.Linq;

namespace P02FeedTheAnimals
{
    class P02FeedTheAnimals
    {
        static void Main(string[] args)
        {
            var annimals = new Dictionary<string, string>();
            var annimalsFood = new Dictionary<string, int>();
            var annimalsArea = new Dictionary<string, int>();
            var fedAnnimal = new List<string>();
            string input;
            bool hungryAnnimal = true;
            while ((input = Console.ReadLine()) != "Last Info")
            {
                string[] listOfAnnimals = input.Split(":").ToArray();

                for (int i = 0; i < 1; i++)
                {
                    string command = listOfAnnimals[0];
                    string annimal = listOfAnnimals[1];
                    int daylydailyFoodLimit = int.Parse(listOfAnnimals[2]);
                    string area = listOfAnnimals[3];

                    if (command == "Add")
                    {
                        if (!(annimals.ContainsKey(annimal)))
                        {
                            annimals.Add(listOfAnnimals[1], listOfAnnimals[3]);
                            annimalsFood.Add(listOfAnnimals[1], int.Parse(listOfAnnimals[2]));
                        }
                        else
                        {
                            annimalsFood[annimal] += int.Parse(listOfAnnimals[2]);
                        }
                    }
                    else if (command == "Feed")
                    {
                        if (annimals.ContainsKey(annimal))
                        {
                            annimalsFood[annimal] -= int.Parse(listOfAnnimals[2]);

                            int food = annimalsFood[annimal];

                            if (food <= 0)
                            {
                                hungryAnnimal = false;
                                fedAnnimal.Add(annimal);
                                annimalsFood.Remove(annimal);
                                annimals.Remove(annimal);
                            }
                        }
                    }
                }
            }

            foreach (var item in fedAnnimal.OrderBy(x => x.Length))
            {
                Console.WriteLine($"{item} was successfully fed");
            }
            if (hungryAnnimal == false)
            {
                Console.WriteLine("Animal:");
                foreach (var kvp in annimalsFood.OrderByDescending(x => x.Key))
                {
                    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                }

                foreach (var kvp in annimalsFood.Where(x => x.Value > 0))
                {
                    string currentAnimal = kvp.Key;

                    if (annimals.ContainsKey(currentAnimal))
                    {
                        foreach (var area in annimals.Where(x => x.Key == currentAnimal))
                        {
                            string arreaToadded = area.Value;

                            if (!(annimalsArea.ContainsKey(arreaToadded) && annimals.ContainsKey(currentAnimal)))
                            {
                                annimalsArea.Add(arreaToadded, 1);
                            }
                            else if (annimalsArea.ContainsKey(arreaToadded) && annimals.ContainsKey(currentAnimal))
                            {
                                annimalsArea[arreaToadded] += 1;
                            }
                        }
                    }
                }

                Console.WriteLine("Areas with hungry animals:");
                foreach (var kvp in annimalsArea)
                {
                    Console.WriteLine($"{kvp.Key} : {kvp.Value}");
                }
            }
        }
    }
}
