using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As9
{
    internal class StudentCollection : IEnumerable<Student>
    {
        List<Student> stList = new List<Student>();

        public void Add()
        {
            Student student = new Student();
            while (true)
            {
                try
                {
                    Console.Write("Nhap id(STxxx[xx]): ");
                    student.pId = Console.ReadLine().Trim();
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.Write("Nhap Name: ");
            student.fullName = Console.ReadLine().Trim();

            while (true)
            {
                try
                {
                    Console.Write("Nhap diem Maths: ");
                    student.pMaths = int.Parse(Console.ReadLine().Trim());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Nhap diem English: ");
                    student.pEnglish = int.Parse(Console.ReadLine().Trim());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            stList.Add(student);
        }

        public IEnumerator<Student> GetEnumerator()
        {
            if (stList.Count == 0)
            {
                Console.WriteLine("Danh sach chua co du lieu.");
                yield break;
            }

            foreach (Student stu in stList)
            {
                yield return stu;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetEnumerators()
        {
            if (stList.Count == 0)
            {
                Console.WriteLine("Danh sach chua co du lieu.");
                yield break;
            }

            foreach (Student stu in stList)
            {
                if (stu.pAvg() >= 40)
                {
                    yield return stu;
                }
            }
        }

        public void Search(string name)
        {
            bool flat = false;
            if (stList.Count == 0)
            {
                Console.WriteLine("Danh sach chua co du lieu.");
                return;
            }

            foreach (Student s in stList)
            {
                if (s.fullName.ToLower() == name.ToLower())
                {
                    s.Display();
                    flat = true;
                }
            }
            if (!flat) {
                Console.WriteLine("Ten can tim khong ton tai trong danh sach.");
            }
        }

        public void Remove(string id)
        {
            if (stList.Count == 0)
            {
                Console.WriteLine("Danh sach chua co du lieu.");
                return;
            }
            foreach(Student s in stList)
            {
                if(s.pId.ToLower() == id.ToLower())
                {
                    stList.Remove(s);
                    Console.WriteLine("Da xoa thanh cong.");
                    return;
                }
            }
            Console.WriteLine("ID can xoa khong ton tai.");
        }

        public void DisplayAll()
        {
            foreach (var student in stList)
            {
                student.Display();
            }
        }
    }
}
