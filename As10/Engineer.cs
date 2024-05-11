using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace As10
{
    internal interface ICalc
    {
        public abstract int CalcSalary();
    }

    internal class Engineer : Employee, ICalc
    { 
        public int allowance;

        public override int CalcSalary()
        {
            return (pSalary * pDays) / 24 + allowance;
        }

        public void Input()
        {
            base.Input();
            Console.Write("Nhap Allowance: ");
            allowance = int.Parse(Console.ReadLine().Trim());
        }

        public override void Display()
        {
            Console.WriteLine("Engineer Information:");
            Console.WriteLine($"ID: {pId}");
            Console.WriteLine($"Name: {fullName}");
            Console.WriteLine($"Base Salary: {pSalary}");
            Console.WriteLine($"Worked Days: {pDays}");
            Console.WriteLine($"Allowance: {allowance}");
        }
    }
}
