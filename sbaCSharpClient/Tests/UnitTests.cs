using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using sbaCSharpClient.domain;
using Assert = NUnit.Framework.Assert;

namespace sbaCSharpClient.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly sbaCSharpClientTest cSharpClientTest;

        public UnitTests()
        {
            cSharpClientTest = new sbaCSharpClientTest();
        }

        [Test]
        public async Task getDocumentTypesAsync()
        {
            SbaPPPLoanDocumentTypeResponse response = await cSharpClientTest.getDocumentTypes();
            Assert.IsNotNull(response);

            string serialized = JsonConvert.SerializeObject(response,
                new JsonSerializerSettings {DateFormatHandling = DateFormatHandling.IsoDateFormat});
            Assert.IsNotNull(serialized);
        }

        [Test]
        public async Task createForgivenessRequest()
        {
            #region build request

            Race race = new Race
            {
                race = "1"
            };

            Demographics demographics = new Demographics
            {
                name = "abc",
                position = "xyz",
                veteran_status = "1",
                gender = "X",
                ethnicity = "X",
                races = new List<Race>(1)
                {
                    race
                }
            };

            SbaPPPLoanForgiveness pppLoanForgiveness = new SbaPPPLoanForgiveness
            {
                etran_loan = new EtranLoan()
                {
                    demographics = new List<Demographics>(1)
                    {
                        demographics
                    },
                    bank_notional_amount = 1900000.00,
                    sba_number = "9999148486",
                    loan_number = "7777777",
                    entity_name = "Abc Inc",
                    ein = "997148486",
                    funding_date = "2020-07-06",
                    forgive_eidl_amount = 10000.00,
                    forgive_eidl_application_number = 123456789,
                    forgive_payroll = 1000.00,
                    forgive_rent = 1000.00,
                    forgive_utilities = 1000.00,
                    forgive_mortgage = 1000.00,
                    address1 = "5050 Ritter Road – Suite B",
                    address2 = "Mechanicsburg PA",
                    dba_name = "Abc Inc",
                    phone_number = "6102342123",
                    forgive_fte_at_loan_application = 10,
                    forgive_line_6_3508_or_line_5_3508ez = 3999.00,
                    forgive_modified_total = 3999.00,
                    forgive_payroll_cost_60_percent_requirement = 1666.66,
                    forgive_amount = 1666.66,
                    forgive_fte_at_forgiveness_application = 10,
                    forgive_schedule_a_line_1 = 1.00,
                    forgive_schedule_a_line_2 = 1.00,
                    forgive_schedule_a_line_3_checkbox = true,
                    forgive_schedule_a_line_3 = 1.00,
                    forgive_schedule_a_line_4 = 1.00,
                    forgive_schedule_a_line_5 = 1.00,
                    forgive_schedule_a_line_6 = 1.00,
                    forgive_schedule_a_line_7 = 1.00,
                    forgive_schedule_a_line_8 = 1.00,
                    forgive_schedule_a_line_9 = 1.00,
                    forgive_schedule_a_line_10 = 6.00,
                    forgive_schedule_a_line_10_checkbox = true,
                    forgive_schedule_a_line_11 = 10,
                    forgive_schedule_a_line_12 = 10,
                    forgive_schedule_a_line_13 = 1,
                    forgive_covered_period_from = "2020-07-06",
                    forgive_covered_period_to = "2020-09-06",
                    forgive_alternate_covered_period_from = "2020-07-06",
                    forgive_alternate_covered_period_to = "2020-09-06",
                    forgive_2_million = false,
                    forgive_payroll_schedule = "WEEKLY",
                    primary_email = "user@example.com",
                    primary_name = "Jason",
                    ez_form = false,
                    no_reduction_in_employees = true,
                    no_reduction_in_employees_and_covid_impact = true,
                    forgive_lender_confirmation = true,
                    forgive_lender_decision = 1
                },
            };

            #endregion

            var response = await cSharpClientTest.createForgivenessRequest(pppLoanForgiveness);
            Assert.IsNotNull(response);

            string serialized = JsonConvert.SerializeObject(response,
                new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.IsoDateFormat });
            Assert.IsNotNull(serialized);
        }

        [Test]
        public async Task uploadForgivenessDocument()
        {
            LoanDocumentResponse response = await cSharpClientTest.uploadForgivenessDocument("Ppdf.pdf", "1",
                "e1805069-9e05-4bc3-9daf-c40159036003",
                @"C:\Users\Administrator\Desktop\Ppdf.pdf");

            Assert.IsNotNull(response);

            string serialized = JsonConvert.SerializeObject(response,
                new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.IsoDateFormat });
            Assert.IsNotNull(serialized);
        }

        [Test]
        public async Task getAllForgivenessRequests()
        {
            SbaPPPLoanForgivenessStatusResponse response = await cSharpClientTest.getAllForgivenessRequests();
            Assert.IsNotNull(response);

            string serialized = JsonConvert.SerializeObject(response,
                new JsonSerializerSettings {DateFormatHandling = DateFormatHandling.IsoDateFormat});
            Assert.IsNotNull(serialized);
        }
        
        [Test]
        public async Task getForgivenessRequestBySbaNumber()
        {
            SbaPPPLoanForgivenessStatusResponse response = await cSharpClientTest.getForgivenessRequestBySbaNumber("9999133076");
            Assert.IsNotNull(response);

            string serialized = JsonConvert.SerializeObject(response,
                new JsonSerializerSettings {DateFormatHandling = DateFormatHandling.IsoDateFormat});
            Assert.IsNotNull(serialized);
        } 
        
       [Test]
        public async Task getSbaLoanForgivenessBySlug()
        {
            SbaPPPLoanForgiveness response = await cSharpClientTest.getSbaLoanForgivenessBySlug("c9836abc-f493-4544-ba8d-da1a306a03ce");
            Assert.IsNotNull(response);

            string serialized = JsonConvert.SerializeObject(response,
                new JsonSerializerSettings {DateFormatHandling = DateFormatHandling.IsoDateFormat});
            Assert.IsNotNull(serialized);
        } 
        
        [Test]
        public async Task deleteSbaLoanForgiveness()
        {
            bool response = await cSharpClientTest.deleteSbaLoanForgiveness("e58dd70a-8aae-4210-8b26-3047fe02dea2");
            Assert.IsTrue(response);
        }
        
        [Test]
        public async Task replyToSbaMessage()
        {
            MessageReply message = new MessageReply
            {
                document = @"C:\Users\Administrator\Desktop\Ppdf.pdf",
                document_name = "Test Document",
                document_type = 4,
                content = "test1"
            };

            string response = await cSharpClientTest.replyToSbaMessage(message, "523ed6d3-7233-40ab-835e-e01f9184dc8f");
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task replyToSbaMessageWithMultipleDocs()
        {
            MessageReplyMultipleFiles message = new MessageReplyMultipleFiles
            {
                // enter path to files you want to upload
                documents = new List<string>() { @"<Path to document file here>", @"<Path to document file here>" },

                // enter name of documents
                document_names = new List<string>() { "<Document Name>", "<Document Name>" },

                // enter document type of each document
                document_types = new List<int?>() { Int32.Parse("<Document Type>"), Int32.Parse("<Document Type>") },

                // enter comment for the upload
                content = "<message content>"
            };

            string slug = "<Enter slug for reply ticket here>";

            string response = await cSharpClientTest.replyToSbaMessageWithMultipleDocs(message, slug);
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task getForgivenessMessagesBySbaNumber()
        {
            SbaPPPLoanMessagesResponse response = await cSharpClientTest.getForgivenessMessagesBySbaNumber(1, "9999133145", true);
            Assert.IsNotNull(response);

            string serialized = JsonConvert.SerializeObject(response,
                new JsonSerializerSettings {DateFormatHandling = DateFormatHandling.IsoDateFormat});
            Assert.IsNotNull(serialized);
        } 

        [Test]
        public async Task getForgivenessMessagesBySlug()
        {
            SbaPPPLoanMessagesResponse response = await cSharpClientTest.getForgivenessMessagesBySlug("e58dd70a-8aae-4210-8b26-3047fe02dea2");
            Assert.IsNotNull(response);

            string serialized = JsonConvert.SerializeObject(response,
                new JsonSerializerSettings {DateFormatHandling = DateFormatHandling.IsoDateFormat});
            Assert.IsNotNull(serialized);
        } 
        
    }
}
