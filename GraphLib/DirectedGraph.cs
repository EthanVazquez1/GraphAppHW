using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class DirectedGraph
    {
        public List<Vertex> Vertices = new List<Vertex>();

        public Vertex AddVertex(string label)
        {
            Vertex v = new Vertex(label);

            Vertices.Add(v);

            return v;
        }

        public int[,] CreateAdjMatrix()
        {
            int[,] AdjMatrix = new int[Vertices.Count, Vertices.Count];

            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertex v1 = Vertices[i];

                for (int j = 0; j < Vertices.Count; j++)
                {
                    Vertex v2 = Vertices[j];

                    Edge edge = v1.Edges.FirstOrDefault(e => e.Child == v2);

                    if (edge != null)
                    {
                        AdjMatrix[i, j] = edge.Weight;
                    }
                }
            }
            return AdjMatrix;
        }

        public void PrintMatrix()
        {
            var matrix = CreateAdjMatrix();

            Console.Write("\t");
            for (int i = 0 ; i < Vertices.Count; i++)
            {
                Console.Write($" {Vertices[i].Label} ");
            }
            Console.WriteLine();
            
            for (int i = 0; i < Vertices.Count; i++)
            {
                Console.Write($"{Vertices[i].Label}\t");

                for (int j = 0; j < Vertices.Count; j++)
                {
                    if (matrix[i, j] != null)
                    {
                        Console.Write($"[{matrix[i, j]}]");
                    }
                    else
                    {
                        Console.Write("[.]");
                    }
                }
                Console.WriteLine();
            }
        }

        public void Dijkstra(int src)
        {

            int[,] graph = CreateAdjMatrix();

            // Set up buckets to store info
            int[] dist = new int[Vertices.Count];
            bool[] visits = new bool[Vertices.Count];

            // initalize the arrays
            for (int i = 0; i < Vertices.Count; i++)
            {
                dist[i] = int.MaxValue;
                visits[i] = false;
            }

            dist[src] = 0;

            for (int count = 0; count < Vertices.Count -1; count++)
            {
                // Pick the minimum distance vertex from the set of vertices not yet processed
                int u = MinDistance(dist, visits);

                // Mark the picked vertex as visited
                visits[u] = true;

                // Update dist value of the adjacent vertices of the picked vertex
                for (int v = 0; v < Vertices.Count; v++)
                {
                    if (!visits[v] &&
                        graph[u, v] != 0 &&
                        dist[u] != int.MaxValue &&
                        dist[u] + graph[u, v] < dist[v]
                        )
                    {
                        dist[v] = dist[u] + graph[u, v];
                    }
                }
            }

            PrintSolution(dist, Vertices.Count);
        }

        private void PrintSolution(int[] dist, int count)
        {
            Console.WriteLine("Vertex\t\tDistance from source");

            for (int i = 0; i < Vertices.Count; i++)
            {
                Console.WriteLine($"{Vertices[i].Label}\t\t{dist[i]}");
            }
        }

        private int MinDistance(int[] dist, bool[] visits)
        {
            int min = int.MaxValue;
            int min_index = -1;

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (visits[i] == false && dist[i] <= min)
                {
                    min = dist[i];
                    min_index = i;
                }
            }

            return min_index;
        }
    }
}