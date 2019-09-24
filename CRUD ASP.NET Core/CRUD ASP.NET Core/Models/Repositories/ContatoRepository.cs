using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ASP.NET_Core.Models.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private List<Contato> _contatoList;

        public ContatoRepository()
        {
            _contatoList = new List<Contato>();
        }

        public void CreateContato(Contato contato)
        {
            throw new NotImplementedException();
        }

        public void DeleteContato(int Id)
        {
            throw new NotImplementedException();
        }

        public Contato GetContato(int Id)
        {
            return new Contato{ Id = Id, Nome = "Enzo", Numero = "+55 11 96900-5352" };
        }

        public List<Contato> GetContatos()
        {
            throw new NotImplementedException();
        }

        public void UpdateContato(int Id, Contato contato)
        {
            throw new NotImplementedException();
        }
    }
}
