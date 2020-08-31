using System;
using System.Collections.Generic;
using System.Text;

namespace sbaCSharpClient.domain
{
    public class MessageReplyMultipleFiles
    {
        public List<int?> document_types { get; set; }

        public List<String> documents { get; set; }

        public List<String> document_names { get; set; }

        public string etran_loan { get; set; }

        public string content { get; set; }
    }
}
