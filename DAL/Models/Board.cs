﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Board
	{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
		public List<Sprint>? Sprints { get; set; }
	}
}