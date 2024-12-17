﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;

        public SellersController(SellerService selerSercive)
        {
            _sellerService = selerSercive; 
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

  












    }
}
