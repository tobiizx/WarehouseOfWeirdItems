using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseOfWeirdItems
{
    public class Warehouse
    {
        private List<Item> items = new List<Item>();
        private int capacity;
        private double maxTotalWeight;

        public int CurrentItemCount => items.Count;

        public Warehouse(int capacity, double maxTotalWeight)
        {
            this.capacity = capacity;
            this.maxTotalWeight = Math.Round(maxTotalWeight, 3);
        }

        public bool AddItem(Item item, out string message)
        {
            double currentWeight = 0;
            foreach (var i in items)
            {
                currentWeight += i.WeightKg;
            }

            if (items.Count >= capacity)
            {
                message = "Error: Warehouse is full.";
                return false;
            }

            if (currentWeight + item.WeightKg > maxTotalWeight)
            {
                message = "Error: Adding this item will exceed the maximum warehouse weight.";
                return false;
            }

            if (item.WeirdnessLevel == 7 && item.IsFragile && items.Count >= capacity / 2)
            {
                message = "Error: Too risky item (fragile and weirdness level 7) at current capacity level.";
                return false;
            }

            items.Add(item);
            message = "Item has been added successfully.";
            return true;
        }

        public void PrintAll()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"Item #{i + 1}:\n{items[i].Description()}\n");
            }
        }

        public bool RemoveItem(string name)
        {
            var item = items.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                items.Remove(item);
                return true;
            }
            return false;
        }

        public void PrintFragileOrHeavy(double weightThreshold)
        {
            var filtered = items.Where(i => i.IsFragile || i.WeightKg > weightThreshold);
            foreach (var item in filtered)
            {
                Console.WriteLine(item.Description());
                Console.WriteLine();
            }
        }

        public double CalculateAverageWeirdness()
        {
            if (items.Count == 0) return 0;
            return items.Average(i => i.WeirdnessLevel);
        }
    }
}
