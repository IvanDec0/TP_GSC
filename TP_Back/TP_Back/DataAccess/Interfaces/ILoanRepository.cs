using TP_Back.DataAccess.Interface;
using TP_Back.Dto;
using TP_Back.Entities;

namespace TP_Back.DataAccess.Interfaces
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        public List<Loan> GetPendingLoans();

        public Task<List<Loan>> GetAllLoansAsync();

        public List<Loan> GetAllLoans();

        public Task<List<Loan>> GetOpenLoansAsync();

        public Task<List<Loan>> GetClosedLoansAsync();
    }
}
