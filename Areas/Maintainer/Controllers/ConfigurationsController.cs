using FakeGundamWikiAPI.Areas.Maintainer.Models.Configurations;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace FakeGundamWikiAPI.Areas.Maintainer.Controllers;

[Area("Maintainer")]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("Maintainer/[controller]")]
[Authorize(Roles = "Administrator")]
public class ConfigurationsController(ApplicationDbContext context, IMapper mapper) : Controller
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var configurations = await _context.Configurations
            .AsNoTracking()
            .ProjectTo<ConfigurationDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return View(configurations);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Create(CreateConfigurationRequest model)
    {
        if (ModelState.IsValid)
        {
            var entity = Configuration.Create(model.ConfigurationName,model.ConfigurationValue);
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
            .Configurations
            .ProjectTo<ConfigurationVM>(_mapper.ConfigurationProvider)
            .FirstOrDefault(x => x.ConfigurationId == id);

        if (entity == null)
            return NotFound();

        return View(entity);
    }

    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UpdateConfigurationRequest model)
    {
        if (ModelState.IsValid)
        {
            var entity = await _context.Configurations.FindAsync(id);

            if (entity == null)
                return NotFound();

            entity.Update(model.ConfigurationName, model.ConfigurationValue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    [HttpGet("Toggle/{id}")]
    public async Task<IActionResult> Toggle(int id)
    {
        var entity = await _context.Configurations.FindAsync(id);

        if (entity == null)
            return NotFound();

        entity.ToggleActive();
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
