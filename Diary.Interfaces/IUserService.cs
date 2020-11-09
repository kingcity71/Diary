using Diary.Models;
using System;

namespace Diary.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserModel userModel);
        UserModel GetUser(Guid id);
        UserModel GetUser(string login);
        string GetGeneratedLogin(string role);
    }
}
