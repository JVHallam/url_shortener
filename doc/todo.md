# Break one:
* Eat dinner
* Shower
* Possibly consider finishing this in the morning
* Reject previous conclusion

# Getting a deployable POC
* CLEAN THE REPO!
    * Setup script has my fucking connection string in it, not cool
    * Create an export_secrets.sh
    * Add this to the .gitignore
    * This is then called from run.sh

* Database Checks + Initialization:
    * In configure, check the environment variables
    * In configure, Check if i can connect to the database, stated in the string
    * In configure, initiliase the database if not already exists

* Setup script:
    * Update the README to detail this
    * Remove my value

* Test it all works:
    * Delete the project
    * Repull it
    * How hard is it to setup from scratch
        * Write a README.md

# Test + Refactor
* A validation middleware, please :'(
* Get an E2E project setup
* Get some basic E2E tests
    * Happy path
    * Bad url
    * Bad Key
    * Bad everything

* Urls + Controllers:
    * Do the URLS and controllers make sense?
    * Should i have a shorten / lengthen controller, made seperate

* Appearances:
    * Get the { almond } braces on the go.
    * Check any names ( Capitals for class methods, lower case of variables );

# Clean up and finish
* Add a front end
* This should be super simple, nothing else

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

* Clean up:
    * Rename the table + fields
    * Set unique values for the urls?

* Happy path:
    * Can save a key to the database
    * The key is returned
    * Can get the key from the service
    * Can use that key to go to the service
