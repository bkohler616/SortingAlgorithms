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
            var quickSort = new QuickSort();


            //Quick Sorts
            quickSort.DataGenerationOrder = GenerationOrder.Randomized;
            ProcessSort(quickSort, "Quicksort Randomized");

            quickSort.DataGenerationOrder = GenerationOrder.Ascending;
            ProcessSort(quickSort, "Quicksort Ascending");

            quickSort.DataGenerationOrder = GenerationOrder.Descending;
            ProcessSort(quickSort, "Quicksort Descending");

            //End of qs
            Console.WriteLine("\nQuick sorts done. Hit any key to clear screen and continue.");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ProcessSort(SortingBase sortToProcess, string sortDescription)
        {
            var timer = new Stopwatch();
            Console.WriteLine($"Generating numbers for {sortDescription}");
            sortToProcess.GenerateData();
            Console.WriteLine($"Start {sortDescription}!");
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
