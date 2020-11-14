using Diary.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diary.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task Create(Message message);

        IEnumerable<Message> GetItems(string user1, string user2);

        IEnumerable<string> GetAllConversationWithUserLogin(string userLogin);
    }
}
