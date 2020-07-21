using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using sbaCSharpClient.domain;

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

        public async Task<SbaPPPLoanForgiveness> invokeSbaLoanForgiveness(SbaPPPLoanForgiveness request, string loanForgivenessUrl)
        {
            try
            {
                var serialized = JsonConvert.SerializeObject(request, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });

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

        public async Task<LoanDocument> invokeSbaLoanDocument(LoanDocument request, string loanDocumentsUrl)
        {
            try
            {
                var serialized = JsonConvert.SerializeObject(request, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });

                RestClient restClient = new RestClient($"{baseUri}/{loanDocumentsUrl}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.POST);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddParameter("application/json", serialized, ParameterType.RequestBody);
                IRestResponse response = await restClient.ExecuteAsync(restRequest);

                if (response.IsSuccessful)
                {
                    LoanDocument loanDocument = JsonConvert.DeserializeObject<LoanDocument>(response.Content);
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

        public async Task<SbaPPPLoanDocumentTypeResponse> getSbaLoanForgiveness(int pageNumber, string sbaNumber, string loanForgivenessUrl)
        {
            try
            {
                if (pageNumber <= 0)
                {
                    throw new Exception("Incorrect input data. please investigate");
                }
                
                string baseUrl = !string.IsNullOrEmpty(sbaNumber)
                    ? $"{baseUri}/{loanForgivenessUrl}?pageNumber={pageNumber}&sbaNumber={sbaNumber}"
                    : $"{baseUri}/{loanForgivenessUrl}?pageNumber={pageNumber}";

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
                throw new Exception($"Did not receive success code. please investigate. received response code: {restResponse.StatusCode}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------"); 
                return null;
            }
        }
        
        public async Task<SbaPPPLoanForgiveness> getSbaLoanForgiveness(string sbaNumber, string loanForgivenessUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(sbaNumber))
                {
                    throw new Exception("Incorrect input data. please investigate");
                }
                
                RestClient restClient = new RestClient($"{baseUri}/{loanForgivenessUrl}?sbaNumber={sbaNumber}");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    SbaPPPLoanForgiveness sbaLoanForgiveness = JsonConvert.DeserializeObject<SbaPPPLoanForgiveness>(restResponse.Content);
                    return sbaLoanForgiveness;
                }
                throw new Exception($"Did not receive success code. please investigate. received response code: {restResponse.StatusCode}");
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

                RestClient restClient = new RestClient($"{baseUri}/{loanForgivenessUrl}?slug={slug}");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    SbaPPPLoanForgiveness sbaLoanForgiveness = JsonConvert.DeserializeObject<SbaPPPLoanForgiveness>(restResponse.Content);
                    return sbaLoanForgiveness;
                }
                throw new Exception($"Did not receive success code. please investigate. received response code: {restResponse.StatusCode}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }

        public async void deleteSbaLoanForgiveness(string slug, string loanForgivenessUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(slug))
                {
                    throw new Exception("Incorrect input data. please investigate");
                }

                RestClient restClient = new RestClient($"{baseUri}/{loanForgivenessUrl}?slug={slug}");
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
                }
                throw new Exception($"Did not receive success code. please investigate. received response code: {restResponse.StatusCode}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
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
                throw new Exception($"Did not receive success code. please investigate. received response code: {restResponse.StatusCode}");
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

                RestClient restClient = new RestClient($"{baseUri}/{loanForgivenessUrl}?id={id}");
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
                throw new Exception($"Did not receive success code. please investigate. received response code: {restResponse.StatusCode}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }

        public async Task<MessageReply> updateSbaLoanForgivenessMessageReply(MessageReply request, string loanForgivenessMessageUrl)
        {
            try
            {
                var serialized = JsonConvert.SerializeObject(request, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });

                RestClient restClient = new RestClient($"{baseUri}/{loanForgivenessMessageUrl}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.POST);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddParameter("application/json", serialized, ParameterType.RequestBody);
                IRestResponse response = await restClient.ExecuteAsync(restRequest);

                if (response.IsSuccessful)
                {
                    MessageReply sbaLoanForgivenessMessageReply = JsonConvert.DeserializeObject<MessageReply>(response.Content);
                    return sbaLoanForgivenessMessageReply;
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

        public async Task<SbaPPPLoanMessagesResponse> getSbaLoanMessagesBySbaNumber(int page, string sbaNumber, bool isComplete, string loanForgivenessMessageUrl)
        {
            try
            {
                if (page <= 0)
                {
                    throw new Exception("Incorrect input data. please investigate");
                }

                string baseUrl = $"{baseUri}/{loanForgivenessMessageUrl}?page={page}&sbaNumber={sbaNumber}&isComplete={isComplete}";

                RestClient restClient = new RestClient(baseUrl);
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    SbaPPPLoanMessagesResponse loanMessagesResponse = JsonConvert.DeserializeObject<SbaPPPLoanMessagesResponse>(restResponse.Content);
                    return loanMessagesResponse;
                }
                throw new Exception($"Did not receive success code. please investigate. received response code: {restResponse.StatusCode}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{Environment.NewLine}{exception.Message}{Environment.NewLine}");
                Console.WriteLine("------------------------------------------------------------------------");
                return null;
            }
        }

        public async Task<SbaPPPLoanForgivenessMessage> getSbaLoanForgivenessMessagesBySlug(string slug, string loanForgivenessMessageUrl)
        {
            try
            {
                string baseUrl = $"{baseUri}/{loanForgivenessMessageUrl}?slug={slug}";

                RestClient restClient = new RestClient(baseUrl);
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader(VENDOR_KEY, vendorKey);
                restRequest.AddHeader("Content-Type", "application/json");
                IRestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                if (restResponse.IsSuccessful)
                {
                    SbaPPPLoanForgivenessMessage loanForgivenessMessage = JsonConvert.DeserializeObject<SbaPPPLoanForgivenessMessage>(restResponse.Content);
                    return loanForgivenessMessage;
                }
                throw new Exception($"Did not receive success code. please investigate. received response code: {restResponse.StatusCode}");
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
