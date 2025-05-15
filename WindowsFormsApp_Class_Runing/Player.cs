using System;

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
        public void LevelUp()
        {
            try
            {
                Console.WriteLine("LeveUp hp를 입력하세요");
                int hp = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("LeveUp power을 입력하세요");
                int attack = Convert.ToInt32(Console.ReadLine());
                SetInfo(hp, attack);
            }
            catch (Exception e)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine(e.Message);

            }
        }
        

    }
    internal class Warrior : Player
    {
        public Warrior() : base(PlayerType.Warrior)
        {
            SetInfo(100, 20);
        }
        public override string Talk(PlayerType playerType)
        {
            // 전사면
            if (playerType == PlayerType.Warrior)
            {
                return "전사입니다.";
            }
            // 마법사면
            else if (playerType == PlayerType.Wizard)
            {
                return "마법사입니다.";
            }
            return "잘못된 타입입니다.";
        }
    }
    internal class Wizard : Player
    {
        public Wizard() : base(PlayerType.Wizard)
        {
            SetInfo(80, 30);
        }
        public override string Talk(PlayerType playerType)
        {
            // 전사면
            if (playerType == PlayerType.Warrior)
            {
                return "전사입니다.";
            }
            // 마법사면
            else if (playerType == PlayerType.Wizard)
            {
                return "마법사입니다.";
            }
            return "잘못된 타입입니다.";
        }
    }
}