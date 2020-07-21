using System;
using System.Collections.Generic;

namespace sbaCSharpClient.domain
{
    public class SbaPPPLoanMessagesResponse
    {
        public int count{ get; set;}

        public String next{ get; set;}

        public String previous{ get; set;}

        public List<SbaPPPLoanForgivenessMessage> results{ get; set;}

    }
}
