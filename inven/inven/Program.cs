using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace inven
{
    class Bullet
    {
        public int x;
        public int y;
        public bool isFire;
    
    }
    
    
    class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();
        public int playerX;
        public int playerY;
        public Bullet[] bullets = new Bullet[20];
        public Bullet[] bullets2 = new Bullet[20];
        public Bullet[] bullets3 = new Bullet[20];
        public int score = 0;
        public Item item = new Item();
        public int itemcount = 0;


        public Player()    //Player 생성자
        {
            playerX = 0;
            playerY = 12;

            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new Bullet();
                bullets[i].x = 0;
                bullets[i].y = 0;
                bullets[i].isFire = false;
            }
            for (int i = 0; i < bullets2.Length; i++)
            {
                bullets2[i] = new Bullet();
                bullets2[i].x = 0;
                bullets2[i].y = 0;
                bullets2[i].isFire = false;
            }
            for (int i = 0; i < bullets3.Length; i++)
            {
                bullets3[i] = new Bullet();
                bullets3[i].x = 0;
                bullets3[i].y = 0;
                bullets3[i].isFire = false;
            }



        }    // Player 생성자 끝
        public void GameMain()
        {
            KeyControl();
            PlayerDraw();
            UIscore();
            if(item.ItemAlive)
            {
                item.ItemMove();
                item.ItemDraw();
                ItemCrash();
            }
        }
        public void PlayerDraw()
        {
            string[] player = new string[]
            {
                ">",
                "==>",
                ">"
            };
            for (int i = 0; i < player.Length; i++)
            {
                Console.SetCursorPosition(playerX, playerY + i);
                Console.Write(player[i]);
            }


        }

        public void BulletDraw()
        {
            string bullet = "->";
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i].isFire)
                {
                    Console.SetCursorPosition(bullets[i].x-1, bullets[i].y+1);
                    Console.Write(bullet);
                    bullets[i].x++;
                    if (bullets[i].x > 77)
                    {
                        bullets[i].isFire = false;
                    }



                }
            }


        }
        public void BulletDraw2()
        {
            string bullet = "->";
            for (int i = 0; i < bullets2.Length; i++)
            {
                if (bullets2[i].isFire)
                {
                    Console.SetCursorPosition(bullets2[i].x - 1, bullets2[i].y+1);
                    Console.Write(bullet);
                    bullets2[i].x++;
                    if (bullets2[i].x > 77)
                    {
                        bullets2[i].isFire = false;
                    }



                }
            }


        }
        public void BulletDraw3()
        {
            string bullet = "->";
            for (int i = 0; i < bullets3.Length; i++)
            {
                if (bullets3[i].isFire)
                {
                    Console.SetCursorPosition(bullets3[i].x - 1, bullets3[i].y +1 );
                    Console.Write(bullet);
                    bullets3[i].x++;
                    if (bullets3[i].x > 77)
                    {
                        bullets3[i].isFire = false;
                    }



                }
            }


        }

        public void KeyControl()
        {
            int pressKey;
            if(Console.KeyAvailable)
            {
                pressKey = _getch();
                if (pressKey == 0 || pressKey == 224) // 화살표 키 또는 특수 키 감지
                {
                    pressKey = _getch(); // 실제 키 값 읽기
                }
                switch (pressKey)
                {
                    case 72: // 위
                        playerY--;
                        if (playerY < 1)
                            playerY = 1;
                        break;
                    case 80: // 아래
                        playerY++;
                        if (playerY > 22)
                            playerY = 22;
                        break;
                    case 75: // 왼쪽
                        playerX--;
                        if (playerX < 1)
                            playerX = 1;
                        break;
                    case 77: // 오른쪽
                        playerX++;
                        if (playerX > 75)
                            playerX = 75;
                        break;
                    case 32: // 스페이스바
                        for (int i = 0; i < bullets.Length; i++)
                        {
                            if (!bullets[i].isFire)
                            {
                                bullets[i].isFire = true;
                                bullets[i].x = playerX+5;
                                bullets[i].y = playerY;
                                break;
                            }
                        }
                        if (itemcount >= 1)
                        {
                            for (int i = 0; i < bullets2.Length; i++)
                            {
                                if (!bullets2[i].isFire)
                                {
                                    bullets2[i].isFire = true;
                                    bullets2[i].x = playerX + 5;
                                    bullets2[i].y = playerY - 1; // 기존 총알보다 위쪽에서 발사
                                    break;
                                }
                            }
                        }

                        if (itemcount >= 2)
                        {
                            for (int i = 0; i < bullets3.Length; i++)
                            {
                                if (!bullets3[i].isFire)
                                {
                                    bullets3[i].isFire = true;
                                    bullets3[i].x = playerX + 5;
                                    bullets3[i].y = playerY + 1; // 기존 총알보다 아래쪽에서 발사
                                    break;
                                }
                            }
                        }
                        break;
                }
            }
        }

        public void ClashEnemyAndBullet(Enemy ene)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i].isFire)
                {
                    if (bullets[i].y+1 == ene.enemyY)
                    {
                        if(bullets[i].x >= (ene.enemyX -1) && bullets[i].x <= (ene.enemyX+1))
                        {
                            item.ItemAlive = true;
                            item.ItemX = ene.enemyX;
                            item.ItemY = ene.enemyY;

                            ene.enemyX = 74;
                            ene.enemyY = new Random().Next(2,22);
                            bullets[i].isFire = false;
                            score += 100;
                        }
                    }
                }
            }
            for (int i = 0; i < bullets2.Length; i++)
            {
                if (bullets2[i].isFire)
                {
                    if (bullets2[i].y + 1 == ene.enemyY)
                    {
                        if (bullets2[i].x >= (ene.enemyX - 1) && bullets2[i].x <= (ene.enemyX + 1))
                        {
                            item.ItemAlive = true;
                            item.ItemX = ene.enemyX;
                            item.ItemY = ene.enemyY;

                            ene.enemyX = 74;
                            ene.enemyY = new Random().Next(2, 22);
                            bullets2[i].isFire = false;
                            score += 100;
                        }
                    }
                }
            }
            for (int i = 0; i < bullets3.Length; i++)
            {
                if (bullets3[i].isFire)
                {
                    if (bullets3[i].y + 1 == ene.enemyY)
                    {
                        if (bullets3[i].x >= (ene.enemyX - 1) && bullets3[i].x <= (ene.enemyX + 1))
                        {
                            item.ItemAlive = true;
                            item.ItemX = ene.enemyX;
                            item.ItemY = ene.enemyY;

                            ene.enemyX = 74;
                            ene.enemyY = new Random().Next(2, 22);
                            bullets3[i].isFire = false;
                            score += 100;
                        }
                    }
                }
            }
        }

        public void UIscore()
        {
            Console.SetCursorPosition(63, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(63, 1);
            Console.Write("┃              ┃");
            Console.SetCursorPosition(65, 1);
            Console.Write("Score : " + score);
            Console.SetCursorPosition(63, 2);
            Console.Write("┗━━━━━━━━━━━━━━┛");
        }

        public void ItemCrash()
        {
            if (playerX >= item.ItemX-1 && playerX<= item.ItemX+1 && playerY >= item.ItemY-1 && playerY <= item.ItemY +1)
            {
                item.ItemAlive = false;
                itemcount++;
                
            }
        }

    }


    class Enemy
    {
        public int enemyX;
        public int enemyY;
        Random rand = new Random();
        public Enemy()
        {
            enemyX = 74;
            enemyY = 12;
        }

        public void EnemyDraw()
        {
            string enemy = "<['v']>";
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write(enemy);
        }
        public void EnemyMove()
        {

            enemyX--;
            if(enemyX < 2)
            {
                enemyX = 74;
                enemyY = rand.Next(2, 22);
            }
        }
    }

    class Item
    {
        public string ItemName;
        public string ItemSprite;
        public int ItemX;
        public int ItemY;
        public bool ItemAlive = false;
        public void ItemDraw()
        {
            Console.SetCursorPosition(ItemX, ItemY);
            ItemSprite = "<★>";
            Console.Write(ItemSprite);
                   
        }

        public void ItemMove()
        {
            if(ItemAlive)
            {
                ItemX--;
                if (ItemX < 2)
                {
                    ItemAlive = false;
                }
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetBufferSize(80, 25);
            Console.SetWindowSize(80, 25);

            Player player = new Player();
            Enemy enemy = new Enemy();
            
            int dwTime = Environment.TickCount;
            while(true)
            {
                if (dwTime + 30 < Environment.TickCount)
                {
                    dwTime = Environment.TickCount;
                    Console.Clear();
                    player.GameMain();

                    
                    if (player.itemcount >= 1)
                    {
                        player.BulletDraw2();
                    }
                    if (player.itemcount >= 2)
                    {
                        player.BulletDraw3();
                    }
                    player.BulletDraw();
                    enemy.EnemyMove();

                    enemy.EnemyDraw();

                    player.ClashEnemyAndBullet(enemy);

                }
            }


        }
    }
}
