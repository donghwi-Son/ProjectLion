using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LikeLion1
{
    class Skill
    {
        public string name;
        public int cooldown;
        public int lastUsedTime;
        public Skill(string name, int cooldown)
        {
            this.name = name;
            this.cooldown = cooldown * 1000;
            lastUsedTime = 0;
        }

        public bool CooldownOK()
        {
            int time = Environment.TickCount;
            if (time - lastUsedTime < cooldown)
            {
                int leftcool = (cooldown - (time - lastUsedTime)) / 1000;
                Console.WriteLine($" {name} 스킬은 아직 사용할 수 없습니다.(남은 시간 : {leftcool}초)");
                return false;
            }
            return true;
        }

        public void Use()
        {
            if (!CooldownOK()) return;
                 
            lastUsedTime = Environment.TickCount; //현재 시간을 저장

            Console.WriteLine($"{name} 사용!");
        }
    }
    class Unit
    {
        public Skill[] skills = new Skill[6];

        public virtual void Flash()
        {
            Console.WriteLine("점멸!");
        }

        public virtual void Ignite()
        {
            Console.WriteLine("점화!");
        }
    }

    class LeeShin : Unit
    {
        public LeeShin()
        {
            skills[0] = new Skill("음파", 10);
            skills[1] = new Skill("방호", 12);
            skills[2] = new Skill("폭풍", 9);
            skills[3] = new Skill("용의 분노", 90);
        }


    }

    class WuKong : Unit
    {
        public WuKong()
        {
            skills[0] = new Skill("파쇄격", 8);
            skills[1] = new Skill("분신", 20);
            skills[2] = new Skill("근두운 급습", 10);
            skills[3] = new Skill("회전격", 130);
        }
    }





    class Program
    {

        static void UIDraw(Unit asd)
        {
            Console.WriteLine("사용 가능한 스킬: ");
            Console.WriteLine($"Q. {asd.skills[0].name} (쿨다운 {asd.skills[0].cooldown / 1000}s)");
            Console.WriteLine($"W. {asd.skills[1].name} (쿨다운 {asd.skills[1].cooldown / 1000}s)");
            Console.WriteLine($"E. {asd.skills[2].name} (쿨다운 {asd.skills[2].cooldown / 1000}s)");
            Console.WriteLine($"R. {asd.skills[3].name} (쿨다운 {asd.skills[3].cooldown / 1000}s)");
            Console.WriteLine($"D. 점화!");
            Console.WriteLine($"F. 점멸!");
            Console.WriteLine("ESC. 종료");
            Console.Write("사용할 스킬 키를 입력하세요: ");
        }
        static void Main(string[] args)
        {
            
            
            Console.SetWindowSize(80, 35);
            Console.SetBufferSize(80, 35);

            LeeShin lee = new LeeShin();
            WuKong wk = new WuKong();
            Console.Clear();
            Console.WriteLine("1.리신");
            Console.WriteLine("2.오공");
            Console.Write("플레이할 캐릭터를 선택(숫자입력) : ");
            int character = int.Parse(Console.ReadLine());
            while (true)
            {
                Console.Clear();
                if (character == 1)
                {
                    UIDraw(lee);
                    ConsoleKey key = Console.ReadKey().Key;
                    Console.WriteLine();
                    if (key == ConsoleKey.Escape) break;
                    switch (key)
                    {
                        case ConsoleKey.Q:
                            lee.skills[0].Use();
                            break;
                        case ConsoleKey.W:
                            lee.skills[1].Use();
                            break;
                        case ConsoleKey.E:
                            lee.skills[2].Use();
                            break;
                        case ConsoleKey.R:
                            lee.skills[3].Use();
                            break;
                        case ConsoleKey.F:
                            lee.Flash();
                            break;
                        case ConsoleKey.D:
                            lee.Ignite();
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
                if(character == 2)
                {
                    UIDraw(wk);
                    ConsoleKey key = Console.ReadKey().Key;
                    Console.WriteLine();
                    if (key == ConsoleKey.Escape) break;
                    switch (key)
                    {
                        case ConsoleKey.Q:
                            wk.skills[0].Use();
                            break;
                        case ConsoleKey.W:
                            wk.skills[1].Use();
                            break;
                        case ConsoleKey.E:
                            wk.skills[2].Use();
                            break;
                        case ConsoleKey.R:
                            wk.skills[3].Use();
                            break;
                        case ConsoleKey.F:
                            wk.Flash();
                            break;
                        case ConsoleKey.D:
                            wk.Ignite();
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
               



                
                Thread.Sleep(1000); 

            }
            Console.WriteLine("게임종료");
        }
    }
}