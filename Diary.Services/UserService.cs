using AutoMapper;
using Diary.Entities;
using Diary.Entities.Enums;
using Diary.Interfaces;
using Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Diary.Services
{
    public partial class UserService : IUserService, 
        IStudentService, IParentService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IPropertyValueService _propertyValueService;
        private readonly IRepository<ClassStudentRelationship> _classStudRepo;
        private readonly IClassService _classService;
        private readonly IRepository<ChildParentRelationship> _childParentsRepo;

        public UserService(IRepository<User> userRepo, IPropertyValueService propertyValueService,
            IRepository<ClassStudentRelationship> classStudRepo, IClassService classService,
            IRepository<ChildParentRelationship> childParentsRepo)
        {
            _userRepo = userRepo;
            _propertyValueService = propertyValueService;
            _classStudRepo = classStudRepo;
            _classService = classService;
            _childParentsRepo = childParentsRepo;
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
            var entityValues = _propertyValueService.GetUserPropertyValues(id);

            var propName = $"{entity.UserRole.ToString()}Name";
            var name = entityValues.ContainsKey(propName) ? entityValues[propName] : string.Empty;

            return new UserModel
            {
                Id = entity.Id,
                Login = entity.Login,
                Role = entity.UserRole.ToString(),
                Name = name
            };
        }

        public UserModel GetUser(string login)
        {
            var entity = _userRepo.GetAllItems().FirstOrDefault(en => en.Login.ToLower() == login.ToLower());
            var entityValues = _propertyValueService.GetUserPropertyValues(entity.Id);

            var propName = $"{entity.UserRole.ToString()}Name";
            var name = entityValues.ContainsKey(propName) ? entityValues[propName] : string.Empty;

            return new UserModel
            {
                Id = entity.Id,
                Login = entity.Login,
                Role = entity.UserRole.ToString(),
                Name = name
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

        private string GetString(IDictionary<string, string> values, string key)
            => values.ContainsKey(key) ? values[key] : string.Empty;

        private DateTime GetDate(IDictionary<string,string> values, string key)
            => values.ContainsKey(key)
                    && DateTime.TryParse(values[key], out var dtValue)
            ? dtValue
            : DateTime.MinValue;

       private T2 Map<T1,T2>(T1 source)
        {
            var config = new MapperConfiguration(conf => conf.CreateMap<T1, T2>());
            var mapper = new Mapper(config);
            var result = mapper.Map<T1, T2>(source);
            return result;
        }
    }
}
