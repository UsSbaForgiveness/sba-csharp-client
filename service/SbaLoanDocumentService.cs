using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sbaCSharpClient.domain;
using sbaCSharpClient.restclient;

namespace sbaCSharpClient.service
{
    public class SbaLoanDocumentService
    {
        private readonly SbaRestApiClient sbaRestApiClient;

        public SbaLoanDocumentService(SbaRestApiClient sbaRestApiClient)
        {
            this.sbaRestApiClient = sbaRestApiClient;
        }

        public Task<LoanDocument> submitLoanDocument(LoanDocument request, string loanDocumentsUrl)
        {
            Console.WriteLine("Processing Loan Document Submission.");
            return sbaRestApiClient.invokeSbaLoanDocument(request, loanDocumentsUrl);
        }

        public Task<SbaPPPLoanDocumentTypeResponse> getDocumentTypes(Dictionary<string, string> reqParams, string loanDocumentTypesUrl)
        {
            Console.WriteLine("Retreiving Sba Loan Document Types");
            return sbaRestApiClient.getSbaLoanDocumentTypes(reqParams, loanDocumentTypesUrl);
        }
        
        public Task<LoanDocumentType> getSbaLoanDocumentTypeById(int id, string loanDocumentTypesUrl)
        {
            Console.WriteLine("Retreiving Sba Loan Document Types");
            return sbaRestApiClient.getSbaLoanDocumentTypeById(id, loanDocumentTypesUrl);
        }
    }
}
