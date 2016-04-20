using System;
using System.Diagnostics;
using System.IO;

namespace SortAlgos
{
    public abstract class SortingBase
    {
        /// <summary>
        /// The size limit of the data list.
        /// </summary>
        private const int MaxSize = 500000;
        /// <summary>
        /// The data where all of the sorting information will be stored.
        /// </summary>
        public int[] SortingList { get; set; }

        /// <summary>
        /// Generate descending data
        /// </summary>
        public void GenerateDescendingData()
        {
            SortingList = new int[MaxSize];
            int temp = MaxSize;
            for (int i = 0; temp > 0; temp--)
            {
                SortingList[i] = temp;
                i++;
            }
        }

        /// <summary>
        /// Generate random integers to be sorted.
        /// </summary>
        public void GenerateRandomData()
        {
            var rng = new Random();
            SortingList = new int[MaxSize];
            //Generate numbers
            for (var i = 0; i < MaxSize; i++)
                SortingList[i] = rng.Next(MaxSize);
        }

        /// <summary>
        /// Generate Ascending integers to be sorted
        /// </summary>
        public void GenerateAscendingData()
        {
            SortingList = new int[MaxSize];
            for (var i = 0; i < MaxSize; i++)
                SortingList[i] = i;
        }

        /// <summary>
        /// Begin sorting the SortingList data.
        /// </summary>
        public void PerformSort()
        {
            throw new NotImplementedException("The sort does not have any procedures.\n" +
                                              "Please implement an override for the PreformSort function");
        }

        /// <summary>
        /// Output the SortingList data to file
        /// </summary>
        /// <param name="fileName">The file name to output to (do not add .txt)</param>
        public void OutputListToFile(string fileName)
        {
            fileName = fileName + ".txt";
            var file = new StreamWriter(fileName);
            foreach (var i in SortingList)
            {
                file.WriteLine(i);
            }
            Process.Start(fileName);
        }
    }
}
