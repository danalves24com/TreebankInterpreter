using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreebankInterpreter
{

    public class NodeList
    {
        private List<Node> nodes;
        private Node super;
        public NodeList(List<Node> nodes, Node super)
        {
            this.nodes = nodes;
            this.super = super;
        }
        public void print( )
        {
            Console.WriteLine(super);
            foreach(Node node in nodes)
            {
                Console.WriteLine("\t"+node);
            }
        }
    }
    public class Node
    {
        private List<Node> nodes;
        private int id;
        private String dat;
        public Node setContent(String dat)
        {
            this.dat = dat;
            return this;
        }
        public String getData()
        {
            return this.dat;
        }
        public Node(int id)
        {
            this.id = id;
            this.nodes = new List<Node>();
        }

        public override string ToString()
        {
            return  this.dat;
        }
    }
}
