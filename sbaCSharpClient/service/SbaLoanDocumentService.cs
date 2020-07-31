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

        public Task<LoanDocumentResponse> uploadForgivenessDocument(string requestName, string requestDocument_type, string etran_loan, string document,  string loanDocumentsUrl)
        {
            Console.WriteLine("Processing Loan Document Submission.");
            return sbaRestApiClient.uploadForgivenessDocument( requestName,  requestDocument_type,  etran_loan,  document, loanDocumentsUrl);
        }

        public Task<SbaPPPLoanDocumentTypeResponse> getDocumentTypes(Dictionary<string, string> reqParams, string loanDocumentTypesUrl)
        {
            Console.WriteLine("Retreiving Sba Loan Document Types");
            return sbaRestApiClient.getSbaLoanDocumentTypes(reqParams, loanDocumentTypesUrl);
        }
        
        public Task<LoanDocumentType> getSbaLoanDocumentTypeById(int id, string loanDocumentTypesUrl)
        {
            Console.WriteLine("Retreiving Sba Loan Document Type by Id");
            return sbaRestApiClient.getSbaLoanDocumentTypeById(id, loanDocumentTypesUrl);
        }
    }
}
