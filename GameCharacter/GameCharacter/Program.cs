using System;

namespace GameCharacter
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("대충 게임");
            GameCharacter warrior = new Warrior("전사");
            GameCharacter mage = new Mage("마법사");
            warrior.BasicAttack(mage);
            mage.SpecialAttack(mage);
        }
    }

}
