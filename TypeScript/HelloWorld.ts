class Person
{
    firstName : string;
    lastName : string;
}


class Startup {
    public static main(): number {
        console.log('Hello World');
        
        return 0;
    }

    public static PrintName(){
        console.log("\n");
        console.log("In PrintName()" + "Richard Jones")
    }

    public static PrintDate()
    {
        var currentDate = new Date();

    var day =  currentDate.getDate();
    var month = currentDate.getMonth()+1;
    var year = currentDate.getFullYear();

    var formatDate =  day +"/" + month +"/" + year;
        console.log("\n");
        console.log(formatDate);
    }

}
Startup.main();
Startup.PrintName();
Startup.PrintDate();