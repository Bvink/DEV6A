using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.api.dijkstra
{
    class Node
    {
        private Vector2 v;
        private List<Edge> edges = new List<Edge>();
        private float distanceFromSource = float.MaxValue;
        private Boolean visited = false;
        private int previousNode = -1;

        public Node(Vector2 v)
        {
            this.v = v;
        }

        public Vector2 getVector()
        {
            return this.v;
        }

        public void addEdge(Edge e)
        {
            this.edges.Add(e);
        }

        public List<Edge> getEdges()
        {
            return edges;
        }

        public void setDistanceFromSource(float dis)
        {
            this.distanceFromSource = dis;
        }

        public float getDistanceFromSource()
        {
            return distanceFromSource;
        }

        public void setVisited(Boolean b)
        {
            this.visited = b;
        }

        public Boolean isVisited()
        {
            return visited;
        }

        public void setPreviousNode(int previousNode)
        {
            this.previousNode = previousNode;
        }

        public int getPreviousNode()
        {
            return previousNode;
        }
    }
}
