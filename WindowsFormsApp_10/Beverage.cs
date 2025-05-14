using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_10
{
    internal class Beverage
    {
        public void Order()
        {
            Console.WriteLine("음료를 주문합니다");
        }
        public void Order(string name)
        {
            Console.WriteLine($"{name} 음료를 주문합니다");
        }
        public void Order(string name, int size)
        {
            Console.WriteLine($"{size}사이즈의 {name}음료를 주문 하였습니다.");
        }
        public void Order(string name,string size)
        {
            Console.WriteLine($"{size}사이즈의 {name}음료를 주문 하였습니다.");
        }

        // 오버라이드 부모 크래스의 메서드를 자식 클래스에서 재정의

        public virtual void Prepare()
        {
            Console.WriteLine("음료를 준비중 입니다.");
        }
    }
    internal class Americano : Beverage
    {
        public override void Prepare()
        {
            Console.WriteLine("아메리카노를 준비중 입니다.");
        }
    }
    internal class Americano2: Americano
    {
        public sealed override void Prepare()
        {
            Console.WriteLine("아메리카노2");
        }
    }
    internal class  Latte : Beverage
    {
        public sealed override void Prepare()
        {// 오버라이드는 여기 까지다!
            Console.WriteLine($"라떼를 준비 하고 있습니다.");
        }
    }
    internal class ColdBrew : Latte
    {
        //public override void Prepare() //sealed로 인해 오버라이드 불가
        //{
        //    Console.WriteLine($"콜드브루를 준비 하고 있습니다.");
        //}
    }
    internal class  ColdBrew2 : Beverage
    {
        public override void Prepare()
        {// Latte를 상속닫지 않기 때문에 오버라이드 가능
            Console.WriteLine("콜드브루를 준비 하는 중입니다.");
        }
    }
}
