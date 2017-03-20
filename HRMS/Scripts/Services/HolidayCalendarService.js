
function HolidayCalendarService() { } HolidayCalendarService.prototype = new Proxy('HolidayCalendar', 'ID');

// Example Custom Method
HolidayCalendarService.prototype.MyCustomMethod = function (params, callback) {

    // Query allows for custom get calls to the server    
    
    // Query API
    this.Query('MyCustomMethodNameOnThisObject?' + params, callback);
    
    // Query Controller
    this.QueryController('MyCustomMethodNameOnThisObject?' + params, callback);
}

var holidayCalendarService = new HolidayCalendarService();

