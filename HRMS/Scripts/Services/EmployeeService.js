
function EmployeeService() { } EmployeeService.prototype = new Proxy('Employee', 'EmployeeID');

// Example Custom Method
EmployeeService.prototype.MyCustomMethod = function (params, callback) {

    // Query allows for custom get calls to the server    
    
    // Query API
    this.Query('MyCustomMethodNameOnThisObject?' + params, callback);
    
    // Query Controller
    this.QueryController('MyCustomMethodNameOnThisObject?' + params, callback);
}

var employeeService = new EmployeeService();

