using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public class Node
    { 
        public Vehicles Vehicle { get; set; }
        public Node Next { get; set; }
        public Node(Vehicles vehicle)
        {
            Vehicle = vehicle;
            Next = null;
        }
    }
}
