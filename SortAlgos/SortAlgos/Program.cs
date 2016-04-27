using System;
using System.Diagnostics;


namespace SortAlgos
{
    internal class Program
    {
        private static void Main(string[] args) {
            //Var's
            SortingBase sorts = new QuickSort();

            /* Driver template comments
            Set data generation order.
            Process the sort
            */
            //Quick Sorts
            sorts.DataGenerationOrder = GenerationOrder.Randomized;
            ProcessSort(sorts, "Quicksort Randomized");

            sorts.DataGenerationOrder = GenerationOrder.Ascending;
            ProcessSort(sorts, "Quicksort Ascending");

            sorts.DataGenerationOrder = GenerationOrder.Descending;
            ProcessSort(sorts, "Quicksort Descending");

            //End of qs
            Console.WriteLine("\nQuick sorts done. Hit any key to clear screen and continue.");
            Console.ReadKey();
            Console.Clear();

            /* 
             ***Bubble sort is irrelevant now, since quicksort is much faster at sorting Ascending data***
             *
            //Bubble Sorts
            sorts = new BubbleSort();
            sorts.DataGenerationOrder = GenerationOrder.Randomized;
            //ProcessSort(sorts, "Bubble Randomized");

            sorts.DataGenerationOrder = GenerationOrder.Ascending;
            ProcessSort(sorts, "Bubble Ascending");

            sorts.DataGenerationOrder = GenerationOrder.Descending;
            //ProcessSort(sorts, "Bubble Descending");
            
            //End of bs
            Console.WriteLine("\nBubble sorts done. All files are in the same directory as this program if you need to see output." +
                              "\nHit any key to clear screen and continue.");
            Console.ReadKey();
            Console.Clear();
            */
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortToProcess"></param>
        /// <param name="sortDescription"></param>
        private static void ProcessSort(SortingBase sortToProcess, string sortDescription) {
            var timer = new Stopwatch();
            Console.WriteLine("Generating numbers for {0}", sortDescription); 
            sortToProcess.GenerateData();
            Console.WriteLine("Start {0}!", sortDescription); 
            timer.Start();
            sortToProcess.PerformSort();
            timer.Stop();
            Console.WriteLine("\tTimer Elapsed: " + timer.Elapsed +
                              "\n\tTimer in MS: " + timer.ElapsedMilliseconds +
                              "\n\tTimer in Ticks: " + timer.ElapsedTicks);
            Console.WriteLine("Outputting to file...");
            sortToProcess.OutputListToFile(sortDescription);
            timer.Reset();
            Console.WriteLine("-----\n");
        }
    }
}