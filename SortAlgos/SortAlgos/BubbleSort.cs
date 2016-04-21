using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgos
{
    public class BubbleSort : SortingBase
    {
        public override void PerformSort()
        {
            bool isSorted;
            var itemCount = MaxSize;
            do
            {
                isSorted = true;
                itemCount--;
                for (var i = 0; i < itemCount; i++)
                {
                    if (SortingList[i] <= SortingList[i + 1]) continue;
                    var temp = SortingList[i + 1];
                    SortingList[i + 1] = SortingList[i];
                    SortingList[i] = temp;
                    isSorted = false;
                }
            } while (!isSorted);
        }
    }
}
