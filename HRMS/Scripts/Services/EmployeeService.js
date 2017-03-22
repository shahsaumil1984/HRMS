
function EmployeeService() { } EmployeeService.prototype = new Proxy('Employee', 'EmployeeID');

// Example Custom Method
EmployeeService.prototype.MyCustomMethod = function (params, callback) {

}

var employeeService = new EmployeeService();

