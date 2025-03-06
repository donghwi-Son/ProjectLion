using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace bjpractice
{
    class Parent
    {
        protected string name;
        public Parent(string x)
        {
            this.name = x;
            Console.WriteLine($"부모 생성자: {name}");
        }
    }

    class Child : Parent
    {
        private int age;

        //부모 생성자를 호출하면서 name 전달 + 추가로 age초기화
        public Child(string t, int age) : base(t)  //1
        {
            this.age = age;
            Console.WriteLine($"자식 생성자: 나이 = {age}");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름 : {name}, 나이 : {age} ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child("홍길동", 25); //0
            child.ShowInfo();
        }
    }
}
