using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NekocakeApp.Models;
using NekocakeApp.ViewModels;

namespace NekocakeApp.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            var viewModel = new PieListViewModel()
            {
                Title = "Welcome to the Pie Shop",
                Pies = _pieRepository.Pies
            };
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
           var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}