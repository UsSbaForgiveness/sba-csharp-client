using System;
using System.Collections.Generic;
using System.Text;

namespace sbaCSharpClient.domain
{
    public class LoanDocumentResponse
    {
        public class LoanDocument
        {

            public string slug { get; set; }

            public string name { get; set; }

            public DateTime? created_at { get; set; }

            public DateTime? updated_at { get; set; }

            public string document { get; set; }

            public string url { get; set; }

            public string etran_loan { get; set; }

            public int? document_type { get; set; }

        }
    }
}
