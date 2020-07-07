using System;
using System.Collections.Generic;

namespace sbaCSharpClient.domain
{
	public class SbaPPPLoanForgivenessStatusResponse
    {

        public int count{ get; set;}

        public string next{ get; set;}

        public string previous{ get; set;}

        public List<SbaPPPLoanForgiveness> results{ get; set;}

        public DateTime created{ get; set;}

        public string assigned_to_user{ get; set;}
    }
}
