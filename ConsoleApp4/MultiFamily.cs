using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class GrandParent
    {
       // public GrandParent() => Console.WriteLine("GrandParent 생성자 호출됨");
        public GrandParent(string name,int age)
        {
            Console.WriteLine($"GrandParent 매개변수 생성자 호출됨");
            Console.WriteLine($"이름은 : {name} 나이는 : {age} 입니다.");
        }
        public void SayHello()
        {
            Console.WriteLine("저는 할아버지 입니다.");
        }
    }
    public class  Parent: GrandParent
    {
        public Parent(): base("hong",50)
        {
            Console.WriteLine("Parent 호출");
        }
        public Parent(string name, int age) : base(name, age)
        {
            Console.WriteLine("Parent 매개변수 생성자 호출됨");
            Console.WriteLine($"이름은 : {name} 나이는 : {age} 입니다.");
        }
        public void SayHello2()
        {
            Console.WriteLine("저는 아버지 입니다.");
        }
    }
    public class Child : Parent
    {
        public Child()
        {
            Console.WriteLine("Child 호출");
        }
        public Child(string name, int age) : base(name, age)
        {
            Console.WriteLine("Child 매개변수 생성자 호출됨");
            Console.WriteLine($"이름은 : {name} 나이는 : {age} 입니다.");
        }
        public void SayHello3()
        {
            Console.WriteLine("저는 자식 입니다.");
        }
    }
    public class GrandChild : Child
    {
        public GrandChild()
        {
            Console.WriteLine("GrandChild 호출");
        }
        public GrandChild(string name, int age) : base(name, age)
        {
            Console.WriteLine("GrandChild 매개변수 생성자 호출됨");
            Console.WriteLine($"이름은 : {name} 나이는 : {age} 입니다.");
        }
        public void SayHello4()
        {
            Console.WriteLine("저는 손자 입니다.");
        }
    }


}
