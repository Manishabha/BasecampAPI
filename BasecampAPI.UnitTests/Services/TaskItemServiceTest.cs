using DAL.Models;
using DAL.Repository;
using DAL.Services;
using Moq;
using Xunit;

namespace BasecampAPI.UnitTests.Services
{
	public class TaskItemServiceTest
	{
		private Mock<IRepository<TaskItem>> _taskItemRepository;

		public TaskItemServiceTest(Mock<IRepository<TaskItem>> taskItemRepository)
		{
			_taskItemRepository = taskItemRepository;
		}

		[Fact]
		public void TaskItemServiceTest_CreateBoard_Returns_Board()
		{
			var taskItem = new TaskItem { Id = 1, Name = "Board - 01" };

			var service = new TaskItemService(_taskItemRepository.Object);
			var result = service.CreateTask(taskItem);

			Assert.NotNull(result);
			Assert.IsType<Board>(result);
			Assert.Equal(taskItem, result);
		}

		[Fact]
		public void TaskItemServiceTest_GetBoard_Returns_Board()
		{
			var task = new TaskItem { Id = 1, Name = "Board - 01" };

			var service = new TaskItemService(_taskItemRepository.Object);
			var result = service.GetTask(task.Id);

			Assert.NotNull(result);
			Assert.IsType<Board>(result);
			Assert.Equal(task, result);
		}

		[Fact]
		public void BoardServiceTest_DeleteBoard_Returns_Board()
		{
			var board = new TaskItem { Id = 1, Name = "Board - 01" };

			var service = new TaskItemService(_taskItemRepository.Object);
			service.DeleteTask(board);

			//Assert.NotNull(result);
			//Assert.IsType<Board>(result);
			//Assert.Equal(board, result);
		}

		[Fact]
		public void TaskItemServiceTest_UpdateTask_Returns_Board()
		{
			var task = new TaskItem { Id = 1, Name = "Task - 01" };

			var service = new TaskItemService(_taskItemRepository.Object);
			service.UpdateTask(task);

			//Assert.NotNull(result);
			//Assert.IsType<Board>(result);
			//Assert.Equal(board, result);
		}
	}
}
