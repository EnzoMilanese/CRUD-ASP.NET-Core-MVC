using CRUD_ASP.NET_Core.Models;
using CRUD_ASP.NET_Core.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ASP.NET_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IHostingEnvironment _hostingEnviroment;

        public HomeController(IContatoRepository contatoRepository,
                              IHostingEnvironment hostingEnviroment)
        {
            _contatoRepository = contatoRepository;
            _hostingEnviroment = hostingEnviroment;
        }

        public IActionResult Index()
        {
            var viewModel = new ContatoVM.Index();
            viewModel.Contatos = _contatoRepository.GetAll();
            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            var model = _contatoRepository.Get(id);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("ContatoNaoExiste", id);
            }
            ContatoVM.Detail viewModel = new ContatoVM.Detail() { Contato = model };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContatoVM.Create model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessarFoto(model);
                Contato contato = new Contato
                {
                    Nome = model.Nome,
                    Numero = model.Numero,
                    FotoPerfil = uniqueFileName
                };

                _contatoRepository.Create(contato);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _contatoRepository.Get(id);
            var viewModel = new ContatoVM.Edit()
            {
                Id = id,
                Nome = model.Nome,
                Numero = model.Numero,
                CaminhoFotoPerfil = model.FotoPerfil
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ContatoVM.Edit model)
        {
            if (ModelState.IsValid)
            {
                Contato contato = _contatoRepository.Get(model.Id);
                contato.Nome = model.Nome;
                contato.Numero = model.Numero;
                if (model.FotoPerfil != null)
                {
                    if (model.CaminhoFotoPerfil != null)
                    {
                        string FotoAntiga = Path.Combine(_hostingEnviroment.WebRootPath, "images", model.CaminhoFotoPerfil);
                        System.IO.File.Delete(FotoAntiga);
                    }
                    contato.FotoPerfil = ProcessarFoto(model);
                }

                _contatoRepository.Update(contato);
                return RedirectToAction("Index");
            }

            return View();
        }

        private string ProcessarFoto(ContatoVM.Create model)
        {
            string uniqueFileName = null;
            if (model.FotoPerfil != null)
            {
                string imageFolder = Path.Combine(_hostingEnviroment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FotoPerfil.FileName;
                string filePath = Path.Combine(imageFolder, uniqueFileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                model.FotoPerfil.CopyTo(stream);
            }
            return uniqueFileName;
        }
    }
}
