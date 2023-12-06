using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services
{
    /// <summary>
    /// Класс функциональности, выполняемой над пользователями
    /// </summary>
    public class UserService
    {
        MessageService messageService;
        IUserRepository userRepository;
        FriendService friendService;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            messageService = new MessageService(new MessageRepository(), userRepository);
            friendService = new FriendService(new FriendRepository(),userRepository);
        }


        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userRegistrationData"></param>
        public void Register(UserRegistrationData userRegistrationData)
        {
            if (String.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(userRegistrationData.Password))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException();

            if (userRegistrationData.Password.Length < 8)
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentNullException();

            if (userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentNullException();

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };

            if (userRepository.Create(userEntity) == 0)
                throw new Exception();

        }

        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="userAuthenticationData"></param>
        /// <returns></returns>
        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
            if (findUserEntity is null) throw new UserNotFoundException();

            if (findUserEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException();

            return ConstructUserModel(findUserEntity);
        }

        /// <summary>
        /// Поиск пользователя по E-mail
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Пользователя, чей e-mail соотвествует введенному адресу</returns>
        public User FindByEmail(string email)
        {
            var findUserEntity = userRepository.FindByEmail(email);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <param name="user"></param>
        public void Update(User user)
        {
            var updatableUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };

            if (this.userRepository.Update(updatableUserEntity) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Создание пользователя по классу UserEntity 
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        private User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessages = messageService.GetIncomingMessagesByUserId(userEntity.id);

            var outgoingMessages = messageService.GetOutcomingMessagesByUserId(userEntity.id);

            var friends = friendService.GetFriendsByUserId(userEntity.id);
            return new User(userEntity.id,
                          userEntity.firstname,
                          userEntity.lastname,
                          userEntity.password,
                          userEntity.email,
                          userEntity.photo,
                          userEntity.favorite_movie,
                          userEntity.favorite_book,
                          incomingMessages,
                          outgoingMessages,
                          friends);
        }


    }
}
