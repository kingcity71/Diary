using Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.WebApp.Models
{
    public class StudentProfileViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ClassModel ClassModel{ get; set; }
        public IEnumerable<UserModel> Parents{ get; set; }
        public DateTime BirthDate { get; set; }
    }
}
