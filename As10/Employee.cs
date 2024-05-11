using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace As10
{
    internal abstract class Employee
    {
        private string id;
        private int baseSalary;
        private int workedDays;

        public string fullName {  get; set; }

        public string pId
        {
            get { return id; }
            set
            {
                if (Regex.IsMatch(value, "^E\\d{4}$"))
                {
                    id = value;
                }
                else
                {
                    throw new Exception("Id sai dinh dang.");
                }
            }
        }

        public int pSalary
        {
            get { return baseSalary; }
            set
            {
                if (value > 100 && value < 5000)
                {
                    baseSalary = value;
                }
                else
                {
                    throw new Exception("Phai nhap luong tu 100 den 5000.");
                }
            }
        }

        public int pDays
        {
            get { return workedDays; }
            set
            {
                if (value > 0 && value <= 31)
                {
                    workedDays = value;
                }
                else
                {
                   throw new Exception("Phai nhap ngay tu 1 den 31.");
                }
            }
        }

        public abstract void Display();
        public abstract int CalcSalary();
        public void Input()
        {
            while (true)
            {
                try
                {
                    Console.Write("Nhap Id [Exxxx]: ");
                    pId = Console.ReadLine().Trim();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.Write("Nhap Name: ");
            fullName = Console.ReadLine().Trim();

            while (true)
            {
                try
                {
                    Console.Write("Nhap BaseSalary: ");
                    pSalary = int.Parse(Console.ReadLine().Trim());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Nhap WorkedDays: ");
                    pDays = int.Parse(Console.ReadLine().Trim());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public string ToString()
        {
            return "ID: " + id + ", Name: " + fullName + ", BaseSalary: " + baseSalary + ", WorkedDays: " + workedDays;
        }
    }
}
