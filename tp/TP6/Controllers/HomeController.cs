using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP6.Models;


// Para session
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
namespace TP6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
        if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Password) )){
            return RedirectToAction("Index","Usuario"); 
        }else
        {
            return View();
            
        }
    }

    [HttpPost]
    public IActionResult IndexCadete(){
       
            
           
        return RedirectToAction("Index","Cadete");
    }
    public IActionResult IndexCliente(){
       
            
           
        return RedirectToAction("Index","Cliente");
    }
    public IActionResult IndexPedido(){
       
            
           
        return RedirectToAction("Index","Pedido");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
