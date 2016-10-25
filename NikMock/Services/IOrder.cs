using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikMock.Services
{
    public interface IOrder
    {
        string ShowTitle(string title);

        string ShowAddress();
    }
}