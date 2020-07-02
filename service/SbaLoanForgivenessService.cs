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

        public Task<LoanDocumentType> getLoanStatus(int page, string loanForgivenessUrl)
        {
            Console.WriteLine("Retreiving Sba Loan Forgiveness request");
            return sbaRestApiClient.getSbaLoanForgiveness(page, loanForgivenessUrl);
        }
    }
}