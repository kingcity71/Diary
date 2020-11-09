using Diary.Entities;
using Diary.Entities.Enums;
using Diary.Interfaces;
using Diary.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Diary.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IPropertyValueService _propertyValueService;

        public UserService(IRepository<User> userRepo, IPropertyValueService propertyValueService)
        {
            _userRepo = userRepo;
            _propertyValueService = propertyValueService;
        }
        public string GetGeneratedLogin(string role)
        {
            var existedIndexes = _userRepo
                .GetAllItems()
                .Where(user => user.Login.ToLower().Contains(role.ToLower()))
                .Select(user => new Regex("[0-9]+").Match(user.Login).Value).
                ToList();
            
            
            if (!existedIndexes.Any()) return $"{role}1";

            var maxIndex = existedIndexes
                .Select(strIndex => int.Parse(strIndex))
                .OrderByDescending(index => index)
                .FirstOrDefault();

            return $"{role}{++maxIndex}";
        }
        public UserModel GetUser(Guid id)
        {
            var entity = _userRepo.GetItem(id);
            return new UserModel
            {
                Id = entity.Id,
                Login = entity.Login,
                Role = entity.UserRole.ToString()
            };
        }

        public UserModel GetUser(string login)
        {
            var entity = _userRepo.GetAllItems().FirstOrDefault(en => en.Login == login);
            return new UserModel
            {
                Id = entity.Id,
                Login = entity.Login,
                Role = entity.UserRole.ToString()
            };
        }

        public void CreateUser(UserModel userModel)
        {
            var user = Activator.CreateInstance<User>();
            user.Id = new Guid();
            user.Login = userModel.Login;
            user.UserRole = (UserRole)Enum.Parse(typeof(UserRole), userModel.Role);

            _userRepo.Create(user);

            _propertyValueService.CreatePropertyValue($"{userModel.Role}Name", userModel.Name, user.Id);
        }
    }
}
