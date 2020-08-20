using System;
using System.Threading.Tasks;
using sbaCSharpClient.domain;
using sbaCSharpClient.restclient;
using System.Collections.Generic;

namespace sbaCSharpClient.service
{
    public class SbaLoanForgivenessMessageService
    {
        private readonly SbaRestApiClient sbaRestApiClient;

        public SbaLoanForgivenessMessageService(SbaRestApiClient sbaRestApiClient)
        {
            this.sbaRestApiClient = sbaRestApiClient;
        }

        public Task<string> replyToSbaMessage(MessageReply request, string slug, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Processing reply To SbaMessage");
            return sbaRestApiClient.replyToSbaMessage(request, slug, loanForgivenessMessageUrl);
        }

        public Task<string> replyToSbaMessageWithMultipleDocs(MessageReplyMultipleFiles request, string slug, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Processing reply To SbaMessage with multiple documents");
            return sbaRestApiClient.replyToSbaMessageWithMultipleDocs(request, slug, loanForgivenessMessageUrl);
        }

        public Task<SbaPPPLoanMessagesResponse> getForgivenessMessagesBySbaNumber(int page, String sbaNumber, bool isComplete, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Retreiving Forgiveness Request Messages by SBA Number");
            return sbaRestApiClient.getForgivenessMessagesBySbaNumber(page, sbaNumber, isComplete, loanForgivenessMessageUrl);
        }

        public Task<SbaPPPLoanMessagesResponse> getForgivenessMessagesBySlug(string slug, string loanForgivenessMessageUrl)
        {
            Console.WriteLine("Retreiving forgiveness Messages By Slug");
            return sbaRestApiClient.getForgivenessMessagesBySlug(slug, loanForgivenessMessageUrl);
        }
    }
}
