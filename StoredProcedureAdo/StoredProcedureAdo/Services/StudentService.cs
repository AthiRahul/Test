using System;
using StoredProcedureAdo.Models;
using Microsoft.Data.SqlClient;
using static System.Reflection.Metadata.BlobBuilder;

namespace StoredProcedureAdo.Services
{
	public class StudentService : IStudentService
	{
		private IConfiguration _config;
		private string _connect;
		public StudentService(IConfiguration config)
		{
			_config = config;
			_connect = _config.GetConnectionString("DefaultConnection");
		}
		public IEnumerable<Students> GetStudents(int age)
		{
			//std list
			List<Students> StudentsByAge = new List<Students>();
		    using(SqlConnection connectn=new SqlConnection(_connect))
			{
				using(SqlCommand cmd=new SqlCommand("GetStudentsByAge", connectn))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Age",age);
					connectn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while( reader.Read())
						{
							Students student = new Students();
                            student.StudentID = (int)reader["StudentID"];
                            student.FirstName = (string)reader["FirstName"];
                            student.LastName = (string)reader["LastName"];
                            student.Age = (int)reader["Age"];
							StudentsByAge.Add(student);
                        }
					}
				}
				
			}
            return StudentsByAge;

        }
	}

		
    
}

