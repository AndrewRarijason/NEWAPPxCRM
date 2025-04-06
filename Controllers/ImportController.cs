using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using new_app_dotnet.Services;

namespace new_app_dotnet.Controllers;


    [Authorize]
[Authorize(Roles = "ROLE_MANAGER")]
public class ImportController : Controller
{
    private readonly ImportCsvService _importCsvService;

    public ImportController(ImportCsvService importCsvService)
    {
        _importCsvService = importCsvService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(Microsoft.AspNetCore.Http.IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            TempData["Error"] = "Veuillez sélectionner un fichier valide.";
            return RedirectToAction("Index");
        }

        try
        {
            // Sauvegarder temporairement le fichier
            var tempFilePath = Path.GetTempFileName();
            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Appeler le service d'import
            bool importResult = await _importCsvService.ImportComplexCsvAsync(tempFilePath);

            // Supprimer le fichier temporaire
            System.IO.File.Delete(tempFilePath);

            if (importResult)
            {
                TempData["Message"] = "Importation réussie !";
            }
            else
            {
                TempData["Error"] = "Erreur lors de l'importation. Veuillez vérifier le format du fichier.";
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Erreur: {ex.Message}";
        }

        return RedirectToAction("Index");
    }
}