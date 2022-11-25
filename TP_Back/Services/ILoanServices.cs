using TP_Back.Dto;
using TP_Back.Entities;

namespace TP_Back.Services
{
    public interface ILoanServices
    {
        public string Create(LoanDtoCreation dto);

        public string Close(int LoanId);

    }
}
