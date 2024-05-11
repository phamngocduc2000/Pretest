using System.Collections;

namespace As9
{



    internal class StudentCollection : IEnumerable<Student>
    {
        List<Student> stList = new List<Student>();

        public void Add()
        {

            Student student = new Student();

            student.pId = Extension.TryToGetInputValue<string>(
                "Nhap id(STxxx[xx]): "
            );

            student.fullName = Extension.TryToGetInputValue<string>(
                "Nhap name: "
            );

            student.pMaths = Extension.TryToGetInputValue<int>(
                "Nhap diem Maths: "
            );

            student.pEnglish = Extension.TryToGetInputValue<int>(
                "Nhap diem English: "
            );

            stList.Add(student);
        }

        public IEnumerable<Student> GetEnumerator()
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



        public IEnumerable<Student> GetEnumerators()
        {
            if (stList.Count == 0)
            {
                Console.WriteLine("Danh sach chua co du lieu.");
                yield break;
            }

            foreach (Student stu in stList)
            {
                if (stu.pAvg >= 40)
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
            if (!flat)
            {
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
            foreach (Student s in stList)
            {
                if (s.pId.ToLower() == id.ToLower())
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


        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return stList;
        }

        IEnumerator<Student> IEnumerable<Student>.GetEnumerator()
        {
            return (IEnumerator<Student>)GetEnumerator().ToList();
        }
    }
}
