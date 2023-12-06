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
    public class AuthenticationView
    {
        

        UserService userService;
        public AuthenticationView(UserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Меню аутентификации
        /// </summary>
        public void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.WriteLine("Введите почтовый адрес:");
            authenticationData.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            authenticationData.Password = Console.ReadLine();

            try
            {
                User user = userService.Authenticate(authenticationData);

                SuccessMessage.Show($"Вы успешно вошли в социальную сеть! Добро пожаловать {user.FirstName}");
                Program.userMenuView.Show(user);

            }
            catch (WrongPasswordException)
            {
                AllertMessage.Show("Пароль не корректный!");
            }
            catch (UserNotFoundException)
            {
                AllertMessage.Show("Пользователь не найден!");
            }
        }
    }
}
