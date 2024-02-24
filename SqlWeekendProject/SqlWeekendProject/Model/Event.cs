using System;
namespace SqlWeekendProject.Model
{
	public class Event
	{
           
            public int ID { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            public string Address { get; set; }

            public DateTime StartDate { get; set; }

            public TimeSpan StartTime { get; set; }

            public TimeSpan EndTime { get; set; }

        public override string ToString()
        {
            return $"{ID}-{Name}-{Description}-{Address}-{StartDate}-{StartTime}-{EndTime}";
        }

    }
}

