using System.ComponentModel.DataAnnotations;

namespace FoodHub.ViewModels
{
	public class RegisterUserViewModel : BaseViewModel
	{
		[Required]
		[StringLength(maximumLength: 50, MinimumLength = 5)]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(maximumLength: 50, MinimumLength = 8)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(maximumLength: 50, MinimumLength = 8)]
		[Compare("Password", ErrorMessage = "PAssword and Confirmation is not match!")]
		public string ConfirmPassword { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.PostalCode)]
		public string ZipCode { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		[StringLength(maximumLength: 500, MinimumLength = 10)]
		public string Address { get; set; }

		[Required]
		[DataType(DataType.PhoneNumber)]
		public string Mobile { get; set; }

		[Required]
		public string Image { get; set; }

		[Required]
		public string Telegram { get; set; }

		[Required]
		public bool AuthAsCollege { get; set; } = false;

		[Required]
		public byte RoleId { get; set; }
	}
}