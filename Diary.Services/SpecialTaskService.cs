using Diary.Interfaces;
using Diary.Models;
using Diary.Entities;
using System.Collections.Generic;
using System.Text;
using SpecialTaskEntity = Diary.Entities.SpecialTask;
using System;
using System.Linq;

namespace Diary.Services
{
    public class SpecialTaskService : ISpecialTaskService
    {
        private readonly ISpecialTaskRepository repo;
        private readonly IFileService fileService;
        private readonly IRepository<SpecialTaskFile> spfRepo;

        public SpecialTaskService(ISpecialTaskRepository repo,
            IFileService fileService,
            IRepository<SpecialTaskFile> spfRepo)
        {
            this.repo = repo;
            this.fileService = fileService;
            this.spfRepo = spfRepo;
        }
        public void Create(Models.SpecialTask st)
        {
            var entity = new SpecialTaskEntity
            {
                Description = st.Description,
                ScheduleId = st.ScheduleId,
                SpecialTaskType = (Entities.Enums.SpecialTaskType)(int)st.SpecialTaskType
            };

            entity = repo.CreateItem(entity);

            if (st.FileId != Guid.Empty)
            {
                var spf = new SpecialTaskFile
                {
                    FileId = st.FileId,
                    SpecialTaskId = entity.Id
                };
                spfRepo.Create(spf);
            }
        }
   
        public IEnumerable<Models.SpecialTask> GetSpecialTasks(Guid schedId)
        {
            var entities = repo.GetMany(schedId);
            var list = new List<Models.SpecialTask>();

            foreach(var entity in entities)
            {
                var model = MapEntityToModel(entity);
                var fileId = repo.FileIds(entity.Id);
                model.FileId = fileId.Any() ? fileId.First() : Guid.Empty;
                list.Add(model);
            }

            return list;
        }


        public void Delete(Guid id)
        {
            var spf = spfRepo.GetItem(x => x.SpecialTaskId == id);
            fileService.Delete(spf.FileId);

            spfRepo.Delete(spf.Id);
            repo.Delete(id);
            
        }

        Models.SpecialTask MapEntityToModel(SpecialTaskEntity st)
            => new Models.SpecialTask
            {
                ScheduleId = st.ScheduleId,
                SpecialTaskType = (Models.Enums.SpecialTaskType)st.SpecialTaskType,
                Description = st.Description,
                Id = st.Id
            };
    }
}
