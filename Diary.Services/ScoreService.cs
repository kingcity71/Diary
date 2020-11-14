using Diary.Entities;
using Diary.Interfaces;
using Diary.Models;
using Diary.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using ScoreResultModel = Diary.Models.Enums.ScoreResult;
using ScoreResultEntity = Diary.Entities.Enums.ScoreResult;
using System.Linq;

namespace Diary.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository _scoreRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ScoreService(IScoreRepository scoreRepository, IMapper mapper, IUserService userService)
        {
            _scoreRepository = scoreRepository;
            _mapper = mapper;
            _userService = userService;
        }
        public IEnumerable<ScoreModel> GetScoreModels(Guid schedId)
        {
            var entities = _scoreRepository.GetItems(schedId);
            var models = entities.Select(Map).ToList();
            return models;
        }

        public void Update(IEnumerable<ScoreModel> scores)
        {
            var entities = scores.Select(Map).ToList();
            _scoreRepository.CreateMany(entities.Where(x => x.Id == Guid.Empty).ToList());
            _scoreRepository.UpdateMany(entities.Where(x => x.Id != Guid.Empty).ToList());
            return;
        }

        private ScoreModel Map(Score entity)
        {
            var model = _mapper.Map<Score, ScoreModel>(entity);
            model.ScoreResult = (ScoreResultModel)entity.ScoreResult;
            model.StudentModel = _userService.GetUser(entity.StudentId);
            return model;
        }
        private Score Map(ScoreModel model)
        {
            var entity = _mapper.Map<ScoreModel, Score>(model);
            entity.ScoreResult = (ScoreResultEntity)model.ScoreResult;
            entity.StudentId = model.StudentModel.Id;
            return entity;
        }
    }
}
