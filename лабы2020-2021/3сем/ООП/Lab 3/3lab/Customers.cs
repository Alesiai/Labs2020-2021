using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public partial class Customer
    {
        public override string ToString() => ("ID: " + this.ID + "\nName: " + this.NAME + "\nSurname: " + this.SURNAME + "\nCard number: " + this.NCARD +
                    "\nAdress: " + this.ADRESS + "\nBalance: " + this.BALANCE + "\n");
        public override int GetHashCode() => Name.Length + this.Ncard * 9 - id;
        public override bool Equals(object obj)
        {
            if (obj is Customer cust)
            {
                return (cust.Adress == Adress && cust.Balance == Balance && cust.Name == Name && cust.Ncard == Ncard);

            }
            else return false;
        }
    }
     

}
   
