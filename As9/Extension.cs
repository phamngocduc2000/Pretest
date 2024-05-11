namespace As9;

public static class Extension
{
    public static T? TryToGetInputValue<T>(string message, Action? fallback = null) 
    {
        while (true)
        {
            try
            {
                if (!string.IsNullOrEmpty(message))
                    Console.WriteLine(message);

                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                    throw new ArgumentNullException(nameof(input));

                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch
            {
                if(fallback is not null){
                    fallback();
                    return default;
                }
                Console.WriteLine("Nhap lai:");
            }
        }
    }

    public static void TryToGetInputValue<T>(string message, out T item,  Action? fallback = null)
    {
        item = TryToGetInputValue<T>(message, fallback)!;
    }
}
