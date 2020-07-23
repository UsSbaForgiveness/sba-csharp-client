# C# Client Code Usage

Please refer [API Dictionary URL](https://ussbaforgiveness.github.io/API-Dictionary.html) for any clarifications related to API request/response attributes.

C# Client code is provided to make it easier to integrate to SBA APIs.

**Usage #1:** Use Services provided in the code to eliminate the complexity of creating Rest Clients to integrate with SBA API&#39;s

> UsSbaForgiveness/sba-csharp-client/tree/master/service

**Usage #2:** Use domain objects to include in your code to make Rest API calls.

>UsSbaForgiveness/sba-csharp-client/tree/master/domain

**Usage #3:** Use complete repository as a C# .NET Core Console Application for your integration.

**Cloning the repository**

Clone repository using SourceTree or Git Bash.

`$git clone https://github.com/UsSbaForgiveness/sba-csharp-client.git`

## Below are the basic example steps for Submitting a Forgiveness request to the SBA System ##

### Step 1: Submit Loan Forgiveness Request ###

This example is part of a sample [Use Case 1](https://ussbaforgiveness.github.io/UseCases/usecase1-Submission-of-forgiveness-request.html)

### POST API Call using SbaLoanForgivenessService Service and SbaPPPLoanForgiveness Request. ###

```SbaLoanForgivenessService.execute(SbaPPPLoanForgiveness request)```

You need to populate SbaPPPLoanForgiveness Request object with all the information provided in the 3508 and 3508EZ documents.

Please refer Document - API Field mapping diagrams
- [3508](https://ussbaforgiveness.github.io/DocumentToAPIMappingImages/Form3508/Form-3508-Mapping-of-PDF-Form-to-API-Elements.html)
- [3508EZ](https://ussbaforgiveness.github.io/DocumentToAPIMappingImages/Form3508EZ/Form-3508EZ-Mapping-of-PDF-Form-to-API-Elements.html)

Response is same as Request Object `SbaPPPLoanForgiveness` with id and slug are populated.

Please refer to [Create Forgiveness Request API](https://ussbaforgiveness.github.io/API-Dictionary.html#2-create-forgiveness-request)

### Step 2: Retrieve the document types required for uploading the documents ###

This example is part of a sample [Use Case 4](https://ussbaforgiveness.github.io/UseCases/usecase4-Get-document-types.html)

### To get Document Type make a GET API Call to ###

```SbaLoanDocumentService.getDocumentTypes(Dictionary<string, string> reqParams, string loanDocumentTypesUrl)```

 _reqParams_: Please refer to [GET Document Types API](https://ussbaforgiveness.github.io/API-Dictionary.html)

### Step 3: Upload Supporting Documentation for a Loan Forgiveness Request ###

This example is part of a sample [Use Case 1](https://ussbaforgiveness.github.io/UseCases/usecase1-Submission-of-forgiveness-request.html)

### To upload the documents ###

a. Need SbaPPPLoanForgiveness Details (Details can be derived from Step 1)
b. Need Document Type (Details can be derived from Step 2)

This is a POST API call to upload documents.

```SbaLoanDocumentService.submitLoanDocument(LoanDocument request)```
Please refer to [Upload Forgiveness Document API](https://ussbaforgiveness.github.io/API-Dictionary.html#3-upload-forgiveness-documents)

### Step 4: Retrieve Loan Forgiveness Request Status and detail ###

This example is part of a sample [Use Case 3](https://ussbaforgiveness.github.io/UseCases/usecase3-Get-forgiveness-details.html)

### This is a GET API Call to retrieve Sba PPP Loan Forgiveness details submitted in Step 1. ###

```SbaLoanForgivenessService.getLoanStatus(int page, string sbaNumber)```

_page_ is a query parameter ex: 1,2 etc

Response `SbaPPPLoanForgivenessStatusResponse` contains all the requests submitted as part of the Loan Forgiveness Process.

Please refer to [Retrieve Forgiveness Request API](https://ussbaforgiveness.github.io/API-Dictionary.html#6-get-forgiveness-request-details-using-sba-number)

### Some more API Samples ###

### Get SBA Messages
### During review of a Forgiveness request, SBA may require additional information from lender. This API is used to retrieve all messages sent by SBA to lender. ###

This example is part of a sample [Use Case 5](https://ussbaforgiveness.github.io/UseCases/usecase5-Correctional-Document-Upload.html)

```SbaLoanForgivenessMessageService.getSbaLoanMessages(int page, String sbaNumber, bool isComplete, string loanForgivenessMessageUrl)```

Response `SbaPPPLoanMessagesResponse` contains all the messages exchanged between SBA and the lender
Please refer to [Get SBA Messages API](https://ussbaforgiveness.github.io/API-Dictionary.html#8-get-forgiveness-messages)

### Reply SBA Messages
### During review of a Forgiveness request, SBA may require additional information from lender. This API is used by lender to respond back to SBA by attaching requested documents. ###

This example is part of a sample [Use Case 5](https://ussbaforgiveness.github.io/UseCases/usecase5-Correctional-Document-Upload.html)

```SbaLoanForgivenessMessageService.updateSbaLoanForgivenessMessageReply(MessageReply request, string loanForgivenessMessageUrl)```

Please refer to [Reply SBA Messages Rest API](https://ussbaforgiveness.github.io/API-Dictionary.html#10-reply-to-sba-message)
