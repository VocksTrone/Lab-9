using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public class BackupStack
    {
        protected Node Top;
        public BackupStack()
        {
            Top = null;
        }
        public void Stack(Vehicles vehicle)
        {
            Node newNode = new Node(vehicle);
            newNode.Next = Top;
            Top = newNode;
        }
        public Vehicles Unstack()
        {
            if (Top != null)
            {
                Vehicles vehicle = Top.Vehicle;
                Top = Top.Next;
                return vehicle;
            }
            else
            {
                return null;
            }
        }
        public bool IsEmpty()
        {
            return Top == null;
        }
    }
}
