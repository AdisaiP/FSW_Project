using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Controllers;

public class ImportAdjustmentController : Controller
{
  private readonly IWebHostEnvironment _env;

  public ImportAdjustmentController(IWebHostEnvironment env)
  {
    _env = env;
  }

  public IActionResult IndexIMD()
  {
    return View();
  }

  public IActionResult CreateIMD()
  {
    return View();
  }

  public IActionResult IndexPurchase()
  {
    return View();
  }

  public IActionResult CreatePurchase()
  {
    return View();
  }

  public IActionResult IndexPost()
  {
    return View();
  }

  public IActionResult CreatePost()
  {
    return View();
  }

}
