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
    public class AccountRepository : IRepository<Account>
    {
        private readonly MyContext context;
        public AccountRepository(MyContext _context)
        {
            this.context =_context;
        }
        public IEnumerable<Account> GetAll()
        {
            return context.Accounts
                //.Include(_=>_.ClientOfAccount)
                //.ToList()
                ;
            //var accounts = context.Accounts;
            //foreach (Account a in accounts)
            //{
            //    context.Entry(a).Reference(_ => _.ClientOfAccount).Load();
            //}
            //return context.Accounts.ToList();
        }

        public Account Get(int id)
        {
            var temp = context.Accounts.Find(id);
            if (temp == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else return temp;
        }

        public void Create(Account inst)
        {
            context.Accounts.Add(inst);
        }

        public void Update(Account inst)
        {
           context.Entry(inst).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var tmp =context.Accounts.Find(id);
            if (tmp != null)
            {
                context.Accounts.Remove(tmp);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}