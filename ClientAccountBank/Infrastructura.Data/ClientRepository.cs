using Domain.Core;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Infrastructure.Data
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly MyContext context;
        public ClientRepository(MyContext _context)
        {
            this.context =_context;
        }
        public IEnumerable<Client> GetAll()
        {
            return context.Clients
                   //.Include(_ => _.AccountsOfClient)
                   //.ThenInclude(p => p.AccountNumber)
                   //.ToList()
                   ;  

            //var clients = context.Clients;
            //foreach (Client c in clients)
            //{
            //    context.Entry(c).Collection(_ => _.AccountsOfClient).Load();
            //}
            //return context.Clients.ToList();
        }

            public Client Get(int id)
        {
            var tmp = from bd in context.Clients
                      where bd.ClientId == id
                      select bd;
            return tmp.Count() > 0 ? tmp.FirstOrDefault() : null;
        }

        public void Create(Client inst)
        {
            context.Clients.Add(inst);
        }

        public void Update(Client inst)
        {
           context.Entry(inst).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var tmp =context.Clients.Find(id);
            if (tmp != null)
            {
                context.Clients.Remove(tmp);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}