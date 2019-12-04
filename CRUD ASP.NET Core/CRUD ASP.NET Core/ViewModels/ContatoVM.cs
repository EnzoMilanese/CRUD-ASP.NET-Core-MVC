using CRUD_ASP.NET_Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ASP.NET_Core.ViewModels
{
    public class ContatoVM
    {
        public class Index
        {
            public IEnumerable<Contato> Contatos { get; set; }
        }

        public class Create
        {
            [Display(Name = "Nome")]
            [Required(ErrorMessage = "Campo não pode ser vazio")]
            public string Nome { get; set; }

            [Display(Name = "Telefone celular")]
            public string Numero { get; set; }

            [Display(Name = "Foto de perfil")]
            public IFormFile FotoPerfil { get; set; }
        }

        public class Edit : Create
        {
            public int Id { get; set; }
            public string CaminhoFotoPerfil { get; set; }
        }

        public class Detail
        {
            public Contato Contato { get; set; }
        }
    }
}
