namespace SocialNetwork.DAL.Entities
{
    /// <summary>
    /// Класс друзей для работы с БД
    /// </summary>
    public class FriendEntity
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int friend_id { get; set; }
    }

}
