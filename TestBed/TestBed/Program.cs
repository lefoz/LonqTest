using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBed
{
    class Program
    {

        static void Main(string[] args)
        {
            using (kasper_madsen_com_dbEntities context = new kasper_madsen_com_dbEntities())
            {
                List<string> cellNames = new List<string>();
                
                //Get the List of cells from Database
                var cellList = from d in context.Production_Cells
                               select d;

                foreach (var cell in cellList)
                {
                    Console.WriteLine("Cell Id = {0} , Cell Name = {1}, Cell Ip = {2}, Cell Port = {3}",
                                      cell.id, cell.name, cell.ip, cell.port);
                    cellNames.Add(cell.name);
                    
                }
                Console.WriteLine("\n");
                Console.ReadKey();
                cellNames.ForEach(Console.WriteLine);                      
                Console.ReadKey();
                Console.WriteLine("\n");

                var recipeList = from r in context.recipees
                                 select r;
                foreach (var recipe in recipeList)
                {
                    Console.WriteLine("Recipe Id = {0}" + "\n" + "Optimal Temperature = {1}, Min Temperature = {2}, Max Temperature = {3}"  + "\n" + "Optimal Humidity = {4}, Min Humidity = {5}, Max Humidity = {6}" + "\n" + "Optimal Light Hours = {7}, Lenght of production = {8} ",
                        recipe.id, recipe.opt_heat, recipe.min_heat, recipe.max_heat, recipe.opt_humidity, recipe.min_humidity, recipe.max_humidity, recipe.opt_light_hour, recipe.end_time +"\n");
                }
                Console.ReadKey();
            }
        }
    }
}
