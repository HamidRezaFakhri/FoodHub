using System;
using System.Collections.Generic;
using System.Linq;
using FoodHub.ViewModels;

namespace FoodHub.Data
{
	public static class DataAccess
	{
		public static IEnumerable<Food> GetFoods(
			DateTime? dateTime = null,
			byte langId = 1,
			long? userId = null,
			int count = 0,
			bool breakfast = true,
			bool lunch = true,
			bool dinner = true)
		{
			using (var db = new FoodHubEntities())
			{
				return db
						.Foods
						.Where(f => f
									 .FoodSchedules
									 .Any(
											fs => fs.AvailableDate > (dateTime ?? DateTime.Now)
											&&
											(
												f.IsMeal == false
												||
												(
													fs.BreakFast == breakfast
													&&
													fs.Lunch == lunch
													&&
													fs.Dinner == dinner
												)
											)
											&&
											fs.AvailableCount + fs.Reserves.Where(r => r.IsSold == true).Sum(r => r.ReserveCount) >= count
										   )
									 &&
									 f.FoodDetails.Any(fd => fd.LanguageId == langId)
									 &&
									 (
										userId == null
										||
										f.UserId == userId
									 )
								 );
			}
		}

		public static bool RegisterUser(RegisterUserViewModel model)
		{
			try
			{
				using (var db = new FoodHubEntities())
				{
					db.Users.Add(new User
					{
						Name = model.Name.Trim(),
						Password = Helpers.Helper.EncryptMD5(model.Password),
						Email = model.Email.Trim(),
						Telegram = model.Telegram.Trim(),
						Address = model.Address.Trim(),
						AuthAsCollege = model.AuthAsCollege,
						Image = model.Image,
						ZipCode = model.ZipCode.Trim(),
						Mobile = model.Mobile.Trim(),
						RoleId = model.RoleId
					});

					db.SaveChanges();
				}

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);

				return false;
			}
		}

		public static bool IsUserExists(string name, string email, string mobile)
		{
			using (var db = new FoodHubEntities())
			{
				return db
						.Users
						.Any(u => u.Name.Trim().Contains(name.Trim())
								  &&
								  u.Email.Trim().Contains(email.Trim())
								  &&
								  u.Mobile.Trim().Contains(mobile.Trim())
								  );
			}
		}

		private static bool IsUserAuthenticated(string email, string password)
		{
			try
			{
				using (var db = new FoodHubEntities())
				{
					return db
							.Users
							.Any(u => u.Email.Trim().Contains(email.Trim())
									&&
									u.Password.Equals(Helpers.Helper.EncryptMD5(password))
									&&
									u.IsActive == true
								);
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		private static IEnumerable<UserListViewModel> GetUsers(UserRole? role = null, bool justActives = true)
		{
			using (var db = new FoodHubEntities())
			{
				return db
						.Users
						.Where(u =>
								(
									role == null
									||
									u.RoleId == (byte)role
								)
								&&
								(
									justActives == false
									||
									u.IsActive == true
								)
							)
						.Select(s => new UserListViewModel
						{
							Address = s.Address,
							AuthAsCollege = s.AuthAsCollege,
							Email = s.Email,
							Id = s.Id,
							Image = s.Image,
							IsActive = s.IsActive,
							Mobile = s.Mobile,
							Name = s.Name,
							RoleId = s.RoleId,
							Telegram = s.Telegram,
							ZipCode = s.ZipCode
						});
			}
		}

		public static FoodViewModel RegisterFood(FoodViewModel model)
		{
			try
			{
				using (var db = new FoodHubEntities())
				{
					var foodDetails = new List<FoodDetail>();
					var foodSchedules = new List<FoodSchedule>();

					model
						.FoodDetails
						.ToList()?
						.ForEach(m => foodDetails.Add(new FoodDetail
						{
							Name = m.Name,
							LanguageId = m.LanguageId,
							Description = m.Description
						}));

					model
						.FoodSchedules
						.ToList()?
						.ForEach(m => foodSchedules.Add(new FoodSchedule
						{
							Price = m.Price,
							BreakFast = m.BreakFast,
							Lunch = m.Lunch,
							Dinner = m.Dinner,
							AvailableDate = m.AvailableDate,
							AvailableCount = m.AvailableCount,
							Description = m.Description
						}));

					db.Foods.Add(new Food
					{
						FoodCategoryId = model.FoodCategoryId,
						UserId = model.UserId,
						Price = model.Price,
						IsMeal = model.IsMeal,
						Image = model.Image,
						FoodDetails = foodDetails,
						FoodSchedules = foodSchedules
					}
					);

					db.SaveChanges();

					return model;
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static void ReserveFood(ReserveViewModel model)
		{

		}

		public static void ChangeReserveToSale(long id)
		{

		}
	}
}