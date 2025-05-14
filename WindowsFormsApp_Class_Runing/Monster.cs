using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Class_Runing
{
    public enum MonsterType
    {
        None,
        Orc,
        Slime,
    }
    internal class Monster :Creature
    {
        protected MonsterType type=MonsterType.None;
        protected Monster(MonsterType type) : base(CreatureType.Monster)
        {
            this.type = type;
        }
        MonsterType GetMonsterType() => type;
    }
    class Orc : Monster
    {
        public Orc() : base(MonsterType.Orc)
        {
            SetInfo(80, 15);
        }
    }
    class Slime : Monster
    {
        public Slime() : base(MonsterType.Slime)
        {
            SetInfo(50, 10);
        }
    }
}
