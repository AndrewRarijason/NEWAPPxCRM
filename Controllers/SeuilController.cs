using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_app_dotnet.Models;
using new_app_dotnet.Services;


namespace new_app_dotnet.Controllers

{
    [Authorize] // 🔹 Restreint l'accès aux utilisateurs authentifiés
    [Authorize(Roles = "ROLE_MANAGER")] // 🔹 Seulement pour les managers
    public class SeuilController : Controller
    {
        private readonly SeuilService _seuilService;

        public SeuilController(SeuilService seuilService)
        {
            _seuilService = seuilService;
        }


        public async Task<IActionResult> Index()
        {

            
            double seuil = await _seuilService.getSeuilAsync();
            TempData["Message"] = "Taux actuel "+seuil;

            
            return View();
        }

       [HttpGet]
        public async Task<IActionResult> UpdateSeuil(decimal nouvelleValeur)
        {

            if (nouvelleValeur <= 0)
            {
                TempData["Message"] = "Le taux doit etre positif";
                return RedirectToAction("Index", "Home");
            }

            bool isUpdated = await _seuilService.UpdateSeuilAsync( nouvelleValeur);

            if (isUpdated)
            {
                TempData["Message"] = "Le seuil a été mise à jour avec succès";
                // Redirige vers l'action Index du contrôleur Home
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Le seuil n'a pas pu être mise à jour. Veuillez réessayer.";
                // Redirige vers l'action Index du contrôleur Home
                return RedirectToAction("Index");
            }
        }

    }
}
