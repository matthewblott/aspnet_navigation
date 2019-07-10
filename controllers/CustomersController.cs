using System;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_template.controllers
{
  public class CustomersController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult List()
    {
      return View();
    }
    
    public IActionResult Edit(int customerId)
    {
      return View();
    }
    
    [HttpPost]
    public IActionResult Create()
    {
      return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    public IActionResult Update()
    {
      return RedirectToAction(nameof(Index));
    }

  }
  
}