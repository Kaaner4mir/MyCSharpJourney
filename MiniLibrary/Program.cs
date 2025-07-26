using System.Reflection.Emit;
using System.Text;

class Library
{
    static List<Book> _books = new List<Book>();
    static Random _ıdGenerator = new Random();

    public static void Main()
    {
        ExampleBooks();
        Loading();
        Console.OutputEncoding = Encoding.UTF8;
        while (true)
        {
            Console.Clear();
            Ops();
            Console.Write("\nLütfen yapmak istediğiniz işlemi numerik olarak giriniz: ");
            if (!short.TryParse(Console.ReadLine(), out short act)) { Invalid(); continue; }
            Console.Clear();
            Loading();
            switch (act)
            {
                case 1:
                    SearchBook();
                    break;
                case 2:
                    AddBook();
                    break;
                case 3:
                    UpdateBook();
                    break;
                case 4:
                    RemoveBook();
                    break;
                case 5:
                    ListingBooks();
                    break;
                case 6:
                    Exit();
                    break;
                default:
                    Invalid();
                    break;
            }
            Loading();
        }
    }
    private static void SearchBook()
    {
        Console.Write("Lütfen aramak istediğiniz kitap adını giriniz: ");
        string? searchBook = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(searchBook))
        {
            Invalid();
            return;
        }

        var results = _books.Where(b => b.Name.ToLower().Contains(searchBook.Trim().ToLower())).ToList();

        if (results.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nAradığınız kitap bulunamadı.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{results.Count} kitap bulundu:");
            Console.ResetColor();

            foreach (var item in results)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Kitap numarası: {item.Id}\n" +
                                  $"Kitap adı     : {item.Name}\n" +
                                  $"Yazar         : {item.Author}\n" +
                                  $"Yayınevi      : {item.PublishingHouse}");
                Console.ResetColor();
                Console.WriteLine("--------------------------------------------------");
            }
        }

        Continue();
    }
    private static void AddBook()
    {
        Console.Write("Kitap adı: ");
        string? name = Console.ReadLine();

        Console.Write("Yazar adı: ");
        string? author = Console.ReadLine();

        Console.Write("Yayınevi: ");
        string? publishingHouse = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(publishingHouse))
        {
            Invalid();
            return;
        }

        _books.Add(new Book()
        {
            Id = _ıdGenerator.Next(1000, 9999),
            Name = name.Trim(),
            Author = author.Trim(),
            PublishingHouse = publishingHouse.Trim()
        });

        Valid();
    }
    private static void UpdateBook()
    {
        Console.Write("Güncellemek istediğiniz kitabın numarasını giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Invalid();
            return;
        }

        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine("Kitap bulunamadı.");
            Continue();
            return;
        }

        Console.WriteLine("Yeni değerleri giriniz. Boş bırakılanlar değiştirilmez.");

        Console.Write("Yeni kitap adı: ");
        string? newName = Console.ReadLine();
        Console.Write("Yeni yazar: ");
        string? newAuthor = Console.ReadLine();
        Console.Write("Yeni yayınevi: ");
        string? newPub = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(newName)) book.Name = newName.Trim();
        if (!string.IsNullOrWhiteSpace(newAuthor)) book.Author = newAuthor.Trim();
        if (!string.IsNullOrWhiteSpace(newPub)) book.PublishingHouse = newPub.Trim();

        Valid();
    }
    private static void RemoveBook()
    {
        Console.Write("Silmek istediğiniz kitabın numarasını giriniz: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Invalid();
            return;
        }

        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine("Kitap bulunamadı.");
            Continue();
            return;
        }

        _books.Remove(book);
        Valid();
    }
    private static void Exit()
    {
        Console.Write("Çıkmak istediğinize emin misiniz? (E/H): ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Geçerli bir giriş yapmadınız. Çıkış iptal edildi.");
            return;
        }

        if (input.Trim().ToUpper() == "E")
        {
            Console.WriteLine("Programdan çıkılıyor...");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Çıkış iptal edildi.");
        }
    }
    private static void ListingBooks()
    {
        foreach (var item in _books)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Kitap numarası: {item.Id}\n" +
                              $"Kitap adı     : {item.Name}\n" +
                              $"Yazar         : {item.Author}\n" +
                              $"Kitap yayınevi: {item.PublishingHouse}");
            Console.WriteLine("--------------------------------------------------");
        }
        Console.ResetColor();
        Continue();
    }
    private static void Ops()
    {
        Op("🔎 1. ", "Kitap arama");
        Op("➕ 2. ", "Kitap ekleme");
        Op("🔃 3. ", "Kitap güncelleme");
        Op("🗑️ 4. ", "Kitap silme");
        Op("🔢 5. ", "Kitapları listeleme");
        Op("❌ 6. ", "Çıkış");
    }
    private static void Op(string message1, string message2)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(message1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message2);
        Console.ResetColor();
    }
    private static void Valid()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("İşleminiz başarıyla gerçekleşti");
        Console.ResetColor();
        Continue();
    }
    private static void Invalid()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Geçersiz bir işlem yaptınız! Lütfen tekrar deneyiniz");
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
    private static void ExampleBooks()
    {
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Kürk Mantolu Madonna", Author = "Sabahattin Ali", PublishingHouse = "Yapı Kredi Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Tutunamayanlar", Author = "Oğuz Atay", PublishingHouse = "İletişim Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Saatleri Ayarlama Enstitüsü", Author = "Ahmet Hamdi Tanpınar", PublishingHouse = "Dergah Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Çalıkuşu", Author = "Reşat Nuri Güntekin", PublishingHouse = "İnkılap Kitabevi" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "İnce Memed", Author = "Yaşar Kemal", PublishingHouse = "Yapı Kredi Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Yaban", Author = "Yakup Kadri Karaosmanoğlu", PublishingHouse = "İletişim Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Fatih Harbiye", Author = "Peyami Safa", PublishingHouse = "Ötüken Neşriyat" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Eylül", Author = "Mehmet Rauf", PublishingHouse = "Ötüken Neşriyat" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Huzur", Author = "Ahmet Hamdi Tanpınar", PublishingHouse = "Dergah Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Sefiller", Author = "Victor Hugo", PublishingHouse = "İş Bankası Kültür Yayınları" });

        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "1984", Author = "George Orwell", PublishingHouse = "Can Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Hayvan Çiftliği", Author = "George Orwell", PublishingHouse = "Can Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Suç ve Ceza", Author = "Fyodor Dostoyevski", PublishingHouse = "İş Bankası Kültür Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Savaş ve Barış", Author = "Lev Tolstoy", PublishingHouse = "Can Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Uçurtma Avcısı", Author = "Khaled Hosseini", PublishingHouse = "Everest Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Simyacı", Author = "Paulo Coelho", PublishingHouse = "Can Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Bülbülü Öldürmek", Author = "Harper Lee", PublishingHouse = "Bilgi Yayınevi" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Yüzüklerin Efendisi", Author = "J.R.R. Tolkien", PublishingHouse = "Metis Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Harry Potter ve Felsefe Taşı", Author = "J.K. Rowling", PublishingHouse = "Yapı Kredi Yayınları" });
        _books.Add(new Book() { Id = _ıdGenerator.Next(1000, 9999), Name = "Büyük Umutlar", Author = "Charles Dickens", PublishingHouse = "İş Bankası Kültür Yayınları" });

    }
    private static void Loading()
    {
        Console.CursorVisible = false;
        char[] items = { '-', '\\', '|', '/', '-', '\\', '|', '/' };

        int loopTime = 0;
        int loopDuration = 50;
        while (loopTime < 32)
        {
            foreach (var item in items)
            {
                Console.Write(item);
                Thread.Sleep(loopDuration);
                loopTime++;
                Console.Clear();
            }
        }
        Console.CursorVisible = true;
    }
}