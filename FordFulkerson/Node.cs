using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFlow
{
    public class Node
    {
        private static int _counter;
        public readonly int Id;
        public string Name { get; set; }
        public List<Edge> NodeEdges { get; set; }
        public Node TraverseParent { get; set; }

        public Node()
        {
            Id = _counter++;
            NodeEdges = new List<Edge>();
        }

        public static void ResetCounter()
        {
            _counter = 0;
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            foreach (var edge in NodeEdges)
            {
                var node = edge.NodeTo;
                if (edge.Capacity > 0)
                    sb.Append(node.Name + "C" + edge.Capacity + " ");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return string.Format("Id={0}, Name={1}", Id, Name);
        }
    }
    public class Edge
    {
        private static int _counter;
        public readonly int Id;
        public Node NodeFrom { get; set; }
        public Node NodeTo { get; set; }
        public float Capacity { get; set; }
        public string Name { get; set; }

        public Edge()
        {
            Id = _counter++;
        }
        public static string GetEdgeKeyName(int NodeId1, int NodeId2)
        {
            return NodeId1 + "->" + NodeId2;
        }
        public static string GetEdgeKeyName(string NodeId1, string NodeId2)
        {
            return NodeId1 + "->" + NodeId2;
        }

        public override string ToString()
        {
            return
                //string.Format("NodeFrom={0}, NodeTo={1}, C={2}", NodeFrom.Name, NodeTo.Name, Capacity);
                string.Format("({0})--{2}-->({1})", NodeFrom.Name, NodeTo.Name, Capacity);
        }

    }
}
