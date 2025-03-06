using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace project_LL1
{
    class Player
    {
        public int playerX;
        public int playerY;
        public int powerup;
        public int maxhp;
        public List<Item> item = new List<Item>();
        public Bullet[] bullet = new Bullet[35];

        public Player()
        {

            playerX = 25;
            playerY = 33;
            powerup = 0;
            maxhp = 5;
            for (int i = 0; i < 35; i++)
            {
                bullet[i] = new Bullet();
            }
        }
        public void Playermove()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (playerX > 0)
                            {
                                playerX--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (playerX < 47)
                            {
                                playerX++;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (playerY > 0)
                            {
                                playerY--;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (playerY < 33)
                            {
                                playerY++;
                            }
                            break;
                        case ConsoleKey.Spacebar:
                            Fire();
                            break;
                        case ConsoleKey.Escape:

                            break;
                    }
                }
            }
        }

        public void Fire()
        {
            for (int i = 0; i < 35; i++)
            {
                if (!bullet[i].isFired)
                {
                    bullet[i].isFired = true;
                    bullet[i].bulletX = playerX + 1;
                    bullet[i].bulletY = playerY - 1;
                    break;
                }
            }
        }

        public void CheckItemCollision()
        {
            for (int i = item.Count - 1; i >= 0; i--)
            {
                if (item[i].itemX <= playerX + 1 && item[i].itemX >= playerX - 1 && item[i].itemY <= playerY + 1 && item[i].itemY >= playerY - 1)
                {
                    powerup++; // 파워업 증가
                    item.RemoveAt(i); // 아이템 제거
                }
            }
        }

        public void CheckenemyCollision(Enemy[] enemy)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i].isAlive)
                {
                    if (enemy[i].enemyY <= playerY && enemy[i].enemyY >= playerY - 1)
                    {
                        if (enemy[i].enemyX + 5 >= playerX && enemy[i].enemyX <= playerX)
                        {
                            enemy[i].isAlive = false;
                            maxhp -= 1;
                        }
                    }
                }
            }
        }

        public void BBCollision(List<BossBullet> bb)
        {
            for (int i = bb.Count - 1; i >= 0; i--)
            {
                if (bb[i].bulletX >= playerX-5 && bb[i].bulletX <= playerX-3 && bb[i].bulletY <= playerY && bb[i].bulletY >= playerY-1)
                {
                    maxhp--;
                    bb.RemoveAt(i);
                }
            }
        }

    }
    class Enemy
    {
        public int enemyX;
        public int enemyY;
        public bool isAlive;
        public bool getShoot;
        public int horizonDelay;
        static Random rand = new Random();
        public Enemy()
        {
            enemyX = rand.Next(0, 45);
            enemyY = 0;
            isAlive = false;
            getShoot = false;
            horizonDelay = rand.Next(500, 1000);
        }

        public void EnemyDown()
        {
            enemyY++;

        }

        public void EnemyLeftRight()
        {
            int a = rand.Next(0, 3);
            switch (a)
            {
                case 0:
                    if (enemyX < 45)
                        enemyX++;
                    break;
                case 1:
                    if (enemyX > 1)
                        enemyX--;
                    break;
                case 2:
                    break;
            }

        }

        public void Respawn()
        {
            enemyX = rand.Next(0, 45);
            enemyY = 0;
            isAlive = true;
            getShoot = false;
            horizonDelay = rand.Next(500, 1000);
        }

    }
    class BossBullet
    {
        public int bulletX;
        public int bulletY;

        public BossBullet(int x, int y)
        {
            bulletX = x;
            bulletY = y;
        }

        public void MoveBullet()
        {
            bulletY++;
        }
    }
    class Bullet
    {
        public int bulletX;
        public int bulletY;
        public bool isFired;
        static Random rand = new Random();

        public void BulletMove()
        {
            bulletY--;
        }

        public bool bulletCrush(Enemy[] enemy, List<Item> item, Boss boss, int power)
        {
            if (boss.isAlive)
            {
                if (bulletX >= boss.bossX && bulletX <= boss.bossX + 9 && bulletY == boss.bossY)
                {
                    if (power >= 5)
                    {
                        boss.TakeDamage(2);
                        boss.itemdropdmg += 2;
                    }
                    else
                    {
                        boss.TakeDamage(1);
                        boss.itemdropdmg += 1;
                    }
                    isFired = false;
                    if (boss.itemdropdmg / 20 == 1)
                    {
                        boss.itemdropdmg -= 20;
                        item.Add(new Item(boss.bossX + 4, boss.bossY));
                    }



                    return true;
                }
            }
            else
            {

                for (int i = 0; i < enemy.Length; i++)
                {
                    if (enemy[i].isAlive)
                    {
                        if (enemy[i].enemyY == bulletY)
                        {
                            if (enemy[i].enemyX + 5 >= bulletX && enemy[i].enemyX <= bulletX)
                            {
                                enemy[i].isAlive = false;
                                isFired = false;
                                enemy[i].getShoot = true;
                                if (rand.Next(0, 10) < 2)
                                {
                                    item.Add(new Item(enemy[i].enemyX, enemy[i].enemyY));
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }

    class Item
    {

        public int itemX;
        public int itemY;
 

        public Item(int x, int y)
        {
            itemX = x;
            itemY = y;
        }
        public void ItemMove()
        {
            itemY++;
        }
    }

    class Boss
    {
        public int bossX;
        public int bossY;
        public int bossHP;
        public bool isAlive;
        public int itemdropdmg;
        static Random rand = new Random();
        public Boss()
        {
            bossX = 20;
            bossY = 5;
            bossHP = 100;
            itemdropdmg = 0;
            isAlive = false;
        }

        public void MoveBoss()
        {
            int moveDirection = rand.Next(0, 3);
            if (moveDirection == 0 && bossX > 8) bossX--;
            if (moveDirection == 1 && bossX < 32) bossX++;
        }

        public void TakeDamage(int dmg)
        {
            bossHP -= dmg;
            if (bossHP <= 0)
            {
                isAlive = false;
            }
        }
    }
    class GameUI
    {
        public void DrawPlayer(Player player)
        {
            if (player.powerup < 5)
            {
                Console.SetCursorPosition(player.playerX + 1, player.playerY - 1);
                Console.Write("^");
                Console.SetCursorPosition(player.playerX, player.playerY);
                Console.Write("^^^");
            }
            else
            {
                Console.SetCursorPosition(player.playerX + 1, player.playerY - 1);
                Console.Write("▲");
                Console.SetCursorPosition(player.playerX, player.playerY);
                Console.Write("┏╋┓");
            }
        }

        public void DrawEnemy(Enemy[] enemy, string enemyStripe)
        {
            for (int i = 0; i < 20; i++)
            {
                if (enemy[i].isAlive)
                {
                    Console.SetCursorPosition(enemy[i].enemyX, enemy[i].enemyY);
                    Console.Write(enemyStripe);
                }
            }
        }

        public void DrawBullet(Bullet[] bullet, int power)
        {
            for (int i = 0; i < 35; i++)
            {
                if (bullet[i].isFired)
                {
                    if (power < 5)
                    {
                        Console.SetCursorPosition(bullet[i].bulletX, bullet[i].bulletY - 2);
                        Console.Write("∧");


                    }
                    else
                    {
                        Console.SetCursorPosition(bullet[i].bulletX, bullet[i].bulletY - 2);
                        Console.Write("◎");
                    }
                }
            }
        }

        public void DrawBB(List<BossBullet> bb)
        {
            for (int i = bb.Count - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(bb[i].bulletX+5, bb[i].bulletY+1);
                Console.Write("v");
            }
        }
        public void DrawItem(List<Item> item)
        {
            foreach (Item i in item)
            {
                Console.SetCursorPosition(i.itemX, i.itemY);
                Console.Write("I");
            }
        }

        public void DrawScore(int score, int power, int hp)
        {
            Console.SetCursorPosition(38, 0);
            Console.Write("Score: " + score);
            Console.SetCursorPosition(5, 34);
            Console.Write("Upgrade : □□□□□");
            if (power >= 5)
            {
                power = 5;
            }
            for (int i = 0; i < power; i++)
            {

                Console.SetCursorPosition(15 + i, 34);
                Console.Write("■");

            }
            Console.SetCursorPosition(4, 0);
            Console.Write("HP");
            for (int i = 0; i < hp; i++)
            {
                Console.SetCursorPosition(6 + i, 0);
                Console.Write("♥");
            }
        }

        public void DrawBoss(Boss boss)
        {
            if (boss.isAlive)
            {
                Console.SetCursorPosition(boss.bossX, boss.bossY);
                Console.Write("(っ ｀ᾥ ´  c)");
                Console.SetCursorPosition(boss.bossX, boss.bossY - 1);
                Console.Write($"HP: {boss.bossHP}");
            }
        }

    }


    class Program
    {
        static Enemy[] enemy = new Enemy[20];
        static Player player = new Player();
        static Boss boss = new Boss();
        static List<BossBullet> bb = new List<BossBullet>();
        static int score = 0;
        static void Main(string[] args)
        {

            Console.SetWindowSize(50, 35);
            Console.SetBufferSize(50, 35);
            Console.CursorVisible = false;
            MainMenu();
            GameUI gameUI = new GameUI();



            for (int i = 0; i < 20; i++)
            {
                enemy[i] = new Enemy();
                Enemy currentenemy = enemy[i];
                Thread enemyLRThread = new Thread(() => EnemyLR(currentenemy));
                enemyLRThread.Start();
            }

            Bullet bullet = new Bullet();

            Random rand = new Random();

            Thread playerThread = new Thread(player.Playermove);
            playerThread.Start();
            Thread enemyDownThread = new Thread(EnemyDown);
            enemyDownThread.Start();

            Thread enemyRespawnThread = new Thread(EnemyRespawn);
            enemyRespawnThread.Start();
            Thread bulletMoveThread = new Thread(BulletMove);
            bulletMoveThread.Start();
            Thread itemMoveThread = new Thread(ItemMove);
            itemMoveThread.Start();
            Thread bossMoveThread = new Thread(BossMove);
            bossMoveThread.Start();
            Thread bossAttThread = new Thread(BossAttack);
            bossAttThread.Start();
            Thread bbMoveThread = new Thread(BossBulletMove);
            bbMoveThread.Start();
            
            Console.Clear();
            while (true)
            {
                Console.Clear();
                player.CheckItemCollision();
                player.BBCollision(bb);
                gameUI.DrawPlayer(player);
                if (score < 30)
                {
                    if (score < 10)
                    {
                        gameUI.DrawEnemy(enemy, "('.')");
                    }
                    else if (score < 20)
                    {
                        gameUI.DrawEnemy(enemy, "(°ㅂ°)");
                    }
                    else
                    {
                        gameUI.DrawEnemy(enemy, "(｀⌒´)");
                    }
                    player.CheckenemyCollision(enemy);
                }
                else
                {
                    boss.isAlive = true;
                    gameUI.DrawBoss(boss);
                }
                gameUI.DrawBB(bb);

                gameUI.DrawBullet(player.bullet, player.powerup);
                gameUI.DrawItem(player.item);

                gameUI.DrawScore(score, player.powerup, player.maxhp);

                if (player.maxhp == 0)
                {
                    Console.Clear();
                    break;
                }
                if(boss.bossHP == 0)
                {
                    Console.Clear(); 
                    break;
                }

                Thread.Sleep(50);
            }
            if (player.maxhp == 0)
            {
                EndScene();
            }
            if(boss.bossHP == 0)
            {
                ClearScene();
            }
        }

        static void ItemMove()
        {
            while (true)
            {
                for (int i = player.item.Count - 1; i >= 0; i--)
                {
                    if (player.item[i].itemY < 33)
                    {
                        player.item[i].ItemMove();
                    }
                    else
                    {
                        player.item.RemoveAt(i);
                    }
                }
                Thread.Sleep(500);
            }
        }

        static void EnemyDown()
        {
            while (true)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (enemy[i].isAlive)
                    {
                        enemy[i].EnemyDown();
                    }
                    if (enemy[i].enemyY == 33)
                    {
                        enemy[i].isAlive = false;
                    }
                }
                if (score < 10)
                {
                    Thread.Sleep(400);
                }
                else if (score < 20)
                {
                    Thread.Sleep(300);
                }
                else
                {
                    Thread.Sleep(200);
                }
            }
        }
        static void EnemyLR(Enemy enemy)
        {
            while (true)
            {
                if (enemy.isAlive)
                {
                    enemy.EnemyLeftRight();
                    Thread.Sleep(enemy.horizonDelay);
                }
                else
                {
                    Thread.Sleep(100);
                }


            }
        }

        static void EnemyRespawn()
        {
            while (true)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (!enemy[i].isAlive)
                    {
                        enemy[i].Respawn();
                        break;
                    }
                }
                Thread.Sleep(2000);
            }
        }

        static void BossMove()
        {
            while (true)
            {
                if (boss.isAlive)
                {
                    boss.MoveBoss();
                    Thread.Sleep(200);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }
        static void BossAttack()
        {
            Random rand = new Random();

            while (true)
            {
                if (boss.isAlive)
                {
                    if (rand.Next(0, 10) < 5)
                    {
                        bb.Add(new BossBullet(boss.bossX + 4, boss.bossY + 1));
                    }
                    else
                    {
                        bb.Add(new BossBullet(boss.bossX - 4, boss.bossY + 1)); // 왼쪽
                        bb.Add(new BossBullet(boss.bossX + 4, boss.bossY + 1));  // 중앙
                        bb.Add(new BossBullet(boss.bossX + 12, boss.bossY + 1));  // 오른쪽

                    }
                }
                Thread.Sleep(3000);
            }
        }
        static void BossBulletMove()
        {
            while (true)
            {
                if (boss.isAlive)
                {
                    for (int i = bb.Count - 1; i >= 0; i--)
                    {
                        bb[i].MoveBullet();

                        if (bb[i].bulletY >= 33)
                        {
                            bb.RemoveAt(i);
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }
        static void BulletMove()
        {
            while (true)
            {
                for (int i = 0; i < 35; i++)
                {
                    if (player.bullet[i].isFired)
                    {
                        player.bullet[i].BulletMove();
                        if (player.bullet[i].bulletCrush(enemy, player.item, boss, player.powerup))
                        {
                            score++;
                        }
                        if (player.bullet[i].bulletY == 2)
                        {
                            player.bullet[i].isFired = false;
                        }
                    }

                }
                Thread.Sleep(100);
            }
        }



        static void EndScene()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 5);
            Console.WriteLine(" _____                         ");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("|  __ \\                        ");
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("| |  \\/  __ _  _ __ ___    ___ ");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("| | __  / _` || '_ ` _ \\  / _ \\");
            Console.SetCursorPosition(10, 9);
            Console.WriteLine("| |_\\ \\| (_| || | | | | ||  __/");
            Console.SetCursorPosition(10, 10);
            Console.WriteLine(" \\____/ \\__,_||_| |_| |_| \\___|");
            Console.SetCursorPosition(10, 15);
            Console.WriteLine(" _____                    ");
            Console.SetCursorPosition(10, 16);
            Console.WriteLine("|  _  |                   ");
            Console.SetCursorPosition(10, 17);
            Console.WriteLine("| | | |__   __  ___  _ __ ");
            Console.SetCursorPosition(10, 18);
            Console.WriteLine("| | | |\\ \\ / / / _ \\| '__|");
            Console.SetCursorPosition(10, 19);
            Console.WriteLine("\\ \\_/ / \\ V / |  __/| |   ");
            Console.SetCursorPosition(10, 20);
            Console.WriteLine(" \\___/   \\_/   \\___||_|   ");

        }
        static void MainMenu()
        {
            int pressbuttontime = Environment.TickCount;
            bool showPressAnyButton = true;
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            for (int i = 1; i < 34; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("┃                                                ┃");
            }
            Console.SetCursorPosition(0, 34);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.SetCursorPosition(3, 5);
            Console.Write(" _____  _          _  _                     ");
            Console.SetCursorPosition(3, 6);
            Console.Write("/  ___|| |        (_)| |                    ");
            Console.SetCursorPosition(3, 7);
            Console.Write("\\ `--. | |_  _ __  _ | | __  ___  _ __  ___ ");
            Console.SetCursorPosition(3, 8);
            Console.Write(" `--. \\| __|| '__|| || |/ / / _ \\| '__|/ __|");
            Console.SetCursorPosition(3, 9);
            Console.Write("/\\__/ /| |_ | |   | ||   < |  __/| |   \\__ \\");
            Console.SetCursorPosition(3, 10);
            Console.Write("\\____/  \\__||_|   |_||_|\\_\\ \\___||_|   |___/");
            Console.SetCursorPosition(3, 11);
            Console.Write("============================================");

            Console.SetCursorPosition(13, 12);
            Console.Write(" __   _____    ___  _____ ");
            Console.SetCursorPosition(13, 13);
            Console.Write("/  | |  _  |  /   ||  ___|");
            Console.SetCursorPosition(13, 14);
            Console.Write("`| | | |_| | / /| ||___ \\ ");
            Console.SetCursorPosition(13, 15);
            Console.Write(" | | \\____ |/ /_| |    \\ \\");
            Console.SetCursorPosition(13, 16);
            Console.Write("_| |_.___/ /\\___  |/\\__/ /");
            Console.SetCursorPosition(13, 17);
            Console.Write("\\___/\\____/     |_/\\____/ ");
            while (true)
            {
                if (Environment.TickCount - pressbuttontime > 500)
                {
                    showPressAnyButton = !showPressAnyButton; // 상태 전환
                    pressbuttontime = Environment.TickCount;
                }

                // "Press Any Button" 텍스트만 깜빡이게 처리
                Console.SetCursorPosition(17, 25);
                if (showPressAnyButton)
                {
                    Console.Write("Press Any Button");
                }
                else
                {
                    Console.Write("                   "); // 공백으로 덮어씌우기
                }

                // 키 입력 감지
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    break; // 키가 입력되면 루프 종료
                }
            }

        }

        static void ClearScene()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.Write(" _____  _                     _ ");
            Console.SetCursorPosition(10, 11);
            Console.Write("/  __ \\| |                   | |");
            Console.SetCursorPosition(10, 12);
            Console.Write("| /  \\/| |  ___   __ _  _ __ | |");
            Console.SetCursorPosition(10, 13);
            Console.Write("| |    | | / _ \\ / _` || '__|| |");
            Console.SetCursorPosition(10, 14);
            Console.Write("| \\__/\\| ||  __/| (_| || |   |_|");
            Console.SetCursorPosition(10, 15);
            Console.Write(" \\____/|_| \\___| \\__,_||_|   (_)");
        }
    }

}
