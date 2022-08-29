using System;
using System.IO;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Util
    {
        public static void PrintEmployees(List<Employee> employees)
        {
            Console.WriteLine("List of Employees: ");
            for(int i = 0; i < employees.Count; i++){
                string template = "{0,-10}\t{1,-20}\t{2}";
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            };            
        }

        public static void MakeCSV(List<Employee> employees)
        {
            // Check to see if folder exists
            if(!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            // StreamWriter file = new StreamWriter("data/employees.csv");
            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            {
                file.WriteLine("ID,Name,PhotoUrl");

                // loop over employees
                for(int i = 0; i < employees.Count; i++)
                {
                    // Write each employee to the file
                    string template = "{0}\t{1}\t{2}";
                    file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                }
            }
        }
    }
}