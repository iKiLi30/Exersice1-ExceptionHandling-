namespace Exersice1_ExceptionHandling_
{
    internal class Program
    {
        static string[] eTypes = { "none", "simplr", "index", "nested index", "filter" }; //массив строк
        static void Main(string[] args)
        {
            foreach(string eType in eTypes)   //обход массива строк
            {
                try
                {
                    Console.WriteLine("Main() try block reached.");                    
                    Console.WriteLine($"TrowException(\"{eType}\") called");
                    ThrowException(eType);
                    Console.WriteLine("Main() try block countines.");
                }
                catch (System.IndexOutOfRangeException outOfRangeException) when (eType == "filter")  // исключение выхода за рамки массива
                { 
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Main() FILTERED System.IndexOutOfRangeExeption" 
                        + $"catch block reached. Message:\n\"{outOfRangeException.Message}\"");
                }
                catch  {
                    Console.WriteLine("Main() general catch block reached.");
                }
                finally
                {
                    Console.WriteLine("Main() finally block reached.");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void ThrowException(string exeptionType)  // функция содержащая виды исключений
        {
            Console.WriteLine($"ThrowException (\"{exeptionType}\") reached");
            switch (exeptionType)
            {
                case "none": Console.WriteLine("Not throwing an exception.");
                    break;
                case "simple": Console.WriteLine("Throwing System.Exeption.");
                    throw new System.Exception();
                case "index": Console.WriteLine("Throwing System.IndexOfRangeException.");
                    eTypes[5] = "error"; 
                    break;
                case "nested index":
                    try
                    {
                        Console.WriteLine("ThrowException (\"nested index\")" + "try block reached.");
                        Console.WriteLine("ThrowException (\"nested index\") called");
                        ThrowException("index");
                    }
                    catch
                    {
                        Console.WriteLine("ThrowException(\"nested index\") general" + " catch block reached.");
                    }
                    break;
                case "filter":
                    try
                    {
                        Console.WriteLine("ThrowException(\"filter\")" + "try block reached.");
                        Console.WriteLine("ThrowException (\"index\") called");
                        ThrowException("index");
                    }
                    catch
                    {
                        Console.WriteLine("ThrowException(\"filter\") general" + " catch blockreached.");
                        throw;
                    }
                    break;
            }
        }
    }
}
