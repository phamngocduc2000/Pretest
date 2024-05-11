namespace As9;

public class StudentFunction
{
    public int Key { get; set; }

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
        int choice = 0;
        int fnCount = _functions.Count;

        void DisplayFunctions()
        {
            Console.WriteLine("================MENU==================");
            foreach (var fn in _functions)
            {
                Console.WriteLine($"{fn.Key}.{fn.Display}");
            }
            Console.WriteLine($"{fnCount + 1}.Quit.");
            Console.WriteLine("======================================");
        }

        while (choice != fnCount + 1)
        {

            DisplayFunctions();
            Extension.TryToGetInputValue(
                "Nhap lua chon:", 
                out choice, () =>{
                    Console.Clear();
                    DisplayFunctions();
                }
            );

            if (choice == (fnCount + 1))
            {
                Console.WriteLine("----Exit----");
                return;
            }

            var function = _functions.FirstOrDefault(
                x => x.Key == choice
            );

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