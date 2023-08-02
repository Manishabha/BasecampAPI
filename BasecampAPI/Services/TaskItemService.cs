using DAL.Models;
using DAL.Repository;
using DAL.Services.Interfaces;

namespace DAL.Services
{
	public class TaskItemService : ITaskItemService
	{
		private readonly IRepository<TaskItem> _taskRepository;

		public TaskItemService(IRepository<TaskItem> taskRepository)
		{
			_taskRepository = taskRepository;
		}
		public TaskItem CreateTask(TaskItem taskItem)
		{
			return _taskRepository.Add(taskItem);
		}

		public void DeleteTask(TaskItem taskItem)
		{
			_taskRepository.Delete(taskItem.Id);
		}

		public TaskItem GetTask(int id)
		{
			return _taskRepository.GetById(id);
		}

		public List<TaskItem> GetAllTasks()
		{
			return _taskRepository.GetAll().ToList();
		}

		public void UpdateTask(TaskItem taskItem)
		{
			_taskRepository.Update(taskItem);
		}
	}
}
