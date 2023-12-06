using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Tests
{
    /// <summary>
    /// Класс для тестирования класса UserService
    /// </summary>
    [TestClass]
    public class UserServiceTests
    {
        UserAuthenticationData userAuthentication = new UserAuthenticationData()
        {
            FirstName = "Алина",
            Password = "123456789",
        };
        UserEntity userEntity = new UserEntity()
        {
            id = 1,
            firstname = "Алина",
            lastname = "Иванова",
            password = "123456789",
            email = "email1@gmail.com",
            photo = "photo1.jpg",
            favorite_movie = "Thor",
            favorite_book = "Bible"
        };


        /// <summary>
        /// Функция тестирования авторизации. Условие прохождения: Метод завершается без выбрасывания исключений
        /// </summary>
        [TestMethod]
        public void UserAuthenticateMustReturnNoException()
        {
            

            var mockIUserRepository = new Mock<IUserRepository>();
            mockIUserRepository.Setup(v => v.FindByEmail(userAuthentication.Email)).Returns(userEntity);
            UserService userService = new UserService(mockIUserRepository.Object);
            Assert.IsNotNull(userService.Authenticate(userAuthentication));
            Assert.AreEqual(userAuthentication.FirstName, userService.Authenticate(userAuthentication).FirstName);
            Assert.AreEqual(userAuthentication.Password, userService.Authenticate(userAuthentication).Password);
        }

        /// <summary>
        /// Функция тестирования авторизации. 
        /// Условие прохождения: Метод завершается выбрасыванием пользовательского исключения UserNotFoundException
        /// </summary>
        [TestMethod]
        public void UserAuthenticateMustReturnUserNotFoundException()
        {
            var userAuthentication = new UserAuthenticationData()
            {
                FirstName = "Алина",
                Password = "123456789",
            };

            var userEntityRegistration = new UserEntity();
            var mockIUserRepository = new Mock<IUserRepository>();
            UserService userService = new UserService(mockIUserRepository.Object);
            Assert.ThrowsException<UserNotFoundException>(() => userService.Authenticate(userAuthentication));
        }

        [TestMethod]
        public void FindByEmailMustReturnUserEntity()
        {
            string email = "email1@gmail.com";
            var userEntityRegistration = new UserEntity();
            var mockIUserRepository = new Mock<IUserRepository>();
            mockIUserRepository.Setup(v => v.FindByEmail(email)).Returns(userEntity);
            UserService userService = new UserService(mockIUserRepository.Object);
            Assert.IsNotNull(userService.FindByEmail(email));
            Assert.AreEqual(email, userService.FindByEmail(email).Email);
        }

        [TestMethod]
        public void FindByEmailMustReturnUserNotFoundException()
        {
            string email = "email1@gmail.com";
            var userEntityRegistration = new UserEntity();
            var mockIUserRepository = new Mock<IUserRepository>();
            UserService userService = new UserService(mockIUserRepository.Object);
            Assert.ThrowsException<UserNotFoundException>(() => userService.FindByEmail(email));
        }
    }
}
    