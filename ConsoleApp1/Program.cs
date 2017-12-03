using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
public class AllPaths
{

    private static String START = "1";
    private static String END = "5";
    private static int NoOfDFS = 0;

    public static void Main(String[] args)
    {
        // this graph is directional
        Graph graph = new Graph();

        //START = "A";
        //END = "D";
        //graph.addEdge("A", "B");
        //graph.addEdge("A", "C");
        //graph.addEdge("B", "A");
        //graph.addEdge("B", "D");
        //graph.addEdge("B", "E"); // this is the only one-way connection
        //graph.addEdge("E", "B"); // this is the only one-way connection
        //graph.addEdge("B", "F");
        //graph.addEdge("C", "A");
        //graph.addEdge("C", "E");
        //graph.addEdge("C", "F");
        //graph.addEdge("D", "B");
        //graph.addEdge("E", "C");
        //graph.addEdge("E", "F");
        //graph.addEdge("F", "B");
        //graph.addEdge("F", "C");
        //graph.addEdge("F", "E");

        START = "3";
        END = "5";
        graph.addTwoWayVertex("1", "2");
        graph.addTwoWayVertex("1", "3");
        graph.addTwoWayVertex("1", "4");
        graph.addTwoWayVertex("2", "5");
        graph.addTwoWayVertex("2", "4");
        graph.addTwoWayVertex("4", "5");

     //START = "3";
     //   END = "5";
     //   graph.addEdge("1", "2");
     //   graph.addEdge("1", "3");
     //   graph.addEdge("1", "4");
     //   graph.addEdge("2", "5");
     //   graph.addEdge("2", "4");
     //   graph.addEdge("4", "5");

        List<String> visited = new List<String>();
        visited.Add(START);
        new AllPaths().depthFirst(graph, visited);
        Console.WriteLine(NoOfDFS);
        Console.ReadKey();
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
        foreach (String node in visited)
        {
            Console.Write(node);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}


