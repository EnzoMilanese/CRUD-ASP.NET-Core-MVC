using CRUD_ASP.NET_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ASP.NET_Core.ViewModels
{
    public class ContatoVM
    {
        public IEnumerable<Contato> Contatos { get; set; }
    }
}
