using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As10
{
    internal class Test
    {
        public void Menu()
        {
            EmployeeCatalog catalog = new EmployeeCatalog();
            int choice = 0;

            do
            {
                Console.WriteLine("================MENU==================");
                Console.WriteLine("1.   Add new Engineer.");
                Console.WriteLine("2.   Display all Engineer.");
                Console.WriteLine("3.   Display Engineer having actual salary more than 500.");
                Console.WriteLine("4.   Quit.");
                Console.WriteLine("======================================");
                Console.WriteLine("Nhap lua chon: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1.   Add new Engineer.");
                        catalog.Add();
                        break;
                    case 2:
                        Console.WriteLine("2.   Display all Engineer.");
                        catalog.GetEnumerator();
                        break;
                    case 3:
                        Console.WriteLine("3.   Display Engineer having actual salary more than 500.");
                        catalog.GetSenior().ToList().ForEach(x => x.Display());
                        break;
                    case 4:
                        Console.WriteLine("4.   Quit.");
                        break;
                    default:
                        Console.WriteLine("Nhap sai! Vui long nhap lai");
                        break;
                }
            } while (choice != 4);
        }
    }
}
