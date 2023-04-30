//Створити клас, що містить методи додавання, віднімання, множення та ділення раціональних дробів
//та такі ж методи для роботи з комплексними числами.
//Для випадку раціональних дробів та випадку комплексних чисел передбачити відповідні інтерфейси.
namespace Lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction f1, f2;
            Complex c1, c2;
            do
            {

                System.Console.WriteLine($"\nEnter the first fraction:");
                f1 = InputFraction();
                System.Console.WriteLine($"\nEnter the second fraction:");
                f2 = InputFraction();

                System.Console.WriteLine($"\n{f1} + {f2} = {Calculator.Add<Fraction>(f1, f2)}");
                System.Console.WriteLine($"{f1} - {f2} = {Calculator.Subtract<Fraction>(f1, f2)}");
                System.Console.WriteLine($"{f1} * {f2} = {Calculator.Multiply<Fraction>(f1, f2)}");
                try
                {
                    System.Console.WriteLine($"{f1} : {f2} = {Calculator.Divide<Fraction>(f1, f2)}");
                }
                catch ( Exception e )
                {
                    System.Console.WriteLine($"{f1} : {f2}: {e.Message}");

                }

                System.Console.WriteLine($"\nEnter the first complex number:");
                c1 = InputComplex();
                System.Console.WriteLine($"\nEnter the second complex number:");
                c2 = InputComplex();

                System.Console.WriteLine($"\n{c1} + {c2} = {Calculator.Add<Complex>(c1, c2)}");
                System.Console.WriteLine($"{c1} - {c2} = {Calculator.Subtract<Complex>(c1, c2)}");
                System.Console.WriteLine($"{c1} * {c2} = {Calculator.Multiply<Complex>(c1, c2)}");
                try
                {
                    System.Console.WriteLine($"{c1} : {c2} = {Calculator.Divide<Complex>(c1, c2)}");
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"{c1} : {c2}: {e.Message}");

                }
            } while (true);
        }

        static Fraction InputFraction()
        {
            Fraction fraction;
            do
            {
                string[] input = Console.ReadLine().Split("/").Select(s => s.Trim()).ToArray(); ;
                if (input.Length != 2)
                {
                    System.Console.WriteLine("\nIncorrect input, fraction must be in the format x/y");
                    System.Console.WriteLine("\nTry again");
                    continue;
                }
                try
                {
                    fraction = new(Int32.Parse(input[0]), Int32.Parse(input[1]));
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"\nAn error occurred when trying to parse the input: {e.Message}");
                    System.Console.WriteLine("\nTry again:");
                    continue;
                }
                break;
            } while (true);
            return fraction;
        }
        static Complex InputComplex()
        {
            Complex complex;
            do
            {
                string[] input = Console.ReadLine().Split("+").Select(s => s.Trim()).ToArray();
                if (input.Length != 2 || input[1].LastIndexOf('i') != input[1].Length - 1)
                {
                    System.Console.WriteLine("\nIncorrect input, complex number must be in the format a+bi");
                    System.Console.WriteLine("\nTry again");
                    continue;
                }
                try
                {
                    complex = new(Double.Parse(input[0]), Double.Parse(input[1].Remove(input[1].Length - 1)));
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"\nAn error occurred when trying to parse the input: {e.Message}");
                    System.Console.WriteLine("\nTry again:");
                    continue;
                }
                break;
            } while (true);
            return complex;
        }
    }
}