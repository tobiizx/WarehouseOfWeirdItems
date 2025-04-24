using System;
using System.Collections.Generic;
using WarehouseOfWeirdItems;

class Program
{
    static void Main()
    {
        List<Warehouse> warehouses = new List<Warehouse>();

        while (true)
        {
            if (warehouses.Count == 0 || Ask("Do you want to create a new warehouse? (yes/no): "))
            {
                Console.Write("Enter the warehouse capacity: ");
                int capacity = int.Parse(Console.ReadLine());

                Console.Write("Enter maximum weight (kg): ");
                double maxWeight = double.Parse(Console.ReadLine());

                warehouses.Add(new Warehouse(capacity, maxWeight));
                Console.WriteLine("New warehouse created.");
            }

            Warehouse current = warehouses[warehouses.Count - 1];

            Console.Write("\nItem name: ");
            string name = Console.ReadLine();

            Console.Write("Weight (kg): ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Weirdness level (1-10): ");
            int weirdness = int.Parse(Console.ReadLine());

            Console.Write("Is fragile? (yes/no): ");
            bool isFragile = Console.ReadLine().Trim().ToLower() == "yes";

            Item item = new Item(name, weight, weirdness, isFragile);
            if (current.AddItem(item, out string message))
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Error: " + message);
            }

            Console.Write("\nType 'add' to add another item, 'new' to create new warehouse, or anything else to quit: ");
            string choice = Console.ReadLine().Trim().ToLower();
            if (choice != "add" && choice != "new")
                break;
        }

        Console.WriteLine("\n==== All Warehouses ====");
        for (int i = 0; i < warehouses.Count; i++)
        {
            Console.WriteLine($"\nWarehouse #{i + 1}:");
            warehouses[i].PrintAll();
            Console.WriteLine($"Average weirdness: {warehouses[i].CalculateAverageWeirdness():0.00}");
        }
    }

    static bool Ask(string message)
    {
        Console.Write(message);
        return Console.ReadLine().Trim().ToLower() == "yes";
    }
}
