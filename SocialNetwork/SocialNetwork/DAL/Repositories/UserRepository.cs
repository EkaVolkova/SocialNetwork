using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Класс для работы с таблицей User БД
    /// </summary>
    public class UserRepository : BaseRepository, IUserRepository
    {
        /// <summary>
        /// Функция создания в таблице users БД строки, соотвветствующей сущности UserEntity
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns>Статус</returns>
        public int Create(UserEntity userEntity)
        {
            return Execute(@"insert into users (firstname,lastname,password,email) 
                             values (:firstname,:lastname,:password,:email)", userEntity);
        }

        /// <summary>
        /// Функция получения всех строк таблицы users БД в формате списка сущностей UserEntity
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserEntity> FindAll()
        {
            return Query<UserEntity>("select * from users");
        }

        /// <summary>
        /// Функция получения строки таблицы users БД в формате сущности UserEntity с соответствующим E-mail
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public UserEntity FindByEmail(string email)
        {
            return QueryFirstOrDefault<UserEntity>("select * from users where email = :email_p", new { email_p = email });
        }


        /// <summary>
        /// Функция получения строки таблицы users БД в формате сущности UserEntity с соответствующим ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserEntity FindById(int id)
        {
            return QueryFirstOrDefault<UserEntity>("select * from users where id = :id_p", new { id_p = id });
        }

        /// <summary>
        /// Функция перезаписи строки таблицы users БД, соответствующей сущности UserEntity
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public int Update(UserEntity userEntity)
        {
            return Execute(@"update users set firstname = :firstname, lastname = :lastname, password = :password, email = :email,
                             photo = :photo, favorite_movie = :favorite_movie, favorite_book = :favorite_book where id = :id", userEntity);
        }

        /// <summary>
        /// Удаляет пользователя из таблицы users БД по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(int id)
        {
            return Execute("delete from users where id = :id_p", new { id_p = id });
        }
    }

}

