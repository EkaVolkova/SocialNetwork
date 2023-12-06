using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Интерфейс для работы с таблицей Message БД
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// Функция создания в таблице messages БД строки, соотвветствующей сущности MessageEntity
        /// </summary>
        /// <param name="messageEntity"></param>
        /// <returns></returns>
        int Create(MessageEntity messageEntity);

        /// <summary>
        /// Функция получения всех строк таблицы messages БД в формате списка сущностей MessageEntity
        /// </summary>
        /// <param name="senderId"></param>
        /// <returns></returns>
        IEnumerable<MessageEntity> FindBySenderId(int senderId);

        /// <summary>
        /// Функция получения строкИ таблицы messages БД в формате сущности MessageEntity по ID
        /// </summary>
        /// <param name="recipientId"></param>
        /// <returns></returns>
        IEnumerable<MessageEntity> FindByRecipientId(int recipientId);
        int DeleteById(int messageId);
    }

}

