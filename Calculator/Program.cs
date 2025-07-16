using System.Linq.Expressions;

internal class Calculator
{
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Operation(ConsoleColor.DarkRed, "1. ", "TOPLAMA");
            Operation(ConsoleColor.DarkRed, "2. ", "ÇIKARMA");
            Operation(ConsoleColor.DarkRed, "3. ", "ÇARPMA");
            Operation(ConsoleColor.DarkRed, "4. ", "BÖLME");
            Operation(ConsoleColor.DarkRed, "5. ", "ÜS ALMA");
            Operation(ConsoleColor.DarkRed, "6. ", "KÖK");
            Operation(ConsoleColor.DarkRed, "7. ", "MOD ALMA");
            Operation(ConsoleColor.DarkRed, "8. ", "FAKTÖRİYEL");

            Console.Write("\nYapmak istediğiniz işlemin numarasını seçiniz : ");
            if (short.TryParse(Console.ReadLine(), out short act))
            {
                Console.Clear();
                string result = act switch
                {
                    1 => PerformBasicOperation((a, b) => a + b),
                    2 => PerformBasicOperation((a, b) => a - b),
                    3 => PerformBasicOperation((a, b) => a * b),
                    4 => PerformBasicOperation((a, b) => a / b),
                    5 => Exponentiation((a, b) => Math.Pow(a, b)),
                    6 => Root((a, b) => Math.Pow(a, 1.0 / b)),
                    7 => Modulus((a, b) => a % b),
                    8 => Factorial(),
                    _ => "Geçersiz bir işlem yaptınız, lütfen tekrar deneyiniz"
                };
                Console.WriteLine(result);
                Continue();
            }
            else
            {

            }
        }
    }
    private static void Continue()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nDevam etmek için bir tuşa basınız");
        Console.ReadKey();
        Console.CursorVisible = true;
    }
    private static string Error()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        return "Geçersiz bir işlem yaptınız! lütfen tekrar deneyiniz";
    }
    private static string Exponentiation(Func<double, double, double> operation)
    {
        if (!TryReadDouble("Taban sayıyı giriniz : ", out double a)) return Error();
        if (!TryReadDouble("Kuvvet derecesini giriniz : ", out double b)) return Error();

        double result = operation(a, b);

        if (a == 0 && b == 0) return "\nTANIMSIZ";

        return $"\nİşlemin sonucu : {result}";
    }
    private static string Factorial()
    {
        if (!TryReadDouble("Faktöriyelini öğrenmek istediğiniz sayıyı giriniz : ", out double a)) return Error();

        if (a < 0 || a != Math.Floor(a))
            return "\nNegatif veya ondalıklı sayıların faktöriyeli tanımsızdır!";

        double result = 1;
        for (int i = 2; i <= (int)a; i++)
        {
            result *= i;
        }

        return $"\n{a}! = {result}";


    }
    private static string Modulus(Func<double, double, double> operation)
    {
        if (!TryReadDouble("Bölünen sayıyı giriniz : ", out double a)) return Error();
        if (!TryReadDouble("Modu giriniz : ", out double b)) return Error();

        double result = operation(a, b);

        return $"\nİşlemin sonucu {result}";
    }
    private static void Operation(ConsoleColor color, string message1, string message2)
    {
        Console.ForegroundColor = color;
        Console.Write(message1);
        Console.ResetColor();
        Console.WriteLine(message2);

    }
    private static string PerformBasicOperation(Func<double, double, double> operation)
    {
        if (!TryReadDouble("Birinci sayıyı giriniz: ", out double a)) return Error();
        if (!TryReadDouble("İkinci sayıyı giriniz: ", out double b)) return Error();

        double result = operation(a, b);

        if (b == 0) return "\nBölen 0 olamaz!";

        return $"\nİşlemin sonucu : {result}";
    }
    private static string Root(Func<double, double, double> operation)
    {
        if (!TryReadDouble("Kök içini giriniz : ", out double a)) return Error();
        if (!TryReadDouble("Kök derecesini giriniz : ", out double b)) return Error();

        double result = operation(a, b);

        return $"\nİşlemin sonucu : {result}";
    }
    private static bool TryReadDouble(string prompt, out double result)
    {
        Console.Write(prompt);
        return double.TryParse(Console.ReadLine(), out result);
    }
}