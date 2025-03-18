using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_1___Bankrekening
{
    public abstract class Bankrekening
    {
        // protected is binnen de klasse en afgeleide klasse beschikbaar maar niet erbuiten!
        protected double balance;

        // Contructor
        public Bankrekening(double opening, string name, string address)
        {
            balance = opening;
            Name = name;
            Adress = address;
        }

        // Expression-bodied read-only property (enkel get)
        public double CurrentBalance => balance;


        // Auto-implemented properties
        public string Name { get; set; }
        public string Adress { get; set; }


        // Methods
        public void DebetBalance(double amount)
        {
            balance += amount;
        }

        // Deze virtual method kan in een afgeleide class override worden met een eigen implementatie.
        public virtual void CreditBalance(double amount)
        {
            balance -= amount;
        }

        // Abstracte method: deze heeft geen implementatie.
        // De implementatie MOET aanwezig zijn in een afgeleide class.
        // In een afgeleide class gebruik je dan het keyword "override" om een eigen implementatie te geven.
        public abstract double CalculateInterest();
    }

    class Rekening<T>
    {
        private List<T> _list = new List<T>();

        public void Add(T input)
        {
            _list.Add(input);
        }

        public string ShowList()
        {
            StringBuilder retVal = new StringBuilder();
            foreach (T element in _list)
            {
                retVal.AppendLine(element.ToString());
            }
            return retVal.ToString();
        }
    }
}