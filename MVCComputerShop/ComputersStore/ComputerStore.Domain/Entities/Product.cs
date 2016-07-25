using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ComputerStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter a product brand")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Please enter a product model")]
        public string Model { get; set; }       
        [Required(ErrorMessage = " Please enter a type")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Please enter a Cpu")]
        public string Cpu { get; set; }
        [Required(ErrorMessage = "Please enter a product Hard Drive")]
        public string HardDrive { get; set; }
        [Required(ErrorMessage = "Please enter a product Grapich Card")]
        public string GraphicCard { get; set; }
        [Required(ErrorMessage = "Please enter a product RAM")]
        public string MemoryRam { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }
    }
}
