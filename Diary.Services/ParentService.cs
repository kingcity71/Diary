﻿using Diary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace Diary.Services
{
    public partial class UserService
    {
        private ParentModel GetParentModel(UserModel userModel)
        {
            var parentModel = Map<UserModel, ParentModel>(userModel);

            var childIds = _childParentsRepo.GetAllItems().Where(x => x.ParentId == userModel.Id).Select(x => x.ChildId).ToList();

            var values = _propertyValueService.GetUserPropertyValues(userModel.Id);

            parentModel.BirthDate = GetDate(values, "ParentBirthDate");

            parentModel.Children = new Dictionary<Guid, string>();
            foreach(var childId in childIds)
            {
                var childModel = GetUser(childId);
                parentModel.Children.Add(childModel.Id, childModel.Name);
            }

            return parentModel;
        }
        public ParentModel GetParentModel(string login) => GetParentModel(GetUser(login));
        public ParentModel GetParentModel(Guid id) => GetParentModel(GetUser(id));

    }
}
