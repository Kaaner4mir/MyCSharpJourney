using System.Text;

class BudgetTrackingSystem
{
    static Random _ıdGenerator = new Random();
    static List<BudgetItem> _items = new List<BudgetItem>();

    static decimal _totalRevenue = 0;
    static decimal _totalExpense = 0;

    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Example();
        while (true)
        {
            Console.Clear();
            Ops("<< BÜTÇE TAKİP PROGRAMI >>");
            Ops("🏦 1. Gelir Ekle");
            Ops("💵 2. Gider Ekle");
            Ops("🔍 3. Raporu görüntüle");
            Ops("⚠️ 4. Çıkış");
            Console.Write("\nYapmak istediğiniz işlemi sayısal olarak giriniz (1-4): ");
            if (!short.TryParse(Console.ReadLine(), out short act))
            {
                Invalid();
            }
            switch (act)
            {
                case 1:
                    AddRevenue();
                    break;
                case 2:
                    AddExpense();
                    break;
                case 3:
                    ViewReport();
                    break;
                default:
                    Invalid();
                    break;
            }
        }

    }
    private static void ViewReport()
    {
        Console.Clear();

        Ops("<< Şirket Gelirler >>");
        foreach (var item in _items)
        {
            if (item.Amount > 0)
            {
                Console.WriteLine($"{item.Type}: {item.Amount}");
            }
        }
        Ops("<< Şirket Giderleri >>");
        foreach (var item in _items)
        {
            if (item.Amount < 0)
            {
                Console.WriteLine($"{item.Type}: {item.Amount}");
            }
        }
        Continue();
    }
    private static void AddExpense()
    {
        Console.Clear();
        Console.Write("Lütfen gider tipini giriniz: ");
        string? type = Console.ReadLine();
        Console.Write("Lütfen açıklama giriniz: ");
        string? description = Console.ReadLine();
        Console.Write("Lütfen gider miktarını giriniz: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal income))
        {
            Invalid();
            Continue();
        }

        if (type != null && description != null)
        {
            _items.Add(new BudgetItem()
            {
                Id = _ıdGenerator.Next(100, 999),
                Type = type,
                Description = description,
                Amount = income,
            });
            Valid();
        }
        else
        {
            Invalid();
        }
    }
    private static void AddRevenue()
    {
        Console.Clear();
        Console.Write("Lütfen gelir tipini giriniz: ");
        string? type = Console.ReadLine();
        Console.Write("Lütfen açıklama giriniz: ");
        string? description = Console.ReadLine();
        Console.Write("Lütfen gelir miktarını giriniz: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal income))
        {
            Invalid();
            Continue();
        }

        if (type != null && description != null)
        {
            _items.Add(new BudgetItem()
            {
                Id = _ıdGenerator.Next(100, 999),
                Type = type,
                Description = description,
                Amount = income,
            });
            Valid();
        }
        else
        {
            Invalid();
        }
    }
    private static void Ops(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    private static void Example()
    {
        _items.Add(new BudgetItem()
        {
            Id = _ıdGenerator.Next(100, 999),
            Type = "Personel maaşları",
            Description = "Çalışanlara ödenen maaşlar (Temmuz)",
            Amount = -1250000.00m
        });

        _items.Add(new BudgetItem()
        {
            Id = _ıdGenerator.Next(100, 999),
            Type = "Reklam gideri",
            Description = "Meta ve Google reklam bütçesi",
            Amount = -190000.00m
        });

        _items.Add(new BudgetItem()
        {
            Id = _ıdGenerator.Next(100, 999),
            Type = "Donanım alımı",
            Description = "Yeni geliştirici bilgisayarları ve ekipmanları",
            Amount = -150000.00m
        });

        _items.Add(new BudgetItem()
        {
            Id = _ıdGenerator.Next(100, 999),
            Type = "Vergi ödemesi",
            Description = "KDV ve kurumlar vergisi ödemeleri",
            Amount = -460000.00m
        });

        _items.Add(new BudgetItem()
        {
            Id = _ıdGenerator.Next(100, 999),
            Type = "Eğitim gideri",
            Description = "Çalışanlara yönelik yazılım eğitim programı",
            Amount = -20000.00m
        });

        _items.Add(new BudgetItem()
        {
            Id = _ıdGenerator.Next(100, 999),
            Type = "Ürün satışı",
            Description = "Temmuz ayı yazılım lisans satışları",
            Amount = 1920000.00m
        });

        _items.Add(new BudgetItem()
        {
            Id = _ıdGenerator.Next(100, 999),
            Type = "Hizmet geliri",
            Description = "Danışmanlık ve teknik destek hizmetleri",
            Amount = 297500.00m
        });

        _items.Add(new BudgetItem()
        {
            Id = _ıdGenerator.Next(100, 999),
            Type = "Reklam ortaklığı",
            Description = "Üçüncü taraf firmalardan alınan reklam ücretleri",
            Amount = 100000.00m
        });


    }
    private static void Valid()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.CursorVisible = false;
        Console.WriteLine("\n✔️ İşleminiz başarıyla tamamlandı.");
        Console.ResetColor();
        Console.CursorVisible = true;
        Continue();
    }
    private static void Invalid()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.CursorVisible = false;
        Console.WriteLine("\n❗ Geçersiz bir işlem yaptınız! Lütfen tekrar deneyiniz.");
        Console.ResetColor();
        Console.CursorVisible = true;
        Continue();
    }
    private static void Continue()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.CursorVisible = false;
        Console.WriteLine("\n➡️ Devam etmek için lütfen bir tuşa basınız");
        Console.ResetColor();
        Console.ReadKey();
        Console.CursorVisible = true;

    }
}