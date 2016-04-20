using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgos
{
    class QuickSort : SortingBase
    {
        public override void PerformSort()
        {
            quickSort(SortingList, 0, SortingList.Length - 1);
        }

        /// <summary>
        /// Quicksort performed via a middle-item type
        /// </summary>
        /// <param name="data">the data to sort</param>
        /// <param name="low">the low end of the current pivot</param>
        /// <param name="high">the high end of the current pivot</param>
        private void quickSort(int[] data, int low, int high)
        {

            //No more sorting to do for this pivot end.
            if (low >= high)
                return;

            //Get the middle item
            int middle = low + (high - low) / 2;
            int pivot = data[middle];

            int incrementalLow = low, incrementalHigh = high;
            while (incrementalLow <= incrementalHigh)
            {
                //Keep incrementing the low until we find an item >= the middle data
                while (data[incrementalLow] < pivot)
                {
                    incrementalLow++;
                }
                //Keep decrementing the high until we find an item <= the middle item
                while (data[incrementalHigh] > pivot)
                {
                    incrementalHigh--;
                }

                //If we managed to get low to get past high, assume it's sorted properly.
                if (incrementalLow <= incrementalHigh)
                {
                    //Swap data items
                    int temp = data[incrementalLow];
                    data[incrementalLow] = data[incrementalHigh];
                    data[incrementalHigh] = temp;
                    incrementalLow++;
                    incrementalHigh--;
                }
            }

            //Create new threads, and go further on each pivot if needed.
            var sortTasks = new List<Task>();
            if (low < incrementalHigh)
                sortTasks.Add(Task.Factory.StartNew(() => { quickSort(data, low, incrementalHigh); }));
            if (high > incrementalLow)
                sortTasks.Add(Task.Factory.StartNew(() => { quickSort(data, incrementalLow, high); }));
            Task.WaitAll(sortTasks.ToArray());
        }
    }
}
