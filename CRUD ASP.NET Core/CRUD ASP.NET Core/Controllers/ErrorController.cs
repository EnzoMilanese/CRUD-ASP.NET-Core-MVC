using CRUD_ASP.NET_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ASP.NET_Core.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var viewModel = new ErroVM() { StatusCode = statusCode };
            switch (statusCode)
            {
                case 404:
                    viewModel.ErrorMessage = "Recurso não foi encontrado";
                    break;
            }
            return View("_Erro", viewModel);
        }

        [Route("Error")]
        public IActionResult HttpStatusCodeHandler()
        {
            var viewModel = new ErroVM()
            {
                StatusCode = 500,
                ErrorMessage = "Ocorreu um erro no servidor..."
            };
            return View("_Erro", viewModel);
        }
    }
}
