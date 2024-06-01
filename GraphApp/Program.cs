using GraphLib;

namespace GraphApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            DirectedGraph graph = new DirectedGraph();

            var a = graph.AddVertex("A");
            var b = graph.AddVertex("B");
            var c = graph.AddVertex("C");
            var d = graph.AddVertex("D");
            var e = graph.AddVertex("E");
            var f = graph.AddVertex("F");
            var g = graph.AddVertex("G");

            a.AddEdge(b, 7);
            a.AddEdge(d, 5);
            a.AddEdge(c, 3);
            a.AddEdge(c, 1);
            a.AddEdge(e, 32);
            a.AddEdge(f, 3);
            a.AddEdge(e, 2);
            a.AddEdge(g, 1);
            a.AddEdge(f, 9);
            a.AddEdge(f, 7);

            Console.WriteLine("Index\tLabel");
            for (int i = 0; i < graph.Vertices.Count; i++)
            {
                Console.WriteLine($"{graph.Vertices[i].Label}");
            }

            graph.PrintMatrix();

            Console.WriteLine();

            graph.Dijkstra(2);
        }
    }
}
