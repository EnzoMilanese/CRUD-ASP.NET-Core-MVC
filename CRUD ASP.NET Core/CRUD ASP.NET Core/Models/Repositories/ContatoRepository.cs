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
            _contatoList.Add(new Contato { Id = 1, Nome = "Enzo", Numero = "+55 11 96900-5352" });
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
            return _contatoList.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Contato> GetContatos()
        {
            return _contatoList;
        }

        public void UpdateContato(int Id, Contato contato)
        {
            throw new NotImplementedException();
        }
    }
}
