using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_09_Class
{
    #region # 부모 클래스


    public class Weapon
    {
        public int damage;

        public Weapon() { }
        public Weapon(int damage)
        {
            this.damage = damage;
        }
        public string Name { get; set; }
        public void Attack()
        {
            Console.WriteLine($"{Name}으로 공격");
        }
        public int AttackPower() => damage;
    }
    #endregion
    #region # 자식 클래스
    public class Sword : Weapon
    {
        public int AttackRang=1;
        public Sword() { }
        public Sword(int damage): base(damage)
        {

        }
        public int Slash(int range)
        {
            if (this.AttackRang >= range)
            {
                return this.damage;
            }
            return 0;
        }
    }
    public class Gun : Weapon
    {
        int attac_range = 10;
        public Gun() { }
        public Gun(int damage) : base(damage)
        {

        }
        public int Fire(int range)
        {
            if (this.attac_range >= range)
            {
                return this.damage;
            }
            return 0;
        }
        public void Reload()
        {
            Console.WriteLine($"총을 제장전 합니다");
        }
    }
    public class Bow : Weapon, Interface1
    {
        public bool isInterface { get; set; } = true;
        public Bow(int damage) : base(damage)
        {
        }
        public void Aim()
        {
            Console.WriteLine($"활을 당겨 조준합니다.");
        }
    }
    #endregion
}
