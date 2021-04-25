using Diary.Models;
using System;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserModel> SearchUsers(string key);
        IEnumerable<UserModel> GetAllUsers();
        void CreateUser(UserModel userModel);
        UserModel GetUser(Guid id);
        UserModel GetUser(string login);
        string GetGeneratedLogin(string role);
    }
}
