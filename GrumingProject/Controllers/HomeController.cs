﻿using GrumingProject.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GrumingProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
		{
			return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));
		}
        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }
    }
}
