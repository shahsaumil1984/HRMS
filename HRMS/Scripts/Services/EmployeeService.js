
function EmployeeService() { } EmployeeService.prototype = new Proxy('Employee', 'EmployeeID');

// Example Custom Method
EmployeeService.prototype.MyCustomMethod = function (params, callback) {

}
EmployeeService.prototype.CheckEmployeeCode = function (params, callback) { this.Query("GetCheckEmployeeCode", params, callback); }

var employeeService = new EmployeeService();

