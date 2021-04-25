using Diary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


using SpaEntity = Diary.Entities.SpecialTaskAnswer;
using SpaModel = Diary.Models.SpecialTaskAnswer;

namespace Diary.Services
{
    public class SpecialTaskAnswerSerivce : ISpecialTaskAnswerSerivce
    {
        private readonly IRepository<SpaEntity> _spaRepo;
        private readonly IRepository<Entities.SpecialTask> _spRepo;
        private readonly IStudentService _studentService;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public SpecialTaskAnswerSerivce(IRepository<SpaEntity> spaRepo, IFileService fileService, IMapper mapper, IRepository<Entities.SpecialTask> spRepo, IStudentService studentService)
        {
            _spaRepo = spaRepo;
            _fileService = fileService;
            _mapper = mapper;
            _spRepo = spRepo;
            _studentService = studentService;
        }
        public SpaModel Create(SpaModel spa)
        {
            var entity = _mapper.Map<SpaModel, SpaEntity>(spa);
            entity = _spaRepo.Create(entity);
            spa.Id = entity.Id;
            return spa;
        }

        public SpaModel Delete(Guid id)
        {
            var spa = _spaRepo.GetItem(id);
            if (spa.FileId != Guid.Empty)
            {
                _fileService.Delete(spa.FileId);
            }
            _spaRepo.Delete(spa.Id);
            return null;
        }

        public SpaModel DeleteFile(Guid spaId)
        {
            if (spaId == Guid.Empty) return null;
            var entity = _spaRepo.GetItem(spaId);
            _fileService.Delete(entity.FileId);
            
            entity.FileId = Guid.Empty;
            _spaRepo.Update(entity);
            return null;
        }

        public IEnumerable<SpaModel> GetMany(Guid schedId)
        {
            var sps = _spRepo.GetAllItems(x => x.ScheduleId == schedId);
            var entities = _spaRepo
                .GetAllItems(x => sps.Select(z => z.Id).Contains(x.SpecialTaskId));
            var models = entities
            .Select(_mapper.Map<SpaEntity, SpaModel>)
            .ToList();
            foreach (var model in models)
                model.Student = _studentService.GetStudentModel(model.StudentId);
            return models;
        }

        public IEnumerable<SpaModel> GetMany(Guid schedId, Guid studId)
        {
            var sps = _spRepo.GetAllItems(x => x.ScheduleId == schedId);
            var entities = _spaRepo
                .GetAllItems(x => sps.Select(z => z.Id).Contains(x.SpecialTaskId) && studId == x.StudentId);
            var models = entities
            .Select(_mapper.Map<SpaEntity, SpaModel>)
            .ToList(); ;
            foreach (var model in models)
                model.Student = _studentService.GetStudentModel(model.StudentId);
            return models;
        }

        public SpaModel Update(SpaModel spa)
        {
            var entity = _spaRepo.GetItem(spa.Id);
            entity.Description = spa.Description;
            entity.ScoreResult = (Entities.Enums.ScoreResult)spa.ScoreResult;
            entity.Comment = spa.Comment;

            if (spa.TeacherId != Guid.Empty)
                entity.TeacherId = spa.TeacherId;
                
            entity = _spaRepo.Update(entity);
            return spa;
        }

        public SpaModel UpdateFile(Guid spaId, Guid newFileId)
        {
            var entity = _spaRepo.GetItem(spaId);

            if (entity.FileId != Guid.Empty)
            {
                _fileService.Delete(entity.FileId);
            }

            entity.FileId = newFileId;
            entity = _spaRepo.Update(entity);
            return null;
        }
    }
}
