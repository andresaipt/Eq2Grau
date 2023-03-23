using Eq2Grau.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eq2Grau.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index(int A, int B, int C) {
            // Variáveis auxiliares
            double delta = B * B - 4 * A * C;
            string x1 = "", x2 = "";

            // Posso calcular as raízes?
            if (A != 0) {
                // Há raizes reais?
                if (delta >= 0) {
                    // Sim, há
                    // x1 = (-b + sqrt(b^2 - 4ac)) / (2a)
                    // x2 = (-b - sqrt(b^2 - 4ac)) / (2a)
                    x1 = (-B + Math.Sqrt(delta)) / (2 * A) + "";
                    x2 = (-B - Math.Sqrt(delta)) / (2 * A) + "";
                } else {
                    // Não há raízes reais
                    // x1 = -b / (2a) + sqrt(-delta) / (2a) i
                    // x2 = -b / (2a) - sqrt(-delta) / (2a) i
                    x1 = -B / (2 * A) + " + " + Math.Sqrt(-delta) / (2 * A) + "i";
                    x2 = -B / (2 * A) + " - " + Math.Sqrt(-delta) / (2 * A) + "i";
                }
            }

            // Preparar os dados para serem enviados para a View
            ViewBag.X1 = x1;
            ViewBag.X2 = x2;

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}