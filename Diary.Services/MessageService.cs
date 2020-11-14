using Diary.Entities;
using Diary.Interfaces;
using Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public MessageService(IMessageRepository messageRepository, 
            IMapper mapper,
            IUserService userService)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task Add(MessageModel messageModel)
        {
            var entity = _mapper.Map<MessageModel, Message>(messageModel);
            entity.Id = new Guid();
            await _messageRepository.Create(entity);
        }

        public IEnumerable<UserModel> GetAllConversationUsers(string user)
            => _messageRepository.GetAllConversationWithUserLogin(user).Select(_userService.GetUser).ToList();

        public IEnumerable<MessageModel> GetMessages(string user1, string user2)
            => _messageRepository.GetItems(user1, user2)
                .Select(entity => _mapper.Map<Message, MessageModel>(entity))
                .ToList();
    }
}
