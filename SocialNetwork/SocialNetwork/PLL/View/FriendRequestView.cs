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
    public class FriendRequestView
    {
        private FriendService friendService;
        public FriendRequestView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        /// <summary>
        /// Меню запроса в друзья
        /// </summary>
        /// <param name="user"></param>
        public void Show(User user)
        {
            Console.WriteLine("Введите почтовый адрес друга");

            var friendEmail = Console.ReadLine();
            FriendRequestData friendRequestData = new FriendRequestData()
            {
                FriendEmail = friendEmail,
                UserId = user.Id
            };
            try
            {
                friendService.MakeRequest(friendRequestData);
                SuccessMessage.Show($"Вы подружились с {friendEmail}");
            }
            catch(UserNotFoundException)
            {
                AllertMessage.Show($"Пользователь {friendEmail} не найден");
            }
            catch (Exception)
            {
                AllertMessage.Show("Произошла ошибка при добавлении в друзья!");
            }

        }
    }
}
