using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ASP.NET_Core.Models
{
    public interface IContatoRepository
    {
        void CreateContato(Contato contato);
        void UpdateContato(int Id, Contato contato);
        void DeleteContato(int Id);
        Contato GetContato(int Id);
        IEnumerable<Contato> GetContatos();
    }
}
