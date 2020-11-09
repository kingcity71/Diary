using Microsoft.AspNetCore.Identity;

namespace Diary.Identity
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
    }
}
