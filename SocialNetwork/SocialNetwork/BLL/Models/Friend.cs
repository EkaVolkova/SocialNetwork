using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FriendEmail { get; set; }
        public string FriendName { get; set; }

        public Friend(int id, int userId, string friendEmail, string friendName)
        {
            Id = id;
            UserId = userId;
            FriendEmail = friendEmail;
            FriendName = friendName;
        }
    }
}
