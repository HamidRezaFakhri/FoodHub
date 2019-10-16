using System.ComponentModel.DataAnnotations;

namespace FoodHub.ViewModels
{
	public class FoodDetailViewModel : BaseViewModel
	{
		[Required]
		public byte LanguageId { get; set; }

		[Required]
		[StringLength(maximumLength: 50, MinimumLength = 5)]
		public string Name { get; set; }

		[DataType(DataType.MultilineText)]
		[StringLength(maximumLength: 50, MinimumLength = 5)]
		public string Description { get; set; }
	}
}