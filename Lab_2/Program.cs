using System.Text;

namespace Lab_2
{
    static internal class Program
    {
        static void Main(string[] args)
        {
            string separator = new string('=', 100);
            Action[] tasks = new Action[] { () => Task1_1(), () => Task1_2(),
                                            () => Task2_1(), () => Task2_2(), () => Task2_3() };
            foreach (var task in tasks)
            {
                char c;
                do
                {
                    task.Invoke();
                    Console.WriteLine(separator);
                    ClearInput();
                    Console.WriteLine("Press R to repeat");
                    c = Console.ReadKey().KeyChar;
                } while (c == 'r');
                Console.WriteLine(separator);
            }
        }
        static void ClearInput()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
        }
        static void Task1_1()
        {
            //Дано n дійсних чисел: x₁, x₂, ... xₙ. Знайти найменше серед додатних.
            System.Console.WriteLine("\nTask 1.1: Find the smallest positive number in the array.\n");
            double[] arr;
            do
            {
                try
                {
                    System.Console.Write("Enter the array: ");
                    arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToDouble);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Input error: {e.Message}");
                    continue;
                }
            } while (true);
            System.Console.WriteLine($"\nResult: {GetLeastPositive(arr)}\n");
        }
        static double GetLeastPositive(double[] arr)
        {
            double result = Double.MaxValue;
            foreach (double val in arr)
            {
                if (val > 0)
                {
                    result = val < result ? val : result;
                }
            }
            return result;
        }
        static void Task1_2()
        {
            //Дано два вектори x,y ∈ Rⁿ .З’ясувати, чи паралельні вони.
            System.Console.WriteLine("\nTask 1.2: Check if the vectors are collinear.\n");
            double[] x, y;
            do
            {
                try
                {
                    System.Console.Write("Enter the firs vector: ");
                    x = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToDouble);
                    System.Console.Write("Enter the second vector: ");
                    y = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToDouble);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Input error: {e.Message}");
                    continue;
                }
            } while (true);
            System.Console.WriteLine($"\nResult: {CheckIfCollinear(x, y)}\n");
        }
        static bool CheckIfCollinear(double[] v1, double[] v2)
        {
            if (v1.Length != v2.Length)
            {
                if (v1.Length > v2.Length)
                {
                    double[] tmp = v2;
                    v2 = v1;
                    v1 = tmp;
                }
                for (int i = v1.Length; i < v2.Length; i++)
                {
                    if (v2[i] != 0) return false;
                }
            }
            if (v1.Length == 0)
            {
                return false;
            }
            double prevRatio = Double.NegativeInfinity;
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] == 0 || v2[i] == 0)
                {
                    if (v1[i] != v2[i])
                    {
                        return false;
                    }
                    else continue;
                }
                double ratio = v1[i] / v2[i];
                if (prevRatio == Double.NegativeInfinity)
                {
                    prevRatio = ratio;
                }
                if (ratio != prevRatio)
                {
                    return false;
                }
            }
            return true;
        }
        static void Task1_3()
        {
            //Перетворити масив таким чином, щоб спочатку розміщувались всі елементи рівні 0, а потім всі інші.
            System.Console.WriteLine("\nTask 1.3: Move all zeros to the start of the array.\n");
            double[] arr;
            do
            {
                try
                {
                    System.Console.Write("Enter the array: ");
                    arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToDouble);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Input error: {e.Message}");
                    continue;
                }
            } while (true);
            MoveZeroesToStart(arr);
            System.Console.WriteLine($"\nResult: {String.Join(", ", arr)}\n");
        }
        static void MoveZeroesToStart(double[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    Array.Copy(arr, count, arr, count + 1, i - count);
                    arr[count++] = 0;
                }
            }
        }
        static void Task2_1()
        {
            //Дана цілочислова квадратна матриця.
            //Розмістити елементи непарних рядків у порядку спадання.
            System.Console.WriteLine("\nTask 2.1: Arrange the elements of the odd rows of an integer square matrix in descending order.\n");
            int[][] sqMatrix;
            int size;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            const int maxValue = 100;
            do
            {
                try
                {
                    System.Console.Write("Enter the matrix size: ");
                    size = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Input error: {e.Message}");
                    continue;
                }
            } while (true);
            sqMatrix = Enumerable.Range(0, size).Select(s => Enumerable.Range(0, size).Select(s => rnd.Next(maxValue) * 2 - maxValue).ToArray()).ToArray();
            System.Console.WriteLine($"\nInput matrix:\n{ToString(sqMatrix)}\n");
            SortOddRows(sqMatrix);
            System.Console.WriteLine($"\nResult:\n{ToString(sqMatrix)}\n");
        }
        static void SortOddRows(int[][] arr)
        {
            for (int i = 1; i < arr.Length; i += 2)
            {
                Quicksort(arr[i]);
                Array.Reverse(arr[i]);
            }
        }
        static int Partition<T>(T[] arr, int start, int end)
        where T : IComparable<T>
        {
            int marker = start;
            for (int i = start; i < end; i++)
            {
                if (arr[i].CompareTo(arr[end]) <= 0)
                {
                    (arr[marker], arr[i]) = (arr[i], arr[marker]);
                    marker++;
                }
            }
            (arr[marker], arr[end]) = (arr[end], arr[marker]);
            return marker;
        }
        static void Quicksort<T>(T[] arr, int start, int end) where T : IComparable<T>
        {
            if (start >= end) return;
            int p = Partition(arr, start, end);
            Quicksort(arr, start, p - 1);
            Quicksort(arr, p + 1, end);
        }
        static void Quicksort<T>(T[] arr) where T : IComparable<T>
        {
            int start = 0, end = arr.Length - 1;
            if (start >= end) return;
            int p = Partition(arr, start, end);
            Quicksort(arr, start, p - 1);
            Quicksort(arr, p + 1, end);
        }
        static string ToString<T>(T[][] arr)
        {
            if (arr.Length == 0 || arr[0].Length == 0) return "";
            StringBuilder sb = new StringBuilder("\t");
            sb.Append(String.Join('\t', Enumerable.Range(0, arr[0].Length).Select(n => $"[{n}]")).ToArray());
            sb.Append('\n');
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append($"[{i}]\t");
                sb.Append(String.Join("\t", arr[i]));
                sb.Append('\n');
            }
            return sb.ToString();
        }
        static void Task2_2()
        {
            //Дана цілочислова прямокутна матриця.
            //Визначити суму елементів в тих стовпцях, які містять хоча б один від’ємний елемент.

            System.Console.WriteLine("\nTask 2.2: Find a sum of elements of the matrix columns that contain at least one negative element.\n");
            int[][] matrix;
            int x, y;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            const int maxValue = 100;
            do
            {
                try
                {
                    System.Console.Write("Enter the matrix dimension: ");
                    int[] dims = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);
                    if (dims.Length != 2)
                    {
                        Console.WriteLine("Input error: You have to enter two numbers");
                        continue;
                    }
                    x = dims[0];
                    y = dims[1];
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Input error: {e.Message}");
                    continue;
                }
            } while (true);
            matrix = Enumerable.Range(0, x).Select(s => Enumerable.Range(0, y).Select(s => rnd.Next(maxValue) * 2 - maxValue).ToArray()).ToArray();
            System.Console.WriteLine($"\nInput matrix:\n{ToString(matrix)}\n");
            SortOddRows(matrix);
            System.Console.WriteLine($"\nResult: {String.Join(", ", FindSumForTask2_2(matrix))}\n");

        }
        static int[] FindSumForTask2_2(int[][] arr)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < arr[0].Length; i++)
            {
                int sum = 0;
                bool flag = false;
                for (int j = 0; j < arr.Length; j++)
                {
                    sum += arr[j][i];
                    if (arr[j][i] < 0)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    result.Add(sum);
                }
            }
            return result.ToArray();
        }
        static void Task2_3()
        {
            //Дана цілочислова прямокутна матриця.
            //Визначити номера рядків і стовпців всіх сідлових точок матриці.

            System.Console.WriteLine("\nTask 2.3: Find a saddle points of the matrix.\n");
            int[][] matrix;
            int x, y;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            const int maxValue = 10;
            do
            {
                try
                {
                    System.Console.Write("Enter the matrix dimension: ");
                    int[] dims = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);
                    if(dims.Length != 2)
                    {
                        Console.WriteLine("Input error: You have to enter two numbers");
                        continue;
                    }
                    x = dims[0];
                    y = dims[1];
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Input error: {e.Message}");
                    continue;
                }
            } while (true);
            (int, int)[] result;
            do
            {
                matrix = Enumerable.Range(0, x).Select(s => Enumerable.Range(0, y).Select(s => rnd.Next(maxValue)).ToArray()).ToArray();
                result = FindSaddlePints(matrix);
            } while (result.Length == 0);
            System.Console.WriteLine($"\nInput matrix:\n{ToString(matrix)}\n");
            System.Console.WriteLine("\nResult:");
            if (result.Length == 0)
            {
                System.Console.WriteLine("There are no saddle points");
            }
            else
            {
                foreach ((int n, int m) in result)
                {
                    System.Console.WriteLine($"A[{n}][{m}] = {matrix[n][m]};");
                }
            }
        }
        /*static void test()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 2, 3, 5, 2 };
            matrix[1] = new int[] { 2, 4, 6, 2 };
            matrix[2] = new int[] { -2, 7, 2, 0 };

            (int, int)[] result = FindSaddlePints(matrix);
            System.Console.WriteLine($"\nInput matrix:\n{ToString(matrix)}\n");
            System.Console.WriteLine("\nResult:");
            if (result.Length == 0)
            {
                System.Console.WriteLine("There are no saddle points");
            }
            else
            {
                foreach ((int n, int m) in result)
                {
                    System.Console.WriteLine($"A[{n}][{m}] = {matrix[n][m]};");
                }
            }
        }
        */
        static (int, int)[] FindSaddlePints(int[][] arr)
        {
            //Матриця А має сідлову точку Аₙₘ, якщо A є мінімальним елементом в рядку n і максимальним в стовпці m.
            List<(int n, int m)> result = new List<(int n, int m)>();
            List<int>[] minCols = new List<int>[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                minCols[i] = new List<int> { 0 };
                for (int j = 1; j < arr[i].Length; j++)
                {
                    if (arr[i][j] < arr[i][minCols[i][0]])
                    {
                        minCols[i].Clear();
                        minCols[i].Add(j);
                    }
                    else if (arr[i][j] == arr[i][minCols[i][0]])
                    {
                        minCols[i].Add(j);
                    }
                }
            }
            for (int i = 0; i < arr[0].Length; i++)
            {
                List<int> maxRows = new List<int> { 0 };
                for (int j = 1; j < arr.Length; j++)
                {
                    if (arr[j][i] > arr[maxRows[0]][i])
                    {
                        maxRows.Clear();
                        maxRows.Add(j);
                    }
                    else if (arr[j][i] == arr[maxRows[0]][i])
                    {
                        maxRows.Add(j);
                    }
                }
                foreach (int maxRow in maxRows)
                {
                    if (minCols[maxRow].Contains(i))
                    {
                        result.Add((maxRow, i));
                    }
                }
            }
            return result.ToArray();
        }
    }
}