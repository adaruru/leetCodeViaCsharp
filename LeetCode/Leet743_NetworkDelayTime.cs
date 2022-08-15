using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 求最短路徑 #sortestPath
    /// #有向圖 #directedGraph #digraph
    /// #DijkstraAlgorithm,
    /// #七橋問題
    /// 
    /// You are given a network of n nodes, labeled from 1 to n.You are also given times,
    /// a list of travel times as directed edges times[i] = (ui, vi, wi), 
    /// where ui is the source node, vi is the target node, 
    /// and wi is the time it takes for a signal to travel from source to target.
    /// 
    /// We will send a signal from a given node k. 
    /// Return the minimum time it takes for all the n nodes to receive the signal. 
    /// If it is impossible for all the n nodes to receive the signal, return -1.
    /// 
    /// 1 <= k <= n <= 100
    /// 1 <= times.length <= 6000
    /// times[i].length == 3
    /// 1 <= ui, vi <= n
    /// ui != vi
    /// 0 <= wi <= 100
    /// All the pairs(ui, vi) are unique. (i.e., no multiple edges.)
    /// </summary>
    public class Leet743_NetworkDelayTime
    {
        /// <summary>
        /// NetworkDelayTime
        /// </summary>
        /// <param name="times">{sourceNode, targetNode ,value}</param>
        /// <param name="n">visit node number</param>
        /// <param name="k">start node</param>
        /// <returns></returns>
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            List<(int node, int wht)>[] routeMap = new List<(int node, int wht)>[n + 1];
            for (var i = 0; i <= n; i++)
            {
                routeMap[i] = new List<(int node, int wht)>();
            }

            foreach (var time in times)
            {
                routeMap[time[0]].Add((time[1], time[2]));
            }

            var result = Dijkstra(routeMap, n, k);
            return result;
        }

        public int Dijkstra(List<(int node, int wht)>[] routeMap, int n, int k)
        {
            bool[] visited = new bool[n + 1];
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            pq.Enqueue(k, 0);
            int result = 0;
            int visitedCount = 0;
            while (pq.TryDequeue(out int node, out int weight))
            {
                if (visited[node]) continue;
                visitedCount++;
                visited[node] = true;
                result = Math.Max(result, weight);
                foreach (var adj in routeMap[node])
                {
                    var totalWT = weight + adj.wht;
                    pq.Enqueue(adj.node, totalWT);
                }
            }
            return visitedCount == n ? result : -1;
        }

        public int NetworkDelayTime2(int[][] times, int n, int k)
        {
            List<(int node, int wht)>[] routeMap = new List<(int node, int wht)>[n + 1];
            for (var i = 0; i <= n; i++)
            {
                routeMap[i] = new List<(int node, int wht)>();
            }

            foreach (var time in times)
            {
                routeMap[time[0]].Add((time[1], time[2]));
            }

            var result = Dijkstra2(routeMap, n, k);
            return result;
        }

        public int Dijkstra2(List<(int node, int wht)>[] routeMap, int n, int k)
        {
            bool[] visited = new bool[n + 1];
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            pq.Enqueue(k, 0);
            int result = 0;
            int visitedCount = 0;
            while (pq.TryDequeue(out int node, out int weight))
            {
                if (visited[node]) continue;
                visitedCount++;
                visited[node] = true;
                result = Math.Max(result, weight);
                foreach (var adj in routeMap[node])
                {
                    var totalWT = weight + adj.wht;
                    pq.Enqueue(adj.node, totalWT);
                }
            }
            return visitedCount == n ? result : -1;
        }
    }

}