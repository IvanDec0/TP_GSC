using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using TP_Back.DataAccess.UnitOfWork;
using TP_Back.Dto;
using TP_Back.Entities;
using TP_Back.Services;

namespace TP_Back.Protos
{
    public class LoanGrpcService: LoanGrpcGateway.LoanGrpcGatewayBase
    {
        private readonly ILoanServices loanServices;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public LoanGrpcService(ILoanServices loanServices, IMapper mapper, IUnitOfWork uow)
        {
            this.loanServices = loanServices;
            this.mapper = mapper;
            this.uow = uow;
        }




        public override Task<Response> StartLoan(NewLoanRequest request, ServerCallContext context)
        {
            var mapped = mapper.Map<LoanDtoCreation>(request);
            var result = loanServices.Create(mapped);

            return Task.FromResult(new Response()
            {
                Message = result
            });
        }



        public override Task<Response> CloseLoan(CloseLoanRequest request, ServerCallContext context)
        {
            var result = loanServices.Close(request.Id);

            return Task.FromResult(
                new Response()
                {
                    Message = result=="Loan Closed" ? $"Loan {request.Id} Closed" : result
                }
            );
        }

        public override async Task<LoansResponse> GetLoans(Empty request, ServerCallContext context)
        {
            var loans = await uow.LoansRepo.GetAllLoansAsync();
            var response = new LoansResponse();
            loans.ForEach(a =>
            {
                response.AllLoans.Add(new LoanRequest
                {
                    Id = a.Id,
                    PersonId = a.Person.Name,
                    ThingId = a.Thing.Description,
                    Status = a.Status,
                    CreationDate = Timestamp.FromDateTime(DateTime.SpecifyKind(a.CreationDate, DateTimeKind.Utc))
                });
            });

            return response;
        }

        public override async Task<LoansResponse> GetOpenLoans(Empty request, ServerCallContext context)
        {
            var loans = await uow.LoansRepo.GetAllLoansAsync();
            var AllLoans = loans.FindAll(q => q.Status == "Open");
            var response = new LoansResponse();
            loans.ForEach(a =>
            {
                response.AllLoans.Add(new LoanRequest
                {
                    Id = a.Id,
                    PersonId = a.Person.Name,
                    ThingId = a.Thing.Description,
                    Status = a.Status,
                    CreationDate = Timestamp.FromDateTime(DateTime.SpecifyKind(a.CreationDate, DateTimeKind.Utc))
                });
            });

            return response;
        }

        public override async Task<LoansClosedResponse> GetClosedLoans(Empty request, ServerCallContext context)
        {
            var loans = await uow.LoansRepo.GetAllLoansAsync();
            var AllLoans = loans.FindAll(q => q.Status == "Closed");
            var response = new LoansClosedResponse();
            loans.ForEach(a =>
            {
                var b = mapper.Map<LoanDto>(a);
                response.AllLoans.Add(new LoanClosedRequest
                {
                    Id = a.Id,
                    PersonId = a.Person.Name,
                    ThingId = a.Thing.Description,
                    Status = a.Status,
                    CreationDate = Timestamp.FromDateTime(DateTime.SpecifyKind(a.CreationDate, DateTimeKind.Utc)),
                    ReturnDate = Timestamp.FromDateTime(DateTime.SpecifyKind(b.ReturnDate, DateTimeKind.Utc)) // Parsear posible null
                });
            });

            return response;
        }
    }
}
