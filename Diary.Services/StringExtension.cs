namespace Diary.Services
{
    public static class StringExtension
    {
        public static bool IsEqualIgnoreCase(this string context, string str)
            => context.ToLower() == str.ToLower();
        
    }
}
