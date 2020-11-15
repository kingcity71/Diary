using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.WebApp.Models
{
    public class StudentDTO
    {
        public bool IsInvalid { get; set; }
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid Parent1Id { get; set; }
        public string Parent1Name { get; set; }
        public Guid Parent2Id { get; set; }
        public string Parent2Name { get; set; }
        public Guid ClassId { get; set; }
        public IDictionary<Guid, string> Classes { get; set; }
    }
}
