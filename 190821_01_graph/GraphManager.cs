using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _190821_01_graph
{
    class GraphManager
    {
        // GraphManager manages nodes using an array
        private GraphNode[] nodes;
        private int num_node;
        private int num_group;
        private int[] frequency_group;

        // Connection
        private int num_all_connect;
        private int num_success_connect;
        private int num_already_exist_connect;
        private int num_failure_connect;

        // Reaching
        private int num_all_reachable;
        private int num_success_reachable;
        private int num_already_exist_reachable;
        private int num_failure_reachable;

        // Class in System.Diagnostics namespace
        public Stopwatch stopwatch;
        
        // Constructor
        public GraphManager()
        {
            num_all_connect = num_success_connect = num_already_exist_connect = num_failure_connect = 0;
            num_all_reachable = num_success_reachable = num_already_exist_reachable = num_failure_reachable = 0;
            num_group = -1;
            stopwatch = new Stopwatch();
        }

        // Parsing graph.txt
        public void ParseFile(string file_loc)
        {
            Console.WriteLine("Loading Graph... \n");
            string[] lines = System.IO.File.ReadAllLines(@file_loc);

            this.num_node = int.Parse(lines[1]);
            this.nodes = new GraphNode[this.num_node];
            for (int i = 0; i < num_node; ++i)
            {
                nodes[i] = new GraphNode(i);
            }

            int current_index = 0;
            for (int i = 2; i < lines.Length; ++i)
            {
                if (lines[i] == "Node : ")
                {
                    current_index = int.Parse(lines[i + 1]);
                }
                else if (lines[i].Contains(','))
                {
                    // num[0]: to_index, num[1]: cost
                    string[] num = lines[i].Split(',');
                    Connect(current_index, int.Parse(num[0]), int.Parse(num[1]));
                }
            }

            StartTimer();
            MakeGroup();
            PrintNumofGroup();
            EndTimer();
        }

        public void PrintNumNode()
        {
            Console.WriteLine($"Num of node: {num_node}");
        }

        public void Connect(int from_index, int to_index, int cost)
        {
            try
            {
                if (this.nodes[from_index].data.ContainsKey(to_index))
                {
                    ++num_already_exist_connect;
                }
                else
                {
                    nodes[from_index].data.Add(to_index, cost);
                    nodes[to_index].data.Add(from_index, cost);
                    ++num_success_connect;
                }
            }
            catch (Exception e)
            {
                ++num_failure_connect;
                Console.WriteLine($"Connection failed: {from_index}, {to_index}");
            }
            ++num_all_connect;
        }

        public void PrintConnectionResult()
        {
            Console.WriteLine("Connection\n" +
                             $"Overall: {num_all_connect}, Success: {num_success_connect}, Already connected: {num_already_exist_connect}, Failure: {num_failure_connect}");
        }

        public bool IsNeighbor(int base_index, int target_index)
        {
            if (nodes[base_index].data.ContainsKey(target_index))
            {
                return true;
            }

            return false;
        }

        public void MakeGroup()
        {
            // num of node that is grouped
            int num_grouped_node = 0;
            // overall index variable
            int i = 0;

            List<int> visited_index = new List<int>();
            Stack<int> stack_target = new Stack<int>();

            stack_target.Push(i);

            int current_index = 0;
            while (num_grouped_node != num_node)
            {
                ++num_group;
                while (stack_target.Count != 0)
                {
                    // when not passed the target yet
                    if (!visited_index.Contains(stack_target.Peek()))
                    {
                        // then reach to the target
                        current_index = stack_target.Pop();
                        visited_index.Add(current_index);
                        // and group the node[current_index]
                        nodes[current_index].group = num_group;
                        ++num_grouped_node;
                    }

                    foreach (int node in nodes[current_index].data.Keys)
                    {
                        if (!stack_target.Contains(node) && !visited_index.Contains(node))
                        {
                            stack_target.Push(node);
                        }
                    }
                }
                // look for the node that not has been grouped yet
                while (visited_index.Contains(i))
                {
                    ++i;
                }
                current_index = i;
                stack_target.Push(current_index);
            }
        }

        // If same group -> reachable
        public bool IsReachable(int from_index, int to_index)
        {
            if (nodes[from_index].group == nodes[to_index].group)
            {
                return true;
            }
            return false;
        }

        public void PrintReachableResult()
        {
            string input = null;
            string[] node_index = null;
            int from_index = -1;
            int to_index = -1;
            while (from_index < 0 || to_index >= num_node)
            {
                Console.Write("Input start node and target node >> ");
                input = Console.ReadLine();
                node_index = input.Split(' ');
                from_index = int.Parse(node_index[0]);
                to_index = int.Parse(node_index[1]);
            }

            Console.Write($"{from_index} to {to_index}: ");
            if (nodes[from_index].group == nodes[to_index].group)
            {
                Console.WriteLine("reachable");
            }
            else
            {
                Console.WriteLine("unreachable");
            }

            Console.WriteLine($"(Group {nodes[from_index].group} : Group {nodes[to_index].group})");
        }

        public void PrintNumofGroup()
        {
            if (num_group > 0)
            {
                Console.WriteLine($"Num of groups: {num_group}");
            }
            else
            {
                Console.WriteLine("No group");
            }
        }

        public void PrintGroupNode(int group)
        {
            for (int i = 0; i < num_node; ++i)
            {
                if (nodes[i].group == group)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public void PrintGroupFrequency()
        {
            frequency_group = new int[num_group + 1];
            frequency_group.Initialize();

            for (int i = 0; i < num_node; ++i)
            {
                ++frequency_group[nodes[i].group];
            }

            Console.WriteLine("Nodes that have oneself's group:");
            for (int i = 0; i < num_group; ++i)
            {
                if (frequency_group[i] == 1)
                {
                    Console.Write($"Group {i}: ");
                    PrintGroupNode(i);
                }
            }
        }

        //
        // stopwatch
        //
        public void StartTimer()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }
        public void EndTimer()
        {
            stopwatch.Stop();
            Console.WriteLine($"Time went on: {stopwatch.ElapsedMilliseconds}miliSec ({stopwatch.Elapsed}, {(stopwatch.ElapsedMilliseconds) / 1000}sec)");
        }
    }
}
