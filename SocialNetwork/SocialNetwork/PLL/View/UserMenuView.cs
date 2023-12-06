using SocialNetwork.BLL.Models;
using System;
using System.Linq;

namespace SocialNetwork.PLL.View
{
    /// <summary>
    /// Класс для меню польователя
    /// </summary>
    public class UserMenuView
    {

        /// <summary>
        /// Вывод меню пользователя 
        /// </summary>
        /// <param name="user"></param>
        public void Show(User user)
        {
            while (true)
            {
                Console.WriteLine("Количество входящих сообщений" + user.IncomingMessages.Count());
                Console.WriteLine("Количество исходящих сообщений" + user.OutgoingMessages.Count());
                Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Добавить в друзья (нажмите 3)");
                Console.WriteLine("Посмотреть список друзей (нажмите 4)");
                Console.WriteLine("Написать сообщение (нажмите 5)");
                Console.WriteLine("Посмотреть входящие сообщения (нажмите 6)");
                Console.WriteLine("Посмотреть исходящие сообщения (нажмите 7)");
                Console.WriteLine("Выйти из профиля (нажмите 8)");

                var key = Console.ReadLine();

                if (key == "8")
                    break;

                switch (key)
                {
                    case "1":
                        {
                            Program.userInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {

                            Program.userDataUpdateView.Show(user);
                            break;
                        }
                    case "3":
                        {
                            Program.friendRequestView.Show(user);
                            break;
                        }
                    case "4":
                        {
                            Program.userFriendsView.Show(user.Friends);
                            break;
                        }
                    case "5":
                        {
                            Program.messageSendingView.Show(user);
                            break;
                        }
                    case "6":
                        {
                            Program.userIncomingMessageView.Show(user.IncomingMessages);
                            break;
                        }
                    case "7":
                        {
                            Program.userOutcomingMessageView.Show(user.OutgoingMessages);
                            break;
                        }
                }
            }
        }
    }
}
