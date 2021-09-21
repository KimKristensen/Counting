# A countable service

## Description
2 services have been implemented:
* The Counter service which is the REST service for incrementing counters
* The CountingBusiness service that calls the Counter service

Both services are written in C# using visual studio, the REST service is a ASP.net core service. 

RestSharp is used for accessing the REST service

## To be done
Not everything has been implemented and the following are the areas that I would adrees next
* Counters are stored in an in-memory readmodel and should be stored in a permanent storage
* The performance of writing counters is not overwhelming
* Improve on error handling








