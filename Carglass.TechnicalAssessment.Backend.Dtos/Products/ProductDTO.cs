using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carglass.TechnicalAssessment.Backend.Dtos.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductType { get; set; }
        public int NumTerminal { get; set; }
        public DateTime SoldAt { get; set; }
    }
}
