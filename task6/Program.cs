// Напишіть консольну програму, яка дозволяє користувачеві зареєструватися під «Логіном», що складається тільки з символів латинського алфавіту, і пароля, що складається з цифр і символів.

using System;

namespace task6;

class Program
{
    static void Main()
    {
        string patternLog = "^[a-zA-Z]+$";
        string patternPass = "^[0-9!@#$%^&*()_+=\\[\\]{};':\"\\\\|,.<>\\/?-]+$";

        Console.WriteLine("Введіть логін (тільки латинські символи):");
        string login = Console.ReadLine();

        while (!System.Text.RegularExpressions.Regex.IsMatch(login, patternLog))
        {
            Console.WriteLine("Невірний логін. Введіть логін (тільки латинські символи):");
            login = Console.ReadLine();
        }

        Console.WriteLine("Введіть пароль (тільки цифри та символи):");

        string password = Console.ReadLine();

        while (!System.Text.RegularExpressions.Regex.IsMatch(password, patternPass))
        {
            Console.WriteLine("Невірний пароль. Введіть пароль (тільки цифри та символи):");
            password = Console.ReadLine();
        }

        Console.WriteLine("Реєстрація успішна!");
        
    }
}