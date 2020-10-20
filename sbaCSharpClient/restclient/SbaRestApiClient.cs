using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using sbaCSharpClient.domain;
using System.Reflection.Metadata;
using System.IO;

namespace sbaCSharpClient.restclient
{
    public class SbaRestApiClient
    {
        private readonly string baseUri;

        private readonly string apiToken;

        private readonly string vendorKey;

        private const string VENDOR_KEY = "Vendor-Key";

        public SbaRestApiClient(string BaseUri, string ApiToken, string VendorKey)
        {
            baseUri = BaseUri;
            apiToken = ApiToken;
            vendorKey = VendorKey;
        }

        public async Task<SbaPPPLoanForgiveness> CreateForgivenessRequest(SbaPPPLoanForgiveness request, string loanForgivenessUrl)
        {
            try
            {
                var serialized = JsonConvert.SerializeObject(request, new JsonSerializerSettings() { 
                                                                        DateFormatHandling = DateFormatHandling.IsoDateFormat,
                                                                        NullValueHandling = NullValueHandling.Ignore });

                RestClient restClient = new RestClient($"{baseUri}/{loanForgivenessUrl}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.POST);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddParameter("application/json", serialized, ParameterType.RequestBody);
                IRestResponse response = await restClient.ExecuteAsync(restRequest);

                if (response.IsSuccessful)
                {
                    SbaPPPLoanForgiveness sbaPPPLoanForgiveness = JsonConvert.DeserializeObject<SbaPPPLoanForgiveness>(response.Content);
                    return sbaPPPLoanForgiveness;
                }
                throw new Exception($"Did not receive success code. please investigate. \nresponse code: {response.StatusCode}.\n response:{response.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }

        public async Task<LoanDocumentResponse> uploadForgivenessDocument(string requestName, string requestDocument_type, string etran_loan, string document, string loanDocumentsUrl)
        {
            try
            {
                RestClient restClient = new RestClient($"{baseUri}/{loanDocumentsUrl}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.POST);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddParameter("name", requestName);
                restRequest.AddParameter("document_type", requestDocument_type);
                restRequest.AddParameter("etran_loan", etran_loan);
                restRequest.AddFile("document", document);

                IRestResponse response = await restClient.ExecuteAsync(restRequest);

                if (response.IsSuccessful)
                {
                    LoanDocumentResponse loanDocument = JsonConvert.DeserializeObject<LoanDocumentResponse>(response.Content);
                    return loanDocument;
                }
                throw new Exception($"Did not receive success code. please investigate. \nresponse code: {response.StatusCode}.\n response:{response.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }

        public async Task<SbaPPPLoanDocumentTypeResponse> getSbaLoanForgiveness(string loanForgivenessUrl)
        {
            try
            {
                string baseUrl = $"{baseUri}/{loanForgivenessUrl}/";

                RestClient restClient = new RestClient(baseUrl);
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    SbaPPPLoanDocumentTypeResponse loanDocumentTypeResponse = JsonConvert.DeserializeObject<SbaPPPLoanDocumentTypeResponse>(restResponse.Content);
                    return loanDocumentTypeResponse;
                }
                throw new Exception($"Did not receive success code. please investigate. received response: {Environment.NewLine}StatusCode - {restResponse.StatusCode}{Environment.NewLine}Response - {restResponse.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }

        public async Task<SbaPPPLoanForgivenessStatusResponse> getAllForgivenessRequests(string ppp_loan_forgiveness_requests)
        {
            try
            {
                RestClient restClient = new RestClient($"{baseUri}/{ppp_loan_forgiveness_requests}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    SbaPPPLoanForgivenessStatusResponse sbaLoanForgiveness = JsonConvert.DeserializeObject<SbaPPPLoanForgivenessStatusResponse>(restResponse.Content);
                    return sbaLoanForgiveness;
                }
                throw new Exception($"Did not receive success code. please investigate. received response: {Environment.NewLine}StatusCode - {restResponse.StatusCode}{Environment.NewLine}Response - {restResponse.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }

        public async Task<SbaPPPLoanForgivenessStatusResponse> getForgivenessRequestBysbaNumber(string sbaNumber, string ppp_loan_forgiveness_requests)
        {
            try
            {
                RestClient restClient = new RestClient($"{baseUri}/{ppp_loan_forgiveness_requests}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddParameter("sba_number", sbaNumber);
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    SbaPPPLoanForgivenessStatusResponse sbaLoanForgiveness = JsonConvert.DeserializeObject<SbaPPPLoanForgivenessStatusResponse>(restResponse.Content);
                    return sbaLoanForgiveness;
                }
                throw new Exception($"Did not receive success code. please investigate. received response: {Environment.NewLine}StatusCode - {restResponse.StatusCode}{Environment.NewLine}Response - {restResponse.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }

        public async Task<SbaPPPLoanForgiveness> getSbaLoanForgivenessBySlug(string slug, string loanForgivenessUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(slug))
                {
                    throw new Exception("Incorrect input data. please investigate");
                }

                RestClient restClient = new RestClient($"{baseUri}/{loanForgivenessUrl}/{slug}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    Console.WriteLine($"{Environment.NewLine}{restResponse.Content}{Environment.NewLine}");
                    Console.WriteLine("------------------------------------------------------------------------");

                    SbaPPPLoanForgiveness sbaLoanForgiveness = JsonConvert.DeserializeObject<SbaPPPLoanForgiveness>(restResponse.Content);
                    return sbaLoanForgiveness;
                }
                throw new Exception($"Did not receive success code. please investigate. received response: {Environment.NewLine}StatusCode - {restResponse.StatusCode}{Environment.NewLine}Response - {restResponse.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }

        public async Task<bool> deleteSbaLoanForgiveness(string slug, string loanForgivenessUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(slug))
                {
                    throw new Exception("Incorrect input data. please investigate");
                }

                RestClient restClient = new RestClient($"{baseUri}/{loanForgivenessUrl}/{slug}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.DELETE);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    Console.WriteLine($"{Environment.NewLine}Delete was successful{Environment.NewLine}");
                    Console.WriteLine("------------------------------------------------------------------------");
                    return true;
                }
                throw new Exception($"Did not receive success code. please investigate. received response: {Environment.NewLine}StatusCode - {restResponse.StatusCode}{Environment.NewLine}Response - {restResponse.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return false;
            }
        }

        public async Task<SbaPPPLoanDocumentTypeResponse> getSbaLoanDocumentTypes(Dictionary<string, string> reqParams, string loanDocumentTypesUrl)
        {
            try
            {
                if (reqParams.Count <= 0)
                {
                    throw new Exception("Incorrect input data. please investigate");
                }
                var serialized = JsonConvert.SerializeObject(reqParams, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });

                RestClient restClient = new RestClient($"{baseUri}/{loanDocumentTypesUrl}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddParameter("application/json", serialized, ParameterType.RequestBody);
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    SbaPPPLoanDocumentTypeResponse documentTypeResponse = JsonConvert.DeserializeObject<SbaPPPLoanDocumentTypeResponse>(restResponse.Content);
                    return documentTypeResponse;
                }
                throw new Exception($"Did not receive success code. please investigate. received response: {Environment.NewLine}StatusCode - {restResponse.StatusCode}{Environment.NewLine}Response - {restResponse.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }

        public async Task<LoanDocumentType> getSbaLoanDocumentTypeById(int id, string loanForgivenessUrl)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Incorrect input data. please investigate");
                }

                RestClient restClient = new RestClient($"{baseUri}/{loanForgivenessUrl}/{id}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    LoanDocumentType loanDocumentType = JsonConvert.DeserializeObject<LoanDocumentType>(restResponse.Content);
                    return loanDocumentType;
                }
                throw new Exception($"Did not receive success code. please investigate. received response: {Environment.NewLine}StatusCode - {restResponse.StatusCode}{Environment.NewLine}Response - {restResponse.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }

        public async Task<string> replyToSbaMessage(MessageReply request, string slug, string loanForgivenessMessageUrl)
        {
            try
            {
                RestClient restClient = new RestClient($"{baseUri}/{loanForgivenessMessageUrl}/{slug}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.PUT);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddParameter("document_name", request.document_name);
                restRequest.AddParameter("document_type", request.document_type);
                restRequest.AddParameter("content", request.content);
                restRequest.AddFile("document", request.document);
                IRestResponse response = await restClient.ExecuteAsync(restRequest);

                if (response.IsSuccessful)
                {
                    return response.Content;
                }
                throw new Exception($"Did not receive success code. please investigate. \nresponse code: {response.StatusCode}.\n response:{response.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return exception.Message;
            }
        }

        public async Task<string> replyToSbaMessageWithMultipleDocs(MessageReplyMultipleFiles request, string slug, string loanForgivenessMessageUrl)
        {   
            try
            {

                RestClient restClient = new RestClient($"{baseUri}/{loanForgivenessMessageUrl}/{slug}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.PUT);
                
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);

                request.document_names.ForEach(t => restRequest.AddParameter("document_name", t, ParameterType.GetOrPost));
                request.document_types.ForEach(t => restRequest.AddParameter("document_type", t, ParameterType.GetOrPost));
                request.documents.ForEach(t => restRequest.AddFile("document", t));

                restRequest.AddParameter("content", request.content, ParameterType.GetOrPost);

                IRestResponse response = await restClient.ExecuteAsync(restRequest);

                if (response.IsSuccessful)
                {
                    return response.Content;
                }

                throw new Exception($"Did not receive success code. please investigate. \nresponse code: {response.StatusCode}.\n response:{response.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return exception.Message;
            }
        }

        public async Task<SbaPPPLoanMessagesResponse> getForgivenessMessagesBySbaNumber(int page, string sbaNumber, bool isComplete, string loanForgivenessMessageUrl)
        {
            try
            {
                if (page <= 0)
                {
                    throw new Exception("Incorrect input data. please investigate");
                }

                string baseUrl = $"{baseUri}/{loanForgivenessMessageUrl}/";

                RestClient restClient = new RestClient(baseUrl);
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddParameter("sba_number", sbaNumber);
                restRequest.AddParameter("page", page);
                restRequest.AddParameter("isComplete", isComplete);
                restRequest.AddHeader("Content-Type", "application/json");
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    SbaPPPLoanMessagesResponse loanMessagesResponse = JsonConvert.DeserializeObject<SbaPPPLoanMessagesResponse>(restResponse.Content);
                    return loanMessagesResponse;
                }
                throw new Exception($"Did not receive success code. please investigate. received response: {Environment.NewLine}StatusCode - {restResponse.StatusCode}{Environment.NewLine}Response - {restResponse.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }

        public async Task<SbaPPPLoanMessagesResponse> getForgivenessMessagesBySlug(string slug, string loanForgivenessMessageUrl)
        {
            try
            {
                string baseUrl = $"{baseUri}/{loanForgivenessMessageUrl}/{slug}/";

                RestClient restClient = new RestClient(baseUrl);
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    SbaPPPLoanMessagesResponse sbaPPPLoanMessagesResponse = JsonConvert.DeserializeObject<SbaPPPLoanMessagesResponse>(restResponse.Content);
                    return sbaPPPLoanMessagesResponse;
                }
                throw new Exception($"Did not receive success code. please investigate. received response: {Environment.NewLine}StatusCode - {restResponse.StatusCode}{Environment.NewLine}Response - {restResponse.Content}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }
    }
}
