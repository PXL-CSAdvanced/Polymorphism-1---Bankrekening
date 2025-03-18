using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_1___Bankrekening
{
    public class BankException : ApplicationException
    {
        public BankException() : base()
        {
        }

        public BankException(string message) : base(message)
        {
        }
    }
}
