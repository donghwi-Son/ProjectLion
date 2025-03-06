using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG_1
{
    public class Monster
    {
        public Info m_tMonster;

        public void GetDamage(int att)
        {
            m_tMonster.iHp -= att;
        }
        public void SetMonster(Info tMonster)
        {
            m_tMonster = tMonster;
        }
        public Info GetMonster()
        {
            return m_tMonster;
        }
        public void Render()
        {
            Console.WriteLine("===================");
            Console.WriteLine("몬스터 이름 : " + m_tMonster.strName);
            Console.WriteLine("체력 : " + m_tMonster.iHp);
            Console.WriteLine("공격력 : " + m_tMonster.iAttack);
        }

    }
}
