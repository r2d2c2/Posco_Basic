using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Runing
{
    public interface Player
    {
        string Job { get; set; }
    }
    public class User : Player
    {
        public virtual string  Job { get; set; }
        public virtual int Hp { get; set; }
        public virtual int Attack { get; set; }

    }
    //전사
    public class Warrior : User
    {
        public override string Job { get; set; } = "Warrior";
        public override int Attack { get; set; } = 10;
        public override int Hp { get; set; } = 100;
    }
    // 마법사
    public class Wizard : User
    {
        public override string Job { get; set; } = "Wizard";
        public override int Attack { get; set; } = 20;
        public override int Hp { get; set; } = 80;
    }
    public class Npc : Player
    {
        public string Job { get; set; }
    }
    public class Monster : Player
    {
        public virtual string Job { get; set; }
        public virtual int Attack { get; set; }
        public virtual int Hp { get; set; }

    }
    //오크
    public class Orc : Monster
    {
        public override string Job { get; set; } = "Orc";
        public override int Attack { get; set; } = 15;
        public override int Hp { get; set; } = 30;
    }
    //슬라임
    public class Slime : Monster
    {
        public override string Job { get; set; } = "Slime";
        public override int Attack { get; set; } = 30;
        public override int Hp { get; set; } = 10;
    }
}
