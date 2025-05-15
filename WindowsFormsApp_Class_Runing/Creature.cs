using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Class_Runing
{
    public enum  CreatureType
    {
        None,
        Player,
        Monster,
    }
    internal class Creature
    {
        CreatureType type = CreatureType.None;
        protected int hp = 0;
        protected int attack = 0;

        public virtual string Talk(PlayerType playerType) { return null; }

        public Creature(CreatureType type)
        {
            this.type = type;
        }
        public void SetInfo(int hp,int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }
        public CreatureType GetType()
        {
            return type;
        }
        public int GetHp()
        {
            return hp;
        }
        public int GetAttack()
        {
            return attack;
        }
        public bool IsDead()
        {
            return hp <= 0;
        }
        public void OnDamage(int damage)
        {
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
            }
        }
    }
}
