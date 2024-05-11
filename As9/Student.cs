using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace As9
{
    internal delegate void DMess(string s);

    internal class Student
    {
        private string id;
        private int maths, english;
        public string fullName;

        event DMess EMess;

        public string pId
        {
            get
            {
                return id;
            }
            set
            {
                if (Regex.IsMatch(value, "^ST\\d{3}\\d{0,2}$"))
                {
                    id = value;
                }
                else
                {
                    EMess("Id khong dung dinh dang.");
                }
            }
        }
        public int pMaths
        {
            get
            {
                return maths;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    maths = value;
                }
                else
                {
                    EMess("Nhap diem trong khoan tu 0 den 100");
                }
            }
        }
        public int pEnglish
        {
            get
            {
                return english;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    english = value;
                }
                else
                {
                    EMess("Nhap diem trong khoan tu 0 den 100");
                }
            }
        }

        public float pAvg()
        {
            return (maths + english) / 2;
        }

        public void Display()
        {
            Console.WriteLine($"Id: {id}, Name: {fullName}, Maths: {maths}, English: {english}, Average: {pAvg()}");
        }

        public void VadidProcess(string s)
        {
            throw new FormatException(s);
        }

        //dang ky event
        public Student()
        {
            EMess += new DMess(VadidProcess);
        }
    }
}
