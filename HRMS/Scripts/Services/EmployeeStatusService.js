
function EmployeeStatusService() { } EmployeeStatusService.prototype = new Proxy('EmployeeStatus', 'StatusID');

// Example Custom Method
EmployeeStatusService.prototype.MyCustomMethod = function (params, callback) {

    // Query allows for custom get calls to the server    

    // Query API
    this.Query('MyCustomMethodNameOnThisObject?' + params, callback);

    // Query Controller
    this.QueryController('MyCustomMethodNameOnThisObject?' + params, callback);

}

var EmployeeStatusService = new EmployeeStatusService();

