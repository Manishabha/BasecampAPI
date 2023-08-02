using DAL.Models;
using DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasecampAPI.Controllers
{
	[Route("api/tasks")]
	[ApiController]
	public class TaskItemController : ControllerBase
	{
		private readonly ITaskItemService taskItemService;
		public TaskItemController(ITaskItemService taskItemService)
		{
			this.taskItemService = taskItemService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				var tasks = this.taskItemService.GetAllTasks();
				return Ok(tasks);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET: api/<TaskItemController>
		//[HttpGet]
		//[Route("/board/{boardId}")]
		//public IActionResult GetTaskForBoard(int boardId)
		//{
		//	try
		//	{
		//		var task = this.taskItemService.GetTask(boardId);
		//		return Ok(task);
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(ex.Message);
		//	}
		//}

		// GET api/<TaskItemController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			try
			{
				var task = this.taskItemService.GetTask(id);
				return Ok(task);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// POST api/<TaskItemController>
		[HttpPost]
		public IActionResult Post([FromBody] TaskItem task)
		{
			try
			{
				if (task == null)
				{
					return BadRequest();
				}

				this.taskItemService.CreateTask(task);
				return Ok(task);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// PUT api/<TaskItemController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] TaskItem task)
		{
			try
			{
				if (task == null)
				{
					return BadRequest();
				}

				this.taskItemService.UpdateTask(task);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete()]
		public IActionResult Delete([FromBody] TaskItem task)
		{
			try
			{
				this.taskItemService.DeleteTask(task);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
