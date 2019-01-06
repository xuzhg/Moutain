﻿using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository repository;
        public NavController(IProductsRepository repo)
        {
            repository = repo;
        }

        // GET: Nav
        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = repository.Products.Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}