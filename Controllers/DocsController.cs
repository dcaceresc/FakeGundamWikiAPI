using FakeGundamWikiAPI.Areas.Maintainer.Models.Examples;

namespace FakeGundamWikiAPI.Controllers;
public class DocsController(ApplicationDbContext context, IMapper mapper) : Controller
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Affiliations()
    {
        var model = await _context
            .Examples
            .ProjectTo<ExampleDto>(_mapper.ConfigurationProvider)
            .Where(x => x.ExampleTypeName == "Affiliation")
            .ToListAsync();
        
        return View(model);
    }

    public async Task<IActionResult> Characters()
    {
        var model = await _context
            .Examples
            .ProjectTo<ExampleDto>(_mapper.ConfigurationProvider)
            .Where(x => x.ExampleTypeName == "Character")
            .ToListAsync();

        return View(model);
    }

    public IActionResult Manufacturers()
    {
        var model = _context
            .Examples
            .ProjectTo<ExampleDto>(_mapper.ConfigurationProvider)
            .Where(x => x.ExampleTypeName == "Manufacturer")
            .ToList();

        return View();
    }

    public IActionResult MobileSuits()
    {
        var model = _context
            .Examples
            .ProjectTo<ExampleDto>(_mapper.ConfigurationProvider)
            .Where(x => x.ExampleTypeName == "MobileSuit")
            .ToList();

        return View();
    }

    public IActionResult Series()
    {
        return View();
    }

    public IActionResult Universes()
    {
        return View();
    }

}
