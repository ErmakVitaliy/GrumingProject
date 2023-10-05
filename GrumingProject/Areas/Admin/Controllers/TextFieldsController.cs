using GrumingProject.Controllers;
using GrumingProject.Domain;
using GrumingProject.Domain.Entities;
using GrumingProject.Service;
using Microsoft.AspNetCore.Mvc;

namespace GrumingProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TextFieldsController : Controller
	{
		private readonly DataManager dataManager;

		public TextFieldsController(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

		public IActionResult Edit(string codeWord)
		{
			var entity = dataManager?.TextFields?.GetTextFieldByCodeWord(codeWord);
			return View(entity);
		}
		[HttpPost]
		public IActionResult Edit(TextField model)
		{
			if (ModelState.IsValid)
			{
				dataManager?.TextFields?.SaveTextField(model);
				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
			}
			return View(model);
		}
	}
}
