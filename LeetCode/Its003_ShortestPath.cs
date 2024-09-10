namespace LeetCode;

//function findShortestPath(graph, start, goal):
//queue = empty queue
//enqueue queue with[start]
//visited = set()

//while queue is not empty:
//    path = dequeue queue
//    node = last node in path

//    if node == goal:
//        return path  # 找到目標，返回路徑

//    if node not in visited:
//        for neighbor in graph[node]:
//            new_path = copy(path)
//            append neighbor to new_path
//            enqueue new_path to queue
//        add node to visited
//return "無法到達"

/// <summary>
/// 圖論算法
/// Dijkstra 算法
/// 廣度優先搜索( BFS )
/// </summary>
public class Its003_ShortestPath
{
    public List<string> ShortestPath(string start, string target, List<string> routes)
    {
        // 建立圖
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

        foreach (var route in routes)
        {
            var stations = route.Split('-');
            string from = stations[0], to = stations[1];

            if (!graph.ContainsKey(from))
                graph[from] = new List<string>();
            if (!graph.ContainsKey(to))
                graph[to] = new List<string>();

            graph[from].Add(to);
            graph[to].Add(from); // 因為是雙向
        }

        // 廣度優先搜索
        Queue<List<string>> queue = new Queue<List<string>>();
        HashSet<string> visited = new HashSet<string>();

        queue.Enqueue(new List<string> { start });
        visited.Add(start);

        while (queue.Count > 0)
        {
            var path = queue.Dequeue();
            string lastStation = path[path.Count - 1];

            if (lastStation == target)
                return path;

            foreach (var neighbor in graph[lastStation])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    var newPath = new List<string>(path) { neighbor };
                    queue.Enqueue(newPath);
                }
            }
        }

        return null; // 找不到路徑
    }
}
