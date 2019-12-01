using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
	public class Workout
	{
		[Required]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required]
		[Display(Name = "Type of exercise")]
		public string type { get; set; }

		[DataType(DataType.Duration)]
		[Display(Name = "Duration of exercise")]
		public TimeSpan duration { get; set; }

		[Display(Name = "Calories burnt")]
		public int caloriesBurnt { get; set; }

		[DataType(DataType.DateTime)]
		[Display(Name = "Start Time")]
		public DateTime startTime { get; set; }

		[Required]
		[Association(name: "FK_UserID", thisKey: "userId",otherKey: "Id", IsForeignKey =true)]
		[Display(Name = "User Id")]
		public int userId { get; set; }

	}
}