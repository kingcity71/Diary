using Diary.Interfaces;
using Diary.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.WebApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;

        public ChatHub(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public async Task Send(string msg, string to)
        {
            await _messageService.Add(new MessageModel { Date = DateTime.Now, MessageBody = msg, From = Context.User.Identity.Name, To = to });
            await Clients.User(to).SendAsync("Send",msg);
        }
    }
}
