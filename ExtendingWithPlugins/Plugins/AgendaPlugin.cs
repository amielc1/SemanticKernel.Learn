using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace ExtendingWithPlugins.Plugins
{
    public class AgendaPlugin
    {
        private Dictionary<DateTime, bool> _days;

        public AgendaPlugin()
        {
            _days = new Dictionary<DateTime, bool>();
            InitializeWorkingDays();
        }

        private void InitializeWorkingDays()
        {
            DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime end = new DateTime(DateTime.Now.Year, 12, 31);
            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                _days[date] = true; // true means working day
            }
        }

        [KernelFunction]
        [Description("Sets the days to holiday in the agenda between given start date and end date")]
        public void SetHoliday(DateTime startDate, DateTime endDate)
        {
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (_days.ContainsKey(date))
                {
                    _days[date] = false; // false means vacation day
                }
            }
        }

        [KernelFunction]
        [Description("Returns true if the specified date is a working day.")]
        public bool IsWorkingDay(DateTime date)
        {
            return _days.ContainsKey(date) && _days[date];
        }
    }
}
