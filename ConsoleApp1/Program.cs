namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
                double lowNumber = GetValidNumber("Enter a positive low number: ", number => number > 0);
                double highNumber = GetValidNumber($"Enter a high number greater than {lowNumber}: ", number => number > lowNumber);

                var numbers = Enumerable.Range((int)Math.Ceiling(lowNumber), (int)(highNumber - lowNumber)).Select(n => (double)n).ToList();
                string filePath = "numbers.txt";
                File.WriteAllLines(filePath, numbers.Select(n => n.ToString()));

                var readNumbers = File.ReadAllLines(filePath).Select(double.Parse).ToList();
                Console.WriteLine($"The sum of the numbers is: {readNumbers.Sum()}");

                Console.WriteLine("Prime numbers between low and high:");
                foreach (var number in numbers)
                {
                    if (IsPrime(number))
                    {
                        Console.WriteLine(number);
                    }
                }
            

            static double GetValidNumber(string prompt, Func<double, bool> validation)
            {
                double number;
                do
                {
                    Console.Write(prompt);
                }
                while (!double.TryParse(Console.ReadLine(), out number) || !validation(number));
                return number;
            }

            static bool IsPrime(double number)
            {
                if (number <= 1) return false;
                if (number == 2) return true;
                if (number % 2 == 0) return false;

                var boundary = (int)Math.Floor(Math.Sqrt(number));

                for (int i = 3; i <= boundary; i += 2)
                {
                    if (number % i == 0)
                        return false;
                }

                return true;
            }
        }
    }
}
