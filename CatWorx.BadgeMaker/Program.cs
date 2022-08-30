using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        async static Task Main(string[] args)
        {
            // this is our employee-getting code now
            List<Employee> employees = new List<Employee>();
            employees = GetEmployees();

            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadge(employees);          
        }

        static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            while (true)
            {
                // move initial prompt inside the loop so it repeats for each employee
            Console.WriteLine("Please enter first name: (leave empty to exit): ");

            // Get a name from the console and assign it to a variable
            // change input to firstName
            string firstName = Console.ReadLine() ?? "";
            if(firstName == "")
            {
                break;
            }

            // add a Console.ReadLine() for each value
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine() ?? "";

            Console.Write("Enter employee ID: ");
            int id = Int32.Parse(Console.ReadLine() ?? "");

            Console.Write("Enter Photo URL: ");
            string photoUrl = Console.ReadLine() ?? "";

            // Create a new Employee Instance
            Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
            employees.Add(currentEmployee);                
            }
            return employees;
            // static List<Employee> GetEmployees();
        }

    }
    
}
