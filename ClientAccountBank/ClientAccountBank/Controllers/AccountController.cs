using System;
using Infrastructure.Service;
using Domain.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClientAccountBank.Controllers
{
    public class AccountController : ApiController
    {
        private readonly UnitUnitOfWork unitOfWork;
        public AccountController()
        {
            unitOfWork = new UnitUnitOfWork();
        }
        [HttpGet]
        //[Route("")]
        public IEnumerable<Account> GetAll()
        {
            return unitOfWork.AccountProp.GetAll();
        }

        [HttpGet]
        //[Route("{id:int}")]
        public Account Get([FromBody]int id)
        {
            return unitOfWork.AccountProp.Get(id);
        }

        [HttpPost]
        //[Route("")]
        public void OpenAccount([FromBody]Account inst)
        {
            unitOfWork.AccountProp.Create(inst);
        }

        [HttpPut]
        //[Route("")]
        public void Update([FromBody]Account inst)
        {
            unitOfWork.AccountProp.Update(inst);
        }

        [HttpDelete]
        //[Route("{id:int}")]
        public void Delete(int id)
        {
            unitOfWork.AccountProp.Delete(id);
        }
    }
}

