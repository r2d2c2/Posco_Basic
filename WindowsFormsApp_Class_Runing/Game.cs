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
                    ProcesField();
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
                if(monster.IsDie())
                {
                    Console.WriteLine("몬스터를 처치하였습니다.");
                    player.GainExp(monster.Exp);
                    break;
                }
                damage = monster.GetAttack();
                player.OnDamage(damage);
                if(player.IsDie())
                {
                    Console.WriteLine("당신은 죽었습니다.");
                    mode = GameMode.Lobby;
                    break;
                }
            }
        }
        private Monster CreatRandomMonster()
        {
            int radomV = random.Next(0, 2);
            //monster = new Ocr();
            switch(radomV)
            {
                case 0:
                    monster = new Goblin();
                    break;
                case 1:
                    monster = new Ocr();
                    break;
                default:
                    break;
            }
        }
    }
}
