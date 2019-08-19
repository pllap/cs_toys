using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _190819_03_graph
{
    class GraphNode
    {
        public int[] distance;

        public GraphNode(int num_node)
        {
            distance = new int[num_node];
            distance.Initialize();
        }
    }

    class GraphManager
    {
        public GraphNode[] node;

        public GraphManager(int num_node)
        {
            node = new GraphNode[num_node];

            for (int i = 0; i < num_node; ++i)
            {
                node[i] = new GraphNode(num_node);
                node[i].distance[i] = -1; // set the distance to itself -1
            }
        }

        public void MakeConnection(int node1_index, int node2_index, int distance)
        {
            Console.Write("Connection between {0} and {1} : ", node1_index, node2_index);
            if (node[node1_index].distance[node2_index] != 0)
            {
                Console.WriteLine("Already connected");
                return;
            }
            Console.WriteLine("Connected");
            node[node1_index].distance[node2_index] = distance;
            node[node2_index].distance[node1_index] = distance;
        }

        public bool IsMovable(int from_index, int to_index)
        {
            if (node[from_index].distance[to_index] > 0)
            {
                Console.WriteLine("Moving from {0} to {1} is vaild (distance : {2})", from_index, to_index, node[from_index].distance[to_index]);
                return true;
            }

            else if (node[from_index].distance[to_index] == 0)
            {
                Console.WriteLine("Moving from {0} to {1} is invalid (no connection)", from_index, to_index);
                return false;
            }

            else
            {
                Console.WriteLine("Moving from {0} to {1} is invalid (same node)", from_index, to_index);
                return false;
            }
        }
    }

    class GraphProgram
    {
        static void Main(string[] args)
        {
            GraphManager graph = new GraphManager(5);

            graph.MakeConnection(0, 1, 4);
            graph.MakeConnection(0, 3, 4);
            graph.MakeConnection(0, 4, 2);
            graph.MakeConnection(1, 0, 4);
            graph.MakeConnection(1, 2, 3);
            graph.MakeConnection(1, 3, 5);
            graph.MakeConnection(1, 4, 6);
            graph.MakeConnection(2, 1, 3);
            graph.MakeConnection(2, 3, 2);
            graph.MakeConnection(3, 0, 4);
            graph.MakeConnection(3, 1, 5);
            graph.MakeConnection(3, 2, 2);
            graph.MakeConnection(4, 0, 2);
            graph.MakeConnection(4, 1, 6);

            Console.WriteLine();

            graph.IsMovable(0, 0); graph.IsMovable(0, 1); graph.IsMovable(0, 2); graph.IsMovable(0, 3); graph.IsMovable(0, 4);
            Console.WriteLine();

            graph.IsMovable(1, 0); graph.IsMovable(1, 1); graph.IsMovable(1, 2); graph.IsMovable(1, 3); graph.IsMovable(1, 4);
            Console.WriteLine();

            graph.IsMovable(2, 0); graph.IsMovable(2, 1); graph.IsMovable(2, 2); graph.IsMovable(2, 3); graph.IsMovable(2, 4);
            Console.WriteLine();

            graph.IsMovable(3, 0); graph.IsMovable(3, 1); graph.IsMovable(3, 2); graph.IsMovable(3, 3); graph.IsMovable(3, 4);
            Console.WriteLine();

            graph.IsMovable(4, 0); graph.IsMovable(4, 1); graph.IsMovable(4, 2); graph.IsMovable(4, 3); graph.IsMovable(4, 4);
        }
    }
}