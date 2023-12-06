using System;

namespace SocialNetwork.PLL.Helper
{
    public class AllertMessage
    {
        public static void Show(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
