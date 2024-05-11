namespace As9
{
    internal class TestStudent
    {
        // public void Menu()
        // {
        //     StudentCollection students = new StudentCollection();
        //     int choice = 0;

        //     do
        //     {
        //         Console.WriteLine("================MENU==================");
        //         Console.WriteLine("1.   Add new student.");
        //         Console.WriteLine("2.   Display all students.");
        //         Console.WriteLine("3.   Display passed students.");
        //         Console.WriteLine("4.   Search students by name.");
        //         Console.WriteLine("5.   Remove a student by ID.");
        //         Console.WriteLine("6.   Quit.");
        //         Console.WriteLine("======================================");
        //         Console.WriteLine("Nhap lua chon: ");
        //         choice = int.Parse(Console.ReadLine());

        //         switch (choice)
        //         {
        //             case 1:
        //                 Console.WriteLine("1.   Add new student.");
        //                 students.Add();
        //                 break;
        //             case 2:
        //                 Console.WriteLine("2.   Display all students.");
        //                 students.DisplayAll();
        //                 break;
        //             case 3:
        //                 Console.WriteLine("3.   Display passed students.");
        //                 students.GetEnumerators().ToList().ForEach(x => x.Display());
        //                 break;
        //             case 4:
        //                 Console.WriteLine("4.   Search students by name.");
        //                 Console.Write("Nhap ten can tim: ");
        //                 string nameFind = Console.ReadLine().Trim();
        //                 students.Search(nameFind);
        //                 break;
        //             case 5:
        //                 Console.WriteLine("5.   Remove a student by ID.");
        //                 Console.Write("Nhap id can xoa: ");
        //                 string idFind = Console.ReadLine().Trim();
        //                 students.Remove(idFind);
        //                 break;
        //             case 6:
        //                 Console.WriteLine("6.   Quit.");
        //                 break;
        //             default:
        //                 Console.WriteLine("Nhap sai! Vui long nhap lai");
        //                 break;
        //         }
        //     } while (choice != 6);
        // }


        public void Menu()
        {
            StudentFunctionCollection functions = new();

            StudentCollection students = new StudentCollection();

            functions.Add(
                new StudentFunction()
                {
                    Key = 1,
                    Display = "Add new student.",
                    Action = students.Add
                },
                new StudentFunction()
                {
                    Key = 2,
                    Display = "Display all students.",
                    Action = students.DisplayAll
                },
                new StudentFunction()
                {
                    Key = 3,
                    Display = "Display passed students.",
                    Action = () =>{
                        students.GetEnumerators().ToList().ForEach(x => x.Display());
                    }
                },
                new StudentFunction()
                {
                    Key = 4,
                    Display = "Search students by name.",
                    Action = () =>
                    {
                        Extension.TryToGetInputValue("Nhap ten can tim: ", out string nameFind);
                        students.Search(nameFind);
                    }
                },
                new StudentFunction()
                {
                    Key = 5,
                    Display = "Search students by name.",
                    Action = () =>
                    {
                        Extension.TryToGetInputValue("Nhap id can xoa:", out string idFind);
                        students.Remove(idFind);
                    }
                }
            );

            functions.Show();
        }

    }
}
