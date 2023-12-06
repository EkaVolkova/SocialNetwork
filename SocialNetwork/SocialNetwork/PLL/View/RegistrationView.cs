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
    public class RegistrationView
    {
        private UserService userService;
        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Меню регистрации пользователя
        /// </summary>
        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.WriteLine("Для создания нового профиля введите данные");
            Console.Write("Ваше имя: ");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Ваша фамилия: ");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Пароль: ");
            userRegistrationData.Password = Console.ReadLine();

            Console.Write("E-mail: ");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                userService.Register(userRegistrationData);

                SuccessMessage.Show("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
            }
            catch (ArgumentNullException)
            {
                AllertMessage.Show("Введите корректное значение.");
            }
            catch (Exception)
            {
                AllertMessage.Show("Произошла ошибка при регистрации.");
            }
        }
    }
}
