# .NET-Office-Management-BackEnd
Office Mangement Backend using .NET 7.0 Web Api with JWT authentication &amp; MariaDB

Note: JWT token is not saved anywhere. This project only shows how we can use JWT token.
We can save it in database and also use refresh token to generated new access token after some time peroid.
These features may or may not be implemented in future.

Instruction:
1. dotnet --list-sdks
2. dotnet new webapi -f net6.0
3. dotnet build
4. dotnet run

Entity Framework Core:
1. dotnet add package Microsoft.EntityFrameworkCore.SqlServer
2. dotnet tool install --global dotnet-ef
3. dotnet add package Microsoft.EntityFrameworkCore.Design
4. dotnet ef migrations add <migration_name>
5. dotnet ef database update
6. dotnet ef migrations list
7. dotnet ef migrations remove

MariaDB:
1. dotnet add package Pomelo.EntityFrameworkCore.MySql

Database Scaffolding / Reverse Engineering:
1. dotnet ef dbcontext scaffold -o "<folder_name>" "Server=localhost;User=<user>;Password=<password>;Database=<db_name>" "Pomelo.EntityFrameworkCore.MySql"

Httprepl
1. dotnet tool install -g Microsoft.dotnet-httprepl
2. httprepl https://localhost:{PORT}
3. some commands, ls / cd / get <optional_parameter>/ post -c "{"key1": "string_value", "key2": boolean_value_true_false}" / delete / exit etc.

Misc.
1. dotnet tool update <package_name>
2. dotnet dev-certs https --trust
3. For certificate issue go to "chrome://flags/" or "edge://flags/", then enable "Allow invalid certificates for resources loaded from localhost."


NOTE:
If page don't show anything at first run, then hit below url at browser
https://127.0.0.1:7000/api/inventory/inventory_list/
and click continue.





# Angular-Office-Management-FrontEnd
Angular frontend for Django-Office-Management-BackEnd repository

Issues:
1. Fix inventory quickedit update error msg in javascript console
2. Fix CORS issue in .NET
3. Fix empty email in profile update and also email error check
4. Need to check why response is sometimes parsed as msg.text and sometimes msg. i.e. inventory quick edit vs create.