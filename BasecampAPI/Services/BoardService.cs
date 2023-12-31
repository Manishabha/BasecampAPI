﻿using DAL.Models;
using DAL.Repository;
using DAL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
	public class BoardService : IBoardService
	{
		private readonly IRepository<Board> _boardRepository;

		public BoardService(IRepository<Board> boardRepository)
		{
			_boardRepository = boardRepository;
		}
		public Board CreateBoard(Board board)
		{
			 return _boardRepository.Add(board);
		}

		public void DeleteBoard(Board board)
		{
			_boardRepository.Delete(board.Id);
		}

		public Board GetBoard(int id)
		{
			return _boardRepository.GetById(id);
		}

		public List<Board> GetAllBoards()
		{
			return _boardRepository.GetAll().ToList();
		}

		public void UpdateBoard(Board board)
		{
			 _boardRepository.Update(board);
		}

		//public async Task<Boolean> BoardExistWithSameName(string name)
		//{
		//	var boards = await _boardRepository.GetAll();
		//	boards.Any(x => x)

		//}
	}
}
