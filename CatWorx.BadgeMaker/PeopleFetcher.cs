using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        // code from GetEmployees in Program.cs
        public static List<Employee> GetEmployees()
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
        }

        async public static Task<List<Employee>> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();

            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                // Console.WriteLine(response);
                JObject json = JObject.Parse(response);

                foreach (JToken token in json.SelectToken("results")!)
                {
                    // parse JSON data
                    Employee emp = new Employee
                    (
                        token.SelectToken("name.first")!.ToString(),
                        token.SelectToken("name.last")!.ToString(),
                        Int32.Parse(token.SelectToken("id.value")!.ToString().Replace("-", "")),
                        token.SelectToken("picture.large")!.ToString()
                    );

                    employees.Add(emp);
                }
            }
            return employees;
        }
    }
}