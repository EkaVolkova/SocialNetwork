using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Интерфейс для работы с таблицей Friend БД
    /// </summary>
    public interface IFriendRepository
    {
        /// <summary>
        /// Функция создания в таблице friends БД строки, соотвветствующей сущности FriendEntity
        /// </summary>
        /// <param name="friendEntity"></param>
        /// <returns></returns>
        int Create(FriendEntity friendEntity);

        /// <summary>
        /// Функция получения всех строк таблицы friends БД в формате списка сущностей FriendEntity
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<FriendEntity> FindAllByUserId(int userId);

        /// <summary>
        /// Удаляет пользователя из таблицы friends БД по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);
    }

}

