using DAL.Models;
using DAL.Repository;
using DAL.Services.Interfaces;

namespace DAL.Services
{
	public class SprintService : ISprintService
	{
		private readonly IRepository<Sprint> _sprintRepository;

		public SprintService(IRepository<Sprint> sprintRepository)
		{
			_sprintRepository = sprintRepository;
		}
		public Sprint CreateSprint(Sprint sprint)
		{
			return _sprintRepository.GetById(sprint.Id);
		}

		public void DeleteSprint(Sprint sprint)
		{
			_sprintRepository.Delete(sprint);
		}

		public Sprint GetSprint(int id)
		{
			return _sprintRepository.GetById(id);
		}

		public List<Sprint> GetAllSprints()
		{
			return _sprintRepository.GetAll().ToList();
		}

		public void UpdateSprint(Sprint sprint)
		{
			_sprintRepository.Update(sprint);
		}

		//	public List<TaskItem> GetAllTasks(int sprintId)
		//{
		//	using (var context = new ApplicationDbContext())
		//	{
		//		var sprintFromDb = context.Sprints.Where(x => x.Id == sprintId).FirstOrDefault();
		//		if (sprintFromDb != null)
		//		{
		//			return sprintFromDb.TaskItems;
		//		}
		//		return default;
		//	}
		//}
	}
}
