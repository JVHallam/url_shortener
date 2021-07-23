# Getting setup

## Environement Variables:
* connectionString="A full connection string to an MS SQL database. I'd used an Azure SQL Server instance whilst testing.";

## Running:
Make sure to have the dotnet cli installed
The application is run by:
* Navigating to url_shortener
* dotnet run

Then, navigate to the root of the application, to test it.

# E2E Testing:
* These tests assume that you already have the application running with SSL on port 5001 (e.g. https://localhost:5001 )
* These are run via "dotnet test" from the url_shortener_xunit_tests project

# Explanation:
* This is an asp.net application
* That stores it's data into a SQL server instance
* The connection string for which is set as the environment variable "connectionString"
* The startup of the application will handle configuration of tables
