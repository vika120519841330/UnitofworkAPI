using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class UnitUnitOfWork : IDisposable
    {
        private readonly MyContext context = new MyContext();
        private AccountRepository accRepository;
        private ClientRepository clRepository;

        public AccountRepository AccountProp
        {
            get
            {
                if (accRepository == null)
                    accRepository = new AccountRepository(context);
                return accRepository;
            }
        }

        public ClientRepository ClientProp
        {
            get
            {
                if (clRepository == null)
                    clRepository = new ClientRepository(context);
                return clRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}