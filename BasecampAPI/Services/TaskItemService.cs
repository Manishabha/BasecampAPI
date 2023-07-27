using DAL.Models;
using DAL.Repository;
using DAL.Services.Interfaces;

namespace DAL.Services
{
	public class TaskItemService : ITaskItemService
	{
		private readonly IRepository<TaskItem> _sprintRepository;

		public TaskItemService(IRepository<TaskItem> sprintRepository)
		{
			_sprintRepository = sprintRepository;
		}
		public TaskItem CreateTask(TaskItem taskItem)
		{
			return _sprintRepository.GetById(taskItem.Id);
		}

		public void DeleteTask(TaskItem taskItem)
		{
			_sprintRepository.Delete(taskItem);
		}

		public TaskItem GetTask(int id)
		{
			return _sprintRepository.GetById(id);
		}

		public List<TaskItem> GetAllTasks()
		{
			return _sprintRepository.GetAll().ToList();
		}

		public void UpdateTask(TaskItem taskItem)
		{
			_sprintRepository.Update(taskItem);
		}
	}
}
