using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using sbaCSharpClient.controller;
using sbaCSharpClient.domain;
using sbaCSharpClient.restclient;
using sbaCSharpClient.service;

namespace sbaCSharpClient
{
    public class Program
    {
        public static void Main()
        {
        }
    }

    public class sbaCSharpClientTest
    {
        public static string BaseUri, ApiToken, VendorKey;

        public static string pppLoanDocumentTypes,
            pppLoanForgivenessRequests,
            pppLoanDocuments,
            pppLoanForgivenessMessageReply,
            pppLoanForgivenessMessages;

        public SbaLoanDocumentsController sbaLoanDocuments;
        public SbaLoanForgivenessController sbaLoanForgiveness;
        public SbaLoanForgivenessMessageController sbaLoanForgivenessMessageController;

        public sbaCSharpClientTest()
        {
            #region read configuration

            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            BaseUri = configurationRoot.GetSection("baseUri").Value;

            ApiToken = configurationRoot.GetSection("api-token").Value;

            VendorKey = configurationRoot.GetSection("vendor-key").Value;

            pppLoanDocumentTypes = configurationRoot.GetSection("loan-forgiveness-document_types-URL").Value;

            pppLoanForgivenessRequests = configurationRoot.GetSection("loan-forgiveness-requests-URL").Value;

            pppLoanDocuments = configurationRoot.GetSection("loan-documents-URL").Value;

            pppLoanForgivenessMessageReply = configurationRoot.GetSection("loan-Forgiveness-Message-Reply-URL").Value;

            pppLoanForgivenessMessages = configurationRoot.GetSection("loan-Forgiveness-Message-URL").Value;

            #endregion

            #region Initialize Controllers

            sbaLoanDocuments =
                new SbaLoanDocumentsController(
                    new SbaLoanDocumentService(new SbaRestApiClient(BaseUri, ApiToken, VendorKey)));

            sbaLoanForgiveness =
                new SbaLoanForgivenessController(
                    new SbaLoanForgivenessService(new SbaRestApiClient(BaseUri, ApiToken, VendorKey)));

            sbaLoanForgivenessMessageController =
                new SbaLoanForgivenessMessageController(
                    new SbaLoanForgivenessMessageService(new SbaRestApiClient(BaseUri, ApiToken, VendorKey)));

            #endregion
        }

        #region API methods

        public async Task<SbaPPPLoanDocumentTypeResponse> getDocumentTypes()
        {
            SbaPPPLoanDocumentTypeResponse loanDocumentType =
                await sbaLoanForgiveness.getDocumenttypes(pppLoanDocumentTypes);
            return loanDocumentType;
        }

        public async Task<SbaPPPLoanForgivenessStatusResponse> getAllForgivenessRequests()
        {
            SbaPPPLoanForgivenessStatusResponse allForgivenessRequests =
                await sbaLoanForgiveness.getAllForgivenessRequests(pppLoanForgivenessRequests);
            return allForgivenessRequests;
        }

        public async Task<SbaPPPLoanForgivenessStatusResponse> getForgivenessRequestBySbaNumber(string sbaNumber)
        {
            SbaPPPLoanForgivenessStatusResponse loanForgivenessStatusResponse =
                await sbaLoanForgiveness.getForgivenessRequestBysbaNumber(sbaNumber, pppLoanForgivenessRequests);
            return loanForgivenessStatusResponse;
        }

        public async Task<SbaPPPLoanForgiveness> getSbaLoanForgivenessBySlug(string slug)
        {
            SbaPPPLoanForgiveness sbaLoanForgivenessBySlug =
                await sbaLoanForgiveness.getSbaLoanForgivenessBySlug(slug, pppLoanForgivenessRequests);
            return sbaLoanForgivenessBySlug;
        }

        public async Task<bool> deleteSbaLoanForgiveness(string slug)
        {
            return await sbaLoanForgiveness.deleteSbaLoanForgiveness(slug, pppLoanDocumentTypes);
        }

        public async Task<SbaPPPLoanForgiveness> createForgivenessRequest(SbaPPPLoanForgiveness pppLoanForgiveness)
        {
            SbaPPPLoanForgiveness sbaPppLoanForgiveness =
                await sbaLoanForgiveness.execute(pppLoanForgiveness, pppLoanForgivenessRequests);

            return sbaPppLoanForgiveness;
        }

        public async Task<LoanDocumentResponse> uploadForgivenessDocument(string requestName, string requestDocument_type, string etran_loan, string document)
        {
            LoanDocumentResponse loanDocument = await sbaLoanDocuments.uploadForgivenessDocument(requestName,
                requestDocument_type, etran_loan, document, pppLoanDocuments);
            return loanDocument;
        }

        public async Task<string> replyToSbaMessage(MessageReply message, string slug)
        {
            string sbaLoanMessageReply =
                await sbaLoanForgivenessMessageController.replyToSbaMessage(message, slug, pppLoanForgivenessMessageReply);
            return sbaLoanMessageReply;
        }

        public async Task<SbaPPPLoanMessagesResponse> getForgivenessMessagesBySbaNumber(int page, String sbaNumber, bool isComplete)
        {
            SbaPPPLoanMessagesResponse sbaPppLoanMessagesResponse =
                await sbaLoanForgivenessMessageController.getForgivenessMessagesBySbaNumber(page, sbaNumber, isComplete,
                    pppLoanForgivenessMessages);
            return sbaPppLoanMessagesResponse;
        }

        public async Task<SbaPPPLoanMessagesResponse> getForgivenessMessagesBySlug(string slug)
        {
            SbaPPPLoanMessagesResponse forgivenessMessagesBySlug =
                await sbaLoanForgivenessMessageController.getForgivenessMessagesBySlug(slug, pppLoanForgivenessMessages);
            return forgivenessMessagesBySlug;
        }

        #endregion
    }


    /* commented code
     try
            {
                #region read configuration

                IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                string baseUri = configurationRoot.GetSection("baseUri").Value,
                    apiToken = configurationRoot.GetSection("api-token").Value,
                    vendorKey = configurationRoot.GetSection("vendor-key").Value;

                string ppp_loan_document_types = configurationRoot.GetSection("loan-forgiveness-document_types-URL").Value;

                string ppp_loan_forgiveness_requests = configurationRoot.GetSection("loan-forgiveness-requests-URL").Value;

                string ppp_loan_documents = configurationRoot.GetSection("loan-documents-URL").Value;

                string ppp_loan_forgiveness_message_reply = configurationRoot.GetSection("loan-Forgiveness-Message-Reply-URL").Value;

                string ppp_loan_forgiveness_messages = configurationRoot.GetSection("loan-Forgiveness-Message-URL").Value;

                #endregion

                #region Initialize Controllers

                SbaLoanDocumentsController sbaLoanDocuments =
                    new SbaLoanDocumentsController(new SbaLoanDocumentService(new SbaRestApiClient(baseUri, apiToken, vendorKey)));

                SbaLoanForgivenessController sbaLoanForgiveness =
                    new SbaLoanForgivenessController(new SbaLoanForgivenessService(new SbaRestApiClient(baseUri, apiToken, vendorKey)));

                SbaLoanForgivenessMessageController sbaLoanForgivenessMessageController =
                    new SbaLoanForgivenessMessageController(new SbaLoanForgivenessMessageService(new SbaRestApiClient(baseUri, apiToken, vendorKey)));


                #endregion

                #region API calls

                await getDocumentTypes(sbaLoanForgiveness, ppp_loan_document_types);

                await createForgivenessRequest(sbaLoanForgiveness, ppp_loan_forgiveness_requests);

                await uploadForgivenessDocument(sbaLoanDocuments, ppp_loan_documents);

                await getAllForgivenessRequests(sbaLoanForgiveness, ppp_loan_forgiveness_requests);

                await getForgivenessRequestBySbaNumber(sbaLoanForgiveness, ppp_loan_forgiveness_requests);

                await getSbaLoanForgivenessBySlug(sbaLoanForgiveness, ppp_loan_forgiveness_requests);

                await deleteSbaLoanForgiveness(sbaLoanForgiveness, ppp_loan_forgiveness_requests);

                await getForgivenessMessagesBySbaNumber(sbaLoanForgivenessMessageController, ppp_loan_forgiveness_messages);

                await getForgivenessMessagesBySlug(sbaLoanForgivenessMessageController, ppp_loan_forgiveness_messages);

                await replyToSbaMessage(sbaLoanForgivenessMessageController, ppp_loan_forgiveness_message_reply);

                #endregion

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

    #region API methods

        public static async Task getDocumentTypes(SbaLoanForgivenessController sbaLoanForgiveness, string ppp_loan_document_types)
        {
            SbaPPPLoanDocumentTypeResponse loanDocumentType =
                await sbaLoanForgiveness.getDocumenttypes(ppp_loan_document_types);
            if (loanDocumentType != null)
            {
                var serialized = JsonConvert.SerializeObject(loanDocumentType,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task getAllForgivenessRequests(SbaLoanForgivenessController sbaLoanForgiveness, string ppp_loan_forgiveness_requests)
        {
            SbaPPPLoanForgivenessStatusResponse loanDocumentType =
                await sbaLoanForgiveness.getAllForgivenessRequests(ppp_loan_forgiveness_requests);
            if (loanDocumentType != null)
            {
                var serialized = JsonConvert.SerializeObject(loanDocumentType,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task getForgivenessRequestBySbaNumber(SbaLoanForgivenessController sbaLoanForgiveness, string ppp_loan_forgiveness_requests)
        {
            SbaPPPLoanForgivenessStatusResponse loanDocumentType =
                await sbaLoanForgiveness.getForgivenessRequestBysbaNumber("9999133076", ppp_loan_forgiveness_requests);
            if (loanDocumentType != null)
            {
                var serialized = JsonConvert.SerializeObject(loanDocumentType,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task getSbaLoanForgivenessBySlug(SbaLoanForgivenessController sbaLoanForgiveness, string ppp_loan_document_types)
        {
            SbaPPPLoanForgiveness loanDocumentType =
                await sbaLoanForgiveness.getSbaLoanForgivenessBySlug("e58dd70a-8aae-4210-8b26-3047fe02dea2", ppp_loan_document_types);
            if (loanDocumentType != null)
            {
                var serialized = JsonConvert.SerializeObject(loanDocumentType,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task<bool> deleteSbaLoanForgiveness(SbaLoanForgivenessController sbaLoanForgiveness, string ppp_loan_document_types)
        {
            return await sbaLoanForgiveness.deleteSbaLoanForgiveness("cd969ec4-42ee-4f85-baa8-1a521009dd86", ppp_loan_document_types);
        }

        private static async Task createForgivenessRequest(SbaLoanForgivenessController sbaLoanForgiveness, string ppp_loan_forgiveness_requests)
        {
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

            SbaPPPLoanForgiveness sbaPppLoanForgiveness =
                await sbaLoanForgiveness.execute(pppLoanForgiveness, ppp_loan_forgiveness_requests);
            if (sbaPppLoanForgiveness != null)
            {
                var serialized = JsonConvert.SerializeObject(sbaPppLoanForgiveness,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task uploadForgivenessDocument(SbaLoanDocumentsController sbaLoanDocuments, string ppp_loan_documents)
        {
            LoanDocumentResponse loanDocument = await sbaLoanDocuments.uploadForgivenessDocument("Ppdf.pdf", "1", "e1805069-9e05-4bc3-9daf-c40159036003",
                @"C:\Users\Administrator\Desktop\Ppdf.pdf", ppp_loan_documents);
            if (loanDocument != null)
            {
                var serialized = JsonConvert.SerializeObject(loanDocument,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task replyToSbaMessage(SbaLoanForgivenessMessageController sbaLoanForgivenessMessageController, string ppp_loan_forgiveness_message_reply)
        {
            MessageReply message = new MessageReply
            {
                document = @"C:\Users\Administrator\Desktop\Ppdf.pdf",
                document_name = "Test Document",
                document_type = 4,
                content = "test1"
            };

            string sbaLoanMessageReply =
                await sbaLoanForgivenessMessageController.replyToSbaMessage(message, "81c8f2f9-72ac-469d-9a8e-2a6aa6049803", ppp_loan_forgiveness_message_reply);

            if (sbaLoanMessageReply != null)
            {
                Console.WriteLine($"{Environment.NewLine}{sbaLoanMessageReply}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task getForgivenessMessagesBySbaNumber(SbaLoanForgivenessMessageController sbaLoanForgivenessMessageController, string ppp_loan_forgiveness_messages)
        {
            SbaPPPLoanMessagesResponse sbaPppLoanMessagesResponse =
                await sbaLoanForgivenessMessageController.getForgivenessMessagesBySbaNumber(1, "9999133145", true,
                    ppp_loan_forgiveness_messages);

            if (sbaPppLoanMessagesResponse != null)
            {
                var serialized = JsonConvert.SerializeObject(sbaPppLoanMessagesResponse,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        private static async Task getForgivenessMessagesBySlug(SbaLoanForgivenessMessageController sbaLoanForgivenessMessageController, string ppp_loan_forgiveness_messages)
        {
            SbaPPPLoanMessagesResponse loanMessagesBySlug =
                await sbaLoanForgivenessMessageController.getForgivenessMessagesBySlug("e58dd70a-8aae-4210-8b26-3047fe02dea2", ppp_loan_forgiveness_messages);

            if (loanMessagesBySlug != null)
            {
                var serialized = JsonConvert.SerializeObject(loanMessagesBySlug,
                    new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
                Console.WriteLine($"{Environment.NewLine}{serialized}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }

        #endregion
     */
}
