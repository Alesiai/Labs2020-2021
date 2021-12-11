using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_10
{
    
    class Worker 
    {
        int salary = 1000;
        string name;
      
        public string Name { get => name; set => this.name = value; }
        public int Salary { get => salary; set => this.salary = value; }
        
        public Worker()
        {

        }
        public Worker(string name, int salary = 1000)
        {
            this.Name = name;
            this.Salary = salary;
          
        }
        public void AddSalary(int salary = 10)
        {
            Salary += salary;
        }
        public void MinusSalary(int salary = 10)
        {
            Salary -= salary;
        }

        public override string ToString()
        {
            return "Name: " + Name.ToString() + " Salary: " + Salary.ToString();
        }
    }

}
