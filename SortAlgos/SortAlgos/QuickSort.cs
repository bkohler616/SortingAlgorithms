using System.Threading.Tasks;


namespace SortAlgos
{
    public class QuickSort : SortingBase
    {
        /// <summary>
        ///     Begin sorting the SortingList data.
        /// </summary>
        public override void PerformSort() { quickSort(SortingList, 0, SortingList.Length - 1, 2); }

        /// <summary>
        ///     Quicksort performed via a middle-item type
        /// </summary>
        /// <param name="data">the data to sort</param>
        /// <param name="low">the low end of the current pivot</param>
        /// <param name="high">the high end of the current pivot</param>
        /// <param name="multithreadCount">enable multithreading for the stated amount of child sets.</param>
        private void quickSort(int[] data, int low, int high, uint multithreadCount) {
            //No more sorting to do for this pivot end.
            if (low >= high)
                return;

            //Get the middle item
            var pivot = data [low + (high - low) / 2];

            int incrementalLow = low, incrementalHigh = high;
            while (incrementalLow <= incrementalHigh) {
                //Keep incrementing the low until we find an item >= the middle data
                while (data [incrementalLow] < pivot) {
                    incrementalLow++;
                }
                //Keep decrementing the high until we find an item <= the middle item
                while (data [incrementalHigh] > pivot) {
                    incrementalHigh--;
                }

                //If we managed to get low to get past high, assume it's sorted properly.
                if (incrementalLow > incrementalHigh) continue; //Shave off ~1-3 ms by using continue.
                //Swap data items
                var temp = data [incrementalLow];
                data [incrementalLow] = data [incrementalHigh];
                data [incrementalHigh] = temp;
                incrementalLow++;
                incrementalHigh--;
            }

            //Create new threads, and go further on each pivot if needed. This shaves time by ~300 ms
            if (multithreadCount == 0) {

                if (low < incrementalHigh)
                    quickSort(data, low, incrementalHigh, 0);
                if (high > incrementalLow)
                    quickSort(data, incrementalLow, high, 0); //It is better to use tail recursion rather than a loop. A loop increases time by ~ 4-8 ms
            }
            else {
                if (low < incrementalHigh)
                {
                    Task.Factory.StartNew(() => { quickSort(data, low, incrementalHigh, multithreadCount - 1); });
                }
                if (high > incrementalLow)
                {
                    Task.Factory.StartNew(() => { quickSort(data, incrementalLow, high, multithreadCount - 1); });
                }
                //Task.WaitAll(lowEnd, highEnd);//Aparently, this adds ~150-300 ms to the time.
            }
        }
    }
}