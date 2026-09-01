// Створіть текстовий файл-чек на кшталт «Найменування товару – 0.00(ціна)грн.» з певною кількістю найменувань товарів та датою здійснення покупки. 
// Виведіть на екран інформацію з чека у форматі поточної локалі користувача та у форматі локалі en-US.

using System;
using System.Globalization;

namespace task4;

class Program
{
    public static string pathToCheck = @"C:\Users\adm.fenovka\Documents\Lessons\HW4\task4\check.txt";
    static void Main(string[] args)
    {
        {
             File.Create(pathToCheck).Close();
            Product[] products = new Product[]
            {
                new Product("Товар 1", 10.50m, DateTime.Now),
                new Product("Товар 2", 20.75m, DateTime.Now),
                new Product("Товар 3", 15.30m, DateTime.Now)
            };
            using (StreamWriter sWriter = new StreamWriter(pathToCheck))
            {
                foreach (var product in products)
                {
                    sWriter.WriteLine($"{product.Name} - {product.Price.ToString("F2")} грн. - {product.PurchaseDate.ToString("dd.MM.yyyy")}");
                }
            }   
        }

        Product[] productsFromFile = new Product[0];
        using (StreamReader sReader = new StreamReader(pathToCheck))
        {
            var lines = new List<string>();
            string line;
            while ((line = sReader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            productsFromFile = new Product[lines.Count];
            for (int i = 0; i < lines.Count; i++)
            {
                var parts = lines[i].Split(" - ");
                if (parts.Length == 3)
                {
                    string name = parts[0];
                    decimal price = decimal.Parse(parts[1].Replace(" грн.", ""));
                    DateTime purchaseDate = DateTime.ParseExact(parts[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    productsFromFile[i] = new Product(name, price, purchaseDate);
                }
            }
        }
        CultureInfo currentCulture = CultureInfo.CurrentCulture;
        CultureInfo enUSCulture = new CultureInfo("en-US");

        foreach(var product in productsFromFile)
        {
            string currentCultureOutput = $"{product.Name} - {product.Price.ToString("C", currentCulture)} - {product.PurchaseDate.ToString(currentCulture)}";
            string enUSCultureOutput = $"{product.Name} - {(Convert.ToDecimal(product.Price) / 43).ToString("C", enUSCulture)} - {product.PurchaseDate.ToString(enUSCulture)}";

            Console.WriteLine("Поточна локаль користувача:");
            Console.WriteLine(currentCultureOutput);
            Console.WriteLine();

            Console.WriteLine("Локаль en-US:");
            Console.WriteLine(enUSCultureOutput);
            Console.WriteLine();
        }
    }





    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Product(string name, decimal price, DateTime purchaseDate)
        {
            Name = name;
            Price = price;
            PurchaseDate = purchaseDate;
        }
    }
}