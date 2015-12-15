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

        public TreeSearch(IEnumerable<Vector2> specialBuildings, IEnumerable<Tuple<Vector2, float>> housesAndDistances)
        {
            this.specialBuildings = specialBuildings;
            this.housesAndDistances = housesAndDistances;
        }

        public IEnumerable<IEnumerable<Vector2>> search()
        {
            return
            from h in this.housesAndDistances
            select
              from s in this.specialBuildings
              where Vector2.Distance(h.Item1, s) <= h.Item2
              select s;
        }
    }
}
