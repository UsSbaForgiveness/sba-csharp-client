using System;
using System.Collections.Generic;

namespace sbaCSharpClient.domain
{
	public class SbaPPPLoanForgivenessStatusResponse
    {

        private int count;

        private int next;

        private int previous;

        private List<SbaPPPLoanForgiveness> results;

        private DateTime created;

        private string assigned_to_user;
    }
}
