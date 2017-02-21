var Startup = (function () {
    function Startup() {
    }
    Startup.main = function () {
        console.log('Hello World');
        return 0;
    };
    Startup.PrintName = function () {
        console.log("\n");
        console.log("In PrintName()" + "Richard Jones");
    };
    Startup.PrintDate = function () {
        var currentDate = new Date();
        var day = currentDate.getDate();
        var month = currentDate.getMonth() + 1;
        var year = currentDate.getFullYear();
        var formatDate = day + "/" + month + "/" + year;
        console.log("\n");
        console.log(formatDate);
    };
    return Startup;
}());
Startup.main();
Startup.PrintName();
Startup.PrintDate();
