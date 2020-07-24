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

        public Task<SbaPPPLoanDocumentTypeResponse> getSbaLoanRequestStatus(int page, string sbaNumber, string loanForgivenessUrl)
        {
            Console.WriteLine("Get Request Received.");
            Task<SbaPPPLoanDocumentTypeResponse> response = sbaLoanForgivenessService.getLoanStatus(page, sbaNumber, loanForgivenessUrl);
            return response;
        }
        
        public Task<SbaPPPLoanForgiveness> getSbaLoanForgiveness(string sbaNumber, string loanForgivenessUrl)
        {
            Console.WriteLine("Get Request Received.");
            Task<SbaPPPLoanForgiveness> response = sbaLoanForgivenessService.getSbaLoanForgiveness(sbaNumber, loanForgivenessUrl);
            return response;
        }
        
        public Task<SbaPPPLoanForgiveness> getSbaLoanForgivenessBySlug(string slug, string loanForgivenessUrl)
        {
            Console.WriteLine("Get Request Received.");
            Task<SbaPPPLoanForgiveness> response = sbaLoanForgivenessService.getSbaLoanForgivenessBySlug(slug, loanForgivenessUrl);
            return response;
        }
        
        public void deleteSbaLoanForgiveness(string slug, string loanForgivenessUrl)
        {
            Console.WriteLine("Get Request Received.");
            sbaLoanForgivenessService.deleteSbaLoanForgiveness(slug, loanForgivenessUrl);
        }
    }
}
