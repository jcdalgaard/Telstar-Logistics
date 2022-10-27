// A C# program for Dijkstra's single
// source shortest path algorithm.
// The program is for adjacency matrix
// representation of the graph
using DbClient.Entitites;
using System;
using TelstarLogistics.DbClient.Setup;

public class CalculateRoute
{
    // A utility function to find the
    // vertex with minimum distance 
    // value, from the set of vertices
    // not yet included in shortest
    // path tree
    //static int V = 9;
    int minDistance(int[] dist,
                    bool[] sptSet,
                    int V)
    {
        // Initialize min value
        int min = int.MaxValue, min_index = -1;

        for (int v = 0; v < V; v++)
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
            }

        return min_index;
    }

    // A utility function to print
    // the constructed distance array
    void printSolution(int[] dist, int n)
    {
        Console.Write("Vertex     Distance "
                      + "from Source\n");
        for (int i = 0; i < n; i++)
            Console.Write(i + " \t\t " + dist[i] + "\n");
    }

    // Function that implements Dijkstra's
    // single source shortest path algorithm
    // for a graph represented using adjacency
    // matrix representation
    int dijkstra(int[,] graph, int src, int target, int V)
    {
        src -= 1;
        target -= 1;
        int[] dist = new int[V]; // The output array. dist[i]
                                 // will hold the shortest
                                 // distance from src to i

        // sptSet[i] will true if vertex
        // i is included in shortest path
        // tree or shortest distance from
        // src to i is finalized
        bool[] sptSet = new bool[V];

        // Initialize all distances as
        // INFINITE and stpSet[] as false
        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }

        // Distance of source vertex
        // from itself is always 0
        dist[src] = 0;

        // Find shortest path for all vertices
        for (int count = 0; count < V - 1; count++)
        {
            // Pick the minimum distance vertex
            // from the set of vertices not yet
            // processed. u is always equal to
            // src in first iteration.
            int u = minDistance(dist, sptSet, V);

            // Mark the picked vertex as processed
            sptSet[u] = true;

            // Update dist value of the adjacent
            // vertices of the picked vertex.
            for (int v = 0; v < V; v++)

                // Update dist[v] only if is not in
                // sptSet, there is an edge from u
                // to v, and total weight of path
                // from src to v through u is smaller
                // than current value of dist[v]
                if (!sptSet[v] && graph[u, v] != 0 &&
                     dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    dist[v] = dist[u] + graph[u, v];
        }

        // print the constructed distance array
        printSolution(dist, V);
        return dist[target];
    }

    // Driver Code

    public Route calculateCheapestRoute(List<Route> AllRoutes, int src, int target) // Get number of cities
    {
        /* int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
        */
        // Initialize graph/distance to 0, and then build from DB
        System.Console.WriteLine("Entered calculateCheapestRoute");
        System.Console.WriteLine(AllRoutes.Count());
        int NumCities = 32;
        int[,] graph = new int[NumCities, NumCities];
        for (int i=0; i < NumCities; i++)
        {
            for (int j=0; j < NumCities; j++)
            {
                graph[i, j] = 0;
            }
        }
        foreach (Route route in AllRoutes)
        {
            //System.Console.WriteLine(route.ID);
            System.Console.WriteLine(route.FirstCityID - 1);
            System.Console.WriteLine(route.SecondCityID - 1);
            graph[route.FirstCityID - 1, route.SecondCityID - 1] = route.NumberOfSegments;
            graph[route.SecondCityID - 1, route.FirstCityID - 1] = route.NumberOfSegments;
        }



        CalculateRoute t = new CalculateRoute();
        int Steps = t.dijkstra(graph, src, target, NumCities);
        System.Console.WriteLine("TEST RAN AND RETURNED");
        System.Console.WriteLine("CityFrom: " + src);
        System.Console.WriteLine("CityTo: " + target);
        System.Console.WriteLine("NumberOfSteps!!!!!!: " + Steps);
        Route cheapestRoute = new Route();
        return cheapestRoute;
    }

}