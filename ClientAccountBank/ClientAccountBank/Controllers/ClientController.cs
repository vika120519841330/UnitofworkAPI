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
    public class ClientController : ApiController
    {
        private readonly UnitUnitOfWork unitOfWork;
        public ClientController()
        {
            unitOfWork = new UnitUnitOfWork();
        }
        [HttpGet]
        //[Route("")]
        public IEnumerable<Client> GetAll()
        {
            return unitOfWork.ClientProp.GetAll();
        }

        [HttpGet]
        //[Route("{id:int}")]
        public Client Get([FromBody]int id)
        {
            return unitOfWork.ClientProp.Get(id);
        }

        [HttpPost]
        //[Route("")]
        public void OpenAccount([FromBody]Client inst)
        {
            unitOfWork.ClientProp.Create(inst);
        }

        [HttpPut]
        //[Route("")]
        public void Update([FromBody]Client inst)
        {
            unitOfWork.ClientProp.Update(inst);
        }

        [HttpDelete]
        //[Route("{id:int}")]
        public void Delete(int id)
        {
            unitOfWork.ClientProp.Delete(id);
        }
    }
}

