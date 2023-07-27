using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Interfaces
{
	public interface ISprintService
	{
		public Sprint GetSprint(int id);

		public List<Sprint> GetAllSprints();

		public void UpdateSprint(Sprint sprint);

		public void DeleteSprint(Sprint sprint);

		public Sprint CreateSprint(Sprint sprint);

		//public List<TaskItem> GetAllTasks(int boardId);
	}
}
