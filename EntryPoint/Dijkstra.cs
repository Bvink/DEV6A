using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Dijkstra
    {

        private Vector2 startingBuilding;
        private Vector2 destinationBuilding;
        private IEnumerable<Tuple<Vector2, Vector2>> roads;

        public Dijkstra(Vector2 startingBuilding,
          Vector2 destinationBuilding, IEnumerable<Tuple<Vector2, Vector2>> roads)
        {
            this.startingBuilding = startingBuilding;
            this.destinationBuilding = destinationBuilding;
            this.roads = roads;
            Vector2 v = new Vector2(2, 2);
            foreach (Tuple<Vector2, Vector2> road in roads)
            {
                
                if(road.Item1 == v || road.Item2 == v)
                    Console.WriteLine(road);
            }
        }

        public IEnumerable<Tuple<Vector2, Vector2>> result()
        {
            var startingRoad = roads.Where(x => x.Item1.Equals(startingBuilding)).First();
            List<Tuple<Vector2, Vector2>> fakeBestPath = new List<Tuple<Vector2, Vector2>>() { startingRoad };
            var prevRoad = startingRoad;
            for (int i = 0; i < 1000; i++)
            {
                prevRoad = (roads.Where(x => x.Item1.Equals(prevRoad.Item2)).OrderBy(x => Vector2.Distance(x.Item2, destinationBuilding)).First());
                fakeBestPath.Add(prevRoad);
            }
            return fakeBestPath;
        }
    }
}
