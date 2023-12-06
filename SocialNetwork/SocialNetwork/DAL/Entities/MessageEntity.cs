namespace SocialNetwork.DAL.Entities
{
    /// <summary>
    /// Класс сообщений для работы с БД
    /// </summary>
    public class MessageEntity
    {
        public int id { get; set; }
        public string content { get; set; }
        public int sender_id { get; set; }
        public int recipient_id { get; set; }
    }

}
