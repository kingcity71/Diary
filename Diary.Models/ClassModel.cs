using Diary.Models.Abstract;
using System.Collections.Generic;

namespace Diary.Models
{
    public class ClassModel : EntityModel
    {
        public int Number{ get; set; }
        public char Letter { get; set; }
        public string FullName{ get => $"{Number}{Letter}"; }
        public IList<UserModel> Students { get; set; } = new List<UserModel>();
    }
}
