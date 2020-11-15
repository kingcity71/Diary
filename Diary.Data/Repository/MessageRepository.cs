using Diary.Entities;
using Diary.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Data.Repository
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(IConfiguration configuration) : base(configuration){}

        new public async Task Create(Message message)
        {
            using var ctx = new Context(_configuration);
            await ctx.Messages.AddAsync(message);
            await ctx.SaveChangesAsync();
        }

        public IEnumerable<string> GetAllConversationWithUserLogin(string userLogin)
        {
            using var ctx = new Context(_configuration);
            var result = new List<string> ();
            var msgs = ctx.Messages.Where(x => x.From.ToLower()== userLogin.ToLower() || x.To.ToLower() == userLogin.ToLower()).ToList();
            foreach(var msg in msgs)
            {
                if (!result.Contains(msg.From) && msg.From!=userLogin)
                    result.Add(msg.From);
                if (!result.Contains(msg.To) && msg.To != userLogin)
                    result.Add(msg.To);
            }
            return result;
        }

        public IEnumerable<Message> GetItems(string user1, string user2)
        {
            using var ctx = new Context(_configuration);
            var entities = ctx.Messages
                .AsNoTracking()
                .Where(x => (x.From.ToLower()==user1.ToLower() && x.To.ToLower()==user2.ToLower())|| (x.From.ToLower() == user2.ToLower() && x.To.ToLower() == user1.ToLower()))
                //users.Contains(x.From) || users.Contains(x.To))
                .OrderByDescending(x => x.Date)
                .ToList();
            return entities;
        }
    }
}
