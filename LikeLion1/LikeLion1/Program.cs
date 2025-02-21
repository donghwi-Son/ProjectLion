using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LikeLion1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("루인 스킬 피해 입력 : ");
            float sd = float.Parse(Console.ReadLine());
            Console.Write("카드 게이지 획득량 입력 : ");
            float gauge = float.Parse(Console.ReadLine());
            Console.Write("각성기 피해 입력 : ");
            float ultd = float.Parse(Console.ReadLine());
            Console.Write("최대 마나 입력 : ");
            float maxmp = float.Parse(Console.ReadLine());
            Console.Write("전투 중 마나 회복량 입력 : ");
            float battlemp = float.Parse(Console.ReadLine());
            Console.Write("비전투 중 마나 회복량 입력 : ");
            float nonbatmp = float.Parse(Console.ReadLine());
            Console.Write("이동 속도 입력 : ");
            float mvspd = float.Parse(Console.ReadLine());
            Console.Write("탈 것 속도 입력 : ");
            float ridespd = float.Parse(Console.ReadLine());
            Console.Write("운반 속도 입력 : ");
            float transspd = float.Parse(Console.ReadLine());
            Console.Write("스킬 재사용 대기시간 감소 입력 : ");
            float cooldown = float.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine($"루인 스킬 피해  : {sd}%");
            Console.WriteLine($"카드 게이지 획득량  : {gauge}%");
            Console.WriteLine($"각성기 피해  : {ultd}%");
            Console.WriteLine("최대 마나  : " + maxmp);
            Console.WriteLine("전투 중 마나 회복량  : " + battlemp);
            Console.WriteLine("비전투 중 마나 회복량 : " + nonbatmp);
            Console.WriteLine($"이동 속도  : {mvspd}%");
            Console.WriteLine($"탈 것 속도  : {ridespd}%");
            Console.WriteLine($"운반 속도  : {transspd}%");
            Console.WriteLine($"스킬 재사용 대기시간 감소  : {cooldown}%");
        }
    }
}