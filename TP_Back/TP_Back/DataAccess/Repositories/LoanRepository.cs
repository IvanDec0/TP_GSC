using Microsoft.EntityFrameworkCore;
using System.Linq;
using TP_Back.DataAccess.Interface;
using TP_Back.DataAccess.Interfaces;
using TP_Back.DataAccess.Repository;
using TP_Back.DataAccess.UnitOfWork;
using TP_Back.Dto;
using TP_Back.Entities;

namespace TP_Back.DataAccess.Repositories
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(ThingsContext context) : base(context)
        {
        }

        public override Loan? GetOne(int id)
        {
            return context.Loans
                .Include(l => l.Thing)
                .Include(l => l.Person)
                .FirstOrDefault(l => l.Id == id);
        }


        public List<Loan> GetPendingLoans()
        {
            return context.Loans
                .Where(l => l.ReturnDate == null)
                .Include(l => l.Thing)
                .Include(l => l.Person)
                .ToList();
        }
        virtual public async Task<List<Loan>> GetAllLoansAsync()
        {
            return await context.Loans
                .Include(l => l.Thing)
                .Include(l => l.Person)
                .ToListAsync();
        }

        virtual public List<Loan> GetAllLoans()
        {
            return context.Loans
                .Include(l => l.Thing)
                .Include(l => l.Person)
                .ToList();
        }

        virtual public async Task<List<Loan>> GetOpenLoansAsync()
        {
            return await context.Loans
                .Include(l => l.Thing)
                .Include(l => l.Person)
                .Where(l => l.Status == "Open")
                .ToListAsync();
                
        }

        virtual public async Task<List<Loan>> GetClosedLoansAsync()
        {
            return await context.Loans
                .Include(l => l.Thing)
                .Include(l => l.Person)
                .Where(l => l.Status == "Closed")
                .ToListAsync();
        }
    }
}