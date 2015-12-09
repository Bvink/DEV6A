using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Merge
    {
        private Vector2[] arr;
        private Vector2[] temparr;
        Vector2 house;

        public void sort(Vector2 house, IEnumerable<Vector2> specialBuildings)
        {
            this.arr = specialBuildings.ToArray();
            this.house = house;
            int length = specialBuildings.Count();
            this.temparr = new Vector2[length];
            split(0, length-1);
        }

        private void split(int low, int high)
        {
            if (low < high)
            {
                int middle = low + (high - low) / 2;
                split(low, middle);
                split(middle + 1, high);
                merge(low, middle, high);
            }
        }

        private void merge(int low, int middle, int high)
        {
            for (int h = low; h <= high; h++)
            {
                temparr[h] = arr[h];
            }

            int i = low;
            int j = middle + 1;
            int k = low;
            while (i <= middle && j <= high)
            {
                if (Vector2.Distance(temparr[i], house) <= Vector2.Distance(temparr[j], house))
                {
                    arr[k] = temparr[i];
                    i++;
                }
                else {
                    arr[k] = temparr[j];
                    j++;
                }
                k++;
            }
            while (i <= middle)
            {
                arr[k] = temparr[i];
                k++;
                i++;
            }
        }

        public IEnumerable<Vector2> getList()
        {
            return this.arr;
        }
    }
}
