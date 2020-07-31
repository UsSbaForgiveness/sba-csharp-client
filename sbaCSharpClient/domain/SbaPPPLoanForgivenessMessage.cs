using System;
using System.Collections.Generic;

namespace sbaCSharpClient.domain
{
    public class SbaPPPLoanForgivenessMessage
    {
        public string sba_number{ get; set;}

        public string subject{ get; set;}

        public string ticket{ get; set;}

        public bool is_complete{ get; set;}

        public string needs_attention{ get; set;}

        public List<Message> messages{ get; set;}

    }
}
