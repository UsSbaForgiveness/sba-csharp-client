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

        public Task<SbaPPPLoanDocumentTypeResponse> getDocumenttypes(string loanForgivenessUrl)
        {
            Console.WriteLine("Get Request Received.");
            Task<SbaPPPLoanDocumentTypeResponse> response = sbaLoanForgivenessService.getDocumenttypes(loanForgivenessUrl);
            return response;
        }

        public Task<SbaPPPLoanForgivenessStatusResponse> getAllForgivenessRequests( string ppp_loan_forgiveness_requests)
        {
            Console.WriteLine("Get Request Received.");
            Task<SbaPPPLoanForgivenessStatusResponse> response = sbaLoanForgivenessService.getAllForgivenessRequests(ppp_loan_forgiveness_requests);
            return response;
        }

        public Task<SbaPPPLoanForgivenessStatusResponse> getForgivenessRequestBysbaNumber(string sbaNumber, string ppp_loan_forgiveness_requests)
        {
            Console.WriteLine("Get Request Received.");
            Task<SbaPPPLoanForgivenessStatusResponse> response = sbaLoanForgivenessService.getForgivenessRequestBysbaNumber(sbaNumber, ppp_loan_forgiveness_requests);
            return response;
        }
        
        public Task<SbaPPPLoanForgiveness> getSbaLoanForgivenessBySlug(string slug, string loanForgivenessUrl)
        {
            Console.WriteLine("Get Request Received.");
            Task<SbaPPPLoanForgiveness> response = sbaLoanForgivenessService.getSbaLoanForgivenessBySlug(slug, loanForgivenessUrl);
            return response;
        }
        
        public async Task<bool> deleteSbaLoanForgiveness(string slug, string loanForgivenessUrl)
        {
            Console.WriteLine("Delete Request Received.");
            return await sbaLoanForgivenessService.deleteSbaLoanForgiveness(slug, loanForgivenessUrl);
        }
    }
}
