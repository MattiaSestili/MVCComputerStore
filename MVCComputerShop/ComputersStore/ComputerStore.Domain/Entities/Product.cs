using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Cpu { get; set; }
        public string HardDrive { get; set; }
        public string GraphicCard { get; set; }
        public string MemoryRam { get; set; }
        public decimal Price { get; set; }
    }
}
