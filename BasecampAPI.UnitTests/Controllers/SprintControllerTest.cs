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
	public class SprintControllerTest
	{
		private Mock<ISprintService> _sprintService;

		public SprintControllerTest()
		{
			_sprintService = new Mock<ISprintService>();
		}
		[Fact]
		public void TaskItemController_Get_Returns_Boards()
		{
			// Arrange
			var tasks = new List<Sprint>();
			tasks.Add(new Sprint { Id = 1, Name = "Sprint-01" });
			_sprintService.Setup(x => x.GetAllSprints()).Returns(tasks);

			// Act
			var controller = new SprintController(_sprintService.Object);
			var response = controller.Get();

			//Assert
			var result = Assert.IsAssignableFrom<OkObjectResult>(response);
			var value = Assert.IsAssignableFrom<List<Sprint>>(result.Value);
			Assert.Single(value);
			Assert.Equal(tasks, value);
		}

		[Fact]
		public async Task TaskItemController_GetById_Returns_Appointment()
		{
			// Arrange
			var sprintId = 2;
			var sprint = new Sprint() { Id = sprintId, Name = "Sprint-01" };

			_sprintService.Setup(x => x.GetSprint(sprintId)).Returns(sprint);

			// Act
			var controller = new SprintController(_sprintService.Object);
			var response = controller.Get(sprintId);

			//Assert
			var result = Assert.IsAssignableFrom<OkObjectResult>(response);
			var value = Assert.IsAssignableFrom<Sprint>(result.Value);
			Assert.Equal(sprint, value);
		}

		[Fact]
		public async Task TaskItemController_CreateTaskItem_CreatesTaskItem_And_Returns_Task()
		{
			// Arrange
			var sprintId = 2;
			var sprint = new Sprint() { Id = sprintId, Name = "Sprint-01" };

			_sprintService.Setup(x => x.CreateSprint(sprint));

			// Act
			var controller = new SprintController(_sprintService.Object);
			var response = controller.Post(sprint);

			//Assert
			var result = Assert.IsAssignableFrom<OkObjectResult>(response);
			var value = Assert.IsAssignableFrom<Sprint>(result.Value);
			Assert.Equal(sprint, value);
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
			var sprintId = 2;
			var sprint = new Sprint() { Id = sprintId, Name = "Task-01" };

			_sprintService.Setup(x => x.UpdateSprint(sprint));

			// Act
			var controller = new SprintController(_sprintService.Object);
			var response = controller.Put(sprint);

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
