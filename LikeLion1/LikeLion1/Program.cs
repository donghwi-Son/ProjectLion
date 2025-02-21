using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion1
{
    class Program
    {
        static void Main(string[] args)
        {
            int att = 16755;
            int maxhp = 78103;
            int crit = 36;
            int special = 1017;
            int overpower = 41;
            int speed = 611;
            int patience = 22;
            int skill = 39;
            Console.WriteLine("공격력: " + att);
            Console.WriteLine("최대 생명력: " + maxhp);
            Console.WriteLine("치명: " + crit);
            Console.WriteLine("특화: " + special);
            Console.WriteLine("제압: " + overpower);
            Console.WriteLine("신속: " + speed);
            Console.WriteLine("인내: " + patience);
            Console.WriteLine("숙련: " + skill);
        }
    }
}