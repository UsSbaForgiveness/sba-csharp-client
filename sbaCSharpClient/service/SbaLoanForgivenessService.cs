using System;
using System.Threading.Tasks;
using sbaCSharpClient.domain;
using sbaCSharpClient.restclient;

namespace sbaCSharpClient.service
{
    public class SbaLoanForgivenessService
    {
        private readonly SbaRestApiClient sbaRestApiClient;

        public SbaLoanForgivenessService(SbaRestApiClient sbaRestApiClient)
        {
            this.sbaRestApiClient = sbaRestApiClient;
        }

        public Task<SbaPPPLoanForgiveness> execute(SbaPPPLoanForgiveness request, string loanForgivenessUrl)
        {
            Console.WriteLine("Processing Sba Loan Forgiveness request");
            return sbaRestApiClient.CreateForgivenessRequest(request, loanForgivenessUrl);
        }

        public Task<SbaPPPLoanDocumentTypeResponse> getDocumenttypes(string loanForgivenessUrl)
        {
            Console.WriteLine("Retreiving document types");
            return sbaRestApiClient.getSbaLoanForgiveness(loanForgivenessUrl);
        }

        public Task<SbaPPPLoanForgivenessStatusResponse> getAllForgivenessRequests(string ppp_loan_forgiveness_requests)
        {
            Console.WriteLine("Retreiving all Forgiveness request");
            return sbaRestApiClient.getAllForgivenessRequests(ppp_loan_forgiveness_requests);
        }

        public Task<SbaPPPLoanForgivenessStatusResponse> getForgivenessRequestBysbaNumber(string sbaNumber, string ppp_loan_forgiveness_requests)
        {
            Console.WriteLine("Retreiving Sba Loan Forgiveness request using sbaNumber");
            return sbaRestApiClient.getForgivenessRequestBysbaNumber(sbaNumber, ppp_loan_forgiveness_requests);
        }

        public Task<SbaPPPLoanForgiveness> getSbaLoanForgivenessBySlug(string slug, string loanForgivenessUrl)
        {
            Console.WriteLine("Retreiving Sba Loan Forgiveness request using slug");
            return sbaRestApiClient.getSbaLoanForgivenessBySlug(slug, loanForgivenessUrl);
        }

        public async Task<bool> deleteSbaLoanForgiveness(string slug, string loanForgivenessUrl)
        {
            Console.WriteLine("Deleting Sba Loan Forgiveness request");
            return await sbaRestApiClient.deleteSbaLoanForgiveness(slug, loanForgivenessUrl);
        }
    }
}