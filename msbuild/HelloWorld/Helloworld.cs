using System;

class HelloWorld
{
    static void Main()
    {
#if DebugConfig
        Console.WriteLine("We are in the Debug Configuration");
#endif
        Console.WriteLine("Hello, world!");
    }
}
