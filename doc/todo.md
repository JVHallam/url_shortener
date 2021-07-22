# Getting a working POC
* Setting up persistance:
    * Get a database set up - use azure
        * Get the connection string
        * Can i connect to it with a remote client

        * Server=tcp:jakepayroc.database.windows.net,1433;Initial Catalog=urls;Persist Security Info=False;User ID=jakeadmin;Password=LongPassword1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

    * Get the dapper dependency
        * dotnet add package dapper
        * dotnet add package System.Data.SqlClient

    * Use it
        * using dapper;
        * using var connection = new SqlConnection(tenantDbConnectionString);
        * var returned = await connection.QuerySingleOrDefaultAsync(sql, queryParams);

    * Get it from the appsettings

    -------------------------------------------------

* Integrate into the database
    * Clean up the database table, to make the names look nice
    * Make the url a unique value
    * make the key, the primary key of the table, lol, why not?

* Happy path:
    * Can save a key to the database
    * The key is returned
    * Can get the key from the service
    * Can use that key to go to the service

# Break one:
* Eat dinner
* Shower
* Possibly consider finishing this in the morning
* Reject previous conclusion

# Getting a deployable POC
* Get the connection string from an environment variable - Make a note of this somewhere
* Have a script that sets things up
* Delete the project
* Repull it
* How hard is it to setup from scratch
    * Write a README.md

# Test + Refactor
* Get an E2E project setup
* Get some basic E2E tests
    * Happy path
    * Bad url
    * Bad Key

* Urls + Controllers:
    * Do the URLS and controllers make sense?
    * Should i have a shorten / lengthen controller, made seperate

* Appearances:
    * Get the { almond } braces on the go.
    * Check any names ( Capitals for class methods, lower case of variables );

# Clean up and finish

----------------------------------------------------------------------
# Complete

# Getting a super short POC
* Get the api POC setup:
    * An api that shortens a url
        * Returns a key
        * doesn't actually save anything

    * An api that lengthens a key, and causes a redirect
        * Returns a default url

* Take a Break:
    * think about what's left

# Break one:
* Get tea
* Take care of anything else
* Then come back and get the database setup

