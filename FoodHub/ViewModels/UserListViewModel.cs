using System.ComponentModel.DataAnnotations;

namespace FoodHub.ViewModels
{
	public class UserListViewModel : BaseViewModel
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string ZipCode { get; set; }

		public string Address { get; set; }

		public string Mobile { get; set; }

		public string Image { get; set; }

		public string Telegram { get; set; }

		public bool AuthAsCollege { get; set; } = false;

		public byte RoleId { get; set; }

		public bool IsActive { get; set; }
	}
}