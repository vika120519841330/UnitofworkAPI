using Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MyContext : DbContext
    {
        // Обьявление таблиц в БД
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }

        //Конструктор, инициализирующий БД
        public MyContext()
        {
            Database.EnsureCreated();
        }

        // Конфигурирование подключения к БД
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                                        Database=clientaccount;
                                        Trusted_Connection=True;");
        }

        // Инициализация БД начальными значениями
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region
            // Инициализация таблицы с моделями Client
            modelBuilder.Entity<Client>().HasData(
                 new Client
                 {
                     ClientId = 1,
                     ClientTitle = "Иванов Иван Иванович",
                     ClientMarkJuridical = false,
                     ClientTaxpayNum = "MP1234565"
                 },
                 new Client
                 {
                     ClientId = 2,
                     ClientTitle = "Петров Петр Петрович",
                     ClientMarkJuridical = false,
                     ClientTaxpayNum = "PB1234964"
                 },
                 new Client
                 {
                     ClientId = 3,
                     ClientTitle = "Сидоров Николай Петрович",
                     ClientMarkJuridical = false,
                     ClientTaxpayNum = "PB7812764"
                 },
                 new Client
                 {
                     ClientId = 4,
                     ClientTitle = "Стройтехносистем",
                     ClientMarkJuridical = true,
                     ClientTaxpayNum = "123456789"
                 },
                 new Client
                 {
                     ClientId = 5,
                     ClientTitle = "Види",
                     ClientMarkJuridical = true,
                     ClientTaxpayNum = "123456788"
                 },
                 new Client
                 {
                     ClientId = 6,
                     ClientTitle = "Промтехнология",
                     ClientMarkJuridical = true,
                     ClientTaxpayNum = "123456787"
                 },
                 new Client
                 {
                     ClientId = 7,
                     ClientTitle = "Модная Галактика",
                     ClientMarkJuridical = true,
                     ClientTaxpayNum = "123456786"
                 }
                 );
            base.OnModelCreating(modelBuilder);
            # endregion
            #region
            // Инициализация таблицы с моделями Account
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    AccountId = 21,
                    AccountBalance = 120,
                    AccountNumber = "123456781"
                },
                new Account
                {
                    AccountId = 22,
                    AccountBalance = 0,
                    AccountNumber = "123456782"
                },
                new Account
                {
                    AccountId = 23,
                    AccountBalance = 1100,
                    AccountNumber = "123456783"
                },
                new Account
                {
                    AccountId = 24,
                    AccountBalance = 1230,
                    AccountNumber = "123456784"
                },
                new Account
                {
                    AccountId = 25,
                    AccountBalance = 57457,
                    AccountNumber = "123456785"
                },
                 new Account
                 {
                     AccountId = 26,
                     AccountBalance = 1250,
                     AccountNumber = "123456786"
                 },
                 new Account
                 {
                     AccountId = 27,
                     AccountBalance = 124530,
                     AccountNumber = "123456787"
                 },
                 new Account
                 {
                     AccountId = 28,
                     AccountBalance = 0,
                     AccountNumber = "123456788"
                 },
                 new Account
                 {
                     AccountId = 29,
                     AccountBalance = 6550,
                     AccountNumber = "123456789"
                 },
                 new Account
                 {
                     AccountId = 30,
                     AccountBalance = 124530,
                     AccountNumber = "123456790"
                 },
                new Account
                {
                    AccountId = 31,
                    AccountBalance = 0,
                    AccountNumber = "123456791"
                },
                new Account
                {
                    AccountId = 32,
                    AccountBalance = 15990,
                    AccountNumber = "123456792"
                }
                );
            base.OnModelCreating(modelBuilder);
            #endregion

            //Связывание с пом.Fluent API зависимой сущности Account с главной сущностью Client
            modelBuilder.Entity<Account>()
           .HasOne(p => p.ClientOfAccount)              // сущность Account связана с Client "один к одному"
           .WithMany(t => t.AccountsOfClient)           // сущность Client связана с сущностью Account "один ко многим"
           .HasForeignKey(p => p.ClientClientId)        // внешний ключ
           .OnDelete(DeleteBehavior.Cascade);           // при удалении главной сущности зависимая также удаляется

        }
    }
}
