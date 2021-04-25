using System;
using System.Collections.Generic;
using Diary.Models;

namespace Diary.Interfaces
{
    public interface ISpecialTaskAnswerSerivce
    {
        IEnumerable<SpecialTaskAnswer> GetMany(Guid schedId);
        IEnumerable<SpecialTaskAnswer> GetMany(Guid schedId, Guid studId);

        SpecialTaskAnswer Create(SpecialTaskAnswer spa);
        SpecialTaskAnswer Update(SpecialTaskAnswer spa);
        SpecialTaskAnswer Delete(Guid id);

        SpecialTaskAnswer UpdateFile(Guid spaId, Guid newFileId);
        SpecialTaskAnswer DeleteFile(Guid spa);
    }
}
