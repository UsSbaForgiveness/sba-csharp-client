using System;
using System.Threading.Tasks;
using sbaCSharpClient.domain;
using sbaCSharpClient.service;

namespace sbaCSharpClient.controller
{
    public class SbaLoanForgivenessController
    {
        private readonly SbaLoanForgivenessService sbaLoanForgivenessService;

        public SbaLoanForgivenessController(SbaLoanForgivenessService sbaLoanForgivenessService)
        {
            this.sbaLoanForgivenessService = sbaLoanForgivenessService;
        }

        public Task<SbaPPPLoanForgiveness> execute(SbaPPPLoanForgiveness request, string loanForgivenessUrl)
        {
            Console.WriteLine($"Submit Request Received: {request}");
            Task<SbaPPPLoanForgiveness> response = sbaLoanForgivenessService.execute(request, loanForgivenessUrl);
            return response;
        }

        public Task<LoanDocumentType> getSbaLoanRequestStatus(int page, string loanForgivenessUrl)
        {
            Console.WriteLine("Get Request Received.");
            Task<LoanDocumentType> response = sbaLoanForgivenessService.getLoanStatus(page, loanForgivenessUrl);
            return response;
        }
    }
}
