using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreebankInterpreter
{
    public class TextDependencyCreator
    {
        private String text;
        public TextDependencyCreator(String text)
        {
            this.text = text;
        }

        public NodeList generateNodes()
        {

            List<Node> nodes = new List<Node>();            
            String currentNodeContent = "";
            Node node = null;
            List<int> ob = new List<int>();
            int it = 0;
            foreach (Char co in this.text)
            {
                if (co.ToString().Equals("(") && it > 0)
                {
                    ob.Add(it);
                }
                it += 1;
            }
            for (int i = ob.Count - 1; i >= 0; i--)
            {
                int index = ob[i];
                int nodesCount = 0, opens = 0, closes = 0;
                String ss = this.text.Substring(index + 1);
                node = new Node(nodesCount);
                nodesCount += 1;
                bool ended = false;
                foreach (Char c in ss)
                {
                    if (!ended)
                    {
                        String cc = c.ToString();

                        if (cc.Equals(")") && opens > 0)
                        {
                            opens -= 1;
                        }
                        else if (cc.Equals("("))
                        {
                            opens += 1;
                        }
                        else if (cc.Equals(")"))
                        {
                            ended = true;
                        }
                        if (!ended)
                        {
                            currentNodeContent += cc;
                        }
                    }
                }
                
                nodes.Add(new Node(i).setContent(currentNodeContent));
                currentNodeContent = "";
            }
            int layer = 0;

            List<Node> children = new List<Node>(), layers = new List<Node>();           
            for (int i = 0; i < nodes.Count; i += 1)
            {
                Node node1 = nodes[i];
                String cont = node1.getData();
                if (cont.Contains("("))
                {                    
                    List<Node> cld = new List<Node>();
                    children.AddRange(layers);
                    foreach (Node n in children)
                    {
                        if(node1.getData().Contains(n.getData()))
                        {
                            cld.Add(n);
                        }
                    }
                    NodeList list = new NodeList(cld, node1);
                    list.print();
                    children = new List<Node>();
                    layers.Add(node1);
                }
                else
                {
                    children.Add(node1);
                }
                for (int p = 0; p < layer; p += 1)
                {
                    //Console.Write("   ");
                }
                //Console.WriteLine(cont);
            }
            /*
             * if (c.ToString().Equals("(") && node == null)
                    {
                        
                        
                    }
                    else if (c.ToString().Equals(")") && (opens - closes) == 0 && node != null)
                    {
                        node.setContent(currentNodeContent);
                        nodes.Add(node);
                        node = null;
                    }
                    else
                    {
                        if (c.ToString().Equals("(")) { opens += 1; }
                        else if (c.ToString().Equals(")")) { closes += 1; }
                        currentNodeContent += c.ToString();
                    }
             */
            return new NodeList(nodes, new Node(-1));
        }

    }
}
