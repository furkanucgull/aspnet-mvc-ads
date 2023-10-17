﻿using Ads.Data;
using Ads.Data.Entities;
using Ads.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ads.Web.Mvc.Controllers
{
    public class AddListingController : Controller
    {
        private readonly AppDbContext _context;

        public AddListingController(AppDbContext context)
        {
            _context = context;
        }

        //public IActionResult Index()
        //{

        //    var categories = _context.CategoryEntities.ToList();
        //    ViewData["Categories"] = new SelectList(categories, "Id", "Name");

        //    var model = new AddListingViewModel();
        //    return View(model);
        //}

        public IActionResult Add()
        {
            var categories = _context.CategoryEntities.ToList();
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");

            var model = new AddListingViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddListingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }


            var categories = _context.CategoryEntities.ToList();
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");


            AddListingEntity add = new()
            {
                ContactEmail = model.ContactEmail,
                AdType = model.AdType,
                AcceptTermsAndConditions = model.AcceptTermsAndConditions,
                AdFeature = model.AddFeature,
                AdvertImages = model.AdvertImages,
                Category = model.Category,
                ContactAddress = model.ContactAddress,
                ContactName = model.ContactName,
                ContactNumber = model.ContactNumber,
                CreatedAt = DateTime.Now,
                DeletedAt = DateTime.Now,
                Description = model.Description,
                IsPriceNegotiable = model.IsPriceNegotiable,
                PaymentMethod = model.PaymentMethod,
                Price = model.Price,
                Title = model.Title,
                UpdatedAt = DateTime.Now,
                User = model.User,
                Advert = model.Advert,
            };
            _context.AddListingEntities.Add(add);
            await _context.SaveChangesAsync();




            return View("Add", model);

        }
    }
}
