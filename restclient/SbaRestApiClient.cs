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
                restRequest.AddHeader("Vendor-Key", vendorKey);
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
                restRequest.AddHeader("Vendor-Key", vendorKey);
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

        public async Task<LoanDocumentType> getSbaLoanForgiveness(int pageNumber, string loanForgivenessUrl)
        {
            try
            {
                if (pageNumber <= 0)
                {
                    throw new Exception("Incorrect input data. please investigate");
                }

                RestClient restClient = new RestClient($"{baseUri}/{loanForgivenessUrl}/{pageNumber}/");
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("Authorization", apiToken);
                restRequest.AddHeader("Vendor-Key", vendorKey);
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
                restRequest.AddHeader("Vendor-Key", vendorKey);
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
    }
}
