using AutoMapper;
using IMapper = Diary.Interfaces.IMapper;

namespace Diary.Services
{
    public class MapperHelper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapConf = new MapperConfiguration(config => config.CreateMap<TSource, TDestination>());
            var mapper = new Mapper(mapConf);
            var model = mapper.Map<TSource, TDestination>(source);
            return model;
        }
    }
}
