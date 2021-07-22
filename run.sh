#!/bin/bash

export connectionString="Server=tcp:jakepayroc.database.windows.net,1433;Initial Catalog=urls;Persist Security Info=False;User ID=jakeadmin;Password=LongPassword1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

dotnet watch run;
