using Bogus;
using System.Collections.Generic;

namespace Indexers_and_Bogus_tryout_app

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department Sales = new Department("Sales");
            Sales.AddEmployee("Chad", "Power");
            Sales.AddEmployee("Leroy", "Jankins");
            Console.WriteLine(Sales.Employees.Count);
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

        public void AddEmployee(string FirstName, string SecondName)
        {
            Employees.Add(new Employee(FirstName, SecondName));
        }
        
    }

    public class Employee
    {
        public string FirstName { get; private set;}
        public string SecondName { get; private set;}
        private static int count = 0; 
        public int Id { get; } 

        public Employee(string FirstName, string SecondName)
        {
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.Id = count++;
        } 
    }
}