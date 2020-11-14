using Diary.Entities.Abstract;
using System;

namespace Diary.Entities
{
    public class Message : Entity
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string MessageBody { get; set; }
    }
}
