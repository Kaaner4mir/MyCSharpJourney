
# Vücut Kitle İndeksi (BMI) Hesaplayıcı - C# Konsol Uygulaması

Bu proje, kullanıcıdan kilo (kg) ve boy (metre) bilgilerini alarak Vücut Kitle İndeksi'ni (BMI - Body Mass Index) hesaplayan basit bir C# konsol uygulamasıdır. Hesaplanan BMI değeri doğrultusunda kullanıcının kilo durumu (zayıf, normal, obez vb.) ekrana yazdırılır.

## 🚀 Özellikler

- Kullanıcıdan boy ve kilo bilgilerini alma
- BMI hesaplama
- BMI değerine göre sağlık durumunu belirleme
- UTF-8 desteği sayesinde Türkçe karakterlerde sorun yaşanmaz

## 📌 BMI Nedir?

BMI, bir kişinin vücut ağırlığının boyuna göre değerlendirilmesini sağlar ve genellikle aşağıdaki aralıklara göre sınıflandırılır:

| BMI Değeri          | Durum             |
|---------------------|------------------|
| 0 - 18.4            | Zayıf            |
| 18.5 - 24.9         | Normal           |
| 25.0 - 29.9         | Fazla kilolu     |
| 30.0 - 34.9         | 1. derece obez   |
| 35.0 - 39.9         | 2. derece obez   |
| 40 ve üzeri         | 3. derece obez   |

## ⚙️ Kurulum ve Çalıştırma

1. Visual Studio 2022 veya uyumlu bir C# geliştirme ortamı kullanın.
2. Yeni bir C# Console Application projesi oluşturun.
3. Aşağıdaki kodu `Program.cs` dosyasına yapıştırın.
4. Projeyi başlatın (`F5` veya `Ctrl + F5`).

```csharp
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

        Console.WriteLine($"
Vücut Kitle İndeksiniz: {bmi:F2}");
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
```

## 🧠 Öğrenilen Konular

- `Console.ReadLine()` ve `Convert.ToDouble()` ile kullanıcıdan veri alma
- Fonksiyon kullanımı
- `Math.Pow()` ile üslü işlemler
- Koşullu ifadeler (`if-else`)
- String formatlama (`{bmi:F2}`)

## 📄 Lisans

Bu proje [MIT Lisansı](LICENSE) kapsamında lisanslanmıştır. Daha fazla bilgi için lütfen `LICENSE` dosyasını inceleyin.
