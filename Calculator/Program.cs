using System.Text;
using System;
using System.Threading;

class Program
{
    static double memory = 0;
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Loading();
        RunCalculator();
    }
    private static void RunCalculator()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("KONSOL HESAP MAKİNESİ\n");
            Console.ResetColor();
            Operators();
            Console.Write("\nBir işlem seçiniz (1-18): ");
            string? input = Console.ReadLine();
            int choice;
            if (!int.TryParse(input, out choice) || choice < 1 || choice > 18)
            {
                Invalid();
                continue;
            }
            if (choice == 18)
            {
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nÇıkış yapılıyor...");
                Console.ResetColor();
                Thread.Sleep(1000);
                break;
            }
            try
            {
                switch (choice)
                {
                    case 1: BasicOperation("Toplama", (a, b) => a + b); break;
                    case 2: BasicOperation("Çıkarma", (a, b) => a - b); break;
                    case 3: BasicOperation("Çarpma", (a, b) => a * b); break;
                    case 4:
                        BasicOperation("Bölme", (a, b) =>
                        {
                            if (b == 0) throw new DivideByZeroException();
                            return a / b;
                        }); break;
                    case 5: BasicOperation("Mod", (a, b) => a % b); break;
                    case 6: BasicOperation("Üs", (a, b) => Math.Pow(a, b)); break;
                    case 7: SqrtOperation(); break;
                    case 8: FactorialOperation(); break;
                    case 9: LogOperation(); break;
                    case 10: TrigOperation("Sinüs", Math.Sin); break;
                    case 11: TrigOperation("Kosinüs", Math.Cos); break;
                    case 12: TrigOperation("Tanjant", Math.Tan); break;
                    case 13: TrigOperation("Kotanjant", x => 1 / Math.Tan(x)); break;
                    case 14: MemoryAdd(); break;
                    case 15: MemorySubtract(); break;
                    case 16: MemoryRecall(); break;
                    case 17: MemoryClear(); break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Hata: {ex.Message}");
                Console.ResetColor();
                Continue();
            }
        }
    }
    private static void BasicOperation(string name, Func<double, double, double> op)
    {
        Console.Write($"\n{name} için ilk sayıyı giriniz: ");
        if (!double.TryParse(Console.ReadLine(), out double a)) { Invalid(); return; }
        Console.Write($"{name} için ikinci sayıyı giriniz: ");
        if (!double.TryParse(Console.ReadLine(), out double b)) { Invalid(); return; }
        double result = op(a, b);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nSonuç: {result}");
        Console.ResetColor();
        Continue();
    }
    private static void SqrtOperation()
    {
        Console.Write("\nKökünü almak istediğiniz sayıyı giriniz: ");
        if (!double.TryParse(Console.ReadLine(), out double a) || a < 0) { Invalid(); return; }
        double result = Math.Sqrt(a);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nSonuç: {result}");
        Console.ResetColor();
        Continue();
    }
    private static void FactorialOperation()
    {
        Console.Write("\nFaktöriyelini almak istediğiniz sayıyı giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 0) { Invalid(); return; }
        long result = 1;
        for (int i = 2; i <= n; i++) result *= i;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nSonuç: {result}");
        Console.ResetColor();
        Continue();
    }
    private static void LogOperation()
    {
        Console.Write("\nLogaritmasını almak istediğiniz sayıyı giriniz: ");
        if (!double.TryParse(Console.ReadLine(), out double a) || a <= 0) { Invalid(); return; }
        double result = Math.Log10(a);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nSonuç: {result}");
        Console.ResetColor();
        Continue();
    }
    private static void TrigOperation(string name, Func<double, double> op)
    {
        Console.Write($"\n{name} için derece cinsinden açıyı giriniz: ");
        if (!double.TryParse(Console.ReadLine(), out double degree)) { Invalid(); return; }
        double rad = degree * Math.PI / 180;
        double result = op(rad);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nSonuç: {result}");
        Console.ResetColor();
        Continue();
    }
    private static void MemoryAdd()
    {
        Console.Write("\nHafızaya eklemek istediğiniz sayıyı giriniz: ");
        if (!double.TryParse(Console.ReadLine(), out double a)) { Invalid(); return; }
        memory += a;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nHafızaya eklendi. (M = {memory})");
        Console.ResetColor();
        Continue();
    }
    private static void MemorySubtract()
    {
        Console.Write("\nHafızadan çıkarmak istediğiniz sayıyı giriniz: ");
        if (!double.TryParse(Console.ReadLine(), out double a)) { Invalid(); return; }
        memory -= a;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nHafızadan çıkarıldı. (M = {memory})");
        Console.ResetColor();
        Continue();
    }
    private static void MemoryRecall()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nHafızadaki değer: {memory}");
        Console.ResetColor();
        Continue();
    }
    private static void MemoryClear()
    {
        memory = 0;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nHafıza sıfırlandı.");
        Console.ResetColor();
        Continue();
    }
    private static void Continue()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nDevam etmek için lütfen bir tuşa basınız");
        Console.ResetColor();
        Console.ReadKey();
        Console.CursorVisible = true;
    }
    private static void Loading()
    {
        int loopTime = 0;
        int loopDuration = 50;
        char[] chars = { '-', '\\', '|', '/', '-', '\\', '|', '/' };
        Console.CursorVisible = false;
        while (loopTime < 4)
        {
            foreach (var item in chars)
            {
                Console.Write(item);
                Thread.Sleep(loopDuration);
                Console.Clear();
            }
            loopTime++;
        }
        Console.CursorVisible = true;
    }
    private static void Operators()
    {
        Operator(" 1. ", "Toplama    ➕");
        Operator(" 2. ", "Çıkarma    ➖");
        Operator(" 3. ", "Çarpma     ✖️");
        Operator(" 4. ", "Bölme      ➗");
        Operator(" 5. ", "Mod        🧮");
        Operator(" 6. ", "Üs         🔺");
        Operator(" 7. ", "Kök        📐");
        Operator(" 8. ", "Faktöriyel !");
        Operator(" 9. ", "Logaritma  📈");
        Operator("10. ", "Sinüs      🌀");
        Operator("11. ", "Kosinüs    🔄");
        Operator("12. ", "Tanjant    ↩️");
        Operator("13. ", "Kotanjant  ↪️");
        Operator("14. ", "M+         ➕");
        Operator("15. ", "M-         ➖");
        Operator("16. ", "MR         🧠");
        Operator("17. ", "MC         🗑️");
        Operator("18. ", "Çıkış      ❌");
    }
    private static void Operator(string message1, string message2)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(message1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message2);
        Console.ResetColor();
    }
    private static void Invalid()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Geçersiz bir işlem yaptınız, Lütfen tekrar deneyiniz!");
        Console.ResetColor();
        Continue();
    }
}
