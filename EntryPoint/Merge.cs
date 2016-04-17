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
        private Vector2 house;
        private int length;

        public Merge(Vector2 house, IEnumerable<Vector2> specialBuildings)
        {
            this.arr = specialBuildings.ToArray();
            this.house = house;
            this.length = specialBuildings.Count();
            this.temparr = new Vector2[length];
        }

        public void sort()
        {
            split(0, length - 1);
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
                if (calcDistance(temparr[i]) <= calcDistance(temparr[j]))
                {
                    arr[k] = temparr[i];
                    i++;
                }
                else
                {
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

        private float calcDistance(Vector2 v)
        {
            return Vector2.Distance(v, this.house);
        }

        public IEnumerable<Vector2> getList()
        {
            return this.arr;
        }
    }
}
