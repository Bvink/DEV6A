using EntryPoint.Api.KdTree;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class TreeSearch
    {

        private IEnumerable<Vector2> specialBuildings;
        private IEnumerable<Tuple<Vector2, float>> housesAndDistances;
        private KDTree tree;
        private List<Vector2> results;

        public TreeSearch(IEnumerable<Vector2> specialBuildings, IEnumerable<Tuple<Vector2, float>> housesAndDistances)
        {
            this.specialBuildings = specialBuildings;
            this.housesAndDistances = housesAndDistances;
            this.tree = new KDTree(2);
            createData(tree);

        }

        public void search()
        {
            this.results = new List<Vector2>();
            this.results = findInRange(results);
        }

        private IEnumerable<Vector2> getSearch()
        {
            return this.results;
        }

        public IEnumerable<IEnumerable<Vector2>> getResults()
        {
            var arr = new[]
            {
                getSearch()
            };
            return arr;
        }

        private void createData(KDTree tree)
        {
            foreach (Vector2 v in specialBuildings)
            {
                double[] key = { convertFloatToDouble(v.X), convertFloatToDouble(v.Y) };
                tree.insert(key, v);
            }
        }

        private List<Vector2> findInRange(List<Vector2> results)
        {

            foreach (Tuple<Vector2, float> h in housesAndDistances)
            {
                double[] low = { h.Item1.X - h.Item2, h.Item1.Y - h.Item2 };
                double[] high = { h.Item1.X + h.Item2, h.Item1.Y + h.Item2 };
                Object[] res = tree.range(low, high);
                foreach (object o in res)
                {
                    if (inRadius(o, h))
                    {
                        results.Add((Vector2)o);
                    }
                }
            }
            return results;
        }

        private bool inRadius(Object o, Tuple<Vector2, float> h)
        {
            return Vector2.Distance((Vector2) o, h.Item1) <= h.Item2;
        }

        private double convertFloatToDouble(float value)
        {
            decimal decimalValue = System.Convert.ToDecimal(value);
            double doubleValue = System.Convert.ToDouble(decimalValue);
            return doubleValue;
        }
    }
}
