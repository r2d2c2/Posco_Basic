using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Delegate
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        //카테고리
        public  string Category { get; set; }
        public Product(string name, int price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
        public override string ToString()
        {
            return($"이름 {Name} 가격{Price} 카테고리{Category}");
        }
    }

    public class ProductFilter 
    {

        public static void Totall(List<Product> product)
        {
            Console.WriteLine(string.Join("\n",product));
        }
        // 익명 함수로 10만원 이상인 제품을 필터링
        public static List<Product> FilterByPrice(List<Product> products)
        {
            List<Product> filteredProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.Price >= 100000)
                {
                    filteredProducts.Add(product);
                }
            }
            return filteredProducts;
        }
        // 카테고리가 가구인 제품을 필터링
        public static List<Product> FilterByCategory(List<Product> products)
        {
            List<Product> filteredProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.Category == "가구")
                {
                    filteredProducts.Add(product);
                }
            }
            return filteredProducts;
        }
    }

    public delegate bool ProductCondition(Product product);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<Product> products = new List<Product>();
            products.Add(new Product("사과", 100000, "과일"));
            products.Add(new Product("바나나", 20000, "과일"));
            products.Add(new Product("오렌지", 30000, "과일"));
            products.Add(new Product("감자", 100000, "채소"));
            products.Add(new Product("양파", 20000, "채소"));
            products.Add(new Product("의자", 50000, "가구"));

            ProductFilter.Totall(products);

            List<Product> products1 = ProductFilter.FilterByPrice(products);
            Console.WriteLine("10만원 이상 인것");
            foreach (var product in products1)
            {
                Console.WriteLine(product);
            }
            //카테고리가 가구인 제품을 필터링
            Console.WriteLine("카테고리가 가구인 제품");
            List<Product> products2 = ProductFilter.FilterByCategory(products);
            foreach (var product in products2)
            {
                Console.WriteLine(product);
            }
        }
    }
}
