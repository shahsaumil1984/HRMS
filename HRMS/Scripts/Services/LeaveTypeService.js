
function LeaveTypeService() { } LeaveTypeService.prototype = new Proxy('LeaveType', 'ID');

// Example Custom Method
LeaveTypeService.prototype.MyCustomMethod = function (params, callback) {

    // Query allows for custom get calls to the server    
    
    // Query API
    this.Query('MyCustomMethodNameOnThisObject?' + params, callback);
    
    // Query Controller
    this.QueryController('MyCustomMethodNameOnThisObject?' + params, callback);
}

var leaveTypeService = new LeaveTypeService();

