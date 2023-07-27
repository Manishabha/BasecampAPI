using Azure;
using BasecampAPI.Controllers;
using BasecampAPI.Enums;
using DAL.Models;
using DAL.Repository;
using DAL.Services;
using DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BasecampAPI.UnitTests.Controllers
{
	public class BoardControllerTest
	{
		private Mock<IBoardService> _boardService;

		public BoardControllerTest()
		{
			_boardService = new Mock<IBoardService>();
		}
		[Fact]
		public void BoardController_Get_Returns_Boards()
		{
			// Arrange
			var boards = new List<Board>();
			boards.Add(new Board { Id = 1, Name = "Task-01" });
			_boardService.Setup(x => x.GetAllBoards()).Returns(boards);

			// Act
			var controller = new BoardController(_boardService.Object);
			var response = controller.Get();

			//Assert
			var result = Assert.IsAssignableFrom<OkObjectResult>(response);
			var value = Assert.IsAssignableFrom<List<Board>>(result.Value);
			Assert.Single(value);
			Assert.Equal(boards, value);
		}

		[Fact]
		public void BoardController_GetById_Returns_Appointment()
		{
			// Arrange
			var taskId = 2;
			var task = new Board() { Id = taskId, Name = "Task-01" };

			_boardService.Setup(x => x.GetBoard(taskId)).Returns(task);

			// Act
			var controller = new BoardController(_boardService.Object);
			var response = controller.Get(taskId);

			//Assert
			var result = Assert.IsAssignableFrom<OkObjectResult>(response);
			var value = Assert.IsAssignableFrom<Board>(result.Value);
			Assert.Equal(task, value);
		}

		[Fact]
		public void BoardController_CreateTaskItem_CreatesTaskItem_And_Returns_Task()
		{
			// Arrange
			var boardId = 2;
			var board = new Board() { Id = boardId, Name = "Task-01" };

			_boardService.Setup(x => x.CreateBoard(board));

			// Act
			var controller = new BoardController(_boardService.Object);
			var response = controller.Post(board);

			//Assert
			var result = Assert.IsAssignableFrom<OkObjectResult>(response);
			var value = Assert.IsAssignableFrom<Board>(result.Value);
			Assert.Equal(board, value);
		}

		//[Fact]
		//public async Task TaskItemController_CreateTaskItem_CreatesTaskItem_And_Throws_Error()
		//{
		//	// Arrange
		//	var taskId = 2;
		//	var task = new TaskItem() { Id = taskId, Name = "Task-01" };

		//	_taskItemService.Setup(x => x.CreateTask(task));

		//	// Act
		//	var controller = new TaskItemController(_taskItemService.Object);
		//	var response = Assert.Throws<Exception>(() => controller.Post(task));
		//	var result = Assert.IsAssignableFrom<BadRequestResult>(response);

		//	//Assert
		//	Assert.Equal(400, result.StatusCode);
		//}


		[Fact]
		public void BoardController_Update_UpdatesTaskItem_And_Returns_Task()
		{
			// Arrange
			var boardId = 2;
			var board = new Board() { Id = boardId, Name = "Task-01" };

			_boardService.Setup(x => x.UpdateBoard(board));

			// Act
			var controller = new BoardController(_boardService.Object);
			var response = controller.Put(board);

			//Assert
			var result = Assert.IsAssignableFrom<OkResult>(response);
			//var value = Assert.IsAssignableFrom<TaskItem>(result.Value);
			//Assert.Equal(task, value);
		}

		//[Fact]
		//public async Task TaskItemController_Update_UpdatesTaskItem_And_Throws_Error()
		//{
		//}

		//[Fact]
		//public async Task TaskItemController_Update_UpdatesAppointment_And_Throws_Error()
		//{

	}
}
