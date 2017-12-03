using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFlow
{
    public class FordFulkerson
    {
        Dictionary<int, Node> Nodes { get; set; }
        Dictionary<string, Edge> Edges { get; set; }
        Node Source { get; set; }
        Node Sink { get; set; }
        private const float MaxValue = float.MaxValue;
        public List<string> AugmentingPaths;

        public FordFulkerson(Dictionary<int, Node> Nodes, Dictionary<string, Edge> Edges, Node Source, Node Sink)
        {
            this.Nodes = Nodes;
            this.Edges = Edges;
            this.Source = Source;
            this.Sink = Sink;
            AugmentingPaths = new List<string>();
        }



        public float Run(FindAugmentingPathMethod Method)
        {
            var flow = 0f;
            int totalTrials = 0;
            var AugmentingPath = FindAugmentingPath(Source, Sink, Method, ref totalTrials);
            var loops = 0;
            while (AugmentingPath != null && AugmentingPath.Count > 0)
            {
                ++loops;
                var minCapacity = MaxValue;
                foreach (var edge in AugmentingPath)
                {
                    if (edge.Capacity < minCapacity)
                        minCapacity = edge.Capacity; // update
                }

                if (minCapacity == MaxValue || minCapacity < 0)
                    throw new Exception("minCapacity " + minCapacity);

                AugmentingPaths.Add(new Path(AugmentingPath, minCapacity).ToString());

                ComputeResidualNetwork(AugmentingPath, minCapacity);
                flow += minCapacity;

                AugmentingPath = FindAugmentingPath(Source, Sink, Method, ref totalTrials);
            }

            // max flow
            //PrintLn("\n** Max flow = " + flow);

            // min cut
            //PrintLn("\n** Min cut");
            //FindMinCut(Source);

            return flow;
        }
        List<Edge> FindAugmentingPath(Node root, Node target,FindAugmentingPathMethod Method, ref int totalTrials)
        {
            switch (Method)
            {
                case FindAugmentingPathMethod.BFS:
                    return Bfs(root, target, ref totalTrials);
                case FindAugmentingPathMethod.DFS:
                    return DFS(root, target, ref totalTrials);
                case FindAugmentingPathMethod.Fatest:
                    return FAT(root, target,true, ref totalTrials);
                case FindAugmentingPathMethod.Thinnest:
                    return FAT(root, target, false, ref totalTrials);
                default:
                    return Bfs(root, target, ref totalTrials);
            }
        }
        void ComputeResidualNetwork(IEnumerable<Edge> path, float minCapacity)
        {
            foreach (var edge in path)
            {
                var keyResidual = Edge.GetEdgeKeyName(edge.NodeTo.Id, edge.NodeFrom.Id);//note that the opposite direction
                var edgeResidual = Edges[keyResidual];

                edge.Capacity -= minCapacity;
                edgeResidual.Capacity += minCapacity;
            }
        }
        // similar to bfs
        void FindMinCut(Node root)
        {
            var queue = new Queue<Node>();
            var discovered = new HashSet<Node>();
            var minCutNodes = new List<Node>();
            var minCutEdges = new List<Edge>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (discovered.Contains(current))
                    continue;

                minCutNodes.Add(current);
                discovered.Add(current);

                var edges = current.NodeEdges;
                foreach (var edge in edges)
                {
                    var next = edge.NodeTo;
                    if (edge.Capacity <= 0 || discovered.Contains(next))
                        continue;
                    queue.Enqueue(next);
                    minCutEdges.Add(edge);
                }
            }

            // bottleneck as a list of arcs
            var minCutResult = new List<Edge>();
            List<int> nodeIds = minCutNodes.Select(node => node.Id).ToList();

            var nodeKeys = new HashSet<int>();
            foreach (var node in minCutNodes)
                nodeKeys.Add(node.Id);

            var edgeKeys = new HashSet<string>();
            foreach (var edge in minCutEdges)
                edgeKeys.Add(edge.Name);


            ////ParseData(); // reset the graph

            // finding by comparing residual and original graph

            foreach (var id in nodeIds)
            {
                var node = Nodes[id];
                var edges = node.NodeEdges;
                foreach (var edge in edges)
                {
                    if (nodeKeys.Contains(edge.NodeTo.Id))
                        continue;

                    if (edge.Capacity > 0 && !edgeKeys.Contains(edge.Name))
                        minCutResult.Add(edge);
                }
            }

            float maxflow = 0;
            foreach (var edge in minCutResult)
            {
                maxflow += edge.Capacity;
                //PrintLn(edge.Info());
            }
            //PrintLn("min-cut total maxflow = " + maxflow);
        }
        public List<HashSet<string>> GetMinCut(Node source)
        {
            List<HashSet<string>> CutST = new List<HashSet<string>>();
            HashSet<string> S = new HashSet<string>();
            HashSet<string> T = new HashSet<string>();
            CutST.Add(S);
            CutST.Add(T);

            var queue = new Queue<Node>();
            queue.Enqueue(source);

            Node current;
            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                S.Add(current.Name);

                foreach (var edge in current.NodeEdges)
                {
                    Node next = edge.NodeTo;
                    if (edge.Capacity > 0 && !S.Contains(next.Name))
                    {
                        S.Add(next.Name);
                        queue.Enqueue(next);
                    }
                }
            }

            return CutST;
        }
        /*
          Customized for network flow, capacity

           Wikipedia
           1. Enqueue the root node.
           2. Dequeue a node and examine it.
               * If the element sought is found in this node, quit the search and return a result.
               * Otherwise enqueue any successors (the direct child nodes) that haven't been seen.
           3. If the queue is empty, every node on the graph has been examined 
               – quit the search and return "not found".
           4. Repeat from Step 2.
        */
        List<Edge> Bfs(Node root, Node target, ref int totalTrials)
        {
            root.TraverseParent = null;
            target.TraverseParent = null; //reset

            var queue = new Queue<Node>();
            var discovered = new HashSet<Node>();
            queue.Enqueue(root);

            var loops = 0;
            int trials = 0;
            Node current;
            //discovered.Add(current);
            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                if (loops == 0) discovered.Add(current);

                if (current.Id == target.Id)
                    return GetAugmentingPath(current);

                var nodeEdges = current.NodeEdges;
                foreach (var edge in nodeEdges)
                {
                    loops++;
                    totalTrials++;
                    var next = edge.NodeTo;
                    //var c = GetCapacity(current, next);
                    //if (c > 0 && !discovered.Contains(next))
                    if (edge.Capacity > 0 && !discovered.Contains(next))
                    {
                        next.TraverseParent = current;
                        discovered.Add(next);
                        queue.Enqueue(next);
                    }
                }
            }
            return null;
        }

        List<Edge> DFS(Node root, Node target, ref int totalTrials)
        {
            Stack<Node> stack = new Stack<Node>();
            HashSet<Node> Visited = new HashSet<Node>();

            stack.Push(root);

            Node CurNode;
            while (stack.Count > 0)
            {
                CurNode = stack.Peek();

                if (CurNode.Id == target.Id)
                    return GetAugmentingPath(CurNode);

                int loops = 0;
                foreach (var edge in CurNode.NodeEdges)
                {
                    loops++;
                    totalTrials++;
                    Node NextNode = edge.NodeTo;
                    if (edge.Capacity > 0 && !Visited.Contains(NextNode) && !stack.Contains(NextNode))
                    {
                        stack.Push(NextNode);
                        NextNode.TraverseParent = CurNode;
                        loops = 0;
                        break;
                    }

                }
                if (loops == CurNode.NodeEdges.Count)
                {
                    stack.Pop();// <-- pop CurNode
                    Visited.Add(CurNode);
                }
            }
            return null;
        }
        List<Edge> FAT(Node root, Node target,bool Fatest, ref int totalTrials)
        {
            List<Path> AllObjectPaths = new List<Path>();
            PathFinder pathFinder = new PathFinder();
            Graph graph = new Graph();

            foreach (Edge ed in Edges.Values)
            {
                if (ed.Capacity > 0)
                    graph.addEdge(ed.NodeFrom.Id.ToString(), ed.NodeTo.Id.ToString());
            }
            string start = root.Id.ToString();
            string end = target.Id.ToString();
            List<string> allPossiblePaths = pathFinder.GetAllPaths(graph, start, end);

            
            int pathID = 0;
            int FatestPathId = 0;
            float FatestPathCapacity = Fatest? float.MinValue: float.MaxValue;
            foreach (string path in allPossiblePaths)
            {
                string[] nods = path.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Path newPath = new Path();
                for (int i = 0; i < nods.Length-1; i++)
                {
                    string edgeName = Edge.GetEdgeKeyName(nods[i], nods[i + 1]);
                    newPath.Edges.Insert(0,Edges[edgeName]);
                }
                AllObjectPaths.Add(newPath);
                if (Fatest)
                {
                    if (newPath.Capacity > FatestPathCapacity)
                    {
                        FatestPathCapacity = newPath.Capacity;
                        FatestPathId = pathID;
                    }
                }
                else //thinnest
                {
                    if (newPath.Capacity < FatestPathCapacity)
                    {
                        FatestPathCapacity = newPath.Capacity;
                        FatestPathId = pathID;
                    }
                }
                ++pathID;
            }

            if (AllObjectPaths.Count==0)
                return null;
            return AllObjectPaths[FatestPathId].Edges;
        }
        List<Edge> GetAugmentingPath(Node node)
        {
            var path = new List<Edge>();
            var current = node;
            while (current.TraverseParent != null)
            {
                var key = Edge.GetEdgeKeyName(current.TraverseParent.Id, current.Id);
                var edge = Edges[key];
                path.Add(edge);
                current = current.TraverseParent;
            }
            Path p = new Path(path);
            return path;
        }

    }
}
