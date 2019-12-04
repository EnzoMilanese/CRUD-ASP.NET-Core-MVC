using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ASP.NET_Core.Models
{
    public interface IContatoRepository
    {
        Contato Create(Contato contato);
        Contato Update(Contato contato);
        Contato Delete(Contato contato);
        Contato Get(int Id);
        List<Contato> GetAll();
    }
}
