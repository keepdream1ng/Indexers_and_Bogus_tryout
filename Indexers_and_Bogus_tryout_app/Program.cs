using Bogus;
using System.Collections.Generic;

namespace Indexers_and_Bogus_tryout_app

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department Sales = new Department("Sales");
            Sales.AddEmployee("Caren", "Trouble");
            Sales.AddEmployee("Chad", "Power");
            Sales.AddEmployee("Leroy", "Jankins");
            Console.WriteLine(Sales.Employees.Count);
            Console.WriteLine(Sales["Chad Power"].Id);
        }
    }

    public class Department
    {
        public string Name { get; private set; } 

        public Department(string name)
        {
            this.Name = name;
        }

        public List <Employee> Employees = new List<Employee> ();

        public void AddEmployee(string FirstName, string LastName)
        {
            Employees.Add(new Employee(FirstName, LastName));
        }

        public Employee this[string FullName]
        {
            get
            {
                foreach (Employee emp in Employees)
                {
                    if (emp.FullName == FullName) return emp;
                }
                return null;
            }
        }
        
    }

    public class Employee
    {
        public string FirstName { get; private set;}
        public string LastName { get; private set;}
        public string FullName { get => $"{FirstName} {LastName}"; }
        private static int _count = 0; 
        public int Id { get; } 

        public Employee(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Id = _count++;
        } 
    }
}