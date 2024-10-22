using System;
using Lab_9;

bool generalContinue = true;
ParkingLot parkingLot = null;

parkingLot = ParkingLots();
while (generalContinue)
{
    try
    {
        SwitchFirstMenu(parkingLot);
    }
    catch (FormatException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("ERROR!, Datos Inválidos");
        Console.ResetColor();
        Console.ReadKey();
    }
}

ParkingLot ParkingLots()
{
    Console.Clear();
    Console.Write("Capacidad del Estacionamiento: ");
    int capacity;
    if (int.TryParse(Console.ReadLine(), out capacity) && capacity > 0)
    {
        return new ParkingLot(capacity);
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ingrese un Número Mayor a 0");
        Console.ResetColor();
        Console.ReadKey();
        return ParkingLots();
    }
}

int FirstMenu()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("--- Estacionamiento Buffalo ---");
    Console.ResetColor();
    Console.WriteLine("\n1. Ingresar Vehículo");
    Console.WriteLine("2. Retirar Vehículo");
    Console.WriteLine("3. Deshacer Última Salida");
    Console.WriteLine("4. Mostrar Vehículos en el Estacionamiento");
    Console.WriteLine("5. Mostrar Lista de Espera");
    Console.WriteLine("6. Salir");
    Console.Write("\nIngrese una Opción: ");
    int firstOption = int.Parse(Console.ReadLine());
    return firstOption;
}

bool GoOut()
{
    Console.WriteLine("\nUsted está Cerrando el Programa");
    generalContinue = false;
    return generalContinue;
}

void SwitchFirstMenu(ParkingLot parkingLot)
{
    switch (FirstMenu())
    {
        case 1:
            Console.Write("\nIngrese la placa del vehículo: ");
            string plate = Console.ReadLine();
            Console.Write("\nIngrese el nombre del vehículo: ");
            string name = Console.ReadLine();
            Vehicles vehicle = new Vehicles(plate, name);
            parkingLot.AddVehicle(vehicle);
            break;
        case 2:
            Console.Write("\nIngrese la placa del vehículo a retirar: ");
            string plateToRemove = Console.ReadLine();
            parkingLot.RemoveVehicle(plateToRemove);
            break;
        case 3:
            parkingLot.UndoLastExit();
            break;
        case 4:
            parkingLot.ShowVehiclesInParkingLot();
            break;
        case 5:
            parkingLot.ShowNextInWaitingList();
            break;
        case 6:
            GoOut();
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ingrese una Opción Válida (1 - 6)");
            Console.ResetColor();
            Console.ReadKey();
            break;
    }
}
