using Diary.Models;
using System.Collections.Generic;

namespace Diary.WebApp.Models
{
    public class ConversationModel
    {
        public string CurrentUserLogin { get; set; }
        public string InterlocutorLogin { get; set; }
        public IDictionary<string,string> UserLoginName { get; set; }
        public IEnumerable<MessageModel> Messages { get; set; }
    }
}
