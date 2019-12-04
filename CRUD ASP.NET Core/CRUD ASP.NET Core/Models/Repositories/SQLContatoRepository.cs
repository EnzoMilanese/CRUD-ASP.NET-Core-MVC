using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ASP.NET_Core.Models.Repositories
{
    public class SQLContatoRepository : IContatoRepository
    {
        private readonly AppDbContext context;

        public SQLContatoRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Contato Create(Contato contato)
        {
            context.Contatos.Add(contato);
            context.SaveChanges();
            return contato;
        }

        public Contato Delete(Contato contatoDeleta)
        {
            var contato = context.Contatos.Find(contatoDeleta.Id);
            if(contato != null)
            {
                context.Contatos.Remove(contato);
                context.SaveChanges();

            }
            return contato;
        }

        public Contato Get(int Id)
        {
            return context.Contatos.Find(Id);
        }

        public List<Contato> GetAll()
        {
            var contatos = context.Contatos.ToList();
            return contatos;
        }

        public Contato Update(Contato contatoModificado)
        {
            var contato = context.Contatos.Attach(contatoModificado);
            contato.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return contato.Entity;
        }
    }
}
