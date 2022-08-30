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

            Console.WriteLine("Please Enter 'Y' if you would like to enter your own employees.");
            string answer = Console.ReadLine() ?? "";

            var yesAnswer = new string[]{"y", "Y", "yes", "Yes", "YES", "YEs", "YeS", "yeS"};

            if(yesAnswer.Contains(answer)){
                employees = PeopleFetcher.GetEmployees();
            }

            else {
                employees = await PeopleFetcher.GetFromApi();
            }
            // employees = PeopleFetcher.GetEmployees();            

            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadge(employees);
            await PeopleFetcher.GetFromApi();          
        }
    }
    
}
