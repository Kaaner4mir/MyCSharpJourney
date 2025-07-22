markdown
# Calculator

Konsol tabanlı gelişmiş bir hesap makinesi uygulamasıdır. 18 farklı işlem seçeneği, bellek yönetimi ve renkli geri bildirimleriyle etkileşimli bir deneyim sunar.

---

## Özellikler

- Temel Aritmetik  
  - Toplama, Çıkarma, Çarpma, Bölme  
- Ek Matematik İşlemleri  
  - Mod alma, Üs alma, Kök alma, Faktöriyel, Logaritma  
- Trigonometri  
  - Sinüs, Kosinüs, Tanjant, Kotanjant  
- Bellek İşlemleri  
  - M+, M–, MR, MC  
- Uygulamadan güvenli çıkış  
- Menü navigasyonu ve hata durumlarında renkli uyarılar  

---

## Gereksinimler

- .NET 5.0 veya üzeri SDK  
- Windows, macOS veya Linux ortamı  
- Tercihen Visual Studio Code veya benzeri bir IDE  

---

## Kurulum ve Çalıştırma

```bash
git clone https://github.com/kullaniciAdin/Calculator.git
cd Calculator
dotnet restore
dotnet build
dotnet run
Kullanım
Uygulama açıldığında ana menüde işlem numarasını (1–18) girin.

Ekrandaki istemlere göre sayıları veya dereceleri girin.

Sonuç ekranda görüntülenir; devam etmek için tuşa basın.

İşlemler arasında geri dönüp yeni seçimler yapabilirsiniz.

Kod Yapısı
1. Menü ve Navigasyon
DisplayMenu() Ana başlık ve işlem listesini temiz bir ekranda gösterir ve kullanıcı girişini okur.

Operations() 1–18 arasındaki işlem seçeneklerini Op() yardımıyla renkli biçimde ekrana yazar.

2. Temel Matematik İşlemleri
PerformBasicMath(string opName, Func<double,double,double> operation) İki sayı alır, özel durum (sıfıra bölme vs.) kontrolleri yapar, sonucu döndürür.

3. Üs ve Kök Alma
Exponentiation(Func<double,double,double> operation) Taban ve kuvvet girdisi alır, Math.Pow ile hesaplar.

Root(Func<double,double,double> operation) Kök içi ve derecesini alır, birinci dereceden kökü Math.Pow(a,1.0/b) formülüyle çözer.

4. Faktöriyel ve Logaritma
Factorial() Pozitif tam sayı girdisiyle iteratif faktöriyel hesaplar.

Logarithm(Func<double,double,double> operation) Taban ve logaritması alınacak sayıyı alır, Math.Log kullanır ve sonucu yuvarlar.

5. Trigonometri
Trigonometry(short dummy) Alt menüde 1–4 arasında sin, cos, tan, cot seçenekleri sunar. Derece girdisini radyana çevirir ve Math sınıfı metotlarını uygular.

6. Bellek Fonksiyonları
MAdd(), MSubstraction(), MRecall(), MClear() Statik memory değişkeni üzerinden ekleme, çıkarma, görüntüleme ve temizleme işlemleri yapar.

7. Yardımcı Metotlar
InputHandler(string prompt, out double result) Konsoldan sayı girdisi alır ve doğruluğunu kontrol eder.

Message(ConsoleColor color, string message) Renkli mesaj formatı oluşturur.

Op(ConsoleColor c1, string m1, ConsoleColor c2, string m2) İki renkli parçayı yan yana yazar.

Continue() Devam etmek için tuşa basma bekler ve ekranı temizleyecek hazırlığı yapar.

Katkıda Bulunma
Repoyu fork’layın.

Yeni bir branch oluşturun (git checkout -b feature/özellik-adi).

Değişikliklerinizi commit edin (git commit -m "Açıklayıcı mesaj").

Branch’inizi push edin (git push origin feature/özellik-adi).

GitHub’da pull request oluşturun.

Lisans
Bu proje MIT lisansı altında lisanslanmıştır. LICENSE dosyasına bakabilirsiniz.
