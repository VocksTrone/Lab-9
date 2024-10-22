using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public class ParkingLot
    {
        protected int Capacity;
        protected LinkedList ParkinLotVehicles;
        protected LinkedList WaitingList;
        protected BackupStack BackupHistorial;

        public ParkingLot(int capacity)
        {
            Capacity = capacity;
            ParkinLotVehicles = new LinkedList();
            WaitingList = new LinkedList();
            BackupHistorial = new BackupStack();
        }

        public int VehiclesQuantity()
        {
            int vehicles = 0;
            Node actualVehicle = ParkinLotVehicles.GetFirstNode();
            while (actualVehicle != null)
            {
                vehicles++;
                actualVehicle = actualVehicle.Next;
            }
            return vehicles;
        }

        public void AddVehicle(Vehicles vehicle)
        {
            if (VehiclesQuantity() < Capacity)
            {
                ParkinLotVehicles.AddVehicle(vehicle);
                Console.WriteLine($"\n{vehicle.Name} ({vehicle.Plate}) se ha Estacionado");
            }
            else
            {
                WaitingList.AddVehicle(vehicle);
                Console.WriteLine($"\nEstacionamiento Lleno, {vehicle.Name} ({vehicle.Plate}) se ha Añadido a la Lista de Espera");
            }
            Console.ReadKey();
        }

        public void RemoveVehicle(string plate)
        {
            Vehicles vehicle = ParkinLotVehicles.DeleteVehicle(plate);
            if (vehicle != null)
            {
                BackupHistorial.Stack(vehicle);
                Console.WriteLine($"\n{vehicle.Name} ({vehicle.Plate}) ha Salido del Estacionamiento");
                if (!WaitingList.IsEmpty())
                {
                    Vehicles waitingVehicle = WaitingList.DeleteFirst();
                    ParkinLotVehicles.AddVehicle(waitingVehicle);
                    Console.WriteLine($"\n{waitingVehicle.Name} ({waitingVehicle.Plate}) Ingresó desde la Lista de Espera");
                }
            }
            else
            {
                Console.WriteLine($"El Vehículo ({plate}) No está Estacionado");
            }
            Console.ReadKey();
        }

        public void UndoLastExit()
        {
            if (!BackupHistorial.IsEmpty())
            {
                Vehicles vehicle = BackupHistorial.Unstack();
                ParkinLotVehicles.AddVehicle(vehicle);
                Console.WriteLine($"Salida Deshecha. {vehicle.Name} ({vehicle.Plate}) Regresó al Estacionamiento");
            }
            else
            {
                Console.WriteLine("\nNo Hay Operaciones para Deshacer");
            }
            Console.ReadKey();
        }

        public void ShowVehiclesInParkingLot()
        {
            Console.Clear();
            Console.WriteLine("Vehículos Estacionados:");
            ParkinLotVehicles.ShowList();
        }

        public void ShowNextInWaitingList()
        {
            Vehicles vehicle = WaitingList.GetFirst();
            if (vehicle != null)
            {
                Console.WriteLine($"\nPróximo Vehículo en Lista de Espera: {vehicle.Name} ({vehicle.Plate})");
            }
            else
            {
                Console.WriteLine("\nNo Hay Vehículos en Lista de Espera");
            }
            Console.ReadKey();
        }
    }
}
