using System;

namespace sbaCSharpClient.domain
{
    public class MessageReply
    {
        public int? document_type{ get; set;}

        public String document{ get; set;}

        public String document_name{ get; set;}

        public string etran_loan { get; set; }

        public string content { get; set; }
    }
}
