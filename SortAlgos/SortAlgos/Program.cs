using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortAlgos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Var's
            SortingBase sorts;

            /* Driver template comments
            Set data generation order.
            Process the sort
            */
            //Quick Sorts
            sorts = new QuickSort();
            sorts.DataGenerationOrder = GenerationOrder.Randomized;
            ProcessSort(sorts, "Quicksort Randomized");

            sorts = new QuickSort();
            sorts.DataGenerationOrder = GenerationOrder.Ascending;
            ProcessSort(sorts, "Quicksort Ascending");

            sorts = new QuickSort();
            sorts.DataGenerationOrder = GenerationOrder.Descending;
            ProcessSort(sorts, "Quicksort Descending");

            //End of qs
            Console.WriteLine("\nQuick sorts done. Hit any key to clear screen and continue.");
            Console.ReadKey();
            Console.Clear();


            //Bubble Sorts
            sorts = new BubbleSort();
            sorts.DataGenerationOrder = GenerationOrder.Randomized;
            ProcessSort(sorts, "Bubble Randomized");

            sorts.DataGenerationOrder = GenerationOrder.Ascending;
            ProcessSort(sorts, "Bubble Ascending");

            sorts.DataGenerationOrder = GenerationOrder.Descending;
            ProcessSort(sorts, "Bubble Descending");

            //End of qs
            Console.WriteLine("\nQuick sorts done. Hit any key to clear screen and continue.");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ProcessSort(SortingBase sortToProcess, string sortDescription)
        {
            var timer = new Stopwatch();
            Console.WriteLine($"Generating numbers for {sortDescription}");//If this doesn't work in VS 2012, switch with non-interpolated string.
            sortToProcess.GenerateData();
            Console.WriteLine($"Start {sortDescription}!"); //If this doesn't work in VS 2012, switch with non-interpolated string.
            timer.Start();
            sortToProcess.PerformSort();
            timer.Stop();
            Console.WriteLine($"\tTimer Elapsed: {timer.Elapsed}" +
                              $"\n\tTimer in MS: {timer.ElapsedMilliseconds}" +
                              $"\n\tTimer in Ticks: {timer.ElapsedTicks}");//If this doesn't work in VS 2012, switch with non-interpolated string.
            Console.WriteLine("Outputting to file...");
            sortToProcess.OutputListToFile(sortDescription);
            timer.Reset();
            Console.WriteLine("-----\n");
        }
    }
}
