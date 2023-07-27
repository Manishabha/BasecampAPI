using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class TaskItem
	{
		[Key]
        public int Id { get; set; }
		public string Description { get; set; }
		public string Name { get; set; }
		public int Estimate { get; set; }
		public int Priotiy { get; set; }
		public string Comments { get; set; }
		public string AssignedTo { get; set; }
		public int Status { get; set; }
		public int? ParentTaskId { get; set; }
		public TaskItem ParentTask { get; set; }
        public int SprintId { get; set; }
		public Sprint Sprint { get; set; }
	}
}
