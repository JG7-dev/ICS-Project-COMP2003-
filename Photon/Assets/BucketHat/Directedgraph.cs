using System;
using System.Collections.Generic;
using System.Linq;

namespace DirectedGraph
{
    public class DG
    {

        #region Data Store Classes //
        public class nodeData //Edit this class to whatever is to be stored in Nodes
        {
            public string dialog;
            public nodeData(string dialog)
            {
                this.dialog = dialog;
            }
        }
        public class linkData //Edit this class to whatever is to be stored in links (IE buttons in our case)
        {
            public string buttonText;
            public linkData(string buttonText)
            {
                this.buttonText = buttonText;
            }
        } 
        #endregion

        public class node
        {
            public string label;
            public nodeData data;
            public List<link> links;
            public node(nodeData data, string label)
            {
                this.data = data;
                this.label = label;
                this.links = new List<link>();
            }
        }
        public class link
        {
            internal string sourceLabel;
            internal string targetLabel;
            public int target;
            public linkData data;
            public link(string source, string target, linkData data)
            {
                this.sourceLabel = source;
                this.targetLabel = target;
                this.data = data;
            }
        }

        public List<node> graph;
        public int root;
        private bool sorted_ = false; //tracks if dg has been sorted for use of binary serach algorithms
        private bool baked_ = false; 
        public DG()
        {
            this.graph = new List<node>();
            this.root = -1;
        }
        public bool appendOrphan(nodeData data, string label)
        {
            graph.Add(new node(data, label));
            sorted_ = false;
            return true;
        }

        internal int internalSearch(string key) //Performs a Binary Search on DG to locate the given index of a node with a label of given input
        {
            if (sorted_ == false) {
                this.graph.Sort((x, y) => x.label.CompareTo(y.label)); //Sorts DG by their label
                sorted_ = true;
            }
            //Classic Binary Search Algorithm
            #region Binary Search
            int min = 0;
            int max = graph.Count() - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == graph[mid].label)
                {
                    return mid;
                }
                else if (key.CompareTo(this.graph[mid].label) == -1)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1; 
            #endregion
        }

        public bool LinkAppend(link input)
        {
            int source = internalSearch(input.sourceLabel);
            graph[source].links.Add(input);
            return true;
        }
        public bool bakeGraph()
        {
            for (int x = 0; x < graph.Count(); x++)
            {
                if (graph[x].links.Count() != 0)
                {
                    for (int y = 0; y < graph[x].links.Count(); y++)
                    {
                        graph[x].links[y].target = internalSearch(graph[x].links[y].targetLabel);
                    }
                }
            }
            root = internalSearch("root");
            baked_ = true;
            return true;
        }
        // graph[x].links       Returns list of links belonging to node X

        #region D4C Reader because this Dirty Deed was Done Dirt Cheap
        private bool showOptions() //loops and prints to console that available paths
        {
            if (graph[pointer].links.Count() > 0)
            {
                foreach (link link in graph[pointer].links)
                {
                    Console.WriteLine(link.data.buttonText); //Replace with Create button function with link.data.buttonText as button text
                }
            }
            return true;
        }
        private int checkOption(string input)
        {
            if (graph[pointer].links.Count() == 0) { return -1; }
            foreach (link link in graph[pointer].links)
            {
                if (link.data.buttonText.ToUpper().CompareTo(input.ToUpper()) == 0)
                {
                    return link.target;
                }
            }
            return -1;
        }

        private int pointer;
        public bool D4CReader()
        {
            if (baked_ == false)
            {
                Console.WriteLine("Error, DG Graph not Baked");
                return false;
            }
            pointer = root;
            Console.WriteLine("Reader Started");
            bool loop_ = true;
            while (loop_)
            {
                Console.WriteLine(graph[pointer].data.dialog);
                showOptions();
                pointer = checkOption(Console.ReadLine());
                if (pointer == -1) { return false; }
            }
            return true;
        } 
        #endregion

    }
}
#region Demo Runtime Program
/*  This was the program run during the Interim Demonstration

    class Program
    {
        static void Main(string[] args)
        {
            DG test = new();
            Console.WriteLine("Reading Directedgraph");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            test.appendOrphan(new DG.nodeData("The First Text"), "root");
            test.appendOrphan(new DG.nodeData("We are at point A"), "A");
            test.appendOrphan(new DG.nodeData("We are at point B"), "B");
            test.appendOrphan(new DG.nodeData("We are now at point C"), "C");
            test.appendOrphan(new DG.nodeData("We are now at point D"), "D");
            test.appendOrphan(new DG.nodeData("We are now at Point E"), "E");
            test.appendOrphan(new DG.nodeData("We are now at Point F"), "F");
            test.appendOrphan(new DG.nodeData("We are at Point O, there are no further points beyond this, but hopefully this proves a point."), "O");
            //Instead of applying each link one at a time, put links into a stack, sort that stack once and then the processing to give each node it's appropriate link is much faster - Ewan
            test.LinkAppend(new DG.link("root","A", new DG.linkData("A")));
            test.LinkAppend(new DG.link("root", "B", new DG.linkData("B")));
            test.LinkAppend(new DG.link("A", "C", new DG.linkData("C")));
            test.LinkAppend(new DG.link("B", "A", new DG.linkData("A")));
            test.LinkAppend(new DG.link("B", "O", new DG.linkData("O")));
            test.LinkAppend(new DG.link("C", "E", new DG.linkData("E")));
            test.LinkAppend(new DG.link("E", "B", new DG.linkData("B")));
            test.LinkAppend(new DG.link("C", "F", new DG.linkData("F")));
            test.LinkAppend(new DG.link("F", "D", new DG.linkData("D")));
            test.LinkAppend(new DG.link("D", "root", new DG.linkData("Start")));
            test.LinkAppend(new DG.link("C", "O", new DG.linkData("O")));

            watch.Stop();
            Console.WriteLine("Read complete:" + watch.ElapsedMilliseconds + " ms.");
            Console.WriteLine("Baking Graph...");
            watch = System.Diagnostics.Stopwatch.StartNew();
            test.bakeGraph();
            watch.Stop();
            Console.WriteLine("Bake complete:" + watch.ElapsedMilliseconds + " ms.");
            Console.WriteLine(test.D4CReader());
        }
    }

*/
#endregion
