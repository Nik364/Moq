using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikMock.Services
{
    public interface ICustomer
    {
        void AddCall();

        string GetCall();

        string GetCall(string user);

        string GetAddress(string user, out string address);

        string GetFamilyCall(ref string user);

        void ShowException(string str);

        string SelfMatch(int value);
    }
}