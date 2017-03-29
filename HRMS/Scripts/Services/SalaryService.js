
function SalaryService() { } SalaryService.prototype = new Proxy('Salary', 'SalaryID');

// Example Custom Method
SalaryService.prototype.MyCustomMethod = function (params, callback) {

}

var salaryService = new SalaryService();

