
function EmployeeSalaryService() { } EmployeeSalaryService.prototype = new Proxy('EmployeeSalary', 'EmployeeID');

var employeeSalaryService = new EmployeeSalaryService();

EmployeeSalaryService.prototype.GetNextEmployeeID = function (employeeID, callback) {    
    this.Query('GetNextEmployeeID?' + 'EmployeeID=' + employeeID , null, callback);   
}

EmployeeSalaryService.prototype.GetPrevEmployeeID = function (employeeID, callback) {
    this.Query('GetPrevEmployeeID?' + 'EmployeeID=' + employeeID, null, callback);
}