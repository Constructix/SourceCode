using System;

public static class ConsoleMain
{
    public static void Main()
    {
        Console.WriteLine($"{DateTime.Now.ToString()}");
        Console.WriteLine("HERE");

        Catalog catalog = new Catalog();
        Console.WriteLine("Should call Catalog.Save method");
        Console.WriteLine(  catalog.Save());

        Console.WriteLine("Should call the interface save method");
        ISavable saveable =  new Catalog();
        Console.WriteLine(saveable.Save());

    }

}

