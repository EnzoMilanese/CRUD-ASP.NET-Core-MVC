using CRUD_ASP.NET_Core.Models;
using CRUD_ASP.NET_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ASP.NET_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContatoRepository _contatoRepository;

        public HomeController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            ContatoVM viewModel = new ContatoVM();
            viewModel.Contatos = _contatoRepository.GetContatos();
            return View(viewModel);
        }
    }
}
