using System;
using System.Data.SqlClient;
using SqlWeekendProject.Model;

namespace SqlWeekendProject.Data
{
	public class SpeakerDao
	{
        
        public int Insert(Speaker speaker)
		{
            var result = 0;
           
            using (SqlConnection connection= new SqlConnection(SqlConnectionStr.LOCAL))
			{
				
				string query = "insert into Speakers(FullName,Position,Company,ImageUrl) values (@fullname,@position,@company,@imageurl)";

				connection.Open();

				using(SqlCommand cmd = new SqlCommand(query, connection))
				{
                    
                    cmd.Parameters.AddWithValue("@fullname", speaker.FullName);
                    cmd.Parameters.AddWithValue("@position", speaker.Position);
                    cmd.Parameters.AddWithValue("@company", speaker.Company);
                    cmd.Parameters.AddWithValue("@imageurl", speaker.ImageUrl);
					result = cmd.ExecuteNonQuery();

                }
			}

			return result;
		}

		public int Update(Speaker speaker)
		{
            using (SqlConnection connection = new SqlConnection(SqlConnectionStr.LOCAL))
            {

                string query = "update SPEAKERS set fullname=@fullname ,position=@position, company=@company, imageurl=@imageurl where id=@id";

                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", speaker.ID);
                    cmd.Parameters.AddWithValue("@fullname", speaker.FullName);
                    cmd.Parameters.AddWithValue("@position", speaker.Position);
                    cmd.Parameters.AddWithValue("@company", speaker.Company);
                    cmd.Parameters.AddWithValue("@imageurl", speaker.ImageUrl);

                    return cmd.ExecuteNonQuery();

                }

            }

        }

        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionStr.LOCAL))
            {

                string query = "delete from SPEAKERS where id=@id";
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    
                    return cmd.ExecuteNonQuery();

                }

            }

        }
        public Speaker GetSpeakerById(int id)
        {
            Speaker speaker = null;

            using (SqlConnection connection = new SqlConnection(SqlConnectionStr.LOCAL))
            {
                string query = "select TOP(1) * from SPEAKERS where id=@id";

                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader sqlData = cmd.ExecuteReader())
                {
                    if (!sqlData.HasRows) return null;

                    while (sqlData.Read())
                    {
                        speaker = new Speaker();
                        
                         speaker.ID = sqlData.GetInt32(sqlData.GetOrdinal("id"));
                         speaker.FullName= sqlData.GetString(sqlData.GetOrdinal("fullname"));
                         speaker.Position = sqlData.GetString(sqlData.GetOrdinal("position"));
                         speaker.Company = sqlData.GetString(sqlData.GetOrdinal("company"));
                         speaker.ImageUrl = sqlData.GetString(sqlData.GetOrdinal("imageurl"));   

                    }
                }

            }
            return speaker;

        }

        public List<Speaker> GetSpeakers()
        {
            List<Speaker> speakers = new List<Speaker>();

            using (SqlConnection connection = new SqlConnection(SqlConnectionStr.LOCAL))
            {
                string query = "select * from SPEAKERS";
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
 
                using (SqlDataReader sqlData = cmd.ExecuteReader())
                {
                    
                    while (sqlData.Read())
                    {

                        Speaker speaker = new Speaker()
                        {
                            ID = sqlData.GetInt32(sqlData.GetOrdinal("id")),
                            FullName = sqlData.GetString(sqlData.GetOrdinal("fullname")),
                            Position = sqlData.GetString(sqlData.GetOrdinal("position")),
                            Company = sqlData.GetString(sqlData.GetOrdinal("company")),
                            ImageUrl = sqlData.GetString(sqlData.GetOrdinal("imageurl"))
                        };

                        speakers.Add(speaker);
                       
                    }
                }
            }
            return speakers;

        }    
	}
}

