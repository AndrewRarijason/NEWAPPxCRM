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
    public class DetailsController : Controller
    {
        private readonly TicketLeadService _ticketLeadService;

        public DetailsController(TicketLeadService ticketLeadService)
        {
            _ticketLeadService = ticketLeadService;
        }

        /// <summary>
        /// Affiche la liste des tickets.
        /// </summary>
        public async Task<IActionResult> Tickets()
        {
            List<TicketDepenseDTO> tickets = await _ticketLeadService.GetTicketsAsync();
            return View(tickets);
        }

        /// <summary>
        /// Affiche la liste des leads.
        /// </summary>
        public async Task<IActionResult> Leads()
        {
            List<LeadDepenseDTO> leads = await _ticketLeadService.GetLeadsAsync();
            return View(leads);
        }

        /// <summary>
        /// Affiche les tickets d'un client spécifique.
        /// </summary>
        public async Task<IActionResult> TicketsByCustomer(long customerId)
        {
            List<TicketDepenseDTO> tickets = await _ticketLeadService.GetTicketsByCustomerIdAsync(customerId);
            Console.WriteLine("LeadsByCustomer"+tickets.Count);
            return View("Tickets",tickets);
        }

        /// <summary>
        /// Affiche les leads d'un client spécifique.
        /// </summary>
        public async Task<IActionResult> LeadsByCustomer(long customerId)
        {
            List<LeadDepenseDTO> leads = await _ticketLeadService.GetLeadsByCustomerIdAsync(customerId);
            Console.WriteLine("LeadsByCustomer"+leads.Count);
            return View("Leads",leads);
        }

        public IActionResult Modifier(int id, decimal valeur)
        {
            var model = new ModifierTicketViewModel
            {
                DepenseId = id,
                ValeurDepense = valeur
            };

            return View(model);
        }

       [HttpGet]
        public async Task<IActionResult> UpdateDepense(int id, decimal nouvelleValeur)
        {
            Console.WriteLine("UpdateDepense"+id+"?????"+nouvelleValeur);

            if (nouvelleValeur < 0)
            {
                TempData["Message"] = "La dépense soit etre positive";
                return RedirectToAction("Index", "Home");
               
            }

            bool isUpdated = await _ticketLeadService.UpdateDepenseAsync(id, nouvelleValeur);

            if (isUpdated)
            {
                TempData["Message"] = "La dépense a été mise à jour avec succès";
                // Redirige vers l'action Index du contrôleur Home
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "La dépense n'a pas pu être mise à jour. Veuillez réessayer.";
                // Redirige vers l'action Index du contrôleur Home
                return RedirectToAction("Index", "Home");
            }
        }


        public async Task<IActionResult> DeleteDepense(int id)
        {
            Console.WriteLine("DelepteDepense"+id);


            bool isUpdated = await _ticketLeadService.DeleteDepenseAsync(id);

            if (isUpdated)
            {
                TempData["Message"] = "La dépense a été efface avec succès";
                // Redirige vers l'action Index du contrôleur Home
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "La dépense n'a pas pu être afface. Veuillez réessayer.";
                // Redirige vers l'action Index du contrôleur Home
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
