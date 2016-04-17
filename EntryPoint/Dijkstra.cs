using EntryPoint.api.dijkstra;
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
        private Node[] nodes;
        private List<Node> nodeExistance = new List<Node>();

        public Dijkstra(Vector2 startingBuilding,
          Vector2 destinationBuilding, IEnumerable<Tuple<Vector2, Vector2>> roads)
        {
            this.startingBuilding = startingBuilding;
            this.destinationBuilding = destinationBuilding;
            this.roads = roads;
            setNodes();
            this.nodes = nodeExistance.ToArray();
            setEdges();
            calculateShortestDistances();
        }

        private void setNodes()
        {
            foreach (Tuple<Vector2, Vector2> road in roads)
            {
                if (!checkIfNodeExists(road.Item1))
                {
                    this.nodeExistance.Add(new Node(road.Item1));
                }
            }
        }

        private void setEdges()
        {
            foreach (Tuple<Vector2, Vector2> road in roads)
            {
                int nodeOne = findNode(road.Item1);
                Edge e = new Edge(findNode(road.Item1), findNode(road.Item2), calcDistance(road.Item1, road.Item2));
                this.nodes[nodeOne].addEdge(e);
            }
        }

        private int findNode(Vector2 v)
        {
            for(int i = 0; i < nodes.Count(); i++)
            {
                if (nodes[i].getVector() == v)
                {
                    return i;
                }
            }
            return 0;
        }

        private float calcDistance(Vector2 v1, Vector2 v2)
        {
            return Vector2.Distance(v1, v2);
        }

        private Boolean checkIfNodeExists(Vector2 v)
        {
            foreach(Node n in nodeExistance)
            {
                if(n.getVector() == v)
                {
                    return true;
                }
            }
            return false;
        }

        public void calculateShortestDistances()
        {

            // Set the source node.
            int startingNode = findNode(startingBuilding);
            this.nodes[startingNode].setDistanceFromSource(0);
            int nextNode = startingNode;

            // Visit every node, in order of stored distance.
            for (int i = 0; i < this.nodes.Count(); i++)
            {

                // Loop around the current node's edges.
                List<Edge> currentNodeEdges = this.nodes[nextNode].getEdges();
                for (int joinedEdge = 0; joinedEdge < currentNodeEdges.Count(); joinedEdge++)
                {

                    // Determine the joined edge neighbour of the current node.
                    int neighbourIndex = currentNodeEdges.ElementAt(joinedEdge).getNeighbourIndex(nextNode);

                    // Only use unvisited neighbours.
                    if (!this.nodes[neighbourIndex].isVisited())
                    {

                        // Calculate the distance for the neighbour.
                        float tentative = this.nodes[nextNode].getDistanceFromSource() + currentNodeEdges.ElementAt(joinedEdge).getDistance();

                        // Overwrite if the calculated distance is less than what is currently stored.
                        if (tentative < nodes[neighbourIndex].getDistanceFromSource())
                        {
                            nodes[neighbourIndex].setDistanceFromSource(tentative);

                            //Remember the previously visited node in the path.
                            nodes[neighbourIndex].setPreviousNode(nextNode);
                        }

                    }

                }

                // Set node to visited when all neighbours are checked.
                nodes[nextNode].setVisited(true);

                // Get the next closest node.
                nextNode = getNodeShortestDistanced();

            }

        }

        private int getNodeShortestDistanced()
        {

            int storedNodeIndex = 0;
            float storedDist = float.MaxValue;

            for (int i = 0; i < this.nodes.Count(); i++)
            {
                float currentDist = this.nodes[i].getDistanceFromSource();
                if (!this.nodes[i].isVisited() && currentDist < storedDist)
                {
                    storedDist = currentDist;
                    storedNodeIndex = i;
                }

            }

            return storedNodeIndex;
        }

        private List<Tuple<Vector2, Vector2>> generateBestPath()
        {
            List<Tuple<Vector2, Vector2>> bestPath = new List<Tuple<Vector2, Vector2>>();
            int destinationBuildingLocation = findNode(destinationBuilding);
            int startingBuildingLocation = findNode(startingBuilding);
            int i = destinationBuildingLocation;
            while (i != startingBuildingLocation)
            {
                int previousNode = nodes[i].getPreviousNode();
                bestPath.Add(new Tuple<Vector2, Vector2>(nodes[i].getVector(), nodes[previousNode].getVector()));
                i = previousNode;
            }
            bestPath.Reverse();
            return bestPath;
        }

        public IEnumerable<Tuple<Vector2, Vector2>> result()
        {
            return generateBestPath();
        }
    }
}
