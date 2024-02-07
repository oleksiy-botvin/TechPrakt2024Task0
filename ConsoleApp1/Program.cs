using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {

        public const ConsoleColor defTextColor = ConsoleColor.White;
        public const ConsoleColor errorColor = ConsoleColor.Red;
        public const ConsoleColor successColor = ConsoleColor.Green;
        public const ConsoleColor hintColor = ConsoleColor.Yellow;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.Title = "Технологічна практика Git. Завдання 1.5";
            Console.ForegroundColor = defTextColor;

            printTitle("сума двох чисел", 60, hintColor);

            int first = inputInt("перше число");
            int second = inputInt("друге число");

            writeLine($"\n{first} + {second} = {first + second}", successColor);

            Console.ReadKey();
        }

        private static int inputInt(string name, int min = int.MinValue, int max = int.MaxValue)
        {
            writeLine($"Вкажіть {name} та натисніть Enter");

            string value = Console.ReadLine();

            if (string.IsNullOrEmpty(value))
            {
                writeLine($"\nЗначення не може бути порожнім. Будь ласка, повторіть спробу!!!", errorColor);
                return inputInt(name, min, max);
            }

            try
            {
                int n = int.Parse(value);

                if (n < min) writeLine($"\nЗначення не може бути меншим за {min}. Будь ласка, повторіть спробу!!!", errorColor);
                else if (n > max) writeLine($"\nЗначення не може бути білшим за {max}. Будь ласка, повторіть спробу!!!", errorColor);
                else return n;

                return inputInt(name, min, max);
            }
            catch (Exception e)
            {
                writeLine();
                writeLine(
                    (e is System.FormatException ? "Помилка формату введення занчення" : "Сталася невідома помилка") +
                        ". Будь ласка, повторіть спробу!!!",
                    errorColor
                );
                return inputInt(name, min, max);
            }
        }

        private static void printTitle(string name, int spaseLenght, ConsoleColor color = defTextColor)
        {
            string it = $"----------{name}";
            for (int i = it.Length; i < spaseLenght; i++) it += "-";
            writeLine();
            writeLine(it, color);
            writeLine();
        }

        private static void writeLine(string value = "", ConsoleColor color = defTextColor) => write($"{value}\n", color);

        private static void write(string value = "", ConsoleColor color = defTextColor)
        {
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = defTextColor;
        }
    }
}
