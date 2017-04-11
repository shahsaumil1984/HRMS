
function EmployeeStatusHistoryService() { } EmployeeStatusHistoryService.prototype = new Proxy('EmployeeStatusHistory', 'EmployeeStatusID');

// Example Custom Method
EmployeeStatusHistoryService.prototype.MyCustomMethod = function (params, callback) {

    // Query allows for custom get calls to the server    

    // Query API
    this.Query('MyCustomMethodNameOnThisObject?' + params, callback);

    // Query Controller
    this.QueryController('MyCustomMethodNameOnThisObject?' + params, callback);
}

EmployeeStatusHistoryService.prototype.GetById = function (id, callback) {
    
    this.Query("GetById?id=" + id, null, callback);
}

var employeeStatusHistoryService = new EmployeeStatusHistoryService();

