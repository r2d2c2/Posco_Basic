using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Animal
    {
        public string Name { get; set; }
        public void Speak() => Console.WriteLine($"{Name} 동물이 소리를 냅니다");

    }
    public class Dog : Animal
    {
        // 물기
        public void Bite()
        {
            Console.WriteLine($"{Name}가 물었습니다");
        }
    }
    public class Cat : Animal
    {
        // 할퀴기
        public void Scratch()
        {
            Console.WriteLine($"{Name}가 할퀴었습니다");
        }
    }
    public class Bird : Animal
    {
        // 날기
        public void Fly()
        {
            Console.WriteLine($"{Name}가 날았습니다");
        }
    }
}
