using System;
using System.Threading.Tasks;
using sbaCSharpClient.domain;
using sbaCSharpClient.restclient;

namespace sbaCSharpClient.service
{
    public class SbaLoanForgivenessMessageService
    {
        private readonly SbaRestApiClient sbaRestApiClient;

        public SbaLoanForgivenessMessageService(SbaRestApiClient sbaRestApiClient)
        {
            this.sbaRestApiClient = sbaRestApiClient;
        }

        public Task<MessageReply> updateSbaLoanMessageReply(MessageReply request, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Processing Update LoanForgiveness Message Reply");
            return sbaRestApiClient.updateSbaLoanForgivenessMessageReply(request, loanForgivenessMessageUrl);
        }

        public Task<SbaPPPLoanMessagesResponse> getSbaLoanMessages(int page, String sbaNumber, bool isComplete, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Retreiving LoanForgiveness Request Messages by SBA Number");
            return sbaRestApiClient.getSbaLoanMessagesBySbaNumber(page, sbaNumber, isComplete, loanForgivenessMessageUrl);
        }

        public Task<SbaPPPLoanForgivenessMessage> getLoanMessagesBySlug(string slug, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Retreiving LoanForgiveness Message");
            return sbaRestApiClient.getSbaLoanForgivenessMessagesBySlug(slug, loanForgivenessMessageUrl);
        }
    }
}
