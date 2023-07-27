using DAL.Models;
using DAL.Repository;
using DAL.Services;
using Moq;
using Xunit;

namespace BasecampAPI.UnitTests.Services
{
	public class SprintServiceTest
	{
		private Mock<IRepository<Sprint>> _sprintRepository;

		public SprintServiceTest(Mock<IRepository<Sprint>> sprintRepository)
		{
			_sprintRepository = sprintRepository;
		}

		[Fact]
		public void BoardServiceTest_CreateBoard_Returns_Board()
		{
			var board = new Sprint { Id = 1, Name = "Board - 01" };

			var service = new SprintService(_sprintRepository.Object);
			var result = service.CreateSprint(board);

			Assert.NotNull(result);
			Assert.IsType<Board>(result);
			Assert.Equal(board, result);
		}

		[Fact]
		public void BoardServiceTest_GetBoard_Returns_Board()
		{
			var board = new Sprint { Id = 1, Name = "Board - 01" };

			var service = new SprintService(_sprintRepository.Object);
			var result = service.GetSprint(board.Id);

			Assert.NotNull(result);
			Assert.IsType<Board>(result);
			Assert.Equal(board, result);
		}

		[Fact]
		public void BoardServiceTest_DeleteBoard_Returns_Board()
		{
			var board = new Sprint { Id = 1, Name = "Board - 01" };

			var service = new SprintService(_sprintRepository.Object);
			service.DeleteSprint(board);

			//Assert.NotNull(result);
			//Assert.IsType<Board>(result);
			//Assert.Equal(board, result);
		}

		[Fact]
		public void BoardServiceTest_UpdateBoard_Returns_Board()
		{
			var board = new Sprint { Id = 1, Name = "Board - 01" };

			var service = new SprintService(_sprintRepository.Object);
			service.UpdateSprint(board);

			//Assert.NotNull(result);
			//Assert.IsType<Board>(result);
			//Assert.Equal(board, result);
		}
	}
}
