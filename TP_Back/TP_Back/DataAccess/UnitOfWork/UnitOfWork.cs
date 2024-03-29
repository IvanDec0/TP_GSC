﻿using Microsoft.EntityFrameworkCore;
using TP_Back.DataAccess.Interface;
using TP_Back.DataAccess.Interfaces;
using TP_Back.DataAccess.Repositories;
using TP_Back.DataAccess.Repository;
using TP_Back.Entities;

namespace TP_Back.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ThingsContext _thingsContext;
        public ICategoryRepository CategoryRepo { get; private set; }
        public IPersonRepository PeopleRepo { get; private set; }
        public IThingRepository ThingsRepo { get; private set; }
        public IUserRepository<User> UsersRepo { get; private set; }
        public ILoanRepository LoansRepo { get; private set; }

        public UnitOfWork(ThingsContext thingsContext)
        {
            _thingsContext = thingsContext;

            CategoryRepo = new CategoryRepository(thingsContext);
            PeopleRepo = new PersonRepository(thingsContext);
            ThingsRepo = new ThingRepository(thingsContext);
            UsersRepo = new UserRepository<User>(thingsContext);
            LoansRepo = new LoanRepository(thingsContext);
        }

        public int SaveChanges() => _thingsContext.SaveChanges();

        public async Task SaveAsync()
        {
            await _thingsContext.SaveChangesAsync();
        }

    }
}
