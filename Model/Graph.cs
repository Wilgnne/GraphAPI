using System;
using System.Collections.Generic;

using GraphLib;

namespace GraphAPI.Model
{
    public struct Vertex
    {
        public string value;
        public float d;
        public float f;
    }
    public struct Edge
    {
        public string from;
        public string to;
        public float w;
    }
    public class Graph
    {
        public List<Vertex> vertices = new List<Vertex>();
        public List<Edge> edges = new List<Edge>();

        public static implicit operator AdjacencyList<string>(Graph m)
        {
            AdjacencyList<string> adjacencyList = new AdjacencyList<string>((x, y) => x.CompareTo(y), true);
            foreach (Vertex vertex in m.vertices)
            {
                adjacencyList.AddVertex(vertex.value);
            }

            foreach (Edge edge in m.edges)
            {
                adjacencyList.AddEdge(edge.from, edge.to, edge.w);
            }
            return adjacencyList;
        }

        public static implicit operator AdjacencyList<char>(Graph m)
        {
            AdjacencyList<char> adjacencyList = new AdjacencyList<char>((x, y) => x.CompareTo(y), true);
            foreach (Vertex vertex in m.vertices)
            {
                adjacencyList.AddVertex(vertex.value.ToCharArray()[0]);
            }

            foreach (Edge edge in m.edges)
            {
                adjacencyList.AddEdge(edge.from.ToCharArray()[0], edge.to.ToCharArray()[0], edge.w);
            }
            return adjacencyList;
        }

        public static implicit operator Graph(AdjacencyList<string> m)
        {
            Graph graph = new Graph();
            foreach (var item in m.Vertices())
            {
                Vertex v = new Vertex();
                v.value = item.value;
                v.d = item.distance;
                v.f = item.f;
                graph.vertices.Add(v);
            }
            foreach (var item in m.Edges())
            {
                Edge e = new Edge();
                e.from = item.from.value;
                e.to = item.to.value;

                graph.edges.Add(e);
            }
            return graph;
        }

        public static implicit operator Graph(AdjacencyList<char> m)
        {
            Graph graph = new Graph();
            foreach (var item in m.Vertices())
            {
                Vertex v = new Vertex();
                v.value = item.value.ToString();
                v.d = item.distance;
                v.f = item.f;
                graph.vertices.Add(v);
            }
            foreach (var item in m.Edges())
            {
                Edge e = new Edge();
                e.from = item.from.value.ToString();
                e.to = item.to.value.ToString();

                graph.edges.Add(e);
            }
            return graph;
        }

        public static implicit operator Graph(AdjacencyMatrix<string> m)
        {
            Graph graph = new Graph();
            foreach (var item in m.Vertices())
            {
                Vertex v = new Vertex();
                v.value = item.value;
                v.d = item.distance;
                v.f = item.f;
                graph.vertices.Add(v);
            }
            foreach (var item in m.Edges())
            {
                Edge e = new Edge();
                e.from = item.from.value;
                e.to = item.to.value;

                graph.edges.Add(e);
            }
            return graph;
        }
    }
}