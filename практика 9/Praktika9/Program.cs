using System;

namespace Praktika9
{
    public class Program
    {
        public static int f(int x)
        {
            if (x < 10 || x > 99)
            {
                Console.WriteLine("Ошибка! Число должно быть двузначным.");
                return -1;
            }

            int tens = x / 10;
            int units = x % 10;
            return tens + units;
        }

        public static string IsPrime(int number)
        {
            if (number <= 1)
                return "Составное число";

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return "Составное число";
            }
            return "Простое число";
        }

        public static int CalculateInternetCost(int A, int B, int C, int D)
        {
            if (D <= B)
                return A;
            else
                return A + (D - B) * C;
        }

        static void Main(string[] args)
        {

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nВыберите задание:");
                Console.WriteLine("1 - Сумма цифр двузначного числа");
                Console.WriteLine("2 - Проверка на простое число");
                Console.WriteLine("3 - Расчет оплаты за интернет");
                Console.WriteLine("0 - Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunTask1();
                        break;
                    case "2":
                        RunTask2();
                        break;
                    case "3":
                        RunTask3();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор! Попробуйте снова.");
                        break;
                }
            }

            Console.WriteLine("Программа завершена. До свидания!");
        }

        static void RunTask1()
        {
            Console.WriteLine("\n ЗАДАНИЕ 1: Сумма цифр двузначного числа");
            Console.Write("Введите двузначное число: ");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                int result = f(number);
                if (result != -1)
                {
                    Console.WriteLine($"Число: {number}");
                    Console.WriteLine($"Десятки: {number / 10}");
                    Console.WriteLine($"Единицы: {number % 10}");
                    Console.WriteLine($"Сумма цифр: {result}");
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Введите корректное число.");
            }
        }

        static void RunTask2()
        {
            Console.WriteLine("\nЗАДАНИЕ 2: Проверка на простое число");
            Console.Write("Введите натуральное число (>1): ");

            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
            {
                string result = IsPrime(number);
                Console.WriteLine($"Число {number} - {result}");
            }
            else
            {
                Console.WriteLine("Ошибка! Введите натуральное число больше 0.");
            }
        }

        static void RunTask3()
        {
            Console.WriteLine("\n ЗАДАНИЕ 3: Расчет оплаты за интернет");

            try
            {
                Console.Write("Введите абонентскую плату (A): ");
                int A = int.Parse(Console.ReadLine());
                Console.Write("Введите включенные мегабайты (B): ");
                int B = int.Parse(Console.ReadLine());

                Console.Write("Введите стоимость доп. мегабайта (C): ");
                int C = int.Parse(Console.ReadLine());

                Console.Write("Введите израсходованные мегабайты (D): ");
                int D = int.Parse(Console.ReadLine());

                // Проверка на превышение 100
                if (A > 100 || B > 100 || C > 100 || D > 100)
                {
                    Console.WriteLine("Ошибка! Все числа не должны превышать 100.");
                    return;
                }

                int cost = CalculateInternetCost(A, B, C, D);

                Console.WriteLine("\nРАСЧЕТ ОПЛАТЫ ");
                Console.WriteLine($"Абонентская плата: {A} руб.");
                Console.WriteLine($"Включено мегабайт: {B} МБ");
                Console.WriteLine($"Израсходовано: {D} МБ");

                if (D <= B)
                {
                    Console.WriteLine($"Итоговая стоимость: {cost} руб. (трафик в пределах пакета)");
                }
                else
                {
                    int extraMB = D - B;
                    int extraCost = extraMB * C;
                    Console.WriteLine($"Сверх лимита: {extraMB} МБ");
                    Console.WriteLine($"Доплата за сверхлимит: {extraCost} руб.");
                    Console.WriteLine($"Итоговая стоимость: {cost} руб.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}");
            }
        }
    }
}