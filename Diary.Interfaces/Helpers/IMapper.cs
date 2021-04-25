namespace Diary.Interfaces
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
