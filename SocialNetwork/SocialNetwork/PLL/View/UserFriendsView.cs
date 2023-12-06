using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.PLL.View
{
    /// <summary>
    /// Класс представления друзей
    /// </summary>
    public class UserFriendsView
    {
        /// <summary>
        /// Меню вывода списка друзей
        /// </summary>
        /// <param name="friends"></param>
        public void Show(IEnumerable<Friend> friends)
        {
            if(friends.Count() == 0)
            {
                Console.WriteLine("У вас пока нет друзей");
                return;
            }    
            Console.WriteLine("Ваши друзья: ");
            friends.ToList().ForEach(f =>
            {
                Console.WriteLine($"Имя: {f.FriendName}\t E-mail: {f.FriendEmail}");
            });
        }
    }
}
