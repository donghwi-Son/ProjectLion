using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacter
{
    class Warrior : GameCharacter
    {
        public Warrior(string name) : base(name, 100, 15, 10)
        {

        }


        public override void BasicAttack(GameCharacter target)
        {
            Console.WriteLine($"{name}이 {target.name}에게 야구 빳다를 던집니다!");
            target.TakeDamage(attack);
        }

        public override void SpecialAttack(GameCharacter target)
        {
            Console.WriteLine($"{name}이 {target.name}에게 날카로운 짱돌을 던집니다!");
            target.TakeDamage(attack * 2);
        }


    }
}
