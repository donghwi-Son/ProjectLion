using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG_1
{
    public class Player
    {
        public Info m_tInfo;

        public void GetDamage(int att) //데미지 받기
        {
            m_tInfo.iHp -= att;
        }
        public Info GetInfo() //정보 외부 전달
        { 
            return m_tInfo;
        }

        public void SetHp(int hp) //hp설정
        { 
            m_tInfo.iHp = hp;
        }

        public void SelectJob()
        {
            m_tInfo = new Info();
            Console.WriteLine("직업을 선택하세요(1.기사 2.마법사 3.도둑) : ");
            int iInput = int.Parse(Console.ReadLine());

            switch (iInput)
            {
                case 1:
                    m_tInfo.strName = "기사";
                    m_tInfo.iHp = 100;
                    m_tInfo.iAttack = 10;
                    break;
                case 2:
                    m_tInfo.strName = "마법사";
                    m_tInfo.iHp = 90;
                    m_tInfo.iAttack = 15;
                    break;
                case 3:
                    m_tInfo.strName = "도둑";
                    m_tInfo.iHp = 80;
                    m_tInfo.iAttack = 13;
                    break;

                default:
                    break;
            }

        }

        public void Render()
        {
            Console.WriteLine("===================");
            Console.WriteLine("직업 : "+m_tInfo.strName);
            Console.WriteLine("체력 : "+m_tInfo.iHp);
            Console.WriteLine("공격력 : "+m_tInfo.iAttack);
        }




        public Player() { }
        ~Player() { }






    }
}
