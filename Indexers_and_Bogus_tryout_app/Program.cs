using Bogus;
using System.Collections.Generic;

namespace Indexers_and_Bogus_tryout_app

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department Sales = new Department("Sales");

            // Creating an instance of a class to get access to a functions
            var faker = new Faker();
            Randomizer.Seed = new Random(123);

            // Generating fake employees.
            for (int i = 0; i < 20; i++)
            {
                Sales.AddEmployee(faker.Name.FirstName(), faker.Name.LastName());
            }

            //Console.WriteLine(Sales.Employees.Count);
            //Console.WriteLine(Sales.Employees[3].FullName);
            Console.WriteLine(string.Join("\n", Sales.Employees));

            // The Indexers by string and int work.
            Console.WriteLine("\n" + Sales["Nico Nienow"].Id);
            Console.WriteLine(Sales[12].FullName);
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

        public Employee this[int Id]
        {
            get
            {
                foreach (Employee emp in Employees)
                {
                    if (emp.Id == Id) return emp;
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

        public override string ToString()
        {
            return FullName;
        }
    }
}