using DAL.Models;
using DAL.Repository;
using DAL.Services;
using Moq;
using Xunit;

namespace BasecampAPI.UnitTests.Services
{
	public class BoardServiceTest
	{
		private Mock<IRepository<Board>> _boardRepository;

		public BoardServiceTest(Mock<IRepository<Board>> boardRepository)
		{
			_boardRepository = boardRepository;
		}

		[Fact]
		public void BoardServiceTest_CreateBoard_Returns_Board()
		{
			var board = new Board { Id = 1, Name = "Board - 01" };

			var service = new BoardService(_boardRepository.Object);
			var result = service.CreateBoard(board);

			Assert.NotNull(result);
			Assert.IsType<Board>(result);
			Assert.Equal(board, result);
		}

		[Fact]
		public void BoardServiceTest_GetBoard_Returns_Board()
		{
			var board = new Board { Id = 1, Name = "Board - 01" };

			var service = new BoardService(_boardRepository.Object);
			var result = service.GetBoard(board.Id);

			Assert.NotNull(result);
			Assert.IsType<Board>(result);
			Assert.Equal(board, result);
		}

		[Fact]
		public void BoardServiceTest_DeleteBoard_Returns_Board()
		{
			var board = new Board { Id = 1, Name = "Board - 01" };

			var service = new BoardService(_boardRepository.Object);
			service.DeleteBoard(board);

			//Assert.NotNull(result);
			//Assert.IsType<Board>(result);
			//Assert.Equal(board, result);
		}

		[Fact]
		public void BoardServiceTest_UpdateBoard_Returns_Board()
		{
			var board = new Board { Id = 1, Name = "Board - 01" };

			var service = new BoardService(_boardRepository.Object);
			service.UpdateBoard(board);

			//Assert.NotNull(result);
			//Assert.IsType<Board>(result);
			//Assert.Equal(board, result);
		}
	}
}
