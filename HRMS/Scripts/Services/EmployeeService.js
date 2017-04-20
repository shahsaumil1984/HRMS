
function EmployeeService() { } EmployeeService.prototype = new Proxy('Employee', 'EmployeeID');

// Example Custom Method
EmployeeService.prototype.MyCustomMethod = function (params, callback) {

}
EmployeeService.prototype.CheckEmployeeCode = function (params, callback) { this.Query("GetCheckEmployeeCode", params, callback); }

EmployeeService.prototype.disableEmployeeByID = function (params, callback) {
    debugger;
    this.Query("disableEmployeeByID", params, callback);
}

var employeeService = new EmployeeService();

