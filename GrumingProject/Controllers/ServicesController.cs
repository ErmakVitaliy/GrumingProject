﻿using Microsoft.AspNetCore.Mvc;
using GrumingProject.Domain;

namespace GrumingProject.Controllers
{
	public class ServicesController : Controller
	{
		private readonly DataManager dataManager;

		public ServicesController(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

		public IActionResult Index(Guid id)
		{
			if(id != default)
			{
				return View("Show",dataManager.ServiceItems.GetServiceByItem(id));
			}
			ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageService");
			return View(dataManager.ServiceItems.GetServiceItems());
			
		}
	}
}
