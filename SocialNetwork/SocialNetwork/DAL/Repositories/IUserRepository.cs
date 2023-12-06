using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Интерфейс для работы с таблицей User БД
    /// </summary>
    public interface IUserRepository
    {

        /// <summary>
        /// Функция создания в таблице users БД строки, соотвветствующей сущности UserEntity
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns>Статус</returns>
        int Create(UserEntity userEntity);

        /// <summary>
        /// Функция получения всех строк таблицы friends БД в формате списка сущностей FriendEntity
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserEntity FindByEmail(string email);

        /// <summary>
        /// Функция получения всех строк таблицы users БД в формате списка сущностей UserEntity
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserEntity> FindAll();

        /// <summary>
        /// Функция получения строки таблицы users БД в формате сущности UserEntity с соответствующим ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserEntity FindById(int id);

        /// <summary>
        /// Функция перезаписи строки таблицы users БД, соответствующей сущности UserEntity
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        int Update(UserEntity userEntity);

        /// <summary>
        /// Удаляет пользователя из таблицы users БД по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteById(int id);
    }

}

