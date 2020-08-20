using System;
using System.Threading.Tasks;
using sbaCSharpClient.domain;
using sbaCSharpClient.service;
using System.Collections.Generic;

namespace sbaCSharpClient.controller
{
    public class SbaLoanForgivenessMessageController
    {
        private readonly SbaLoanForgivenessMessageService sbaLoanForgivenessMessageService;

        public SbaLoanForgivenessMessageController(SbaLoanForgivenessMessageService sbaLoanForgivenessMessageService)
        {
            this.sbaLoanForgivenessMessageService = sbaLoanForgivenessMessageService;
        }

        public Task<string> replyToSbaMessage(MessageReply request, string slug, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Processing reply To SbaMessage");
            return sbaLoanForgivenessMessageService.replyToSbaMessage(request, slug, loanForgivenessMessageUrl);
        }

        public Task<string> replyToSbaMessageWithMultipleDocs(MessageReplyMultipleFiles request, string slug, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Processing reply To SbaMessage with multiple documents");
            return sbaLoanForgivenessMessageService.replyToSbaMessageWithMultipleDocs(request, slug, loanForgivenessMessageUrl);
        }

        public Task<SbaPPPLoanMessagesResponse> getForgivenessMessagesBySbaNumber(int page, String sbaNumber, bool isComplete, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Retreiving LoanForgiveness Request Messages by SBA Number");
            return sbaLoanForgivenessMessageService.getForgivenessMessagesBySbaNumber(page, sbaNumber, isComplete, loanForgivenessMessageUrl);
        }

        public Task<SbaPPPLoanMessagesResponse> getForgivenessMessagesBySlug(string slug, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Retreiving all Forgiveness requests");
            return sbaLoanForgivenessMessageService.getForgivenessMessagesBySlug(slug, loanForgivenessMessageUrl);
        }
    }
}
