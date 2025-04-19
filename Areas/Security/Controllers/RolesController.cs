using FakeGundamWikiAPI.Areas.Security.Models.Roles;
using Microsoft.AspNetCore.Authorization;

namespace FakeGundamWikiAPI.Areas.Security.Controllers;

[Area("Security")]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("Security/[controller]")]
[Authorize(Roles = "Administrator")]

public class RolesController(ApplicationDbContext context, IMapper mapper) : Controller
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public IActionResult Index()
    {
        var roles = _context
            .Roles
            .AsNoTracking()
            .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
            .ToList();

        return View(roles);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateRoleRequest model)
    {
        if (ModelState.IsValid)
        {
            var entity = Role.Create(model.RoleName);
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    [HttpGet("Edit/{id:int}")]
    public IActionResult Edit(int id)
    {
        var entity = _context
           .Roles
           .ProjectTo<RoleVM>(_mapper.ConfigurationProvider)
           .FirstOrDefault(x => x.RoleId == id);

        if (entity == null)
            return NotFound();

        return View(entity);
    }
}
