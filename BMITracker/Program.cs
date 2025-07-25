using System.Text;

class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Kilonuzu girin (kg): ");
        double weight = Convert.ToDouble(Console.ReadLine());

        Console.Write("Boyunuzu girin (metre, örn: 1.75): ");
        double height = Convert.ToDouble(Console.ReadLine());

        double bmi = BMICalculator(weight, height);
        string category = BMIResult(bmi);

        Console.WriteLine($"\nVücut Kitle İndeksiniz: {bmi:F2}");
        Console.WriteLine($"Durum: {category}");
        Console.ReadLine();
    }

    private static double BMICalculator(double weight, double height)
    {
        return weight / Math.Pow(height, 2);
    }

    private static string BMIResult(double bmi)
    {
        if (bmi < 18.5)
            return "Zayıf";
        else if (bmi < 25)
            return "Normal";
        else if (bmi < 30)
            return "Fazla kilolu";
        else if (bmi < 35)
            return "1. derece obez";
        else if (bmi < 40)
            return "2. derece obez";
        else
            return "3. derece obez";
    }
}
