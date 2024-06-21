using System;
using StoredProcedureAdo.Models;

namespace StoredProcedureAdo.Services
{
	public interface IStudentService
	{
		public IEnumerable<Students> GetStudents(int age);

	}
}

