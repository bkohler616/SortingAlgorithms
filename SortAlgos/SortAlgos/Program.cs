using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Var's
            var timer = new Stopwatch();
            var quickSort = new QuickSort();

            //Sorting template:
            /*
            output "generating data"
            generate data
            output "start sort type"
            timer start
            perform sort
            timer stop
            output timer
            sortType.OutputListToFile
            timer reset
            */

            //qs random
            Console.WriteLine("Generating numbers for Quicksort Random");
            quickSort.GenerateRandomData();
            Console.WriteLine("Start Quicksort Random!");
            timer.Start();
            quickSort.PerformSort();
            timer.Stop();
            Console.WriteLine("Timer Elapsed: " + timer.Elapsed +
                              "\nTimer in MS: " + timer.ElapsedMilliseconds +
                              "\nTimer in Ticks: " + timer.ElapsedTicks);
            Console.WriteLine("Outputting to file...");
            quickSort.OutputListToFile("QuickSortRandom");
            timer.Reset();
            Console.WriteLine("-----");


            //qs ascending
            Console.WriteLine("Generating numbers for Quicksort Ascending");
            quickSort.GenerateAscendingData();
            Console.WriteLine("Start Quicksort Ascending!");
            timer.Start();
            quickSort.PerformSort();
            timer.Stop();
            Console.WriteLine("Timer Elapsed: " + timer.Elapsed +
                              "\nTimer in MS: " + timer.ElapsedMilliseconds +
                              "\nTimer in Ticks: " + timer.ElapsedTicks);
            Console.WriteLine("Outputting to file...");
            quickSort.OutputListToFile("QuickSortAscending");
            timer.Reset();
            Console.WriteLine("-----");

            //qs descending
            Console.WriteLine("Generating numbers for Quicksort Descending");
            quickSort.GenerateDescendingData();
            Console.WriteLine("Start Quicksort Descending!");
            timer.Start();
            quickSort.PerformSort();
            timer.Stop();
            Console.WriteLine("Timer Elapsed: " + timer.Elapsed +
                              "\nTimer in MS: " + timer.ElapsedMilliseconds +
                              "\nTimer in Ticks: " + timer.ElapsedTicks);
            Console.WriteLine("Outputting to file...");
            quickSort.OutputListToFile("QuickSortDescending");
            timer.Reset();
            Console.WriteLine("-----");

            //End of qs
            Console.WriteLine("\nQuick sorts done. Hit any key to clear screen and continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
