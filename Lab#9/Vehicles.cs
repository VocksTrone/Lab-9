using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    public class Vehicles
    {
        public string Plate { get; set; }
        public string Name { get; set; }
        public Vehicles(string plate, string name)
        {
            Plate = plate;
            Name = name;
        }
        public string OverrideInfo()
        {
            return $"{Name} ({Plate})";
        }
    }
}
