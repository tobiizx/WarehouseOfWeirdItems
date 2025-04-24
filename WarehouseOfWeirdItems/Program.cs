using System;
using WarehouseOfWeirdItems;

class Program
{
    static void Main()
    {
        Console.Write("Enter the warehouse capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        Console.Write("Enter maximum weight (kg): ");
        double maxWeight = double.Parse(Console.ReadLine());

        Warehouse warehouse = new Warehouse(capacity, maxWeight);

        while (true)
        {
            Console.Write("\nItem name: ");
            string name = Console.ReadLine();

            Console.Write("Weight (kg): ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Weirdness level (1-10): ");
            int weirdness = int.Parse(Console.ReadLine());

            Console.Write("Is fragile? (yes/no): ");
            bool isFragile = Console.ReadLine().Trim().ToLower() == "yes";

            Item item = new Item(name, weight, weirdness, isFragile);
            if (warehouse.AddItem(item, out string message))
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine(message);
            }

            Console.Write("Do you want to add another item? (yes/no): ");
            if (Console.ReadLine().Trim().ToLower() != "yes")
            {
                break;
            }
        }

        Console.WriteLine("\nWarehouse contents:");
        warehouse.PrintAll();
    }
}
