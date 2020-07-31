using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sbaCSharpClient.domain;
using sbaCSharpClient.service;

namespace sbaCSharpClient.controller
{
    public class SbaLoanDocumentsController
    {
        private readonly SbaLoanDocumentService sbaLoanDocumentService;

        public SbaLoanDocumentsController(SbaLoanDocumentService sbaLoanDocumentService)
        {
            this.sbaLoanDocumentService = sbaLoanDocumentService;
        }

        public Task<SbaPPPLoanDocumentTypeResponse> getDocumentTypes(Dictionary<string, string> reqParams, string loanDocumentTypesUrl)
        {
            Console.WriteLine("Get Loan Document Types.");
            Task<SbaPPPLoanDocumentTypeResponse> documentTypes = sbaLoanDocumentService.getDocumentTypes(reqParams, loanDocumentTypesUrl);
            return documentTypes;
        }


        public Task<LoanDocumentResponse> uploadForgivenessDocument(string requestName, string requestDocument_type, string etran_loan, string document, string loanDocumentsUrl)
        {
            Console.WriteLine("Submit Loan Document.");
            Task<LoanDocumentResponse> loanDocument = sbaLoanDocumentService.uploadForgivenessDocument(requestName, requestDocument_type, etran_loan, document,  loanDocumentsUrl);
            return loanDocument;
        }
        
        public Task<LoanDocumentType> getSbaLoanDocumentTypeById(int id, string loanDocumentsUrl)
        {
            Task<LoanDocumentType> document = sbaLoanDocumentService.getSbaLoanDocumentTypeById(id, loanDocumentsUrl);
            return document;
        }
    }
}
