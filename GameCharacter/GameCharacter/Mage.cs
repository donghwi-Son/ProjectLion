using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacter
{
    class Mage : GameCharacter
    {
        public Mage(string name) : base(name,80,20,5)
        {

        }


        public override void BasicAttack(GameCharacter target)
        {
            Console.WriteLine($"{name}이 {target.name}에게 마법 구체를 던집니다!");
            target.TakeDamage(attack);
        }

        public override void SpecialAttack(GameCharacter target)
        {
            Console.WriteLine($"{name}이 {target.name}에게 화염 폭발을 시전합니다!");
            target.TakeDamage(attack*2);
        }


    }
}
