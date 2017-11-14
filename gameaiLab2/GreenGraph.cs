using System;
using System.Collections.Generic;

class GreenGraph : Graph {
   
   // List of nodes in this graph
   private List<Node> nodes;
   // An adjacency matrix, recording edges between nodes
   // Edges FROM node i are recorded in adjMatrix[i]
   // Edge FROM node i to node j is recorded in adjMatrix[i][j]
   // Each int entry records the edge cost (> -1)
   // If entry is 0 there is no edge 
   private List<List<int>> adjMatrix;

   public GreenGraph() {
      nodes = new List<Node>();
      adjMatrix = new List<List<int>>();
   }
   public void AddNode(Node a){
       int count = 0;
        nodes.Add(a);
        adjMatrix.Add(new List<int>(nodes.Count));
        foreach (List<int> myList in adjMatrix){
            count++;
            int diff = nodes.Count - myList.Count;
            if (diff != 0){
                for (int i = 0; i < diff; i++){
                    adjMatrix[count-1].Add(0);
                }
            }
        }


   }
   public void AddEdge(Node a, Node b, int c){
            
        int n = nodes.IndexOf(a);
        int m = nodes.IndexOf(b);
        adjMatrix[n].Insert(m, c);
       
       
   }
   public List<Node> Nodes(){
       return nodes;
   }
    
   public List<Node> Neighbours(Node a){
      List<Node> neighbours = new List<Node>();
		for(int i = 0; i < nodes.Count - 1; i ++){
			int n = adjMatrix[nodes.IndexOf(a)][i];
			if (n != 0){
				neighbours.Add(nodes[i]);
			}
		}
		return neighbours;
        

       
   }
   public int Cost(Node a,Node b){
       return adjMatrix[nodes.IndexOf(a)][nodes.IndexOf(b)];
       
   }


   // ADD MISSING METHODS HERE



   public void Write() {
      Console.WriteLine("GreenGraph");

      for (int i = 0; i < nodes.Count; i++) {
         Console.Write(nodes[i] + ": ");

         bool first = true;
         for (int j = 0; j < nodes.Count; j++) {
            if (adjMatrix[i][j] > 0) {
               if (!first) Console.Write(", ");
               Console.Write(nodes[j] + "(" + adjMatrix[i][j] + ")");
               first = false;
            }
         }

         Console.Write("\n");
      }
   }
}