using BasecampAPI.Attributes;
using BasecampAPI.Enums;
using DAL.Models;
using DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasecampAPI.Controllers
{
	[Route("api/sprint/")]
	[ApiController]
	public class SprintController : ControllerBase
	{
		private readonly ISprintService _sprintService;
		public SprintController(ISprintService sprintService) 
		{
			_sprintService = sprintService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				var boards = _sprintService.GetAllSprints();
				return Ok(boards);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			try
			{
				var board = _sprintService.GetSprint(id);
				return Ok(board);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[UnhandledExceptionAttribute((int)ErrorCode.BoardCreateFailed)]
		public IActionResult Post([FromBody] Sprint sprint)
		{
			try
			{
				if (sprint == null)
				{
					return BadRequest();
				}
				//var boardWithSameName = this.boardService.BoardExistWithSameName(board.Name);
				//if (boardWithSameName)
				//{
				//	return BadRequest("Board with same name already exist. Choose a different name!!");
				//}
				_sprintService.CreateSprint(sprint);
				return Ok();
			} 
			catch (Exception ex) 
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut()]
		public IActionResult Put([FromBody] Sprint sprint)
		{
			try
			{
				_sprintService.UpdateSprint(sprint);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// DELETE api/<BoardController>/5
		[HttpDelete]
		public IActionResult Delete([FromBody] Sprint sprint)
		{
			try
			{
				_sprintService.DeleteSprint(sprint);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		//[HttpGet]
		//[Route("alltasks")]
		//public IActionResult GetAllTask(int id)
		//{
		//	try
		//	{
		//		this.boardService.GetAllTasks(id);
		//		return Ok();
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(ex.Message);
		//	}
		//}
	}
}
