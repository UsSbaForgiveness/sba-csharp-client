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
            return sbaRestApiClient.invokeSbaLoanForgiveness(request, loanForgivenessUrl);
        }

        public Task<SbaPPPLoanDocumentTypeResponse> getLoanStatus(int page, string sbaNumber, string loanForgivenessUrl)
        {
            Console.WriteLine("Retreiving Sba Loan Forgiveness request");
            return sbaRestApiClient.getSbaLoanForgiveness(page, sbaNumber, loanForgivenessUrl);
        }
        
        public Task<SbaPPPLoanForgiveness> getSbaLoanForgiveness(string sbaNumber, string loanForgivenessUrl)
        {
            Console.WriteLine("Retreiving Sba Loan Forgiveness request");
            return sbaRestApiClient.getSbaLoanForgiveness(sbaNumber, loanForgivenessUrl);
        }
        
        public Task<SbaPPPLoanForgiveness> getSbaLoanForgivenessBySlug(string slug, string loanForgivenessUrl)
        {
            Console.WriteLine("Retreiving Sba Loan Forgiveness request");
            return sbaRestApiClient.getSbaLoanForgivenessBySlug(slug, loanForgivenessUrl);
        }
        
        public void deleteSbaLoanForgiveness(string slug, string loanForgivenessUrl)
        {
            Console.WriteLine("Retreiving Sba Loan Forgiveness request");
            sbaRestApiClient.deleteSbaLoanForgiveness(slug, loanForgivenessUrl);
        }
    }
}
