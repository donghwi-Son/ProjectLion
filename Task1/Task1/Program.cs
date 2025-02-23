using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //로딩바
            Console.WriteLine("□□□□□□□□□□");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("■□□□□□□□□□");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("■■□□□□□□□□");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("■■■□□□□□□□");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("■■■■□□□□□□");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("■■■■■□□□□□");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("■■■■■■□□□□");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("■■■■■■■□□□");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("■■■■■■■■□□");
            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("■■■■■■■■■□");
            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("■■■■■■■■■■");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("=======잼없는 게임=======");
            Console.WriteLine();
            //게임스토리
            Console.WriteLine("엔터를 누르면 시작!");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("개발자 : 손동휘");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("게임스토리");
            Thread.Sleep(1000);
            Console.WriteLine("우리의 민수는 멋사 유니티 강의를 듣기 위해");
            Thread.Sleep(1000);
            Console.WriteLine("오늘도 아침 일찍 일어나 토스트를 먹고");
            Thread.Sleep(1000);
            Console.WriteLine("수업을 들으려고 한다");
            Thread.Sleep(1000);
            Console.Write("엔터를 눌러 계속...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("샤워를 마치고 토스트를 먹으려던 바로 그 때!");
            Thread.Sleep(1000);
            Console.WriteLine("민수는 늘 먹던 잼이 사라져 있는것을 발견한다");
            Thread.Sleep(1000);
            Console.WriteLine("민수는 잼을 찾기 위해 집을 나선다...");
            Thread.Sleep(1000);
            Console.Write("엔터를 눌러 계속...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("민수를 도와 잼을 찾으시오");
            Thread.Sleep(3000);
            Console.Write("엔터를 눌러 계속...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("다음중 한 사람은 거짓을 말하고 있다");
            Console.WriteLine("1. 민수의 친구 : 너희 어머니가 잼을 드시는걸 봤어");
            Console.WriteLine("2. 민수의 엄마 : 아빠가 어제 잼을 먹은거 같던데~");
            Console.WriteLine("3. 민수의 아빠 : 난 무죄야 ㅠㅠ");
            Console.WriteLine("거짓을 말하는 인원을 골라보자!");
            Console.Write("번호를 입력하세요(숫자 입력 후 엔터를 치시오) : ");
            int input = int.Parse(Console.ReadLine());
            Console.Clear();
            if (input == 1)
            {
                Console.WriteLine("정직했던 민수의 친구는 상처를 받고 민수와 절교했다...(bad end)");
            }
            if(input == 2)
            {
                Console.WriteLine("민수의 엄마는 민수에게 사과하고 새 잼을 사주었다!(good end)");
            }
            if (input == 3)
            {
                Console.WriteLine("민수의 아빠는 억울함에 화가 나 민수의 용돈을 삭감했다...(bad end)");
            }
        }
    }
}
