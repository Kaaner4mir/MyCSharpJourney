using System.Text;

class GPACalculator
{
    enum LetterGrade
    {
        FF, FD, DD, DC, CC, CB, BB, BA, AA
    }
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        while (true)
        {
            double average = CalculateAverage(GetExamGrades());
            DisplayResults(average);

            Console.CursorVisible = false;
            Console.WriteLine("\n➡️ Devam etmek için bir tuşa basınız...");
            Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = true;
        }
    }
    /// <summary> Kullanıcıdan sınav sayısını ve geçerli notları alır. </summary>
    private static double[] GetExamGrades()
    {
        int examCount;
        while (true)
        {
            Console.Write("🔢 Sınav sayısını giriniz: ");
            if (int.TryParse(Console.ReadLine(), out examCount) && examCount > 0)
                break;

            WriteError("❌ Geçersiz sayı girdiniz! Lütfen pozitif bir tam sayı giriniz.");
        }

        double[] grades = new double[examCount];
        Console.WriteLine();
        for (int i = 0; i < examCount; i++)
        {
            while (true)
            {
                Console.Write($"🖊️ {i + 1}. notunuzu giriniz (0-100): ");
                if (double.TryParse(Console.ReadLine(), out double grade) &&
                    grade >= 0 && grade <= 100)
                {
                    grades[i] = grade;
                    break;
                }
                WriteWarning("❗Not 0 ile 100 arasında olmalıdır.");
            }
        }

        return grades;
    }
    /// <summary> Not dizisinden ortalamayı hesaplar. </summary>
    private static double CalculateAverage(double[] grades)
    {
        double total = 0;
        foreach (var grade in grades)
        {
            total += grade;
        }
        return total / grades.Length;
    }
    /// <summary> Ortalamaya göre sonuçları ve harf notunu gösterir. </summary>
    private static void DisplayResults(double average)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n📈 Ortalama: {average:F2}");
        Console.WriteLine($"📈 Harf Notu: {GetLetterGrade(average)}");
        Console.ResetColor();
    }
    /// <summary> Ortalamaya göre harf notunu enum olarak döndürür. </summary>
    private static LetterGrade GetLetterGrade(double average)
    {
        return average switch
        {
            >= 90 => LetterGrade.AA,
            >= 85 => LetterGrade.BA,
            >= 80 => LetterGrade.BB,
            >= 75 => LetterGrade.CB,
            >= 70 => LetterGrade.CC,
            >= 65 => LetterGrade.DC,
            >= 60 => LetterGrade.DD,
            >= 50 => LetterGrade.FD,
            _ => LetterGrade.FF
        };
    }
    /// <summary> Hata mesajı gösterir. </summary>
    private static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    /// <summary> Uyarı mesajı gösterir. </summary>
    private static void WriteWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
