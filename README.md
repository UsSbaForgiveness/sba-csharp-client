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

### POST API Call using SbaLoanForgivenessService Service and SbaPPPLoanForgiveness Request.###

```SbaLoanForgivenessService.execute(SbaPPPLoanForgiveness request)```

You need to populate SbaPPPLoanForgiveness Request object with all the information provided in the 3508 and 3508EZ documents.

Response is same as Request Object `SbaPPPLoanForgiveness` with id and slug are populated.

Please refer Document - Field mapping diagrams provided in the API Page: https://ussbaforgiveness.github.io/

### **Note**

> If you are uploading the documents immediately after Step 1, Response object from Step 1 contains all the information needed so please skip Step 2.

and continue with Step 3.

### Step 2: Retrieve Loan Forgiveness Request Status and detail ###

### This is a GET API Call to retrieve Sba PPP Loan Forgiveness details submitted in Step 1. ###

```SbaLoanForgivenessService.getLoanStatus(int page, string sbaNumber)```

_page_ is a query parameter ex: 1,2 etc

Response `SbaPPPLoanForgivenessStatusResponse` contains all the requests submitted as part of the Loan Forgiveness Process.

### Step 3: Upload Supporting Documentation for a Loan Forgiveness Request ###

### To upload the documents ###

a. Need SbaPPPLoanForgiveness Details (Details can be from Step 1 or Step 2)

b. Need Document Type

### To get Document Type make a GET API Call to ###

```SbaLoanDocumentService.getDocumentTypes((Dictionary<string, string> reqParams, string loanDocumentTypesUrl)```

 _reqParams_: Please refer GET Document Types API Swagger at #[API Dictionary URL](https://ussbaforgiveness.github.io/API-Dictionary.html#1-get-document-types)

This is a POST API call to upload documents.

```SbaLoanDocumentService.submitLoanDocument(LoanDocument request)```
