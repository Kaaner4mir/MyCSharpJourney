# 💼 Budget Tracking System | Console App (C#)

🧾 C# dilinde geliştirilen sade ve etkileşimli bir konsol uygulaması.  
Kullanıcıdan alınan gelir ve gider bilgilerini `BudgetItem` yapısı ile takip eder, raporlar ve kayıt altına alır. Hem bireysel hem küçük işletme kullanımı için uygundur.

---

## 🚀 Özellikler

- 🏦 Gelir ekleme
- 💵 Gider ekleme
- 📊 Gelir-gider bazlı rapor görüntüleme
- ✅ Doğrulama mekanizmaları (`TryParse`)
- 🎨 Konsol renklendirmesi ile kullanıcı dostu arayüz
- 📋 Örnek verilerle açılışta başlatma (`Example()` metodu)

---

## 🛠️ Teknolojiler

- C# (.NET Console Application)
- OOP prensipleri (`BudgetItem`)
- List<BudgetItem> ile dinamik veri yönetimi
- Random ile benzersiz ID üretimi
- Konsol odaklı etkileşim ve renkli çıktı (`ConsoleColor`)
- UTF8 çıkış desteği (`Console.OutputEncoding`)

---

## 📁 Dosya Yapısı

```plaintext
BudgetTrackingSystem/
├── Program.cs            // Tüm uygulama akışı
├── BudgetItem.cs         // Gelir/gider veri modeli
├── README.md             // Proje dokümantasyonu
