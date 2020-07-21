using System;
using System.Threading.Tasks;
using sbaCSharpClient.domain;
using sbaCSharpClient.service;

namespace sbaCSharpClient.controller
{
    public class SbaLoanForgivenessMessageController
    {
        private readonly SbaLoanForgivenessMessageService sbaLoanForgivenessMessageService;

        public SbaLoanForgivenessMessageController(SbaLoanForgivenessMessageService sbaLoanForgivenessMessageService)
        {
            this.sbaLoanForgivenessMessageService = sbaLoanForgivenessMessageService;
        }

        public Task<MessageReply> updateSbaLoanMessageReply(MessageReply request, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Processing Update LoanForgiveness Message Reply");
            return sbaLoanForgivenessMessageService.updateSbaLoanMessageReply(request, loanForgivenessMessageUrl);
        }

        public Task<SbaPPPLoanMessagesResponse> getSbaLoanMessages(int page, String sbaNumber, bool isComplete, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Retreiving LoanForgiveness Request Messages by SBA Number");
            return sbaLoanForgivenessMessageService.getSbaLoanMessages(page, sbaNumber, isComplete, loanForgivenessMessageUrl);
        }

        public Task<SbaPPPLoanForgivenessMessage> getLoanMessagesBySlug(string slug, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Retreiving LoanForgiveness Message");
            return sbaLoanForgivenessMessageService.getLoanMessagesBySlug(slug, loanForgivenessMessageUrl);
        }
    }
}
