using BasecampAPI.Attributes;
using BasecampAPI.Enums;
using DAL.Models;
using DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasecampAPI.Controllers
{
	[Route("api/board/")]
	[ApiController]
	public class BoardController : ControllerBase
	{
		private readonly IBoardService boardService;
		public BoardController(IBoardService boardService) 
		{
			this.boardService = boardService;
		}

		// GET: api/<BoardController>
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				var boards = this.boardService.GetAllBoards();
				return Ok(boards);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET api/<BoardController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			try
			{
				var board = this.boardService.GetBoard(id);
				return Ok(board);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// POST api/<BoardController>
		[HttpPost]
		[UnhandledExceptionAttribute((int)ErrorCode.BoardCreateFailed)]
		public IActionResult Post([FromBody] Board board)
		{
			try
			{
				if (board == null)
				{
					return BadRequest();
				}
				//}
				//var boardWithSameName = this.boardService.BoardExistWithSameName(board.Name);
				//if (boardWithSameName)
				//{
				//	return BadRequest("Board with same name already exist. Choose a different name!!");
				//}
				this.boardService.CreateBoard(board);
				return Ok();
			} 
			catch (Exception ex) 
			{
				return BadRequest(ex.Message);
			}
		}

		// PUT api/<BoardController>/5
		[HttpPut()]
		public IActionResult Put([FromBody] Board board)
		{
			try
			{
				this.boardService.UpdateBoard(board);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// DELETE api/<BoardController>/5
		[HttpDelete()]
		public IActionResult Delete(Board board)
		{
			try
			{
				this.boardService.DeleteBoard(board);
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
