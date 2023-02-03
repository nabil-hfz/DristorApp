using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DristorApp.Models;
using Microsoft.AspNetCore.SignalR;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using DristorApp.Data.Models;
using Microsoft.Extensions.Options;
using static System.Net.WebRequestMethods;
using System;
using System.IO;
using System.Net.NetworkInformation;

namespace DristorApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    //  Index() de tipul IActionResult. Aceasta este
    //  definita ca fiind public pentru a putea fi
    //  accesata de framework.
    //  Actiunile nu pot fi supraincarcate si nu pot fi statice
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
}


// ViewResult – aceasta clasa returneaza continut HTML

// EmptyResult – aceasta clasa returneaza un raspuns gol – pagina returnata nu are niciun continut (ex: returneaza status code 200 -> adica request-ul a fost executat correct, dar raspunsul este gol)

// ContentResult - poate fi folosit pentru a returna text

// FileContentResult / FileStreamResult - reprezinta continutul unui
// fisier(folosit pentru descarcarea fisierelor)

// JsonResult – reprezinta un JSON care poate fi cerut prin AJAX sau alte metode

// RedirectResult – reprezinta redirectionarea catre un nou URL

// RedirectToRouteResult – reprezinta redirectionarea catre o alta
// actiune in acelasi Controller sau in alt Controller

// PartialViewResult – returneaza HTML-ul dintr-un partial

// StatusCodeResult – returneaza un raspuns de tip: BadRequest (400), Unauthorized (401), Forbidden (403), NotFound (404).


//➢ ViewResult -> View()
//➢ ContentResult -> Content() – primeste ca parametru un string care va
//  fi afisat in browser

//➢ FileContentResult/FilePathResult/FileStreamResult -> File()
//➢ JsonResult -> Json() – primeste ca parametru orice tip de date si va returna un raspuns sub forma JSON(se va serializa parametrul primit sub forma unui string JSON)
//➢ RedirectResult -> Redirect() – primeste ca parametru un URL(in format string) si va redirectiona browser-ul catre acel URL
//➢ RedirectToRouteResult -> RedirectToRoute() – primeste ca parametru un nume de ruta(care este definita in fisierul Program.cs) si va redirectiona browser-ul catre acea ruta
//➢ PartialViewResult -> PartialView() – returneaza continutul unui partial

// De exemplu
//public IActionResult Download()
//{
//    byte[] fileBytes = System.IO.File.ReadAllBytes(@"c:\folder\myfile.ext");
//    string downloadName = "myfile.ext";
//    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, downloadName);
//}


//[ActionName("afisare")]
//public IActionResult Index()
//{
//    return Content("students/afisare");
//}
// /Home/Index => /Home/afisare


//[NonAction]
//public Student GetStudent(int id)
//{
//    return ...;
//}
//Aceasta metoda nu poate fi accesata prin intermediul unei rute, desi este publica.In schimb, ea poate fi accesata din celelalte metode ale aceluiasi Controller sau ale unui alt Controller.


// ************ verbul HTTP. De exemplu, se pot defini doua actiuni cu acelasi nume, insa care raspund la un verb HTTP diferit si au parametrii diferiti.--------------
// In cazul in care atributul ActionVerbs este omis, verbul default folosit este GET
// Aceste verbe sunt folosite in urmatoarele contexte:
// ➢ GET: este folosit in accesarea unei resurse(cererea unei pagini de la server)
// ➢ POST – este folosit in crearea unei resurse sau trimiterea datelor la server prin intermediul unui formular
// ➢ PUT/PATCH – verbul este folosit pentru modificarea(totala sau partiala) a unei resurse.De exemplu: cand se editeaza o intrare deja existenta in baza de date, se foloseste unul dintre aceste verbe
// ➢ DELETE – verb folosit pentru stergerea unei resurse
// ➢ HEAD – este identic cu GET, dar returneaza doar antetele pentru raspuns, nu si continutul raspunsului.De obicei se foloseste pentru a verifica daca exista o resursa sau daca poate fi accesata
// ➢ OPTIONS – returneaza metodele HTTP acceptate de server pentru o adresa URL specificata
// In ASP.NET Core MVC pentru editare (PUT) si stergere (DELETE) se foloseste tot POST→[HttpPost].

// DE exemplu:
// GET: se afiseaza formularul de creare a unui student
//public IActionResult New()
//{
//    return View();
//}

//[HttpPost]
//public IActionResult New(Student student)
//{
//    // cod creare student
//    // dupa crearea studentului, se preia ID-ul nou inserat din baza de date
//    // se redirectioneaza browser-ul catre studentul nou creat
//    return Redirect("/students/" + id);
//}

//Ex: Redirect("/Students/Edit" + ID);
//    Redirect("/Home/Index");

//Ex:return RedirectToRoute("Nume_Ruta");
//   return RedirectToRoute(new { controller = "Home", action = "Index"});

//Ex: return RedirectToAction("Edit"); // metoda din acelasi Controller
//    return RedirectToAction("Nume_Actiune", "Nume_Controller");
//    return RedirectToAction("Index", "Students");

//---- RedirectPermanent/ RedirectToRoutePermanent/ RedirectToActionPermanent
//Aceste metode se utilizeaza la fel ca in exemplele anterioare, singura
//diferenta fiind starea redirect-ului.In acest caz se realizeaza un
//redirect permanent(HTTP 301). Raspunsul o sa fie stocat in memoria
//cache a browser- ului, iar serverul nu o sa mai fie interogat pentru
//accesarile ulterioare.
//Pentru a returna un status al request-ului HTTP, se poate proceda astfel:
//      public StatusCodeResult BadRequst()
//{
//    return StatusCode(StatusCodes.Status400BadRequest);
//}
//public StatusCodeResult Unauthorized()
//{
//    return StatusCode(StatusCodes.Status401Unauthorized);
//}
//public IActionResult Forbidden()
//{
//    return StatusCode(StatusCodes.Status403Forbidden);
//}
//public IActionResult NotFound()
//{
//    return StatusCode(StatusCodes.Status404NotFound);
//    //sau return NotFound();
//}