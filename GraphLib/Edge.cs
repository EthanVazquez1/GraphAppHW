using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class Edge
    {
        public Vertex Parent {  get; set; }
        public Vertex Child { get; set; }
        public int Weight { get; set; }
    }
}
