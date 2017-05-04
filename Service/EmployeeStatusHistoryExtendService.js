function EmployeeStatusHistoryExtendService() { } EmployeeStatusHistoryExtendService.prototype = new Proxy('EmployeeStatusHistoryExtend', 'EmployeeStatusID');

// Example Custom Method
EmployeeStatusHistoryExtendService.prototype.MyCustomMethod = function (params, callback) {

    // Query allows for custom get calls to the server    

    // Query API
    this.Query('MyCustomMethodNameOnThisObject?' + params, callback);

    // Query Controller
    this.QueryController('MyCustomMethodNameOnThisObject?' + params, callback);
}
var employeeStatusHistoryExtendService = new EmployeeStatusHistoryExtendService();

