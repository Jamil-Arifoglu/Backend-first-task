﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P230_Pronia.DAL;
using P230_Pronia.Entities;

namespace P230_Pronia.Controllers
{
	public class ShopController : Controller
	{
		readonly ProniaDbContext _context;

        public ShopController(ProniaDbContext context)
		{
			_context = context;
		}
		public IActionResult index()
        {
            List<Plant> plants = _context.Plants.
                  Include(p => p.PlantTags).ThenInclude(tp => tp.Tag).
                  Include(p => p.PlantCategories).ThenInclude(cp => cp.Category).
                  Include(p => p.PlantDeliveryInformation).
                   Include(p => p.PlantImages)
                  .ToList();
            return View(plants);
        }
        public IActionResult Detail(int id)
        {
            Plant? plant = _context.Plants.
                  Include(p => p.PlantTags).ThenInclude(tp => tp.Tag).
                  Include(p => p.PlantCategories).ThenInclude(cp => cp.Category).
                  Include(p => p.PlantDeliveryInformation).
                   Include(p => p.PlantImages).FirstOrDefault(x=>x.Id==id);
                  
            return View(plant);
        }
    }
}
