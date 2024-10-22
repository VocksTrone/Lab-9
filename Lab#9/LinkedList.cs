using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public class LinkedList
    {
        protected Node First;
        public LinkedList()
        {
            First = null;
        }
        public void AddVehicle(Vehicles vehicle)
        {
            Node newNode = new Node(vehicle);
            if (First != null)
            {
                Node actualNode = First;
                while (actualNode.Next != null)
                {
                    actualNode = actualNode.Next;
                }
                actualNode.Next = newNode;
            }
            else
            {
                First = newNode;
            }
        }
        public Vehicles GetFirst()
        {
            if (First == null)
            {
                return null;
            }
            else
            {
                return First.Vehicle;
            }
        }
        public bool IsEmpty()
        {
            return (First == null); 
        }
        public Vehicles DeleteFirst()
        {
            if (First != null)
            {
                Vehicles vehicle = First.Vehicle;
                First = First.Next;
                return vehicle;
            }
            else
            {
                return null;
            }
        }
        public Vehicles DeleteVehicle(string plate)
        {
            if (First == null)
            {
                return null;
            }
            else
            {
                if (First.Vehicle.Plate == plate)
                {
                    Vehicles deleteVehicle = First.Vehicle;
                    First = First.Next;
                    return deleteVehicle;
                }
                else
                {
                    Node actualVehicle = First;
                    while (actualVehicle.Next != null && 
                        actualVehicle.Vehicle.Plate != plate)
                    {
                        actualVehicle = actualVehicle.Next;
                    }
                    if (actualVehicle.Next == null)
                    {
                        return null;
                    }
                    else
                    {
                        Vehicles deleteVehicleTwo = actualVehicle.Next.Vehicle;
                        actualVehicle.Next = actualVehicle.Next.Next;
                        return deleteVehicleTwo;
                    }
                }
            }
        }
        public void ShowList()
        {
            Node actualVehicle = First;
            if (actualVehicle != null)
            {
                while (actualVehicle != null)
                {
                    Console.WriteLine(actualVehicle.Vehicle.OverrideInfo());
                    actualVehicle = actualVehicle.Next;
                }
            }
            else
            {
                Console.WriteLine("\nNo Hay Vehículos en la Lista");
            }
            Console.ReadKey();
        }
        public Node GetFirstNode()
        {
            return First;
        }
    }
}
