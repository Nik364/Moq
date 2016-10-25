using NikMock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikMock.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal RawPrice { get; set; }

        public decimal GetPriceWithTax(ITaxCalculate calc)
        {
            return calc.GetTax(RawPrice) + RawPrice;
        }
    }
}