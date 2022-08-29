﻿using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            // this is our employee-getting code now
            List<Employee> employees = GetEmployees();
            PrintEmployees(employees);            
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

        static void PrintEmployees(List<Employee> employees)
        {
            Console.WriteLine("List of Employees: ");
            for(int i = 0; i < employees.Count; i++){
                string template = "{0,-10}\t{1,-20}\t{2}";
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            };
        }
    }
    
}