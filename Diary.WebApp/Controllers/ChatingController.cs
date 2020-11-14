using Diary.Interfaces;
using Diary.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.WebApp.Controllers
{
    public class ChatingController : BaseController
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public ChatingController(RoleManager<IdentityRole> roleManager, IMessageService messageService, IUserService userService) 
            : base(roleManager)
        {
            _messageService = messageService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var myChatUsers = _messageService.GetAllConversationUsers(GetCurrentUser());
            return View(myChatUsers);
        }
        
        public IActionResult Conversation(string interlocutorLogin)//логин собеседника
        {
            var conversationHistory = _messageService.GetMessages(GetCurrentUser(), interlocutorLogin);
            var currentUserName = _userService.GetUser(GetCurrentUser()).Name;
            var interlocutorName = _userService.GetUser(interlocutorLogin).Name;
            
            var viewModel = Activator.CreateInstance<ConversationModel>();
            
            viewModel.CurrentUserLogin = GetCurrentUser();
            viewModel.InterlocutorLogin = interlocutorLogin;
            viewModel.Messages = conversationHistory;
            viewModel.UserLoginName = new Dictionary<string,string> { { GetCurrentUser(), currentUserName }, { interlocutorLogin, interlocutorName } };
            
            return View(viewModel);
        }
    }
}
