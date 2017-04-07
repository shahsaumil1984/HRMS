
function SalaryService() { } SalaryService.prototype = new Proxy('Salary', 'SalaryID');

// Example Custom Method
SalaryService.prototype.GetByMonth = function (employeeID, monthID, callback) {
    this.QueryByPost('GetByMonth?' + 'employeeID=' + employeeID + "&monthID=" + monthID, null, callback);
}

SalaryService.prototype.UploadCSV = function (params, callback) { this.QueryByPost("UploadCSV", params, callback); }

var salaryService = new SalaryService();

