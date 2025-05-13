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

namespace WindowsFormsApp_09_Class
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Sword sword0 = new Sword(10);
            sword0.Name = "롱소드";
            sword0.Attack();
            sword0.Slash(100);
            Console.WriteLine("==============================");
            Weapon sword = new Sword(10);
            
            Weapon sword3= new Sword(10) as Sword;
            sword.Name = "롱소드";
            sword.Attack();
            ((Sword)sword).Slash(100);

            Console.WriteLine("==========================");
            Sword swoard22 = new Sword(30);
            swoard22.Name = "롱소드";
            swoard22.Attack();
            Console.WriteLine($"검 공격데미지{swoard22.Slash(1)}");

            Console.WriteLine("==========================");
            Weapon weapon4 = swoard22;
            weapon4.Attack();
            Console.WriteLine($"검 공격데미지{((Sword)weapon4).Slash(1)}");

            Console.WriteLine("==========================");
            weapon4=new Gun(100);
            weapon4.Name = "기본 활";
            weapon4.Attack();
            Console.WriteLine($"활 공격데미지{((Gun)weapon4).Fire(10)}");
            Console.WriteLine("==========================");
            Sword sword5 = new Sword(10);
            Gun gun5 = new Gun(100);
            Bow bow5 = new Bow(50);

            Console.WriteLine("===========================");
            Interface1 interface1 = new Bow(50);
            ((Bow)interface1).Aim();
        }
    }
}
