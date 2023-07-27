using DAL.Models;

namespace DAL.Services.Interfaces
{
	public interface IBoardService
	{
		public Board GetBoard(int id);

		public List<Board> GetAllBoards();

		public void UpdateBoard(Board board);

		public void DeleteBoard(Board board);

		public Board CreateBoard(Board board);

		//public bool BoardExistWithSameName(string name);

		//public List<TaskItem> GetAllTasks(int boardId);
	}
}
