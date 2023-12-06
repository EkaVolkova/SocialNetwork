using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageService
    {
        IMessageRepository messageRepository;
        IUserRepository userRepository;
        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }
        
        public void SendMessage(MessageSendingData messageSendingData)
        {
            if (String.IsNullOrEmpty(messageSendingData.Email))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(messageSendingData.Message))
                throw new ArgumentNullException();

            var recipientEntity = userRepository.FindByEmail(messageSendingData.Email);
            var userService = new UserService(userRepository);
            var user = userService.FindByEmail(userRepository.FindById(messageSendingData.Id).email);
            if (recipientEntity == null)
                throw new ArgumentNullException();


            if (messageSendingData.Message.Length > 5000)
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(messageSendingData.Email))
                throw new ArgumentNullException();

            var messageEntity = new MessageEntity() { 
                                                    sender_id = messageSendingData.Id, 
                                                    recipient_id = recipientEntity.id, 
                                                    content = messageSendingData.Message};
            if (messageRepository.Create(messageEntity) == 0)
                throw new Exception();
            
        }
        public IEnumerable<Message> GetIncomingMessagesByUserId(int recipientId)
        {
            var messages = new List<Message>();

            messageRepository.FindByRecipientId(recipientId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.sender_id);
                var recipientUserEntity = userRepository.FindById(m.recipient_id);

                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
            });

            return messages;
        }

        public IEnumerable<Message> GetOutcomingMessagesByUserId(int senderId)
        {
            var messages = new List<Message>();

            messageRepository.FindBySenderId(senderId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.sender_id);
                var recipientUserEntity = userRepository.FindById(m.recipient_id);

                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
            });

            return messages;
        }


    }
}
