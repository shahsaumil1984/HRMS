
function EmployeeSalaryService() { } EmployeeSalaryService.prototype = new Proxy('EmployeeSalary', 'EmployeeID');

var employeeSalaryService = new EmployeeSalaryService();

