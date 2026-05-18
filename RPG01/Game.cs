using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace RPG01
{
    class Game
    {        
        Player player;

        int width = 10;
        int height = 10;

        Shop shop = new Shop();

        int shopX = 5;
        int shopY = 5;

        Battle battle = new Battle();
        int battleX = 3;
        int battleY = 3;
        char[,] map;
        public Game(Player player)
        {
            this.player = player;

            map = new char[height, width];
            // 맵 생성
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                        map[y, x] = '■'; // 벽
                    else
                        map[y, x] = '□'; // 길
                }
            }
        }
        public void Run()
        {
            Thread.Sleep(1000);

            Console.Clear();
            while (true)
            {
                //Console.Clear();                

                //DrawMap();
                Console.CursorVisible = false;
                ConsoleKeyInfo keyInfo = InputManager.GetKey();

                int nextX = player.X;
                int nextY = player.Y;

                // 이동 계산
                if (InputManager.IsUp(keyInfo))
                    nextY--;

                if (InputManager.IsDown(keyInfo))
                    nextY++;

                if (InputManager.IsLeft(keyInfo))
                    nextX--;

                if (InputManager.IsRight(keyInfo))
                    nextX++;

               
                // 충돌 체크 (벽이면 이동 금지)
                if (nextX >= 0 && nextX < width &&
                    nextY >= 0 && nextY < height &&
                    map[nextY, nextX] != '■')
                {
                    player.X = nextX;
                    player.Y = nextY;
                }

                //상점
                if (player.X == shopX && player.Y == shopY)
                {
                    shop.ShowItems(player);
                    // 상점에서 나오면 옆으로 이동
                    player.X = shopX - 1;
                }

                //던전
                if (player.X == battleX && player.Y == battleY)
                {
                    Monster monster = new Monster();
                    battle.ShowBattle(player, monster);
                    player.X = battleX - 1;
                }
                //인벤토리
                if (keyInfo.Key == ConsoleKey.I)
                {
                    Console.Clear();
                    player.ShowInventory();

                    Console.WriteLine("\n아무 키나 누르면 계속...");
                    Console.ReadKey();
                    
                }
                //내정보
                if (keyInfo.Key == ConsoleKey.U)
                {
                    Console.Clear();
                    player.PlayerInfo();

                    Console.WriteLine("\n아무 키나 누르면 계속...");
                    Console.ReadKey();

                }
                Render();
                Thread.Sleep(100);
            }

        }
        public void Render()
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (player.X == x && player.Y == y)
                        sb.Append("@");

                    else if (x == shopX && y == shopY)
                        sb.Append("S");
                    else if (x == battleX && y == battleY)
                        sb.Append("B");

                    else
                        sb.Append(map[y, x]);
                }
                sb.AppendLine();
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(sb.ToString());
            Console.WriteLine("1. U -> 내 정보 2. I -> 인벤토리 보기");

        }
    }
}
