using Diary.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Models
{
    public class MessageModel : EntityModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string MessageBody { get; set; }
    }
}
