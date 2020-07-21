using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using sbaCSharpClient.controller;
using sbaCSharpClient.domain;
using sbaCSharpClient.restclient;
using sbaCSharpClient.service;

namespace sbaCSharpClient
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                string baseUri = "", // to be passed 
                    apiToken = "", // to be passed 
                    vendorKey = ""; // to be passed
                
                SbaLoanDocumentsController sbaLoanDocuments =
                    new SbaLoanDocumentsController(new SbaLoanDocumentService(new SbaRestApiClient(baseUri, apiToken, vendorKey)));

                SbaLoanForgivenessController sbaLoanForgiveness =
                    new SbaLoanForgivenessController(new SbaLoanForgivenessService(new SbaRestApiClient(baseUri, apiToken, vendorKey)));

                SbaLoanForgivenessMessageController sbaLoanForgivenessMessageController =
                    new SbaLoanForgivenessMessageController(new SbaLoanForgivenessMessageService(new SbaRestApiClient(baseUri, apiToken, vendorKey)));

                await getDocumentTypes(sbaLoanDocuments);

                await submitLoanDocument(sbaLoanDocuments);

                await getSbaLoanDocumentTypeById(sbaLoanDocuments);
 
                await invokeSbaLoanForgiveness(sbaLoanForgiveness);

                await getSbaLoanRequestStatus(sbaLoanForgiveness);

                await getSbaLoanForgiveness(sbaLoanForgiveness);

                await getSbaLoanForgivenessBySlug(sbaLoanForgiveness);

                await updateSbaLoanMessageReply(sbaLoanForgivenessMessageController);

                await getSbaLoanMessages(sbaLoanForgivenessMessageController);

                await getLoanMessagesBySlug(sbaLoanForgivenessMessageController);

            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static async Task getSbaLoanRequestStatus(SbaLoanForgivenessController sbaLoanForgiveness)
        {
            SbaPPPLoanDocumentTypeResponse loanDocumentType =
                await sbaLoanForgiveness.getSbaLoanRequestStatus(2,"1,",
                    "ppp_loan_document_types"); // loanForgivenessUrl - to be passed
            if (loanDocumentType != null)
            {
                var serialized = JsonConvert.SerializeObject(loanDocumentType,
                    new JsonSerializerSettings() {DateFormatHandling = DateFormatHandling.IsoDateFormat});
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task getSbaLoanForgiveness(SbaLoanForgivenessController sbaLoanForgiveness)
        {
            SbaPPPLoanForgiveness loanDocumentType =
                await sbaLoanForgiveness.getSbaLoanForgiveness("2",
                    "ppp_loan_document_types"); // loanForgivenessUrl - to be passed
            if (loanDocumentType != null)
            {
                var serialized = JsonConvert.SerializeObject(loanDocumentType,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }
        
        private static async Task getSbaLoanForgivenessBySlug(SbaLoanForgivenessController sbaLoanForgiveness)
        {
            SbaPPPLoanForgiveness loanDocumentType =
                await sbaLoanForgiveness.getSbaLoanForgivenessBySlug("2",
                    "ppp_loan_document_types"); // loanForgivenessUrl - to be passed
            if (loanDocumentType != null)
            {
                var serialized = JsonConvert.SerializeObject(loanDocumentType,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task invokeSbaLoanForgiveness(SbaLoanForgivenessController sbaLoanForgiveness)
        {
            Race race = new Race
            {
                race = "X"
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
                borrower_name = "Sba PPP Loan Forgiveness Test",
                etran_loan = new EtranLoan()
                {
                    demographics = new List<Demographics>(1)
                    {
                        demographics
                    },
                    bank_notional_amount = "1.00",
                    sba_number = "4008437204",
                    loan_number = "13872711",
                    entity_name = "Salmon Falls Nursery, Inc",
                    ein = "201569741",
                    funding_date = "2020-06-28",
                    forgive_eidl_amount = "1.00",
                    forgive_eidl_application_number = 0,
                    forgive_payroll = "6.00",
                    forgive_rent = "1.00",
                    forgive_utilities = "1.00",
                    forgive_mortgage = "1.00",
                    address1 = "string",
                    address2 = "string",
                    dba_name = "string",
                    phone_number = "string",
                    //assign_to_user = null,
                    forgive_fte_at_loan_application = 0,
                    //updated = "06/28/2020",
                    forgive_line_6_3508_or_line_5_3508ez = "1.00",
                    forgive_modified_total = "1.00",
                    forgive_payroll_cost_60_percent_requirement = "1.00",
                    forgive_amount = "1.00",
                    forgive_fte_at_forgiveness_application = 0,
                    forgive_schedule_a_line_1 = "1.00",
                    forgive_schedule_a_line_2 = "1.00",
                    forgive_schedule_a_line_3_checkbox = true,
                    forgive_schedule_a_line_3 = "0.00",
                    forgive_schedule_a_line_4 = "1.00",
                    forgive_schedule_a_line_5 = "1.00",
                    forgive_schedule_a_line_6 = "1.00",
                    forgive_schedule_a_line_7 = "1.00",
                    forgive_schedule_a_line_8 = "1.00",
                    forgive_schedule_a_line_9 = "1.00",
                    forgive_schedule_a_line_10 = "6.00",
                    forgive_schedule_a_line_10_checkbox = true,
                    forgive_schedule_a_line_11 = "1.00",
                    forgive_schedule_a_line_12 = "2.00",
                    forgive_schedule_a_line_13 = "1.00",
                    forgive_covered_period_from = "2020-06-28",
                    forgive_covered_period_to = "2020-06-28",
                    forgive_alternate_covered_period_from = "2020-06-28",
                    forgive_alternate_covered_period_to = "2020-06-28",
                    forgive_2_million = true,
                    forgive_payroll_schedule = "string",
                    //primary_email = "user@example.com",
                    //primary_name = "string",
                    //ez_form = false,
                    //no_employees = false,
                    //no_reduction_in_employees = false,
                    //no_reduction_in_employees_and_covid_impact = false
                },
                //created = "06/28/2020",
                //assigned_to_user = " "
            };

            SbaPPPLoanForgiveness sbaPppLoanForgiveness =
                await sbaLoanForgiveness.execute(pppLoanForgiveness, "ppp_loan_forgiveness_requests");
            if (sbaPppLoanForgiveness != null)
            {
                var serialized = JsonConvert.SerializeObject(sbaPppLoanForgiveness,
                    new JsonSerializerSettings() {DateFormatHandling = DateFormatHandling.IsoDateFormat});
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task submitLoanDocument(SbaLoanDocumentsController sbaLoanDocuments)
        {
            LoanDocument request = new LoanDocument
            {
                slug = "e4dd77f4-18a4-428a-a26b-c5e9ed19133a",
                name = "testUpload",
                created_at = Convert.ToDateTime("2020-06-28T19:38:52.009454Z"),
                updated_at = Convert.ToDateTime("2020-06-28T19:38:52.009482Z"),
                document =
                    "https://lenders-cooperative-sandbox-app.s3.us-gov-west-1.amazonaws.com/media/loan/e4dd77f4-18a4-428a-a26b-c5e9ed19133a/files/testUpload.docx?AWSAccessKeyId=AKIAQ2EGUESVW7SZX5UO&Signature=TZZBJ%2BGKnpvDBvcnvktCLPmkT10%3D&Expires=1593381648",
                url =
                    "https://lenders-cooperative-sandbox-app.s3.us-gov-west-1.amazonaws.com/media/loan/e4dd77f4-18a4-428a-a26b-c5e9ed19133a/files/testUpload.docx?AWSAccessKeyId=AKIAQ2EGUESVW7SZX5UO&Signature=TZZBJ%2BGKnpvDBvcnvktCLPmkT10%3D&Expires=1593381648",
                etran_loan = "a82c54eb-36f3-460b-ad1d-1c7a6cde4d07",
                document_type = new LoanDocumentType
                {
                    id = 1,
                    name = "Payroll",
                    description = "Payroll Documents"
                }
            };

            LoanDocument loanDocument = await sbaLoanDocuments.submitLoanDocument(request, "ppp_loan_documents");
            if (loanDocument != null)
            {
                var serialized = JsonConvert.SerializeObject(loanDocument,
                    new JsonSerializerSettings() {DateFormatHandling = DateFormatHandling.IsoDateFormat});
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task getSbaLoanDocumentTypeById(SbaLoanDocumentsController sbaLoanDocuments)
        {
            LoanDocumentType loanDocumentType =
                await sbaLoanDocuments.getSbaLoanDocumentTypeById(2, "ppp_loan_document_types"); // loanForgivenessUrl - to be passed
            if (loanDocumentType != null)
            {
                var serialized = JsonConvert.SerializeObject(loanDocumentType,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task getDocumentTypes(SbaLoanDocumentsController sbaLoanDocuments)
        {
            Dictionary<string, string> reqParams = new Dictionary<string, string>();
            reqParams.Add("name", "test");
            reqParams.Add("description", "test");
            reqParams.Add("page", "test");

            SbaPPPLoanDocumentTypeResponse documentTypes =
                await sbaLoanDocuments.getDocumentTypes(reqParams, "ppp_loan_document_types");
            if (documentTypes != null)
            {
                var serialized = JsonConvert.SerializeObject(documentTypes,
                    new JsonSerializerSettings() {DateFormatHandling = DateFormatHandling.IsoDateFormat});
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task updateSbaLoanMessageReply(SbaLoanForgivenessMessageController sbaLoanForgivenessMessageController)
        {
            MessageReply message = new MessageReply();

            MessageReply sbaLoanMessageReply =
                await sbaLoanForgivenessMessageController.updateSbaLoanMessageReply(message,
                    "ppp_loan_forgiveness_message_reply");

            if (sbaLoanMessageReply != null)
            {
                var serialized = JsonConvert.SerializeObject(sbaLoanMessageReply,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task getSbaLoanMessages(SbaLoanForgivenessMessageController sbaLoanForgivenessMessageController)
        {
            SbaPPPLoanMessagesResponse sbaPppLoanMessagesResponse =
                await sbaLoanForgivenessMessageController.getSbaLoanMessages(1, "test", true,
                    "ppp_loan_forgiveness_messages");

            if (sbaPppLoanMessagesResponse != null)
            {
                var serialized = JsonConvert.SerializeObject(sbaPppLoanMessagesResponse,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task getLoanMessagesBySlug(SbaLoanForgivenessMessageController sbaLoanForgivenessMessageController)
        {
            SbaPPPLoanForgivenessMessage loanMessagesBySlug =
                await sbaLoanForgivenessMessageController.getLoanMessagesBySlug("test",
                    "ppp_loan_forgiveness_messages");

            if (loanMessagesBySlug != null)
            {
                var serialized = JsonConvert.SerializeObject(loanMessagesBySlug,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }
    }
}
