using SocialNetwork.BLL.Models;
using System;

namespace SocialNetwork.PLL.View
{
    /// <summary>
    /// Класс представления информации о пользователе
    /// </summary>
    public class UserInfoView
    {
        /// <summary>
        /// Меню представления информации о пользователе
        /// </summary>
        /// <param name="user"></param>
        public void Show(User user)
        {
            Console.WriteLine("Информация о моем профиле");
            Console.WriteLine("Мой идентификатор: {0}", user.Id);
            Console.WriteLine("Меня зовут: {0}", user.FirstName);
            Console.WriteLine("Моя фамилия: {0}", user.LastName);
            Console.WriteLine("Мой пароль: {0}", user.Password);
            Console.WriteLine("Мой почтовый адрес: {0}", user.Email);
            Console.WriteLine("Ссылка на моё фото: {0}", user.Photo);
            Console.WriteLine("Мой любимый фильм: {0}", user.FavoriteMovie);
            Console.WriteLine("Моя любимая книга: {0}", user.FavoriteBook);
        }
    }
}
