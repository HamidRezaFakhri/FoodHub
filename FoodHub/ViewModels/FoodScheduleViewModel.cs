using System.ComponentModel.DataAnnotations;

namespace FoodHub.ViewModels
{
	public class FoodScheduleViewModel : BaseViewModel
	{
		public bool BreakFast { get; set; }

		public bool Lunch { get; set; }

		public bool Dinner { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		[DataType(DataType.MultilineText)]
		[StringLength(maximumLength: 50, MinimumLength = 5)]
		public string Description { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public System.DateTime AvailableDate { get; set; }

		[Required]
		public int AvailableCount { get; set; }
	}
}