# .NET Code Challenge

This application outputs the horse names in price ascending order. 

There are some outstanding things to be decided:
* The XML feed could potentially contain multiple races. How will we identify the correct one
* The JSON feed could potentially contain multiple markets. How will we identify the correct one, or do we combine them?
* How can we identify which feed provider to use, based on the race's URL?
* We need to hook up a DI container so that the factory can be injected into the application properly.

The RaceDataProviders have been unit tested as they are the most critical components of the application.
