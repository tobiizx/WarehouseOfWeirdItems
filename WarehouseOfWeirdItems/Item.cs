using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseOfWeirdItems
{
    public class Item
    {
        public string Name { get; }
        public double WeightKg { get; }
        public int WeirdnessLevel { get; }
        public bool IsFragile { get; }

        public Item(string name, double weightKg, int weirdnessLevel, bool isFragile)
        {
            Name = name;
            WeightKg = Math.Round(weightKg, 3);
            WeirdnessLevel = weirdnessLevel;
            IsFragile = isFragile;
        }

        public string Description()
        {
            return $@"{{
            ""name"": ""{Name}"",
            ""weight_kg"": {WeightKg},
            ""weirdness_level"": {WeirdnessLevel},
            ""is_fragile"": ""{(IsFragile ? "YES" : "NO")}""
}}";
        }
    }

}