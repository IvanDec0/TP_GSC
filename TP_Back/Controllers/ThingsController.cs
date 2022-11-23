using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_Back.DataAccess;
using TP_Back.DataAccess.UnitOfWork;
using TP_Back.Dto;
using TP_Back.Entities;
using TP_Back.Models;

namespace TP_Back.Controllers
{
    public class ThingsController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ILogger<ThingsController> logger;


        public ThingsController(IUnitOfWork uow, IMapper mapper, ILogger<ThingsController> logger)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: Things
        [HttpGet]
        public IActionResult Index()
        {
            var Things = uow.ThingsRepo.GetAll();
            var ThingsMapped = mapper.Map<List<ThingDto>>(Things);
            
            return View(ThingsMapped);
        }

        // GET: Things/Details/5
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null || id == 0)
                return NotFound();

            var thing = uow.ThingsRepo.GetOne(id.Value);
            if (thing is null)
                return NotFound();

            return View(thing);
        }

        // GET: Things/Create
        public IActionResult Create()
        {
            var Categories = uow.CategoryRepo.GetAll();
            var CategoriesMapped = mapper.Map<CategoryDto[]>(Categories);

            var modelThing = new ModelThingCreation()
            {
                Categories = CategoriesMapped.ToList(),
            };

            return View(modelThing);
        }

        // POST: Things/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModelThingCreation thingDto)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError($"Invalid POST attempt in {nameof(Create)}");
                return BadRequest(ModelState);
            }

            var selectedCategory = uow.CategoryRepo.GetOne(thingDto.CategoryId);

            var thing = new Thing
            {
                Description = thingDto.Description,
                Category = selectedCategory!
            };
            await uow.ThingsRepo.InsertAsync(thing);
            await uow.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Things/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
                return NotFound();

            var thing = uow.ThingsRepo.GetOne(id.Value);
            if (thing is null)
                return NotFound();

            var Categories = uow.CategoryRepo.GetAll();
            var CategoriesMapped = mapper.Map<CategoryDto[]>(Categories);

            var createThingViewModel = new ModelThingCreation()
            {
                Categories = CategoriesMapped.ToList(),
                Description = thing.Description,
                CategoryId = thing.Category.Id
            };

            return View(createThingViewModel);
        }

        // POST: Things/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, ModelThingCreation thingDto)
        {
            if (!ModelState.IsValid || id < 1)
            {
                logger.LogError($"Invalid UPDATE attempt in {nameof(Edit)}");
                return BadRequest(ModelState);
            }


            var thing = await uow.ThingsRepo.GetAsync(q => q.Id == id);
            if (thing == null)
            {
                logger.LogError($"Invalid UPDATE attempt in {nameof(Edit)}");
                return BadRequest("Submitted data is invalid");
            }
            var ActualCategory = uow.CategoryRepo.GetOne(thingDto.CategoryId);

            thing.Description = thingDto.Description;
            thing.Category = ActualCategory!;

            uow.ThingsRepo.update(thing);
            await uow.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Things/Delete/5
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
                return NotFound();

            var thing = uow.ThingsRepo.GetOne(id.Value);
            if (thing is null)
                return NotFound();

            var thingMapped = mapper.Map<ThingDto>(thing);

            return View(thingMapped);
        }

        // POST: Things/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int? id)
        {
            if (id is null)
                return NotFound();

            uow.ThingsRepo.DeleteById(id.Value);
            uow.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }

}
