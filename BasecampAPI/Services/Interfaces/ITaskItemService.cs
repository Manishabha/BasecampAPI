using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Interfaces
{
	public interface ITaskItemService
	{
		public TaskItem GetTask(int id);

		public List<TaskItem> GetAllTasks();

		public void UpdateTask(TaskItem taskItem);

		public void DeleteTask(TaskItem taskItem);

		public TaskItem CreateTask(TaskItem taskItem);
	}
}
