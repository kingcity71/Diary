using System;
using System.Linq;

namespace Diary.WebApp.Models
{
    public class MonthScheduleViewModel
    {
        public MonthScheduleViewModel(int month, int year)
        {
            CalendarMatrix = GetCalendarMatrix(new DateTime(year, month, 1));
            Date = new DateTime(year, month, 1);
        }
        public int[][] CalendarMatrix{ get; set; }
        public DateTime Date { get; set; }

        public int[][] GetCalendarMatrix(DateTime date)
        {
            var dayOfWeek = (int)new DateTime(date.Year, date.Month, 1).DayOfWeek;

            var difference = (dayOfWeek != 0 ? dayOfWeek : 7) - 1;

            var daysInMonth = Enumerable.Range(0, difference).Select(x => 0).ToList();
            daysInMonth.AddRange(Enumerable.Range(1, DateTime.DaysInMonth(date.Year, date.Month)).ToList());
            daysInMonth.AddRange(Enumerable.Range(daysInMonth.Last(),
                                    daysInMonth.Count() <= 7 * 5
                                            ? 7 * 5 - daysInMonth.Count()
                                            : 7 * 6 - daysInMonth.Count()).Select(x => 0));

            var result = daysInMonth.Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / 7)
            .Select(x => x.Select(v => v.Value).ToArray())
            .ToArray();

            return result;
        }
    }
}