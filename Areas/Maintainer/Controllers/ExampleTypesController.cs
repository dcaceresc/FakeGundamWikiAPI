using AutoMapper;
using FakeGundamWikiAPI.Areas.Maintainer.Models.ExampleTypes;
using Microsoft.AspNetCore.Authorization;

namespace FakeGundamWikiAPI.Areas.Maintainer.Controllers;

[Area("Maintainer")]
[Route("Maintainer/[controller]")]
[Authorize(Roles = "Administrator")]
public class ExampleTypesController(ApplicationDbContext context, IMapper mapper) : Controller
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public IActionResult Index()
    {
        var model = _context
            .ExampleTypes
            .AsNoTracking()
            .ProjectTo<ExampleTypeDto>(_mapper.ConfigurationProvider)
            .ToList();

        return View(model);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateExampleTypeRequest model)
    {
        if (ModelState.IsValid)
        {
            var entity = new ExampleType
            {
                ExampleTypeName = model.ExampleTypeName,
                IsActive = true
            };

            _context.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    [HttpGet("Edit/{id}")]
    public IActionResult Edit(int id)
    {
        var entity = _context
            .ExampleTypes
            .ProjectTo<ExampleTypeVM>(_mapper.ConfigurationProvider)
            .FirstOrDefault(x => x.ExampleTypeId == id);

        if (entity == null)
            return NotFound();

        return View(entity);
    }

    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EditExampleTypeRequest model)
    {
        if (ModelState.IsValid)
        {
            var entity = _context.ExampleTypes.Find(id);

            if (entity == null)
                return NotFound();

            entity.ExampleTypeName = model.ExampleTypeName;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }


    [HttpGet("Toggle/{id}")]
    public async Task<IActionResult> Toggle(int id)
    {
        var entity = _context.ExampleTypes.Find(id);
        
        if (entity == null)
            return NotFound();

        entity.IsActive = !entity.IsActive;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
