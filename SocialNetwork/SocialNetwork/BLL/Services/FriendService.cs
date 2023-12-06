using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public FriendService(IFriendRepository friendRepository, IUserRepository userRepository)
        {
            this.friendRepository = friendRepository;
            this.userRepository = userRepository;
        }
        public void MakeRequest(FriendRequestData friendRequestData)
        {
            if (friendRequestData.FriendEmail == null)
                throw new UserNotFoundException();

            var friend = userRepository.FindByEmail(friendRequestData.FriendEmail);
            if (friend == null)
                throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendRequestData.UserId,
                friend_id = friend.id

            };
            if (friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        public IEnumerable<Friend> GetFriendsByUserId(int Id)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(Id).ToList().ForEach(f =>
            {
                var friendUserEntity = userRepository.FindById(f.friend_id);

                friends.Add(new Friend(f.id, f.user_id, friendUserEntity.email, friendUserEntity.firstname));
            });
            return friends;
        }
    }
}
