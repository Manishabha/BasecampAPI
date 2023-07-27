using Azure;
using BasecampAPI.Controllers;
using BasecampAPI.Enums;
using DAL.Models;
using DAL.Repository;
using DAL.Services;
using DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BasecampAPI.UnitTests.Controllers
{
	public class TaskControllerTest
	{
		private Mock<ITaskItemService> _taskItemService;

		public TaskControllerTest()
		{
			_taskItemService = new Mock<ITaskItemService>();
		}
		[Fact]
		public void TaskItemController_Get_Returns_Boards()
		{
			// Arrange
			var tasks = new List<TaskItem>();
			tasks.Add(new TaskItem { Id = 1, Name = "Task-01" });
			_taskItemService.Setup(x => x.GetAllTasks()).Returns(tasks);

			// Act
			var controller = new TaskItemController(_taskItemService.Object);
			var response = controller.Get();

			//Assert
			var result = Assert.IsAssignableFrom<OkObjectResult>(response);
			var value = Assert.IsAssignableFrom<List<TaskItem>>(result.Value);
			Assert.Single(value);
			Assert.Equal(tasks, value);
		}

		[Fact]
		public async Task TaskItemController_GetById_Returns_Appointment()
		{
			// Arrange
			var taskId = 2;
			var task = new TaskItem() { Id = taskId, Name = "Task-01" };

			_taskItemService.Setup(x => x.GetTask(taskId)).Returns(task);

			// Act
			var controller = new TaskItemController(_taskItemService.Object);
			var response = controller.Get(taskId);

			//Assert
			var result = Assert.IsAssignableFrom<OkObjectResult>(response);
			var value = Assert.IsAssignableFrom<TaskItem>(result.Value);
			Assert.Equal(task, value);
		}

		[Fact]
		public async Task TaskItemController_CreateTaskItem_CreatesTaskItem_And_Returns_Task()
		{
			// Arrange
			var taskId = 2;
			var task = new TaskItem() { Id = taskId, Name = "Task-01" };

			_taskItemService.Setup(x => x.CreateTask(task));

			// Act
			var controller = new TaskItemController(_taskItemService.Object);
			var response = controller.Post(task);

			//Assert
			var result = Assert.IsAssignableFrom<OkObjectResult>(response);
			var value = Assert.IsAssignableFrom<TaskItem>(result.Value);
			Assert.Equal(task, value);
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
		public async Task TaskItemController_Update_UpdatesTaskItem_And_Returns_Task()
		{
			// Arrange
			var taskId = 2;
			var task = new TaskItem() { Id = taskId, Name = "Task-01" };

			_taskItemService.Setup(x => x.UpdateTask(task));

			// Act
			var controller = new TaskItemController(_taskItemService.Object);
			var response = controller.Put(taskId, task);

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
