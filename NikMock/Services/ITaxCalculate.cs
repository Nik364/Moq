using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikMock.Services
{
    public interface ITaxCalculate
    {
        decimal GetTax(decimal rawPrice);
    }
}