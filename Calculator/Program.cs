class Calculator
{
    public static void Main()
    {
        while (true)
        {
            DisplayMenu();
        }
    }

    private static void DisplayMenu()
    {
        Console.Title = "Calculator";
        Console.Clear();
        Operations();
        Console.Write("\nYapmak istediğiniz işlemin numarasını giriniz (1-18) : ");
        if (short.TryParse(Console.ReadLine(), out short act))
        {
            string result = act switch
            {
                1 => PerformBasicMath("Addition", (a, b) => a + b),
                2 => PerformBasicMath("Substraction", (a, b) => a - b),
                3 => PerformBasicMath("Multiplication", (a, b) => a * b),
                4 => PerformBasicMath("Division", (a, b) => a / b),
                5 => PerformBasicMath("Modulus", (a, b) => a % b),
                6 => Exponentiation((a, b) => Math.Pow(a, b)),
                7 => Root((a, b) => Math.Pow(a, 1.0 / b)),
                _ => Message(ConsoleColor.DarkYellow, "Yapmak istediğiniz işleme ait numara geçersizdir!")
            };
            Console.WriteLine(result);
            Continue();
        }
        else
        {
            Message(ConsoleColor.DarkYellow, "\nGeçersiz bir işlem yaptınız!");
            Continue();
        }
    }

    private static void Operations()
    {
        Op(ConsoleColor.DarkCyan, " 1. ", ConsoleColor.White, "Toplama");
        Op(ConsoleColor.DarkCyan, " 2. ", ConsoleColor.White, "Çıkarma");
        Op(ConsoleColor.DarkCyan, " 3. ", ConsoleColor.White, "Çarpma");
        Op(ConsoleColor.DarkCyan, " 4. ", ConsoleColor.White, "Bölme");
        Op(ConsoleColor.DarkCyan, " 5. ", ConsoleColor.White, "Mod alma");
        Op(ConsoleColor.DarkCyan, " 6. ", ConsoleColor.White, "Üs alma");
        Op(ConsoleColor.DarkCyan, " 7. ", ConsoleColor.White, "Kök alma");
        Op(ConsoleColor.DarkCyan, " 8. ", ConsoleColor.White, "Faktöriyel");
        Op(ConsoleColor.DarkCyan, " 9. ", ConsoleColor.White, "Logaritma");
        Op(ConsoleColor.DarkCyan, "10. ", ConsoleColor.White, "Sinüs");
        Op(ConsoleColor.DarkCyan, "11. ", ConsoleColor.White, "Kosinüs");
        Op(ConsoleColor.DarkCyan, "12. ", ConsoleColor.White, "Tanjant");
        Op(ConsoleColor.DarkCyan, "13. ", ConsoleColor.White, "Kotanjant");
        Op(ConsoleColor.DarkCyan, "14. ", ConsoleColor.White, "M+");
        Op(ConsoleColor.DarkCyan, "15. ", ConsoleColor.White, "M-");
        Op(ConsoleColor.DarkCyan, "16. ", ConsoleColor.White, "MR");
        Op(ConsoleColor.DarkCyan, "17. ", ConsoleColor.White, "MC");
        Op(ConsoleColor.DarkCyan, "18. ", ConsoleColor.White, "Exit");
    }
    private static string Exponentiation(Func<double, double, double> operation)
    {
        Console.Clear();
        if (!InputHandler("Taban sayıyı giriniz : ", out double a))
            return Message(ConsoleColor.DarkYellow, "Lütfen geçerli bir sayı giriniz!");
        if (!InputHandler("Kuvveti giriniz : ", out double b))
            return Message(ConsoleColor.DarkYellow, "Lütfen geçerli bir sayı giriniz!");

        double result = operation(a, b);

        return $"\nSonuç : {result}";
    }

    private static string PerformBasicMath(string opName, Func<double, double, double> operation)
    {
        Console.Clear();
        if (!InputHandler("Birinci sayıyı giriniz : ", out double a))
            return Message(ConsoleColor.DarkYellow, "Lütfen geçerli bir sayı giriniz!");
        if (!InputHandler("İkinci sayıyı giriniz : ", out double b))
            return Message(ConsoleColor.DarkYellow, "Lütfen geçerli bir sayı giriniz!");

        if (opName == "Division" && a == 0 && b == 0)
            return Message(ConsoleColor.DarkRed, "TANIMSIZ!");
        if (opName == "Division" && b == 0)
            return Message(ConsoleColor.Red, "Sıfıra bölme hatası: Bölen 0 olamaz!");

        double result = operation(a, b);

        if (double.IsNaN(result) || double.IsInfinity(result))
            return Message(ConsoleColor.Red, "Geçersiz matematiksel işlem!");

        return $"\nSonuç : {result}";
    }

    private static string Root(Func<double, double, double> operation)
    {
        Console.Clear();
        try
        {
            if (!InputHandler("Kök içini giriniz : ", out double a)) return Message(ConsoleColor.DarkYellow, "Lütfen geçerli bir sayı giriniz!");
            if (!InputHandler("Kök derecesini giriniz : ", out double b)) return Message(ConsoleColor.DarkYellow, "Lütfen geçerli bir sayı giriniz!");

            double result = operation(a, b);

            result = Math.Round(result);

            if (double.IsNaN(result) || double.IsInfinity(result)) return $"\nBilinmeyen bir hata oluştu!";

            return $"Sonuç : {result}";
        }
        catch (Exception ex)
        {
            return $"Bilinmeyen bir hata : {ex.Message}";
        }
    }

    private static void Continue()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nDevam etmek için herhangi bir tuşa basınız");
        Console.ReadKey();
        Console.CursorVisible = true;
    }

    private static bool InputHandler(string prompt, out double result)
    {
        Console.Write(prompt);
        return double.TryParse(Console.ReadLine(), out result);
    }

    private static void Op(ConsoleColor color1, string message1, ConsoleColor color2, string message2)
    {
        Console.ForegroundColor = color1;
        Console.Write(message1);
        Console.ForegroundColor = color2;
        Console.WriteLine(message2);
    }

    private static string Message(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;
        return $"\n{message}";
    }
}