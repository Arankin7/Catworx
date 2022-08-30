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

            // employees = PeopleFetcher.GetEmployees();
            employees = await PeopleFetcher.GetFromApi();

            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadge(employees);
            await PeopleFetcher.GetFromApi();          
        }
    }
    
}
