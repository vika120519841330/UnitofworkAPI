using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core
{
    public class Client
    {
        // Имя первичного ключа сущности - Идентификатор клиента
        public int ClientId;
        // Полное наименование клиента(название юр.лица/ФИО физ.лица)
        public string ClientTitle;
        // Отметка о том клиент является юр.лицом (true) или физюлицом(false)
        public bool ClientMarkJuridical;
        //УНП юр.лица/Номер паспорта физ.лица
        public string ClientTaxpayNum;
        // Навигационное свойство - Коллекция всех р/с, привязанных к клиенту
        public List<Account> AccountsOfClient;
    }
}