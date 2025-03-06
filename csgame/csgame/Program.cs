using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csgame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int x = 0;
            int y = 1;
            Console.WriteLine("'##::::'##::::'###::::'########:'########:");
            Console.WriteLine(" ###::'###:::'## ##:::..... ##:: ##.....::");
            Console.WriteLine(" ####'####::'##:. ##:::::: ##::: ##:::::::");
            Console.WriteLine(" ## ### ##:'##:::. ##:::: ##:::: ######:::");
            Console.WriteLine(" ##. #: ##: #########::: ##::::: ##...::::");
            Console.WriteLine(" ##:.:: ##: ##.... ##:: ##:::::: ##:::::::");
            Console.WriteLine(" ##:::: ##: ##:::: ##: ########: ########:");
            Console.WriteLine("..:::::..::..:::::..::........::........::");
            Console.WriteLine();
            Console.WriteLine("   게임을 시작하려면 아무 키나 누르세요");
            Console.ReadKey();
            while (true)
            {
                string[] strings = new string[15];
                strings[0] = ("■■■■■■■■■■■■■■■");
                strings[1] = ("□□■□□□■□□□□□□□■");
                strings[2] = ("■□■□■□■□■■■■■□■");
                strings[3] = ("■□□□■□■□■□□□■□■");
                strings[4] = ("■■■■■□■□■□■■■□■");
                strings[5] = ("■□□□□□■□■□■□■□■");
                strings[6] = ("■□■■■■■□■□■□■□■");
                strings[7] = ("■□□□□□□□■□■□■□■");
                strings[8] = ("■■■□■■■■■□■□■□■");
                strings[9] = ("■□□□■□□□□□■□■□■");
                strings[10]= ("■□■■■□■■■■■□■□■");
                strings[11]= ("■□□□□□■□□□□□■□■");
                strings[12]= ("■□■■■■■□■■■■■□■");
                strings[13]= ("■□□□□□□□□□□□■□□");
                strings[14]= ("■■■■■■■■■■■■■■■");
                Console.Clear();

                PrintMap(strings);
                PrintPlayer(x, y);



                if (x == 14 && y == 13)
                {
                    Console.Clear();
                    Console.WriteLine("  ____  ___   ___  ____  _ ");
                    Console.WriteLine(" / ___|/ _ \\ / _ \\|  _ \\| |");
                    Console.WriteLine("| |  _| | | | | | | | | | |");
                    Console.WriteLine("| |_| | |_| | |_| | |_| |_|");
                    Console.WriteLine(" \\____|\\___/ \\___/|____/(_)");
                    break;
                }

                Console.SetCursorPosition(0, 17);
                Console.Write("방향키로 이동");
                ConsoleKeyInfo arr = Console.ReadKey();
                if (arr.Key == ConsoleKey.UpArrow && strings[y - 1][x] == '□')
                {
                    y--;
                }
                else if (arr.Key == ConsoleKey.DownArrow && strings[y + 1][x] == '□')
                {
                    y++;
                }
                else if (arr.Key == ConsoleKey.LeftArrow && strings[y][x-1] == '□')
                {
                    x--;
                }
                else if (arr.Key == ConsoleKey.RightArrow && strings[y][x+1] == '□')
                {
                    x++;
                }

            }
        }

        static void PrintMap(string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(strings[i]);
            }
        }

        static void PrintPlayer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("◈");
        }

        
    }
}
