using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodHub.ViewModels
{
	public class FoodViewModel : BaseViewModel
	{
		[Required]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		[Required]
		public long UserId { get; set; }

		[Required]
		[DataType(DataType.ImageUrl)]
		public string Image { get; set; }

		public bool IsMeal { get; set; } = false;

		[Required]
		public byte FoodCategoryId { get; set; }

		[Required]
		public IEnumerable<FoodDetailViewModel> FoodDetails { get; set; }

		[Required]
		public IEnumerable<FoodScheduleViewModel> FoodSchedules { get; set; }
	}
}