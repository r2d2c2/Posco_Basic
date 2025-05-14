using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Class_Runing
{
    enum PlayerType
    {
        None,
        //전사
        Warrior,
        //마법사
        Wizard,
    }
    internal class Player : Creature
    {
        protected PlayerType type = PlayerType.None;
        public Player(PlayerType type) : base(CreatureType.Player)
        {
            this.type = type;
        }
        public PlayerType GetPlayerType()
        {
            return type;
        }
    }
    class Warrior : Player
    {
        public Warrior() : base(PlayerType.Warrior)
        {
            SetInfo(100, 20);
        }
    }
    class Wizard : Player
    {
        public Wizard() : base(PlayerType.Wizard)
        {
            SetInfo(80, 30);
        }
    }

}
