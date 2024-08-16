Welcome to this sample application API built in [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) + [ServiceStack](https://github.com/ServiceStack/ServiceStack) that leverages [REST Countries API](https://restcountries.com/).

There are three components to this system (microservish)
- React UI [live](https://thisdotco.onrender.com) [source](https://github.com/Siliconrob/thisdotco)

The following components are on the free hosted tier level of [Render](https://render.com/) and are shutdown when not in use.  Accessing each component from a shutdown state requires it to spin back up and this can delay requests for a minute or so.

- .NET API built with [ServiceStack](https://github.com/ServiceStack/ServiceStack) [live](https://calamansi.onrender.com) 
- FastAPI API built with [FastAPI](https://fastapi.tiangolo.com/) [live](https://restful-with-more-fastapi.onrender.com)

## Demo use

- Default interactive [ServiceStack Project UI](https://calamansi.onrender.com/ui) provides numerous options for experimentation.  I suggest experimenting with it

![servicestack_ui](https://github.com/user-attachments/assets/03e3b4e7-06c8-4aab-8c64-bc9d0bad1e7f)
 
- Also an [OpenAPI](https://calamansi.onrender.com/swagger/index.html) reference as well.  Compare and contrast with the above ServiceStack one

![servicestack_swagger](https://github.com/user-attachments/assets/686b1f66-2229-4022-826f-9c3a30a37028)

## Flow

![thisdotco-netapi drawio](https://github.com/user-attachments/assets/7bdb9ef3-f773-4521-a211-1bbbe80a159b)

This API was built on top of ServiceStack which is my favorite framework when working with .NET.  It is everything that .NET Core should be and is built for maximum productivity with all the correct options builtin to get you off and running along with being setup for long term success i.e. batteries included.

## Design

Looking over the [REST Countries API](https://restcountries.com/), two points jump out to me.

- There are only a limited amount of countries in the world.  The API returns 250 for all.  This is a small data amount even pulling in all the details.
- The country data is not changing and would only change if a new country is formed or a major political event occurs.

With this in mind I query 2 endpoints and be done with the entire API implementation if I pull down the full Country data.  Therefore I did that approach.
- An API request checks the in memory cache represntation of all the countries.  If it exists find the country by the various inputs and return the data.  If the all countries data is not cached go grab it from the REST endpoint and cache it.  That means you can take a one time penalty hit for grabbing all the data, but after that point you have immediate access until your cached values expire.
- Countries endpoint has the ability to do a free text search.  This means taking the JSON object and flattening all the data and then doing a string search for the containing term.  If I say free text search for `United` it will return all countries that have that text in any data field of the overall Country data object.
- Languages and Regions endpoints perform an extra manipulation step on the cached all countries data by doing a grouping first either by Region or Language into a dictionary and then performing the id check or return all.

That's it no need to do anything else and it is a straightforward and clear way to build the API.

## Development

This project was built using the default NET 8 ServiceStack template.  Download the latest version of .NET 8 and I am using [Rider](https://www.jetbrains.com/rider/) to run the program.  You could use and tool you wish that will open solution file `calamansi.sln`

### Powershell command line run 
- `dotnet build`
- `cd .\calamansi`
- `dotnet run`

### Docker
- There is a provided [Dockerfile](https://github.com/Siliconrob/calamansi/blob/main/Dockerfile) in the solution that was created for deployment

## Render Deployment

- Signup for a free [Render](https://dashboard.render.com/register) account.  You won't regrest it :)
- Connect your [GitHub](https://docs.render.com/github) account
- Choose the `Web Services` [option](https://docs.render.com/web-services)
 - Setup a name
 - Use the defaults and choose the `Dockerfile` under `Dockerfile Path`
 - Trigger a manual deployment
