// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Disktsra
{
    public static void Main(string[] args)
    {
        int numberOfNodes = 4;
        int sourceNode = 0;
        int[][] adjacencyMatrix = {
            new int[]{ 0,5,8,1000},
            new int[]{ 5,0,9,2},
            new int[]{ 8,9,0,6},
            new int[]{ 1000,2,6,0}
        };
        int[] distanceFromSource = Dijkstra(adjacencyMatrix, sourceNode);
        Console.WriteLine(string.Join("  ",distanceFromSource));
    }
    
    static int GetMinDistanceNode (int[] distanceFromSource, bool[] visitedNodes, int countOfNodes){
        int minDistance = Int32.MaxValue, minDistanceNode =-1;
        for(int i=0;i<countOfNodes;++i){
            if(!visitedNodes[i] && distanceFromSource[i]<minDistance){
                minDistance = distanceFromSource[i];
                minDistanceNode = i;
            }
        }
        return minDistanceNode;
    }
    
    static int[] Dijkstra(int[][] adjacencyMatrix, int sourceNode){
        int countOfNodes = adjacencyMatrix.Length;
        bool[] visitedNodes = new bool[countOfNodes];
        int[] distanceFromSource =  new int[countOfNodes];
        for(int i=0;i<countOfNodes;++i){
            visitedNodes[i]= false;
            distanceFromSource [i] = Int32.MaxValue;
        }
        
        distanceFromSource[sourceNode] = 0;
        for(int i=0;i<countOfNodes-1;++i){
            int minDistanceNode = GetMinDistanceNode(distanceFromSource, visitedNodes, countOfNodes);
            Console.WriteLine($"Min Distance Node {minDistanceNode}");
            visitedNodes[minDistanceNode]= true;
            for(int v=0;v<countOfNodes;++v){
                if(!visitedNodes[v] && 
                    distanceFromSource[v]>distanceFromSource[minDistanceNode]+adjacencyMatrix[minDistanceNode][v]){
                        distanceFromSource[v] = distanceFromSource[minDistanceNode]+adjacencyMatrix[minDistanceNode][v];
                    }
            }
            Console.WriteLine(string.Join("  ",distanceFromSource));
        }
        return distanceFromSource;
    }
}