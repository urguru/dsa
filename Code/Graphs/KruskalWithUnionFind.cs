// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        int nodeCount = 5;
        int edgeCount = 7;
        int[][] edgeList = {
            new int[] {0,1,1},
            new int[] {1,2,1},
            new int[] {2,3,2},
            new int[] {0,3,2},
            new int[] {0,4,3},
            new int[] {3,4,3},
            new int[] {1,4,6}
        };
        KruskalsAlgorithm(edgeList,nodeCount,edgeCount);
    }
    
    public static void KruskalsAlgorithm(int[][] edges, int nodeCount, int edgeCount){
        Array.Sort(edges,(x, y) => x[2].CompareTo(y[2]));
        int edgesRequiredForMST = nodeCount -1;
        UnionFind unionFind = new UnionFind(nodeCount);
        int totalWeightOfMST = 0 ;
        for(int i=0;i<edgeCount && edgesRequiredForMST >0 ; ++i){
            if(unionFind.Union(edges[i][0],edges[i][1])){
                totalWeightOfMST += edges[i][2];
                edgesRequiredForMST --;
                Console.WriteLine($"The edge from {edges[i][0]} to {edges[i][1]} with weight {edges[i][2]} is included in the MST");
            }
        }
    }
}

class UnionFind {
    private int[] Parent;
    private int[] Rank;
    int NodeCount;
    
    public UnionFind(int n){
        NodeCount=n;
        Parent = new int[n];
        Rank = new int[n];
        for(int i=0;i<n;++i){
            Parent[i]=i;
            Rank[i]=1;
        }
    }
    
    public int FindParent(int nodeId){
        if(nodeId>=NodeCount){
            return -1;
        }
        
        if(nodeId == Parent[nodeId]){
            return nodeId;
        }
        
        return FindParent(Parent[nodeId]);
    }
    
    public bool Union(int nodeA, int nodeB){
        if(FindParent(nodeA)==FindParent(nodeB)){
            return false;
        }
        
        if(Rank[nodeA]==Rank[nodeB]){
            Parent[nodeB] = nodeA;
            Rank[nodeA]++;
        }else if (Rank[nodeA]>Rank[nodeB]){
            Parent[nodeB] = nodeA;
        }else{
            Parent[nodeA] = nodeB;
        }
        
        return true;   
    }
}
