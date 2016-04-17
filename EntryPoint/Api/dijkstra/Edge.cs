using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.api.dijkstra
{
    class Edge
    {
        private int fromNodeIndex;
        private int toNodeIndex;
        private float Distance;

        public Edge(int fromNodeIndex, int toNodeIndex, float length)
        {
            this.fromNodeIndex = fromNodeIndex;
            this.toNodeIndex = toNodeIndex;
            this.Distance = length;
        }

        private int getFromNodeIndex()
        {
            return fromNodeIndex;
        }

        private int getToNodeIndex()
        {
            return toNodeIndex;
        }

        public float getDistance()
        {
            return Distance;
        }

        public int getNeighbourIndex(int nodeIndex)
        {
            if (this.fromNodeIndex == nodeIndex)
            {
                return this.toNodeIndex;
            }
            else
            {
                return this.fromNodeIndex;
            }
        }

    }
}
