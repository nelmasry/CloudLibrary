# CloudLibrary
Library for creating and maintaining cloud infrastructure without needing to have deep knowledge about different cloud providers

Solution has 3 projects:
* **CloudLibrary:** Main .net standard Class library for cloud)
* **CloudLibrary.Test:** some unit test for class library core functions
* **Cloud_Library_Client:** Console app consuming CloudLibrary APIs

Console app should be run to consume CloudLibrary class library by creating resources in different environments like UAT,Prod..etc and waiting few seconds before deleting some of the infrastructure created

**hint.** Current initial path for creating infrastructure folders is "D:\CloudInfra", please change it in appsettings.json file in case change needed. 
