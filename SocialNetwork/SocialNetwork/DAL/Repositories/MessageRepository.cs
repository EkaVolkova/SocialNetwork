using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Класс для работы с таблицей Message БД
    /// </summary>
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        /// <summary>
        /// Функция создания в таблице messages БД строки, соотвветствующей сущности MessageEntity
        /// </summary>
        /// <param name="messageEntity"></param>
        /// <returns></returns>
        public int Create(MessageEntity messageEntity)
        {
            return Execute(@"insert into messages(content, sender_id, recipient_id) 
                             values(:content,:sender_id,:recipient_id)", messageEntity);
        }

        public IEnumerable<MessageEntity> FindBySenderId(int senderId)
        {
            return Query<MessageEntity>("select * from messages where sender_id = :sender_id", new { sender_id = senderId });
        }

        public IEnumerable<MessageEntity> FindByRecipientId(int recipientId)
        {
            return Query<MessageEntity>("select * from messages where recipient_id = :recipient_id", new { recipient_id = recipientId });
        }

        public int DeleteById(int messageId)
        {
            return Execute("delete from messages where id = :id", new { id = messageId });
        }

    }

}

