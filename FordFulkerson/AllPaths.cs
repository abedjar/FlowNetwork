using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFlow
{
    public class Graph
    {
        private Dictionary<String, List<String>> map = new Dictionary<String, List<String>>();

        public void addEdge(String node1, String node2)
        {
            List<String> adjacent;
            if (!map.Keys.Contains(node1))
            {
                adjacent = new List<String>();
                map[node1] = adjacent;
            }
            else
                adjacent = map[node1];
            adjacent.Add(node2);
        }

        public void addTwoWayVertex(String node1, String node2)
        {
            addEdge(node1, node2);
            addEdge(node2, node1);
        }

        public bool isConnected(String node1, String node2)
        {
            List<String> adjacent = map[node1];
            if (adjacent == null)
            {
                return false;
            }
            return adjacent.Contains(node2);
        }

        public List<String> adjacentNodes(String last)
        {
            List<String> adjacent;
            if (!map.Keys.Contains(last))
            {
                return new List<String>();
            }
            else
            {
                adjacent = map[last];
                return new List<String>(adjacent);
            }
        }
    }
    public class PathFinder
    {

        private static String START = "1";
        private static String END = "5";
        private static int NoOfDFS = 0;
        private static List<string> PathsFound = new List<string>();

        public PathFinder()
        {
            PathsFound = new List<string>();
        }
        public List<string> GetAllPaths(Graph g,string start,string end)
        {
            START = start;
            END = end;
            List<String> visited = new List<String>();
            visited.Add(START);
            new PathFinder().depthFirst(g, visited);

            return PathsFound;
        }

        private void depthFirst(Graph graph, List<String> visited)
        {
            NoOfDFS++;
            List<String> nodes = graph.adjacentNodes(visited[visited.Count - 1]);
            // examine adjacent nodes
            foreach (String node in nodes)
            {
                if (visited.Contains(node))
                {
                    continue;
                }
                if (node.Equals(END))
                {
                    visited.Add(node);
                    printPath(visited);
                    visited.RemoveAt(visited.Count - 1);
                    break;
                }
            }
            foreach (String node in nodes)
            {
                if (visited.Contains(node) || node.Equals(END))
                {
                    continue;
                }
                visited.Add(node);
                depthFirst(graph, visited);
                visited.RemoveAt(visited.Count - 1);
            }
        }

        private void printPath(List<String> visited)
        {
            string path = "";
            foreach (String node in visited)
                path += node + " ";

            PathsFound.Add(path);
        }
    }



}
