GPACalculator
Konsol tabanlı bir not ortalaması ve harf notu hesaplayıcısıdır. Kullanıcıdan alacağı sınav sayısı ve notlar üzerinden geçerli aralıkta kontrol ederek ortalama hesaplar, ardından enum tabanlı switch ifadesiyle harf notunu belirler. Hata ve uyarı durumlarında renkli mesajlar ve emoji’ler kullanılarak kullanıcı deneyimi zenginleştirilmiştir.

Özellikler
Dinamik sınav sayısı girişi

Not validasyonu (0–100 aralığında)

Ortalama hesaplama

Harf notu belirleme (FF’den AA’ya)

Sürekli çalıştırma döngüsü

Renkli hata (kırmızı) ve uyarı (sarı) mesajları

Konsol çıktılarına emoji desteği

Gereksinimler
.NET 5.0 veya üzeri SDK

İşletim Sistemi: Windows, macOS veya Linux

Tercihen Visual Studio Code veya benzeri bir IDE

Kurulum
Depoyu klonlayın:

bash
git clone https://github.com/kullaniciAdin/GPACalculator.git
Proje dizinine gidin:

bash
cd GPACalculator
Bağımlılıkları yükleyip derleyin:

bash
dotnet restore
dotnet build
Çalıştırma
Aşağıdaki komutla uygulamayı başlatın:

bash
dotnet run --project GPACalculator.csproj
Uygulama her çalıştırıldığında:

Sınav sayısını girmenizi ister.

Her notu tek tek doğrular.

Ortalama ve harf notunuzu renkli şekilde ekrana yazar.

Devam etmek için bir tuşa basmanızı bekler, ardından ekranı temizler.

Kod Yapısı
enum LetterGrade Harf notlarını FF–AA aralığında tanımlar.

GetExamGrades() Sınav sayısı ve not girişi ile validasyon işlemlerini yürütür.

CalculateAverage(double[]) Girilen notların ortalamasını döndürür.

GetLetterGrade(double) Ortalama değerine göre enum eşlemesi yapar.

DisplayResults(double) Ortalama ve harf notunu yeşil renkte ekrana basar.

WriteError(string) / WriteWarning(string) Hata ve uyarı mesajlarını ilgili renkte gösterir.

Özelleştirme Fırsatları
Harf notu aralıklarını değiştirmek için GetLetterGrade içindeki switch ifadelerini güncelleyebilirsiniz.

Yeni mesaj stilleri ve renk kombinasyonları eklemek için Console.ForegroundColor ayarlarını özelleştirebilirsiniz.

Döngüyü kaldırıp tek seferlik çalışacak şekilde while (true) yerine direkt Main akışını tercih edebilirsiniz.

Katkıda Bulunma
Bu repoyu fork’layın.

Yeni bir branch açın (git checkout -b feature/özellik-adi).

Değişikliklerinizi commit edin (git commit -m "Yeni özellik ekledim").

Branch’inizi push’layın (git push origin feature/özellik-adi).

GitHub’daki pull request oluşturma sürecini tamamlayın.

Lisans
Bu proje MIT lisansı altında lisanslanmıştır. Detaylar LICENSE dosyasında yer almaktadır.
