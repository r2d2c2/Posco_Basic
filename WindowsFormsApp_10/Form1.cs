using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Beverage beverage = new Beverage();
            beverage.Order();
            beverage.Order("아메리카노");
            beverage.Order("아메리카노", "Tall");

            Beverage beverage2 = new Americano();
            beverage2.Prepare();
            // Beverage를 사용하지만 Americano의 Prepare() 메서드가 호출됨

            Console.WriteLine("=========================");
            Beverage latte = new Latte();
            latte.Prepare();
            Beverage cold = new ColdBrew();
            cold.Prepare();
            Beverage cold2=new ColdBrew2();
            cold2.Prepare();
        }
    }
}
