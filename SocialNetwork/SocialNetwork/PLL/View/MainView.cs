using System;

namespace SocialNetwork.PLL.View
{
    public class MainView
    {
        /// <summary>
        /// Основное меню социальной сети
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Добро пожаловать в социальную сеть.");

            while (true)
            {
                Console.WriteLine("Войти в профиль (нажмите 1)");
                Console.WriteLine("Зарегистрироваться (нажмите 2)");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Program.authenticationView.Show();

                            break;
                        }

                    case "2":
                        {

                            Program.registrationView.Show();

                            break;
                        }
                }
            }
        }
    }
}
