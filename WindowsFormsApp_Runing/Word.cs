using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Runing
{
    internal class Word
    {
        public Player Lobby(ref Player player)
        {
            Console.WriteLine("로비에 입장 히였습니다");
            Console.WriteLine("직업을 선택하여 주세요");
            Console.Write(" 전사 1, 마법사 2");
            string input = Console.ReadLine();
            int job = 0;
            int.TryParse(input, out job);
            if (job == 1)
            {
                player = new Warrior();
                return player;
            }
            else if (job == 2)
            {
                player = new Wizard();
                return player;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                return Lobby(ref player);
            }
        }
        public void Tallk(ref User user)
        {
            Console.WriteLine("안녕하세요");
            Console.WriteLine("무엇을 도와 드릴까요?");
            Console.WriteLine("1. 퀘스트");
            Console.WriteLine("2. 상점");
            Console.WriteLine("3. 정보");
            Console.WriteLine("4. 던전으로...");
            string input = Console.ReadLine();
            int choice = 0;
            int.TryParse(input, out choice);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("마왕 토벌");
                    break;
                case 2:
                    Console.WriteLine("상점에 오신것을 환영합니다");
                    Console.WriteLine("보유 골드 0");
                    break;
                case 3:
                    Console.WriteLine($"직업 : {user.Job}");
                    Console.WriteLine($"공격력 : {user.Attack}");
                    Console.WriteLine($"체력 : {user.Hp}");

                    break;
                case 4:
                    Console.WriteLine("던전으로 가시겠습니까?");
                    Console.WriteLine("1. 예");
                    Console.WriteLine("2. 아니요");
                    string input2 = Console.ReadLine();
                    int choice2 = 0;
                    int.TryParse(input2, out choice2);
                    if (choice2 == 1)
                    {
                        Console.WriteLine("던전으로 이동합니다");
                        Dungeon(ref user);
                        return;
                    }
                    else if (choice2 == 2)
                    {
                        Console.WriteLine("로비로 돌아갑니다");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Tallk(ref user);
                    }
                    break;
                default:
                    break;
            }
        }
        public Monster Dungeon(ref User user)
        {
            Random random = new Random();
            int monster = random.Next(1, 4);
            switch(monster)
            {
                case 1:
                    Console.WriteLine("슬라임이 나타났다");
                    Monster slime = new Slime();

                    user.Hp -= slime.Attack;
                    Console.WriteLine($"슬라임의 공격으로 {user.Hp}의 피해를 입었습니다");
                    if (user.Hp <= 0)
                    {
                        Console.WriteLine("당신은 죽었습니다");
                        return null;
                    }
                    else
                    {
                        Console.WriteLine($"당신의 체력은 {user.Hp}입니다");
                    }
                    slime.Hp -= user.Attack;
                    Console.WriteLine($"슬라임에게 {user.Attack}의 피해를 입혔습니다");
                    if (slime.Hp <= 0)
                    {
                        Console.WriteLine("슬라임을 처치하였습니다");
                        return null;
                    }
                    else
                    {
                        Console.WriteLine($"슬라임의 체력은 {slime.Hp}입니다");
                    }

                    return slime;
                    
                case 2:
                    Console.WriteLine("아무것도 없다");
                    return null;
                case 3:
                    Console.WriteLine("오크가 나타났다");
                    Monster orc = new Orc();
                    user.Hp -= orc.Attack;
                    Console.WriteLine($"오크의 공격으로 {user.Hp}의 피해를 입었습니다");
                    if (user.Hp <= 0)
                    {
                        Console.WriteLine("당신은 죽었습니다");
                        return null;
                    }
                    else
                    {
                        Console.WriteLine($"당신의 체력은 {user.Hp}입니다");
                    }
                    orc.Hp -= user.Attack;
                    Console.WriteLine($"오크에게 {user.Attack}의 피해를 입혔습니다");
                    if (orc.Hp <= 0)
                    {
                        Console.WriteLine("오크를 처치하였습니다");
                        return null;
                    }
                    else
                    {
                        Console.WriteLine($"오크의 체력은 {orc.Hp}입니다");
                    }
                    return orc;
                default:
                    return null;
            }
        }
    }
}
