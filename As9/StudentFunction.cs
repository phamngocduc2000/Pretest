namespace As9;

public enum StudentActionEnum
{
    None,
    Add,
    DisplayAll,
    DisplayPassed,
    SearchByName,
    DeleteById,
    Exit
}

public class StudentFunction
{
    public StudentActionEnum Key { get; set; }

    public string Display { get; set; }

    public Action Action;
}

public class StudentFunctionCollection
{
    private IList<StudentFunction> _functions = [];

    public void Add(StudentFunction function)
    {
        if (_functions.Any(x => x.Key == function.Key))
            throw new InvalidDataException($"function key = {function.Key} already existed.");
        _functions.Add(function);
    }

    public void Add(params StudentFunction[] functions)
    {
        foreach (var fn in functions)
        {
            Add(fn);
        }
    }

    public void Show()
    {
        StudentActionEnum choice = StudentActionEnum.None;
        int fnCount = _functions.Count;

        void DisplayFunctions()
        {
            Console.WriteLine("================MENU==================");
            foreach (var fn in _functions)
            {
                Console.WriteLine($"{(int)fn.Key}. {fn.Display}");
            }
            
            if(!_functions.Any(x => x.Key ==StudentActionEnum.Exit))
                Console.WriteLine($"{(int)StudentActionEnum.Exit}. Quit.");

            Console.WriteLine("======================================");
        }

        while (true)
        {

            DisplayFunctions();
            Extension.TryToGetInputValue(
                "Nhap lua chon:",
                out int _input,
                () =>
                {
                    Console.Clear();
                    DisplayFunctions();
                }
            );

            choice = (StudentActionEnum)_input;

            var function = _functions.FirstOrDefault(
                x => x.Key == choice
            );

            if (choice == StudentActionEnum.Exit)
            {
                if (function is not null)
                {
                    function.Action();
                    return;
                }
                Console.WriteLine("----Exit----");
                return;
            }

            if (function is null)
            {
                Console.WriteLine("Khong tim thay chuc nang, vui long nhap lai!");
                continue;
            }
            Console.WriteLine($"{function.Key}.{function.Display}");
            function.Action();
        }
    }

}