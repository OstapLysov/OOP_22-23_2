using System.ComponentModel;

namespace Lab_4
{
    /*
     * Написати програму, що реалізує векторний добуток, заданих як одновимірні масиви.
     * У програмі передбачити два методи:
     * - метод векторного добутку (на вхід два вектори, значення, що повертається – вектор),
     * - метод виводу векторного добутку на екран.
     * Завдання такожвиконати за допомогою колекцій LinkedList<LinkedList<T>>.
    */
    internal class Program
    {
        static void Main(string[] args)
        {

            //LinkedList<double> v1 = new LinkedList<double>(new[] { 1.0, 2.0, 3.0 });
            //LinkedList<double> v2 = new LinkedList<double>(new[] { 6.0, 5.0, 4.0 });
            System.Console.WriteLine($"\nEnter the first vector:");
            var v1 = InputVector();
            System.Console.WriteLine($"\nEnter the second vector:");
            var v2 = InputVector();
            {
                System.Console.WriteLine($"\nFunction with array:");
                var result = CrossProduct(v1.ToArray(), v2.ToArray());
                Console.Write("Cross product of vectors:");
                foreach (var v in result)
                {
                    Console.Write($" {v}");
                }
                Console.WriteLine();
            }
            {
                System.Console.WriteLine($"\nFunction with LinkedList<LinkedList<double>>:");
                var result = CrossProduct(new LinkedList<LinkedList<double>>(new[] { v1, v2 }));
                Console.Write("Cross product of vectors:");
                foreach (var v in result)
                {
                    Console.Write($" {v}");
                }
                Console.WriteLine();
            }
            {
                System.Console.WriteLine($"\nSecond function with LinkedList<LinkedList<double>>:");
                var result = CrossProduct2(new LinkedList<LinkedList<double>>(new[] { v1, v2 }));
                Console.Write("Cross product of vectors:");
                foreach (var v in result)
                {
                    Console.Write($" {v}");
                }
                Console.WriteLine();
            }
        }

        static LinkedList<double> CrossProduct(LinkedList<LinkedList<double>> vectors)
        {
            if (vectors.Count < 2)
            {
                throw new ArgumentException(nameof(vectors));
            }
            var v1 = vectors.First.Value;
            var v2 = vectors.First.Next.Value;
            if (v1.Count != 3 || v2.Count != 3)
            {
                throw new ArgumentException("Vectros must be three-dimentional");
            }
            LinkedList<double> result = new LinkedList<double>();

            result.AddLast(v1.First.Next.Value * v2.Last.Value - v1.Last.Value * v2.First.Next.Value);
            result.AddLast(v1.Last.Value * v2.First.Value - v1.First.Value * v2.Last.Value);
            result.AddLast(v1.First.Value * v2.First.Next.Value - v1.First.Next.Value * v2.First.Value);

            return result;
        }

        static LinkedList<double> CrossProduct2(LinkedList<LinkedList<double>> vectors)
        {
            if (vectors.Count < 2)
            {
                throw new ArgumentException(nameof(vectors));
            }

            var v1 = vectors.First.Value;
            var v2 = vectors.First.Next.Value;

            return new LinkedList<double>(CrossProduct(v1.ToArray(), v2.ToArray()));
        }

        static double[] CrossProduct(double[] vector1, double[] vector2)
        {
            if (vector1.Length != 3 || vector2.Length != 3)
            {
                throw new ArgumentException("Vectros must be three-dimentional");
            }
            double[] result = new double[3];

            result[0] = vector1[1] * vector2[2] - vector1[2] * vector2[1];
            result[1] = vector1[2] * vector2[0] - vector1[0] * vector2[2];
            result[2] = vector1[0] * vector2[1] - vector1[1] * vector2[0];

            return result;
        }

        static LinkedList<double> InputVector()
        {
            LinkedList<double> vector;
            do
            {
                string[] input = Console.ReadLine().Split().Select(s => s.Trim()).ToArray(); ;
                if (input.Length != 3)
                {
                    System.Console.WriteLine("\nIncorrect input, vector must be in the format x y z");
                }
                try
                {
                    vector = new LinkedList<double>(new[] { Double.Parse(input[0]), Double.Parse(input[1]), Double.Parse(input[2]) });
                    return vector;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"\nAn error occurred when trying to process the input: {e.Message}");
                }
                System.Console.WriteLine("\nTry again: ");
            } while (true);
        }
    }
}