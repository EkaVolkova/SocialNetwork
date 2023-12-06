using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.View
{
    public class MessageSendingView
    {
        private MessageService messageService;
        public MessageSendingView(MessageService messageService)
        {
            this.messageService = messageService;
        }

        /// <summary>
        /// Меню отправки сообщений
        /// </summary>
        /// <param name="user"></param>
        public void Show(User user)
        {
            var messageSendingData = new MessageSendingData();
            Console.WriteLine("Введите email");
            messageSendingData.Email = Console.ReadLine();
            Console.WriteLine("Введите сообщение");
            messageSendingData.Message = Console.ReadLine();
            messageSendingData.Id = user.Id;
            try
            {
                messageService.SendMessage(messageSendingData);
                SuccessMessage.Show("Сообщение отправлено");
            }
            catch(UserNotFoundException)
            {
                AllertMessage.Show("Адресат не найден");
            }
            catch(ArgumentNullException)
            {
                AllertMessage.Show("Ошибка формата собщения");
            }
            catch (Exception)
            {
                AllertMessage.Show("Произошла ошибка при отправке сообщения!");
            }



        }
    }
}
