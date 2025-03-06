using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacter
{
    public abstract class GameCharacter
    {
        public string name { get; set; }
        public int health { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }


        protected GameCharacter(string name, int health, int attack, int defense)
        {
            this.name = name;
            this.health = health;
            this.attack = attack;
            this.defense = defense;
        }

        public abstract void BasicAttack(GameCharacter target);

        public abstract void SpecialAttack(GameCharacter target);

        public void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - defense);
            health = Math.Max(0, health - actualDamage);
            Console.WriteLine($"{name}이 {actualDamage}의 데미지를 받았습니다. 남은 체력 : {health}");


        }



    }

}
