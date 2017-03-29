
function EmployeeSalaryService() { } EmployeeSalaryService.prototype = new Proxy('Employee', 'EmployeeID');

var employeeSalaryService = new EmployeeSalaryService();

