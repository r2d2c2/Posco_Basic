using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Class_Runing
{
    public enum GameMode
    {
        Lobby,
        Town,
        Dungeon,
        Field,
    }
    internal class Game
    {
        private GameMode mode = GameMode.Lobby;
        private Player player;
        private Monster monster;
        Random random = new Random();
        public void Process()
        {
            switch (mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;

            }
        }
        private void ProcessField()
        {
            Console.WriteLine("필드에 나왔습니다.");
            Console.WriteLine("1. 몬스터와 전투");
            Console.WriteLine("2. 일정확율로 마을로 돌아가기");
            string input = Console.ReadLine();
            int choice = 0;
            int.TryParse(input, out choice);

            CreatRandomMonster();

            switch (choice)
            {
                case 1:
                    ProcessFight(); 
                    break;
                case 2:
                    TryEscape();
                    break;
                default:
                    break;
            }
        }
        private void TryEscape()
        {
            int randomV=random.Next(0,101);
            if (randomV < 30)
            {
                mode=GameMode.Town;
            }
            else
            {
                ProcessFight();
            }
        }
        private void ProcessFight()
        {
            while (true)
            {
                int damage=player.GetAttack();
                monster.OnDamage(damage);
                if(monster.IsDead())
                {
                    Console.WriteLine("몬스터를 처치하였습니다.");
                    Console.WriteLine($"남은 체력은 {player.GetHp()}");
                    break;
                }
                damage = monster.GetAttack();
                player.OnDamage(damage);
                if(player.IsDead())
                {
                    Console.WriteLine("당신은 죽었습니다.");
                    mode = GameMode.Lobby;
                    break;
                }
            }
        }
        private void CreatRandomMonster()
        {
            int radomV = random.Next(0, 2);
            switch(radomV)
            {
                case 0:
                    monster= new Orc();
                    Console.WriteLine("야생의 오크 발견!!!!");
                    break;
                case 1:
                    monster = new Slime();
                    Console.WriteLine("야생의 슬라임 발견!!!");
                    break;
                default:
                    break;
            }
        }
        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다");
            Console.WriteLine("1 필드로 가기");
            Console.WriteLine("2 로비로 가기");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    mode = GameMode.Field;
                    break;
                case "2":
                    mode = GameMode.Lobby;
                    break;
            }
        }
        private void ProcessLobby()
        {
            Console.WriteLine("직업을 선택 하세요");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 마법사");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    player = new Warrior();
                    mode=GameMode.Town;
                    break;
                case "2":
                    player = new Wizard();
                    mode = GameMode.Town;
                    break;
                default:
                    break;
            }
        }
    }
}
