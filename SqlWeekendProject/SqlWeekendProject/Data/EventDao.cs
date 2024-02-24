using System;
using System.Data.SqlClient;
using SqlWeekendProject.Model;

namespace SqlWeekendProject.Data
{
	public class EventDao
	{

        public void Insert(Event event1,List<int> speakerIds)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionStr.LOCAL))
            {
                string query = "insert into EVENTS(Name,[Desc],Adress,StartDate,StartTime,EndTime) values (@name,@description,@adress,@startdate,@starttime,@endtime)";

                connection.Open();

                using(SqlCommand cmd= new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name",event1.Name);
                    cmd.Parameters.AddWithValue("@description", event1.Description);
                    cmd.Parameters.AddWithValue("@adress", event1.Address);
                    cmd.Parameters.AddWithValue("@startdate", event1.StartDate);
                    cmd.Parameters.AddWithValue("@starttime", event1.StartTime);
                    cmd.Parameters.AddWithValue("@endtime", event1.EndTime);

                    cmd.ExecuteNonQuery();
                }
            }    
            AddEventSpeakers(event1.ID, speakerIds);
        }
        public void AddEventSpeakers(int eventId, List<int> speakerIds)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionStr.LOCAL))
            {
                connection.Open();

                string query = "insert into EVENTSSPEAKERS (EventId, SpeakerId) VALUES (@EventId, @SpeakerId)";
                foreach (int speakerId in speakerIds)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EventId", eventId);
                        command.Parameters.AddWithValue("@SpeakerId", speakerId);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public Event GetById(int id)
        {
            Event event1 = null;

            using (SqlConnection connection = new SqlConnection(SqlConnectionStr.LOCAL))
            {
                connection.Open();

                string query = "select * from events where id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader sqlData = command.ExecuteReader())
                {

                    if (!sqlData.HasRows) return null;

                    while (sqlData.Read())
                    {
                        event1 = new Event()
                        {
                            ID = sqlData.GetInt32(sqlData.GetOrdinal("ID")),
                            Name = sqlData.GetString(sqlData.GetOrdinal("NAME")),
                            Description = sqlData.GetString(sqlData.GetOrdinal("DESC")),
                            StartDate = sqlData.GetDateTime(sqlData.GetOrdinal("STARTDATE")),
                            StartTime = sqlData.GetTimeSpan(sqlData.GetOrdinal("STARTTIME")),
                            EndTime = sqlData.GetTimeSpan(sqlData.GetOrdinal("ENDTIME")),
                            Address = sqlData.GetString(sqlData.GetOrdinal("ADRESS"))
                        };

                    }                             
                }              
            }

            return event1;
        }

        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            using (SqlConnection connection = new SqlConnection(SqlConnectionStr.LOCAL))
            {
                connection.Open();

                string query = "SELECT * FROM events";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader sqlData = command.ExecuteReader())
                {
                    while (sqlData.Read())
                    {
                        Event event1 = new Event()
                        {
                            ID = sqlData.GetInt32(sqlData.GetOrdinal("ID")),
                            Name = sqlData.GetString(sqlData.GetOrdinal("NAME")),
                            Description = sqlData.GetString(sqlData.GetOrdinal("DESC")),
                            StartDate = sqlData.GetDateTime(sqlData.GetOrdinal("STARTDATE")),
                            StartTime = sqlData.GetTimeSpan(sqlData.GetOrdinal("STARTTIME")),
                            EndTime = sqlData.GetTimeSpan(sqlData.GetOrdinal("ENDTIME")),
                            Address = sqlData.GetString(sqlData.GetOrdinal("ADRESS"))
                        };

                        events.Add(event1);
                    }
                }
            }

            return events;
        }

        public int AddSpeaker(int eventId, int speakerId)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionStr.LOCAL))
            {
                connection.Open();

                string query = "insert into EventSpeakers (EventId, SpeakerId) VALUES (@EventId, @SpeakerId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    command.Parameters.AddWithValue("@SpeakerId", speakerId);

                    return command.ExecuteNonQuery();
                }
            }
        }

        public int RemoveSpeaker(int eventId, int speakerId)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionStr.LOCAL))
            {
                connection.Open();

                string query = "delete from EVENTSPEAKERS where EventId = @EventId and SpeakerId = @SpeakerId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    command.Parameters.AddWithValue("@SpeakerId", speakerId);

                  return  command.ExecuteNonQuery();
                }
            }
        }
        public int Delete(int eventId)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionStr.LOCAL))
            {
                connection.Open();

                string query = "delete from EVENTS where id = @EventId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);

                   return command.ExecuteNonQuery();
                }
            }
        }

    }
}

