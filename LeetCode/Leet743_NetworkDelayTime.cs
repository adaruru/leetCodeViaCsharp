﻿using System;
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

        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            var result = Dijkstra();
            return result;
        }

        public int Dijkstra()
        {
            return 1;
        }
    }

}