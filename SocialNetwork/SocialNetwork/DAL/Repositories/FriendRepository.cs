using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Класс для работы с таблицей friends БД
    /// </summary>
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        /// <summary>
        /// Функция получения всех строк таблицы friends БД в формате списка сущностей FriendEntity
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
            return Query<FriendEntity>(@"select * from friends where user_id = :user_id", new { user_id = userId });
        }

        /// <summary>
        /// Функция создания в таблице friends БД строки, соотвветствующей сущности FriendEntity
        /// </summary>
        /// <param name="friendEntity"></param>
        /// <returns></returns>
        public int Create(FriendEntity friendEntity)
        {
            return Execute(@"insert into friends (user_id,friend_id) values (:user_id,:friend_id)", friendEntity);
        }

        /// <summary>
        /// Удаляет пользователя из таблицы friends БД по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            return Execute(@"delete from friends where id = :id_p", new { id_p = id });
        }
    }

}

