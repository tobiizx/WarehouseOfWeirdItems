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
                message = "Warehouse is full.";
                return false;
            }

            if (currentWeight + item.WeightKg > maxTotalWeight)
            {
                message = "Adding this item will exceed the maximum warehouse weight.";
                return false;
            }

            items.Add(item);
            message = "Item has been added succesfully.";
            return true;
        }

        public void PrintAll()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"Item #{i + 1}:\n{items[i].Description()}\n");
            }
        }
    }
}
