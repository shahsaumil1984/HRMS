
function EmployeeDocumentService() { } EmployeeDocumentService.prototype = new Proxy('EmployeeDocument', 'EmployeeDocumentID');

// Example Custom Method
EmployeeDocumentService.prototype.MyCustomMethod = function (params, callback) {

    // Query allows for custom get calls to the server    

    // Query API
    this.Query('MyCustomMethodNameOnThisObject?' + params, callback);

    // Query Controller
    this.QueryController('MyCustomMethodNameOnThisObject?' + params, callback);
}

var employeeDocumentService = new EmployeeDocumentService();

