using System;
using System.ComponentModel.DataAnnotations;

namespace FoodHub.ViewModels
{
	public class ReserveViewModel : BaseViewModel
	{
		[Required]
		public long FoodScheduleId { get; set; }

		[DataType(DataType.Date)]
		public DateTime ReserveDate { get; set; } = DateTime.Now;

		[Required]
		public int ReserveCount { get; set; }

		public bool BreakFast { get; set; } = true;

		public bool Lunch { get; set; } = true;

		public bool Dinner { get; set; } = true;

		public bool IsSold { get; set; } = false;

		[DataType(DataType.MultilineText)]
		[StringLength(maximumLength: 500, MinimumLength = 5)]
		public string Description { get; set; }

		[Required]
		public long ReserveUserId { get; set; }
	}
}