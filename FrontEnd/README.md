# Angular-Office-Management
Angular frontend

Issues:
1. Fix inventory quickedit update error msg in javascript console
2. Fix CORS issue in .NET
3. Fix empty email in profile update and also email error check
4. Need to check why response is sometimes parsed as msg.text and sometimes msg. i.e. inventory quick edit vs create.


Some helpful commands,
1. 'npm install --save-dev @angular/cli@latest' to fix 'could not find module '@angular-devkit/build-angular' issue.



Need to fix:
1. HTTP response msg parsing:
 a. Inventory quick edit success shows error msg in log
 b. Read OK response msg properly
 c. push success
2. Loading screen


Error Response Example:
1. Login Error:
{
    "headers": {
        "normalizedNames": {},
        "lazyUpdate": null
    },
    "status": 401,
    "statusText": "OK",
    "url": "https://127.0.0.1:7000/api/user/login/",
    "ok": false,
    "name": "HttpErrorResponse",
    "message": "Http failure response for https://127.0.0.1:7000/api/user/login/: 401 OK",
    "error": {
        "detail": "Invalid Login credential"
    }
}

2. Assert Created OK:
