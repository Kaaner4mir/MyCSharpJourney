# GPA (Not Ortalaması) Hesaplayıcı 🧮

Bu C# konsol uygulaması, kullanıcıdan alınan sınav notlarına göre ortalama hesaplar ve bu ortalamaya karşılık gelen harf notunu (`AA`, `BA`, `BB` ...) gösterir.

## 🚀 Özellikler

- İstenilen sayıda sınav notu girilebilir.
- Her bir notun 0 ile 100 arasında olması kontrol edilir.
- Girilen notlara göre:
  - Ortalama hesaplanır.
  - Harf karşılığı belirlenir.
- Kullanıcı dostu uyarı ve hata mesajları.
- Sonsuz döngü ile tekrar tekrar hesaplama yapılabilir.

## 📋 Kullanım

1. Uygulama çalıştırılır.
2. Sınav sayısı girilir (pozitif tam sayı).
3. Her bir sınav için 0-100 aralığında not girilir.
4. Ortalama ve harf notu görüntülenir.
5. Devam etmek için herhangi bir tuşa basılarak yeni hesaplama yapılabilir.

## 🔤 Harf Notu Aralıkları

| Ortalama       | Harf Notu |
|----------------|-----------|
| 90 - 100       | AA        |
| 85 - 89        | BA        |
| 80 - 84        | BB        |
| 75 - 79        | CB        |
| 70 - 74        | CC        |
| 65 - 69        | DC        |
| 60 - 64        | DD        |
| 50 - 59        | FD        |
| 0  - 49        | FF        |

## 📦 Gereksinimler

- .NET 6 veya üzeri
- Visual Studio 2022 / Visual Studio Code

## 📄 Lisans

Bu proje [MIT Lisansı](LICENSE) altında lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasını inceleyin.
