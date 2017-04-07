
function SalaryService() { } SalaryService.prototype = new Proxy('Salary', 'SalaryID');

// Example Custom Method
SalaryService.prototype.GetByMonth = function (employeeID, monthID, callback) {
    debugger;
    this.QueryByPost('GetByMonth?' + 'employeeID=' + employeeID + "&monthID=" + monthID, null, callback);
}

var salaryService = new SalaryService();

