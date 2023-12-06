using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.PLL.View
{
    /// <summary>
    /// Класс для представления входящих сообщений
    /// </summary>
    public class UserIncomingMessageView
    {
        /// <summary>
        /// Меню для представления входящих сообщений
        /// </summary>
        /// <param name="incomingMessages"></param>
        public void Show(IEnumerable<Message> incomingMessages)
        {
            Console.WriteLine("Входящие сообщения");


            if (incomingMessages.Count() == 0)
            {
                Console.WriteLine("Входящих сообщения нет");
                return;
            }

            incomingMessages.ToList().ForEach(message =>
            {
                Console.WriteLine("От кого:\r\n{0}\r\n\nТекст сообщения:\r\n {1}\r\n\n\n", message.SenderEmail, message.Content);
            });
        }

    }
}
