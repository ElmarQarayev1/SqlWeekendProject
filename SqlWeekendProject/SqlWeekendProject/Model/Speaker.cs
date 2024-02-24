using System;
namespace SqlWeekendProject.Model
{
	public class Speaker
	{

        public int ID { get; set; }

        public string FullName { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return $"{ID}-{FullName}-{Position}-{Company}-{ImageUrl}";
        }
    }

}


