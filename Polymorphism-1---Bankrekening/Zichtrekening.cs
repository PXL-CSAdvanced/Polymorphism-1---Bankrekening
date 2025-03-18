using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_1___Bankrekening
{
    public class Zichtrekening : Bankrekening
    {
        public Zichtrekening(double opening, string name, string address) : base(opening, name, address)
        {
        }

        public override void CreditBalance(double amount)
        {
            // Als het saldo onder 0 zou gaan, gooi dan een BankException
            // (BankException is een eigen class die overerft van ApplicationException)
            //if ((saldo - waarde) < 0)
            if (amount > balance)
            {
                throw new BankException("Zichtrekening: saldo ontoereikend!");
            }
            // CreditBalance() method op van de base class (Bankrekening) oproepen
            base.CreditBalance(amount);
        }

        // Verplichte implementatie van de abstracte method CalculateInterest() van abstracte class Bankrekening.
        // Om een eigen implementatie hiervan te doen, gebruiken we het keyword "override".
        public override double CalculateInterest() => balance * 0.005;

        public override string ToString()
        {
            return $"Zicht: {balance}";
        }
    }
}
