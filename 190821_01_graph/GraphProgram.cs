using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _190821_01_graph
{
    class GraphProgram
    {
        static void Main(string[] args)
        {
            GraphManager graph = new GraphManager();

            graph.ParseFile("C:\\Users\\pllap\\Desktop\\graph\\50000.txt");
            graph.PrintNumNode();
            graph.PrintConnectionResult();
            graph.PrintGroupFrequency();
            while (true)
            {
                graph.PrintReachableResult();
            }
        }
    }
}

/* Graph.txt

GraphFile
5
Node : 
0
1,4
3,4
4,2
--
Node : 
1
0,4
2,3
3,5
4,6
--
Node : 
2
1,3
3,2
--
Node : 
3
0,4
1,5
2,2
--
Node : 
4
0,2
1,6
--

 */
