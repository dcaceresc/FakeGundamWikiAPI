using FakeGundamWikiAPI.Areas.Security.Models.Roles;
using FakeGundamWikiAPI.Areas.Security.Models.Users;
using Microsoft.AspNetCore.Authorization;

namespace FakeGundamWikiAPI.Areas.Security.Controllers;

[Area("Security")]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("Security/[controller]")]
[Authorize(Roles = "Administrator")]
public class UsersController(ApplicationDbContext context, IMapper mapper, AuthenticationService authenticationService) : Controller
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    private readonly AuthenticationService _authenticationService = authenticationService;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var users = await _context
            .Users
            .AsNoTracking()
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return View(users);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        ViewBag.Roles = _context
            .Roles
            .AsNoTracking()
            .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
            .ToList();

        return View();
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateUserRequest model)
    {
        if (ModelState.IsValid)
        {
            var entity = Data.Entities.User.Create(model.UserName, model.FirstName, model.LastName, _authenticationService.HashPassword(model.Password));

            _context.Add(entity);
            await _context.SaveChangesAsync();

            foreach (var roleId in model.RoleIds)
            {
                var userRole = entity.AssignRole(roleId);
                _context.Add(userRole);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    [HttpGet("Edit/{id:int}")]
    public IActionResult Edit(int id)
    {
        var entity = _context
            .Users
            .ProjectTo<UserVM>(_mapper.ConfigurationProvider)
            .FirstOrDefault(x => x.UserId == id);

        if (entity == null)
            return NotFound();

        ViewBag.Roles = _context
            .Roles
            .AsNoTracking()
            .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
            .ToList();


        return PartialView(entity);
    }

    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EditUserRequest model)
    {
        if (ModelState.IsValid)
        {
            var entity = _context.Users.Find(id);

            if (entity == null)
                return NotFound();

            entity.Update(model.UserName, model.FirstName, model.LastName, _authenticationService.HashPassword(model.Password));


            var userRoles = _context.UserRoles.Where(x => x.UserId == id).ToList();
            foreach (var userRole in userRoles)
            {
                _context.UserRoles.Remove(userRole);
            }

            foreach (var roleId in model.RoleIds)
            {
                var userRole = entity.AssignRole(roleId);
                _context.Add(userRole);
            }


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }


    [HttpGet("Toggle/{id}")]
    public async Task<IActionResult> Toggle(int id)
    {
        var entity = _context.Users.Find(id);

        if (entity == null)
            return NotFound();

        entity.ToggleActive();

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }



}
