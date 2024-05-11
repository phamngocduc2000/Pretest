using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As10
{
    internal class EmployeeCatalog : IEnumerable<Engineer>
    {
        List<Engineer> listEngineer = new List<Engineer>();
        public IEnumerator<Engineer> GetEnumerator()
        {
            Console.WriteLine("BBBBB");

            if (listEngineer.Count == 0)
            {
                Console.WriteLine("Danh sach chua co du lieu.");
                yield break;
            }
            else
            {
                foreach (Engineer engineer in listEngineer)
                {
                    yield return engineer; 
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Engineer> GetSenior()
        {
            if (listEngineer.Count == 0)
            {
                Console.WriteLine("Danh sach chua co du lieu.");
                yield break;
            }
            else
            {
                foreach (Engineer engineer in listEngineer)
                {
                    if (engineer.CalcSalary() >= 500)
                    {
                        yield return engineer;
                    }
                }
            }
        }

        public void Add()
        {
            Engineer engi = new Engineer();
            engi.Input();
            listEngineer.Add(engi);
        }

        public void DisplayAll()
        {
            Console.WriteLine("AAAAA");
            GetEnumerator();
        }
    }
}
