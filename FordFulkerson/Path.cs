using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFlow
{
    public class Path
    {
        public List<Edge> Edges;
        public float Flow { get; set; }

        public float Capacity
        {
            get
            {
                float cap = 0;
                foreach (var edge in Edges)
                    cap += edge.Capacity;
                return cap;
            }
        }

        public Path(List<Edge> Edges)
        {
            this.Edges = Edges;
        }
        public Path(List<Edge> Edges, float Flow)
        {
            this.Edges = Edges;
            this.Flow = Flow;
        }

        public Path()
        {
            this.Edges = new List<Edge>();
        }

        public override string ToString()
        {
            string s = "flow[" + Flow + "]= ";
            for (int i = Edges.Count - 1; i > 0; i--)
            {
                Edge edge = Edges[i];
                s += "(" + edge.NodeFrom.Id + ")" + "--" + edge.Capacity + "-->";
            }
            s += "(" + Edges[0].NodeFrom.Id + ")" + "--" + Edges[0].Capacity + "-->" + "(" + Edges[0].NodeTo.Id + ")";
            return s;
        }
    }
}
