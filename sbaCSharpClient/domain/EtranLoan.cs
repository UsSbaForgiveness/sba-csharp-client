using System;
using System.Collections.Generic;

namespace sbaCSharpClient.domain
{
	public class EtranLoan
	{
        public string primary_email { get; set; }

		public string primary_name { get; set; }

		public string slug{ get; set;}

		public double? bank_notional_amount{ get; set;}

		public string sba_number{ get; set;}

		public string loan_number{ get; set;}

		public string entity_name{ get; set;}

		public string application_id{ get; set;}

		public string ein{ get; set;}

		// format - yyyy-MM-dd
		public string funding_date{ get; set;}

		public double? forgive_eidl_amount{ get; set;}

		public int? forgive_eidl_application_number{ get; set;}

		public double? forgive_payroll{ get; set;}

		public double? forgive_rent{ get; set;}

		public double? forgive_utilities{ get; set;}

		public double? forgive_mortgage{ get; set;}

		public string address1{ get; set;}

		public string address2{ get; set;}

		public string dba_name{ get; set;}

		public string phone_number{ get; set;}

		public int forgive_fte_at_loan_application{ get; set;}

		public List<Demographics> demographics{ get; set;}

		public List<LoanDocument> documents{ get; set;}

		public double? forgive_line_6_3508_or_line_5_3508ez{ get; set;}

		public double? forgive_modified_total{ get; set;}

		public double? forgive_payroll_cost_60_percent_requirement{ get; set;}

		public double? forgive_amount{ get; set;}

		public int forgive_fte_at_forgiveness_application{ get; set;}

		public double? forgive_schedule_a_line_1{ get; set;}

		public double? forgive_schedule_a_line_2{ get; set;}

		public bool? forgive_schedule_a_line_3_checkbox{ get; set;}

		public double? forgive_schedule_a_line_3{ get; set;}

		public double? forgive_schedule_a_line_4{ get; set;}

		public double? forgive_schedule_a_line_5{ get; set;}

		public double? forgive_schedule_a_line_6{ get; set;}

		public double? forgive_schedule_a_line_7{ get; set;}

		public double? forgive_schedule_a_line_8{ get; set;}

		public double? forgive_schedule_a_line_9{ get; set;}

		public double? forgive_schedule_a_line_10{ get; set;}

		public bool? forgive_schedule_a_line_10_checkbox{ get; set;}

		public double? forgive_schedule_a_line_11{ get; set;}

		public double? forgive_schedule_a_line_12{ get; set;}

		public double? forgive_schedule_a_line_13{ get; set;}

		public string forgive_covered_period_from{ get; set;}

		public string forgive_covered_period_to{ get; set;}

		public string forgive_alternate_covered_period_from{ get; set;}

		public string forgive_alternate_covered_period_to{ get; set;}

		public bool? forgive_2_million{ get; set;}

		public string forgive_payroll_schedule{ get; set;}

		public int forgive_lender_decision { get;  set; }

        public bool? ez_form { get;  set; }

        public bool? no_reduction_in_employees { get;  set; }

        public bool? no_reduction_in_employees_and_covid_impact { get;  set; }

        public bool? forgive_lender_confirmation { get;  set; }

		public string status { get; set; }

		public DateTime? approval_date { get; set; }

        public string final_forgive_amount { get; set; }

        public double? calculated_interest { get; set; }

        public double? final_forgive_payment { get; set; }

        public DateTime? final_forgive_payment_date { get; set; }

        public  string final_forgive_payment_batch { get; set; }

        public double? final_forgive_amount_with_interest { get; set; }

		public string sba_decision { get;  set; }

		public Organization organization { get; set; }

	}
}
