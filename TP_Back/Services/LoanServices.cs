using TP_Back.DataAccess.UnitOfWork;
using TP_Back.Dto;
using TP_Back.Entities;

namespace TP_Back.Services
{
    public class LoanServices : ILoanServices
    {
        private readonly IUnitOfWork uow;

        public LoanServices(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    

        public string Create(LoanDtoCreation dto)
        {


            var thing = uow.ThingsRepo.GetOne(dto.ThingId);
            if (thing is null)
                return "Thing not found";

            var person = uow.PeopleRepo.GetOne(dto.PersonId);
            if (person is null)
                return "Person not found";

            var PendingLoans = uow.LoansRepo.GetPendingLoans();
            var ActualLoan = PendingLoans.FindAll(q => q.Thing.Id == dto.ThingId);
            if (ActualLoan != null) { 
                foreach(var loan in ActualLoan) {
                if (loan.Status == "Open")
                    return "Thing is already on a loan";
                }
            }
            var newLoan = new Loan()
            {
                Thing = thing,
                Person = person,
                CreationDate = DateTime.Now,
                ReturnDate = null,
                Status = "Open"
            };

            uow.LoansRepo.add(newLoan);
            uow.SaveChanges();

            return "Created";
        }

        public string Close(int LoanId)
        {
            var loan = uow.LoansRepo.GetOne(LoanId);
            if (loan is null)
                return "Loan not found";

            if (loan.Status == "Closed")
                return "Loan is already closed";

            loan.Status = "Closed";
            uow.SaveChanges();

            return "Loan Closed";
        }
    }
}
