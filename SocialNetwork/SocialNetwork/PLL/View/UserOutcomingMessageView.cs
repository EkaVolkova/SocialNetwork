using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.PLL.View
{
    /// <summary>
    /// Класс для представления исходящих сообщений
    /// </summary>
    public class UserOutcomingMessageView
    {
        /// <summary>
        /// Меню для представления исходящих сообщений
        /// </summary>
        /// <param name="outcomingMessages"></param>
        public void Show(IEnumerable<Message> outcomingMessages)
        {

            if (outcomingMessages.Count() == 0)
            {
                Console.WriteLine("Исходящих сообщений нет");
                return;
            }

            Console.WriteLine("Исходящие сообщения");
            outcomingMessages.ToList().ForEach(message =>
            {
                Console.WriteLine("Кому:\r\n{0}\r\n\nТекст сообщения:\r\n{1}", message.RecipientEmail, message.Content);
            });
        }

    }
}
