using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //제품 목록
            List<Product> products = new List<Product>
            {
                new Product("소파", 150000, "가구"),
                new Product("책상", 200000, "가구"),
                new Product("의자", 50000, "가구"),
                new Product("모니터", 300000, "전자제품"),
                new Product("키보드", 50000, "전자제품"),
                new Product("마우스", 30000, "전자제품")
            };
            List<Product> expoensive = ProductFilter.Filter(products, p => p.Price >= 100000);

            List<Product> furniture = ProductFilter.Filter(products, p => p.Category == "가구");

            Console.WriteLine("10만원 이상 제품");
            foreach (var p in expoensive)
            {
                Console.WriteLine($"{p}");
            }
            Console.WriteLine("가구인 제품");
            foreach (var p in furniture)
            {
                Console.WriteLine(p);
            }
        }
    }
}
