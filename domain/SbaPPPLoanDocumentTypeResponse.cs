using System.Collections.Generic;

namespace sbaCSharpClient.domain
{
	public class SbaPPPLoanDocumentTypeResponse
    {

        public int count{ get; set;}

        public int? next{ get; set;}

        public int? previous{ get; set;}

        public List<LoanDocumentType> results{ get; set;}

    }
}
