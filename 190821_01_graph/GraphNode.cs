using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _190821_01_graph
{
    class GraphNode
    {
        // each node knows itself's key and group
        public int key;
        public int group;
        // data: target node, cost
        public Dictionary<int, int> data;

        public GraphNode(int key)
        {
            this.key = key;
            this.group = -1;
            data = new Dictionary<int, int>();
        }
    }
}
