


namespace CashRegisterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w aplikacji Kasa Sklepowa!");
            Console.WriteLine("Naciśnij Rozpocznij symulację programu, aby kontynuować.");
            Console.ReadLine();
            Console.Clear();

            // Lista produktów w sklepie
            List<Product> products = new List<Product>()
            {
                new Product("001", "Masło extra", 6.50),
                new Product("002", "Chleb wiejski", 4.50),
                new Product("003", "Makaron Babuni", 9.20),
                new Product("004", "Dżem truskawkowy", 8.10),
                new Product("005", "Kiełbasa myśliwska", 29.00),
                new Product("006", "Szynka konserwowa", 22.00),
                new Product("007", "Chipsy paprykowe", 6.00),
                new Product("008", "Serek wiejski", 3.50),
                new Product("009", "Sól kuchenna", 2.70),
                new Product("010", "Cukier kryształ", 3.20)
            };

            Console.WriteLine("Dostępne produkty w sklepie:");

            // Wyświetlenie listy produktów
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Barcode}\t{product.Name}\t{product.NetPrice} PLN");
            }

            Console.WriteLine("\nNaciśnij Enter, aby rozpocząć zakupy.");
            Console.ReadLine();
            Console.Clear();

            // Koszyk zakupowy
            List<Product> shoppingCart = new List<Product>();
            double totalPrice = 0;

            Console.WriteLine("Zakupy:");
            Console.WriteLine("Aby zakończyć dodawanie produktów, naciśnij klawisz P.");

            // Skanowanie kodów kreskowych produktów
            string input;
            do
            {
                Console.Write("Podaj kod kreskowy produktu: ");
                input = Console.ReadLine();

                // Szukanie produktu po kodzie kreskowym
                Product scannedProduct = products.Find(p => p.Barcode == input);
                if (scannedProduct != null)
                {
                    shoppingCart.Add(scannedProduct);
                    totalPrice += scannedProduct.NetPrice;
                    Console.WriteLine($"Zeskanowano: {scannedProduct.Name} ({scannedProduct.NetPrice} PLN)");

                    Console.WriteLine($"Aktualna wartość brutto zakupów: {Math.Round(totalPrice * 1.23, 2)} PLN");
                }
                else
                {
                    Console.WriteLine("Produkt o podanym kodzie kreskowym nie istnieje.");
                }
            } while (input != "P");

            // Wyświetlenie paragonu za zakupy
            Console.Clear();
            Console.WriteLine("Paragon za zakupy:");
            Console.WriteLine($"Data zakupów: {DateTime.Now}");

            Console.WriteLine("Produkty:");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"{product.Name}\t{product.NetPrice} PLN");
            }

            double totalVat = totalPrice * 0.23;

            Console.WriteLine($"Łączna kwota do zapłaty (brutto): {Math.Round(totalPrice * 1.23, 2)} PLN");
            Console.WriteLine($"Łączny podatek VAT: {Math.Round(totalVat, 2)} PLN");
        }
    }

    class Product
    {
        public string Barcode { get; }
        public string Name { get; }
        public double NetPrice { get; }

        public Product(string barcode, string name, double netPrice)
        {
            Barcode = barcode;
            Name = name;
            NetPrice = netPrice;
        }
    }
}