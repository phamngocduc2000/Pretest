using System.Text.RegularExpressions;

namespace As9
{
    internal delegate void DMess(string msg);

    internal class Student
    {
        private string _id;
        private int maths, english;
        public string fullName;

        event DMess EMess;


        public string pId
        {
            get
            {
                return _id;
            }
            set
            {
                if (Regex.IsMatch(value, "^ST\\d{3}\\d{0,2}$"))
                {
                    _id = value;
                }
                else
                {
                    EMess("Id khong dung dinh dang.");
                }
            }
        }

        public int pMaths
        {
            set
            {
                if (value < 0 || value > 100)
                    EMess("Value must greater than 0 and less than 100");
                maths = value;
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

        public float pAvg => (maths + english) / 2;

        public void Display()
        {
            Console.WriteLine($"Id: {_id}\n Name: {fullName}, Maths: {maths}, English: {english}, Average: {pAvg}");
        }

        public void VadidProcess(string msg)
        {
            throw new ArgumentOutOfRangeException(msg);
        }

        //dang ky event
        public Student()
        {
            EMess += new DMess(VadidProcess);
        }
    }
}
