using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class Account
    {
        // Имя первичного ключа сущности - Идентификатор р/с
        public int AccountId { get; set; }
        // Номер р/с
        public string AccountNumber { get; set; }
        // Баланс р/с
        public double AccountBalance { get; set; }
        // Внешний ключ - ID владельца р/с
        public int ClientClientId { get; set; }
        [ForeignKey("ClientClientId")]
        // Навигационное свойство - Клиент-владелец р/с
        public Client ClientOfAccount { get; set; }
    }
}