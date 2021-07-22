# Getting setup
* In the "export_secrets.sh"
    * Set your connection string
* run run.sh

* Alternatively:
    * Manually export your sql connection string as "connectionString"
    * dotnet run

# Explanation:
* This is a asp.net application
* That stores it's data into a SQL server instance
* The connection string for which is set as the environment variable "connectionString"
* The startup of the application will handle configuration of tables
