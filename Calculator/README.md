
# 🧮 Konsol Hesap Makinesi

C# ile geliştirilmiş, kapsamlı özelliklere sahip konsol tabanlı hesap makinesi uygulaması.

## ✨ Özellikler

### 🔢 Temel İşlemler
- **Toplama** ➕ - İki sayının toplamını hesaplar
- **Çıkarma** ➖ - İki sayının farkını hesaplar
- **Çarpma** ✖️ - İki sayının çarpımını hesaplar
- **Bölme** ➗ - İki sayının bölümünü hesaplar (sıfıra bölme kontrolü ile)
- **Mod** 🧮 - İki sayının modunu hesaplar

### 📐 Gelişmiş Matematik İşlemleri
- **Üs** 🔺 - Bir sayının üssünü hesaplar
- **Kök** 📐 - Bir sayının karekökünü hesaplar
- **Faktöriyel** ! - Bir sayının faktöriyelini hesaplar
- **Logaritma** 📈 - Bir sayının 10 tabanında logaritmasını hesaplar

### 📊 Trigonometrik Fonksiyonlar
- **Sinüs** 🌀 - Derece cinsinden açının sinüsünü hesaplar
- **Kosinüs** 🔄 - Derece cinsinden açının kosinüsünü hesaplar
- **Tanjant** ↩️ - Derece cinsinden açının tanjantını hesaplar
- **Kotanjant** ↪️ - Derece cinsinden açının kotanjantını hesaplar

### 🧠 Hafıza İşlemleri
- **M+** ➕ - Sayıyı hafızaya ekler
- **M-** ➖ - Sayıyı hafızadan çıkarır
- **MR** 🧠 - Hafızadaki değeri gösterir
- **MC** 🗑️ - Hafızayı sıfırlar

## 🚀 Kurulum ve Çalıştırma

### Gereksinimler
- .NET 6.0 veya üzeri
- Windows, macOS veya Linux

### Adımlar

1. **Projeyi klonlayın:**
```bash
git clone <repository-url>
cd Calculator
```

2. **Projeyi derleyin:**
```bash
dotnet build
```

3. **Uygulamayı çalıştırın:**
```bash
dotnet run
```

## 📖 Kullanım Kılavuzu

### Başlangıç
1. Uygulama başladığında animasyonlu bir yükleme ekranı görürsünüz
2. Ana menü ekranında 18 farklı işlem seçeneği listelenir
3. İstediğiniz işlemin numarasını girin (1-18)

### Temel İşlemler (1-5)
- İki sayı girmeniz istenir
- Sonuç sarı renkte gösterilir
- Devam etmek için herhangi bir tuşa basın

### Gelişmiş İşlemler (6-13)
- **Üs (6):** Taban ve üs değerlerini girin
- **Kök (7):** Negatif olmayan bir sayı girin
- **Faktöriyel (8):** Negatif olmayan bir tam sayı girin
- **Logaritma (9):** Pozitif bir sayı girin
- **Trigonometrik (10-13):** Derece cinsinden açı değeri girin

### Hafıza İşlemleri (14-17)
- **M+ (14):** Hafızaya eklenecek sayıyı girin
- **M- (15):** Hafızadan çıkarılacak sayıyı girin
- **MR (16):** Hafızadaki değeri görüntüler
- **MC (17):** Hafızayı sıfırlar

### Çıkış (18)
- Programdan güvenli bir şekilde çıkar

## 🎯 Örnek Kullanımlar

### Örnek 1: Temel Hesaplama
```
Seçim: 1 (Toplama)
İlk sayı: 15.5
İkinci sayı: 7.3
Sonuç: 22.8
```

### Örnek 2: Trigonometrik Hesaplama
```
Seçim: 10 (Sinüs)
Açı (derece): 30
Sonuç: 0.5
```

### Örnek 3: Hafıza Kullanımı
```
Seçim: 14 (M+)
Sayı: 100
Hafızaya eklendi. (M = 100)

Seçim: 16 (MR)
Hafızadaki değer: 100
```

## ⚠️ Hata Yönetimi

Uygulama aşağıdaki durumlarda hata mesajları gösterir:
- Geçersiz sayı girişi
- Sıfıra bölme denemesi
- Negatif sayının karekökü
- Negatif sayının faktöriyeli
- Sıfır veya negatif sayının logaritması
- Geçersiz menü seçimi

## 🎨 Özellikler

- **Renkli Konsol Arayüzü:** Farklı işlemler için farklı renkler
- **Animasyonlu Yükleme:** Başlangıçta görsel geri bildirim
- **Kullanıcı Dostu:** Türkçe arayüz ve açık talimatlar
- **Hata Toleransı:** Geçersiz girişlerde uyarı ve tekrar deneme
- **Hafıza Sistemi:** Geçici değer saklama özelliği

## 🔧 Teknik Detaylar

- **Dil:** C# (.NET)
- **Platform:** Konsol Uygulaması
- **Kodlama:** UTF-8 (Türkçe karakter desteği)
- **Mimari:** Modüler fonksiyon yapısı
- **Hata Yönetimi:** Try-catch blokları ile kapsamlı hata kontrolü

## 📝 Lisans

Bu proje eğitim amaçlı geliştirilmiştir. Özgürce kullanabilir ve değiştirebilirsiniz.

## 🤝 Katkıda Bulunma

1. Projeyi fork edin
2. Yeni bir branch oluşturun (`git checkout -b feature/yeni-ozellik`)
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik eklendi'`)
4. Branch'inizi push edin (`git push origin feature/yeni-ozellik`)
5. Pull Request oluşturun

## 📞 İletişim

Sorularınız veya önerileriniz için issue açabilirsiniz.

---

**Not:** Bu hesap makinesi akademik ve eğitim amaçlı geliştirilmiştir. Kritik hesaplamalar için profesyonel matematik yazılımları kullanmanız önerilir.
