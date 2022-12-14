using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP6.Models;



namespace TP6.Controllers;

public class errorUsuarioController : Controller
{
    private readonly ILogger<errorUsuarioController> _logger;

    public errorUsuarioController(ILogger<errorUsuarioController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
      
            return View();
            
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}