using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG01
{
    class InputManager
    {
        public static ConsoleKeyInfo GetKey()
        {
            return Console.ReadKey(true);
        }
        
        public static bool IsUp(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow;
        }
        public static bool IsDown(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow;
        }
        public static bool IsLeft(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.A || key.Key == ConsoleKey.LeftArrow;
        }
        public static bool IsRight(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.D || key.Key == ConsoleKey.RightArrow;
        }

        public static bool IsExit(ConsoleKeyInfo key)
        {
            return key.Key == ConsoleKey.Q;
        }
    }
}
