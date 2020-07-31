using System.Collections.Generic;

namespace sbaCSharpClient.domain
{
	public class Demographics
    {

        public string name{ get; set;}

        public string position{ get; set;}

        public string veteran_status{ get; set;}

        public string gender{ get; set;}

        public string ethnicity{ get; set;}

        public List<Race> races{ get; set;}

    }
}
