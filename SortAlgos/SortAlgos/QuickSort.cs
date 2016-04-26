using System.Threading.Tasks;


namespace SortAlgos
{
    public class QuickSort : SortingBase
    {
        public override void PerformSort() { quickSort(SortingList, 0, SortingList.Length - 1, true); }

        /// <summary>
        ///     Quicksort performed via a middle-item type
        /// </summary>
        /// <param name="data">the data to sort</param>
        /// <param name="low">the low end of the current pivot</param>
        /// <param name="high">the high end of the current pivot</param>
        private void quickSort(int[] data, int low, int high, bool isMultithread) {
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
            if (isMultithread) {
                if (low < incrementalHigh) {
                    Task.Factory.StartNew(() => { quickSort(data, low, incrementalHigh, false); });
                }
                if (high > incrementalLow) {
                    Task.Factory.StartNew(() => { quickSort(data, incrementalLow, high, false); });
                }
                //Task.WaitAll(lowEnd, highEnd);//Aparently, this adds ~150-300 ms to the time.
            }
            else {
                if (low < incrementalHigh)
                    quickSort(data, low, incrementalHigh, false);
                if (high > incrementalLow)
                    quickSort(data, incrementalLow, high, false); //It is better to use tail recursion rather than a loop. A loop increases time by ~ 4-8 ms
            }
        }
    }
}