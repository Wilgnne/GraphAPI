using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using GraphAPI.Model;
using GraphLib;

namespace GraphAPI.Controllers
{
    public struct FromVertex
    {
        public Graph graph;
        public string orig;
    }
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        string url = "https://localhost:5001/api/graph/BFS";

        [AcceptVerbs("POST")]
        [Route("BFS")]
        public Graph BFS(FromVertex from)
        {
            Graph graph = from.graph;
            string s = from.orig;
            AdjacencyList<string> adjacencyList = graph;
            adjacencyList.BFS(s);
            return adjacencyList;
        }

        [AcceptVerbs("POST")]
        [Route("DFS")]
        public Graph DFS(FromVertex from)
        {
            Graph graph = from.graph;
            AdjacencyList<string> adjacencyList = graph;
            adjacencyList.DFS();
            return adjacencyList;
        }

        [AcceptVerbs("POST")]
        [Route("Dijkstra")]
        public Graph Dijkstra(FromVertex from)
        {
            Graph graph = from.graph;
            AdjacencyList<string> adjacencyList = graph;
            return TreeAlgorithms<string>.Dijkstra(adjacencyList, from.orig);
        }

        [AcceptVerbs("POST")]
        [Route("Kruskal")]
        public Graph Kruskal(FromVertex from)
        {
            Graph graph = from.graph;
            AdjacencyList<char> adjacencyList = graph;
            return TreeAlgorithms<char>.Kruskal(adjacencyList);
        }

        [AcceptVerbs("POST")]
        [Route("Prim")]
        public Graph Prim(FromVertex from)
        {
            Graph graph = from.graph;
            AdjacencyList<string> adjacencyList = graph;
            return TreeAlgorithms<string>.Prim(adjacencyList, from.orig);
        }

        [AcceptVerbs("POST")]
        [Route("BellmanFord")]
        public Graph BellmanFord(FromVertex from)
        {
            Graph graph = from.graph;
            AdjacencyList<string> adjacencyList = graph;
            
            TreeAlgorithms<string>.BellmanFord(adjacencyList, from.orig, out GraphLib.Model.Graph<string> q);
            AdjacencyMatrix<string> output = (AdjacencyMatrix<string>)q;
            return output;
        }

    }
}
