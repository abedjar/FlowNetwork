using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MaxFlow;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Node> Nodes { get; set; }
        private Dictionary<string, Edge> Edges { get; set; }

        Dictionary<int, List<float>> Times;

        FordFulkerson ford;
        int Trials = 0;
        public Form1()
        {
            InitializeComponent();

            cbMethod.SelectedIndex = 0;
            Times = new Dictionary<int, List<float>>();
            for (int i = 0; i < cbMethod.Items.Count; i++)
                Times.Add(i, new List<float>());

            Nodes = new Dictionary<int, Node>();
            Edges = new Dictionary<string, Edge>();
        }

        private void btnFindMaxFlow_Click(object sender, EventArgs e)
        {
            ParseData();
            FindAugmentingPathMethod Method = (FindAugmentingPathMethod)Enum.Parse(typeof(FindAugmentingPathMethod), cbMethod.SelectedIndex.ToString());

            var Sourse = Nodes[0];
            var Sink = Nodes[Nodes.Count - 1];

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            ford = new FordFulkerson(Nodes, Edges, Sourse, Sink);
            float maxFlow = ford.Run(Method);

            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            tbMaxFlow.Text = maxFlow.ToString() + " # " + ts.Ticks;

            if (Trials > 0)
                Times[cbMethod.SelectedIndex].Add(ts.Ticks);
            tbAvgTime.Text = Times[cbMethod.SelectedIndex].Count > 0 ? Times[cbMethod.SelectedIndex].Average().ToString() : "0";
            ShowAugmentingPaths();
            Trials++;
        }
        void ParseData()
        {
            Reset();

            var names = tbNodes.Text.Split(',');
            foreach (Node node in names.Select(name => new Node() { Name = name }))
                Nodes.Add(node.Id, node);

            var edges = rtbEdges.Lines;

            foreach (var edge in edges)
            {
                string[] s = edge.Split(' ');

                Node node1 = Nodes[int.Parse(s[0])];
                Node node2 = Nodes[int.Parse(s[1])];
                float capacity = float.Parse(s[2]);

                AddEdge(node1, node2, capacity);
                AddEdge(node2, node1, 0f); // residual, if undirected graph, set value as capacity
            }
        }
        void Reset()
        {
            Nodes.Clear();
            Edges.Clear();
            Node.ResetCounter();
        }
        public void AddEdge(Node nodeFrom, Node nodeTo, float capacity)
        {
            string NewEdgeName = Edge.GetEdgeKeyName(nodeFrom.Id, nodeTo.Id);
            Edge NewEdge = new Edge()
            {
                NodeFrom = nodeFrom,
                NodeTo = nodeTo,
                Capacity = capacity,
                Name = NewEdgeName
            };

            if (Edges.Keys.Contains(NewEdgeName))
            {
                if (Edges[NewEdgeName].Capacity == 0)
                    Edges[NewEdgeName].Capacity = NewEdge.Capacity;
            }
            else
            {
                Edges.Add(NewEdgeName, NewEdge);
                nodeFrom.NodeEdges.Add(NewEdge);
            }


        }
        void ShowAugmentingPaths()
        {
            rbtAugPaths.Clear();
            foreach (var item in ford.AugmentingPaths)
            {
                rbtAugPaths.AppendText(item + "\n");
            }

            tbNoOfAugPaths.Text = ford.AugmentingPaths.Count.ToString();
        }
        private void btnMinCut_Click(object sender, EventArgs e)
        {
            List<HashSet<string>> CutST = ford.GetMinCut(Nodes[0]);

            string s = string.Join(", ", CutST[0]);

            string t = "";
            for (int i = 0; i < Nodes.Count; i++)
                if (!CutST[0].Contains(Nodes[i].Name))
                {
                    t += ", " + Nodes[i].Name;
                }
            rtbMinCut.Text = "S= {" + s + "}\nT= {" + t.Substring(2) + "}";

        }

        private void cbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Trials = 0;
        }

        private void do1000_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                btnFindMaxFlow_Click(null, null);
            }
        }

        private void btnGlobal_Click(object sender, EventArgs e)
        {
            ParseData();
            FindAugmentingPathMethod Method = (FindAugmentingPathMethod)Enum.Parse(typeof(FindAugmentingPathMethod), cbMethod.SelectedIndex.ToString());

            var Sourse = Nodes[0];
            List<string> resutls = new List<string>();
            Dictionary<int, Node> NodesCopy = new Dictionary<int, Node>(Nodes);
            foreach (Node Sink in NodesCopy.Values)
            {
                Sourse = Nodes[0];
                var t = Nodes[Sink.Id];
                ford = new FordFulkerson(Nodes, Edges, Sourse, t);
                float maxFlow = ford.Run(Method);

                resutls.Add(Sourse.Name + "--" + maxFlow + "-->" + Sink.Name);
                ParseData();
            }

        }

        private void btnAllPaths_Click(object sender, EventArgs e)
        {


            ParseData();
            
        }
    }
}
