using Diary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diary.Interfaces
{
    public interface IMessageService 
    {
        Task Add(MessageModel messageModel);
        IEnumerable<MessageModel> GetMessages(string user1, string user2);

        IEnumerable<UserModel> GetAllConversationUsers(string user);
    }
}
