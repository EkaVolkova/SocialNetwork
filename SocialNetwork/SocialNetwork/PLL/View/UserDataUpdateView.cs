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
    /// <summary>
    /// Класс для обновления информации о пользоваетеле
    /// </summary>
    public class UserDataUpdateView
    {
        private UserService userService;
        public UserDataUpdateView(UserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Меню обновления информации о пользователе в БД
        /// </summary>
        /// <param name="user"></param>
        public void Show(User user)
        {
            Console.Write("Меня зовут:");
            user.FirstName = Console.ReadLine();

            Console.Write("Моя фамилия:");
            user.LastName = Console.ReadLine();

            Console.Write("Ссылка на моё фото:");
            user.Photo = Console.ReadLine();

            Console.Write("Мой любимый фильм:");
            user.FavoriteMovie = Console.ReadLine();

            Console.Write("Моя любимая книга:");
            user.FavoriteBook = Console.ReadLine();

            userService.Update(user);

            SuccessMessage.Show("Ваш профиль успешно обновлён!");
        }
    }
}
