using FakeGundamWikiAPI.Areas.Maintainer.Models.Examples;
using FakeGundamWikiAPI.Areas.Maintainer.Models.ExampleTypes;
using FakeGundamWikiAPI.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FakeGundamWikiAPI.Areas.Maintainer.Controllers;

[Area("Maintainer")]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("Maintainer/[controller]")]
[Authorize(Roles = "Administrator")]
public class ExamplesController(ApplicationDbContext context, IMapper mapper) : BaseController
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    [HttpGet("")]
    public async Task<IActionResult> Index(int page = 1)
    {
        var allItems = await _context
            .Examples
            .AsNoTracking()
            .ProjectTo<ExampleDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        var pagedItems = allItems.Skip((page - 1) * 10).Take(10).ToList();
        var totalPages = (int)Math.Ceiling((double)allItems.Count / 10);

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = totalPages;
        ViewBag.PageSizes = 10;

        return View(pagedItems);
    }

    [HttpGet("Create")]
    public async Task<IActionResult> Create()
    {
        var exampleTypes = await _context
            .ExampleTypes
            .AsNoTracking()
            .ProjectTo<ExampleTypeDto>(_mapper.ConfigurationProvider)
            .Where(x => x.IsActive)
            .ToListAsync();

        ViewBag.ExampleTypes = new SelectList(exampleTypes, nameof(ExampleTypeDto.ExampleTypeId), nameof(ExampleTypeDto.ExampleTypeName));

        return View();
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateExampleRequest model)
    {
        if (ModelState.IsValid)
        {
            var entity = new Example
            {
                ExampleName = model.ExampleName,
                ExampleCode = model.ExampleCode,
                ExampleResult = model.ExampleResult,
                ExampleTypeId = model.ExampleTypeId,
                IsActive = true
            };

            _context.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var entity = await _context
            .Examples
            .ProjectTo<ExampleVM>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.ExampleId == id);

        if (entity == null)
            return NotFound();

        var exampleTypes = await _context
            .ExampleTypes
            .AsNoTracking()
            .ProjectTo<ExampleTypeDto>(_mapper.ConfigurationProvider)
            .Where(x => x.IsActive)
            .ToListAsync();

        ViewBag.ExampleTypes = new SelectList(exampleTypes, nameof(ExampleTypeDto.ExampleTypeId), nameof(ExampleTypeDto.ExampleTypeName));

        return View(entity);
    }

    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EditExampleRequest model)
    {
        if (ModelState.IsValid)
        {
            var entity = await _context.Examples.FindAsync([id]);

            if (entity == null)
                return NotFound();

            entity.ExampleName = model.ExampleName;
            entity.ExampleCode = model.ExampleCode;
            entity.ExampleResult = model.ExampleResult;
            entity.ExampleTypeId = model.ExampleTypeId;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost("Toggle/{id}")]
    public async Task<IActionResult> Toggle(int id)
    {
        var entity = await _context.Examples.FindAsync([id]);

        if (entity == null)
            return NotFound();

        entity.IsActive = !entity.IsActive;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
