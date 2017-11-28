using System;

public static class ExtenstionHelpers
{
    public static void Dump<T>(this T instance)
    {
        Console.WriteLine(instance);
    }
}