using System.Collections.Generic;
using System.Web.Mvc;

namespace FoodHub.Controllers
{
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			Data.DataAccess.RegisterFood(new ViewModels.FoodViewModel
			{
				FoodCategoryId = 1,
				Image = "Image path Url",
				IsMeal = true,
				Price = 10000,
				UserId = 1,
				FoodDetails = new List<ViewModels.FoodDetailViewModel>
				{
					new ViewModels.FoodDetailViewModel{ LanguageId = 1, Name = "قیمه", Description = "This is Gheymeh"}
				},
				FoodSchedules = new List<ViewModels.FoodScheduleViewModel>
				{
					new ViewModels.FoodScheduleViewModel
						{
						  BreakFast = true,
						  Lunch = true,
						  Dinner = true,
						  Price = 1000,
						  AvailableCount = 20,
						  AvailableDate = System.DateTime.Now.AddDays(2),
						  Description = "Today we have 20 Gheymeh"
						}
				}
			});


			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}